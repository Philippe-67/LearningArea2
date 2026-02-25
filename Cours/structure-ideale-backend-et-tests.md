# Structure idéale d’un backend et tests

## Objectif
Comprendre comment organiser le code d’un backend pour qu’il soit clair, maintenable, évolutif et facilement testable.

---

## 1. Pourquoi structurer son backend ?
- Facilite la compréhension du code
- Permet d’ajouter des fonctionnalités sans tout casser
- Rend le projet plus facile à tester et à corriger

---

## 2. Les dossiers principaux

- **Controllers** : gèrent les requêtes reçues
- **Services** et **IServices** : logique métier, interfaces pour définir le contrat
- **Models** : décrivent les données
- **Repositories** et **IRepositories** : accès à la base de données, interfaces pour définir le contrat
- **DTOs** : objets échangés entre backend et frontend
- **Tests** : vérification du fonctionnement du code

---

## 3. Les fichiers essentiels
- **appsettings.json** : configuration
- **Program.cs** : point d’entrée
- **Startup.cs** : configuration des routes, services, injection de dépendances

---

## 4. Définitions simples

- **Contrôleur (Controller)** : reçoit les requêtes, appelle les services, renvoie la réponse.
- **Service / IService** : logique métier, interface pour définir les méthodes à implémenter.
- **Modèle (Model)** : représente une entité du domaine.
- **Repository / IRepository** : accès aux données, interface pour définir les méthodes à implémenter.
- **DTO** : format des données envoyées ou reçues.

---

## 5. Injection de dépendances

L’injection de dépendances permet de donner à une classe les objets dont elle a besoin, sans qu’elle ait à les créer elle-même.

**Exemple :**
`csharp
public class ProduitController {
    private readonly IProduitService _service;
    public ProduitController(IProduitService service) {
        _service = service;
    }
}
// Dans la configuration
services.AddScoped<IProduitService, ProduitService>();
`

- Le contrôleur demande un IProduitService, le framework lui fournit l’implémentation.
- On peut facilement remplacer l’implémentation pour les tests.

---

## 6. Exemple d’arborescence commentée

`
MonApi/
│
├── Controllers/
│   └── ProduitController.cs
│
├── Services/
│   ├── IProduitService.cs
│   └── ProduitService.cs
│
├── Models/
│   └── Produit.cs
│
├── Repositories/
│   ├── IProduitRepository.cs
│   └── ProduitRepository.cs
│
├── DTOs/
│   └── ProduitDto.cs
│
├── Tests/
│   └── ProduitServiceTests.cs
│
├── appsettings.json
├── Program.cs
└── Startup.cs
`

---

## 7. Flux d'une requête HTTP

Voici comment une requête traverse les différentes couches :

```
1. Client (Frontend)        → Envoie une requête HTTP
                            ↓
2. Controller              → Reçoit la requête, valide les données
                            ↓
3. Service (IService)      → Applique la logique métier
                            ↓
4. Repository (IRepository) → Accède à la base de données
                            ↓
5. Données                 → Retourne les données
                            ↑
6. Service                 → Transforme en DTO
                            ↑
7. Controller              → Renvoie la réponse HTTP
                            ↑
8. Client (Frontend)        ← Reçoit la réponse
```

**Exemple concret** : GET /api/produits/5
- Le controller appelle le service : `_service.GetProduitByIdAsync(5)`
- Le service appelle le repository : `_repository.GetByIdAsync(5)`
- Le repository interroge la base de données
- Le repository retourne un `Produit` (Model)
- Le service transforme en `ProduitDto`
- Le controller renvoie le DTO au client

---

## 8. Exemples de code complets

### 8.1 Model (Entité de base de données)

```csharp
// Models/Produit.cs
public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Prix { get; set; }
    public int Stock { get; set; }
    public DateTime DateCreation { get; set; }
}
```

**Rôle** : Représente une table dans la base de données. Contient toutes les propriétés de l'entité.

---

### 8.2 DTO (Data Transfer Object)

```csharp
// DTOs/ProduitDto.cs
public class ProduitDto
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public decimal Prix { get; set; }
    public bool Disponible { get; set; }
}

// DTOs/CreateProduitDto.cs
public class CreateProduitDto
{
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [MaxLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
    public string Nom { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [Range(0.01, 10000, ErrorMessage = "Le prix doit être entre 0.01 et 10000")]
    public decimal Prix { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Le stock ne peut pas être négatif")]
    public int Stock { get; set; }
}
```

**Rôle** : Contrôle exactement quelles données sont envoyées/reçues. Sécurise l'API en validant les données.

**Pourquoi deux DTOs différents ?**
- `ProduitDto` : Pour envoyer des données au client (GET)
- `CreateProduitDto` : Pour recevoir des données du client (POST) avec validation

---

### 8.3 Interface Repository

```csharp
// Repositories/IProduitRepository.cs
public interface IProduitRepository
{
    Task<List<Produit>> GetAllAsync();
    Task<Produit?> GetByIdAsync(int id);
    Task<Produit> CreateAsync(Produit produit);
    Task<Produit?> UpdateAsync(int id, Produit produit);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
```

**Rôle** : Définit le contrat pour l'accès aux données. Toutes les méthodes retournent `Task` pour l'asynchrone.

---

### 8.4 Implémentation Repository

```csharp
// Repositories/ProduitRepository.cs
public class ProduitRepository : IProduitRepository
{
    private readonly ApplicationDbContext _context;

    public ProduitRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produit>> GetAllAsync()
    {
        return await _context.Produits
            .OrderBy(p => p.Nom)
            .ToListAsync();
    }

    public async Task<Produit?> GetByIdAsync(int id)
    {
        return await _context.Produits
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Produit> CreateAsync(Produit produit)
    {
        produit.DateCreation = DateTime.Now;
        _context.Produits.Add(produit);
        await _context.SaveChangesAsync();
        return produit;
    }

    public async Task<Produit?> UpdateAsync(int id, Produit produit)
    {
        var existingProduit = await GetByIdAsync(id);
        if (existingProduit == null) return null;

        existingProduit.Nom = produit.Nom;
        existingProduit.Description = produit.Description;
        existingProduit.Prix = produit.Prix;
        existingProduit.Stock = produit.Stock;

        await _context.SaveChangesAsync();
        return existingProduit;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var produit = await GetByIdAsync(id);
        if (produit == null) return false;

        _context.Produits.Remove(produit);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Produits.AnyAsync(p => p.Id == id);
    }
}
```

**Rôle** : Gère toutes les opérations de base de données. Utilise Entity Framework Core pour communiquer avec la base.

**Points importants** :
- Utilise `async/await` pour les opérations asynchrones
- Retourne `null` si l'élément n'existe pas
- Utilise LINQ pour interroger les données

---

### 8.5 Interface Service

```csharp
// Services/IProduitService.cs
public interface IProduitService
{
    Task<List<ProduitDto>> GetAllProduitsAsync();
    Task<ProduitDto?> GetProduitByIdAsync(int id);
    Task<ProduitDto> CreateProduitAsync(CreateProduitDto createDto);
    Task<ProduitDto?> UpdateProduitAsync(int id, CreateProduitDto updateDto);
    Task<bool> DeleteProduitAsync(int id);
}
```

**Rôle** : Définit le contrat de la logique métier. Travaille avec des DTOs (pas des Models).

---

### 8.6 Implémentation Service

```csharp
// Services/ProduitService.cs
public class ProduitService : IProduitService
{
    private readonly IProduitRepository _repository;

    public ProduitService(IProduitRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProduitDto>> GetAllProduitsAsync()
    {
        var produits = await _repository.GetAllAsync();
        
        // Transformation Model → DTO
        return produits.Select(p => new ProduitDto
        {
            Id = p.Id,
            Nom = p.Nom,
            Prix = p.Prix,
            Disponible = p.Stock > 0
        }).ToList();
    }

    public async Task<ProduitDto?> GetProduitByIdAsync(int id)
    {
        var produit = await _repository.GetByIdAsync(id);
        if (produit == null) return null;

        // Transformation Model → DTO
        return new ProduitDto
        {
            Id = produit.Id,
            Nom = produit.Nom,
            Prix = produit.Prix,
            Disponible = produit.Stock > 0
        };
    }

    public async Task<ProduitDto> CreateProduitAsync(CreateProduitDto createDto)
    {
        // Transformation DTO → Model
        var produit = new Produit
        {
            Nom = createDto.Nom,
            Description = createDto.Description,
            Prix = createDto.Prix,
            Stock = createDto.Stock
        };

        var createdProduit = await _repository.CreateAsync(produit);

        // Transformation Model → DTO
        return new ProduitDto
        {
            Id = createdProduit.Id,
            Nom = createdProduit.Nom,
            Prix = createdProduit.Prix,
            Disponible = createdProduit.Stock > 0
        };
    }

    public async Task<ProduitDto?> UpdateProduitAsync(int id, CreateProduitDto updateDto)
    {
        // Vérifier si le produit existe
        if (!await _repository.ExistsAsync(id)) return null;

        // Transformation DTO → Model
        var produit = new Produit
        {
            Nom = updateDto.Nom,
            Description = updateDto.Description,
            Prix = updateDto.Prix,
            Stock = updateDto.Stock
        };

        var updatedProduit = await _repository.UpdateAsync(id, produit);
        if (updatedProduit == null) return null;

        // Transformation Model → DTO
        return new ProduitDto
        {
            Id = updatedProduit.Id,
            Nom = updatedProduit.Nom,
            Prix = updatedProduit.Prix,
            Disponible = updatedProduit.Stock > 0
        };
    }

    public async Task<bool> DeleteProduitAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
```

**Rôle** : Applique la logique métier, transforme Model ↔ DTO, coordonne les appels au Repository.

**Points importants** :
- Ne manipule jamais directement la base de données
- Fait toutes les transformations Model ↔ DTO
- Ajoute la logique métier (ex: "Disponible" basé sur le stock)

---

### 8.7 Controller

```csharp
// Controllers/ProduitController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProduitController : ControllerBase
{
    private readonly IProduitService _service;
    private readonly ILogger<ProduitController> _logger;

    public ProduitController(IProduitService service, ILogger<ProduitController> logger)
    {
        _service = service;
        _logger = logger;
    }

    // GET: api/produit
    [HttpGet]
    public async Task<ActionResult<List<ProduitDto>>> GetAll()
    {
        try
        {
            var produits = await _service.GetAllProduitsAsync();
            return Ok(produits);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la récupération des produits");
            return StatusCode(500, "Erreur serveur");
        }
    }

    // GET: api/produit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProduitDto>> GetById(int id)
    {
        try
        {
            var produit = await _service.GetProduitByIdAsync(id);
            if (produit == null)
            {
                return NotFound($"Produit avec ID {id} introuvable");
            }
            return Ok(produit);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la récupération du produit {Id}", id);
            return StatusCode(500, "Erreur serveur");
        }
    }

    // POST: api/produit
    [HttpPost]
    public async Task<ActionResult<ProduitDto>> Create([FromBody] CreateProduitDto createDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produit = await _service.CreateProduitAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = produit.Id }, produit);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la création du produit");
            return StatusCode(500, "Erreur serveur");
        }
    }

    // PUT: api/produit/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ProduitDto>> Update(int id, [FromBody] CreateProduitDto updateDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produit = await _service.UpdateProduitAsync(id, updateDto);
            if (produit == null)
            {
                return NotFound($"Produit avec ID {id} introuvable");
            }
            return Ok(produit);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la mise à jour du produit {Id}", id);
            return StatusCode(500, "Erreur serveur");
        }
    }

    // DELETE: api/produit/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var success = await _service.DeleteProduitAsync(id);
            if (!success)
            {
                return NotFound($"Produit avec ID {id} introuvable");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la suppression du produit {Id}", id);
            return StatusCode(500, "Erreur serveur");
        }
    }
}
```

**Rôle** : Gère les requêtes HTTP, valide les données, appelle le service, renvoie les réponses appropriées.

**Points importants** :
- Attributs de routing : `[HttpGet]`, `[HttpPost]`, etc.
- Codes HTTP appropriés : 200 (Ok), 201 (Created), 404 (NotFound), 500 (Error)
- Validation avec `ModelState.IsValid`
- Logging des erreurs avec `ILogger`
- Try-catch pour capturer les exceptions

---

### 8.8 Configuration dans Program.cs

```csharp
// Program.cs
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la base de données
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injection de dépendances : Repositories
builder.Services.AddScoped<IProduitRepository, ProduitRepository>();

// Injection de dépendances : Services
builder.Services.AddScoped<IProduitService, ProduitService>();

// Configuration des controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

**Rôle** : Configure l'application, enregistre les dépendances (services et repositories) pour l'injection.

**Points importants** :
- `AddScoped` : Une instance par requête HTTP
- `AddSingleton` : Une seule instance pour toute l'application
- `AddTransient` : Une nouvelle instance à chaque utilisation

Pour les services et repositories, on utilise généralement `AddScoped`.

---

## 9. Conseils pratiques
- Toujours séparer la logique métier (service) de l’accès aux données (repository)
- Définir des interfaces (IServices, IRepositories) pour chaque service/repository
- Utiliser l’injection de dépendances pour brancher l’implémentation à l’interface
- Utiliser des DTO pour contrôler ce qui est envoyé au client
- Nommer les fichiers et dossiers de façon claire
- Commenter le code pour expliquer les parties complexes
- Ajouter des tests pour vérifier le fonctionnement

---

---

## 10. Tableau récapitulatif des responsabilités

| Couche | Responsabilité | Ce qu'elle fait | Ce qu'elle NE fait PAS |
|--------|----------------|-----------------|------------------------|
| **Controller** | Gestion HTTP | Reçoit les requêtes, valide, appelle le service, renvoie la réponse | Ne fait pas de logique métier, n'accède pas à la base |
| **Service** | Logique métier | Applique les règles métier, transforme Model ↔ DTO | N'accède pas directement à la base de données |
| **Repository** | Accès données | Interroge la base de données, retourne des Models | Ne transforme pas en DTO, ne fait pas de logique métier |
| **Model** | Entité BDD | Représente une table de base de données | N'est jamais envoyé au client |
| **DTO** | Transfert données | Contrôle ce qui est envoyé/reçu par l'API | Ne contient pas de logique |

---

## 11. Avantages de cette architecture

### ✅ Testabilité
- Chaque couche peut être testée indépendamment
- On peut facilement mocker (simuler) les dépendances
- Les tests unitaires sont simples à écrire

**Exemple** : Tester le service sans toucher à la base de données :
```csharp
// On simule le repository
var mockRepository = new Mock<IProduitRepository>();
mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Produit { Id = 1, Nom = "Test" });

var service = new ProduitService(mockRepository.Object);
var result = await service.GetProduitByIdAsync(1);
// On peut vérifier que le service transforme correctement
```

### ✅ Maintenabilité
- Le code est organisé de façon logique
- Facile de trouver où faire une modification
- Un changement dans une couche n'affecte pas les autres

**Exemple** : Si on change de base de données (SQL Server → PostgreSQL), on modifie seulement le Repository.

### ✅ Évolutivité
- Facile d'ajouter de nouvelles fonctionnalités
- On peut remplacer une implémentation sans tout casser
- Permet le travail en équipe (chacun sur sa couche)

**Exemple** : Ajouter un système de cache sans toucher au controller ni au service.

### ✅ Sécurité
- Les DTOs contrôlent exactement ce qui est exposé
- Validation centralisée des données entrantes
- Séparation claire entre données internes (Model) et externes (DTO)

**Exemple** : Le Model `Produit` a un `DateCreation`, mais le DTO ne l'expose pas au client.

---

## Points à retenir
- Un backend bien structuré facilite le travail d'équipe et l'évolution du projet
- Les interfaces IServices et IRepositories rendent le code flexible et testable
- L'injection de dépendances permet de brancher facilement les implémentations
- Respecter la séparation des responsabilités pour un code propre et maintenable
- Chaque couche a un rôle précis : Controller (HTTP), Service (logique), Repository (données)
- Les Models restent dans le backend, seuls les DTOs sont envoyés au client
- Les tests sont essentiels pour garantir la qualité du code

