# Structure et utilité des éléments du backend MonApi

## Objectif
Comprendre le rôle de chaque dossier et fichier du projet backend MonApi, et apprendre à tester l’API avec MonApi.http.

## Explications détaillées

- **bin** : Dossier où sont stockés les fichiers compilés (exécutables, DLL). Géré automatiquement.
- **obj** : Dossier temporaire pour la compilation. Géré automatiquement.
- **Properties** : Contient les paramètres de lancement du projet (ex : launchSettings.json).
- **appsettings.Development.json** : Fichier de configuration spécifique à l’environnement de développement.
- **appsettings.json** : Fichier de configuration principal de l’application.
- **MonApi.csproj** : Fichier de projet .NET, décrit les dépendances et options de compilation.
- **MonApi.http** : Fichier pour tester l’API avec des requêtes HTTP.
- **Program.cs** : Fichier principal du code source, point d’entrée de l’application.

## Utilisation de MonApi.http pour tester l’API

### Exemple de requête GET
GET http://localhost:5000/weatherforecast
Accept: application/json

- Clique sur « Send Request » dans VS Code pour obtenir la réponse.

### Exemple de requête POST
POST http://localhost:5000/api/users
Content-Type: application/json

{
  "name": "Alice",
  "email": "alice@example.com"
}

- Clique sur « Send Request » pour envoyer des données à l’API.

### Explication sur la réponse
- La réponse s’affiche dans VS Code : code HTTP, données renvoyées ou message d’erreur.
- Permet de vérifier le bon fonctionnement de l’API directement dans l’éditeur.

## Points à retenir
- Chaque dossier/fichier a un rôle précis : organisation, configuration, code, tests.
- MonApi.http permet de tester facilement l’API sans outil externe.

## Conseils pratiques
- Ne pas modifier bin et obj.
- Utiliser MonApi.http pour tester tous les endpoints de l’API.
- Lire les réponses pour comprendre le fonctionnement ou détecter les erreurs.
---

## Tests unitaires : pourquoi et comment

### Qu'est-ce qu'un test unitaire ?

Un test unitaire vérifie qu'une petite partie de code (une méthode, une fonction) fonctionne correctement de manière isolée.

**Analogie** : C'est comme vérifier que chaque pièce d'un moteur fonctionne avant d'assembler la voiture entière.

### Pourquoi écrire des tests ?

- **Détecter les bugs rapidement** : Avant qu'ils n'arrivent en production
- **Faciliter les modifications** : Tu peux changer du code en toute confiance
- **Documentation vivante** : Les tests montrent comment utiliser le code
- **Gagner du temps** : Moins de temps passé à déboguer manuellement

### Framework de test : xUnit

En .NET, on utilise souvent **xUnit** pour les tests unitaires.

```csharp
// Installation du package
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
```

### Exemple concret : Tester un service

**Service à tester :**
```csharp
public class CalculService
{
    public int Additionner(int a, int b)
    {
        return a + b;
    }

    public bool EstPair(int nombre)
    {
        return nombre % 2 == 0;
    }
}
```

**Classe de test :**
```csharp
using Xunit;

public class CalculServiceTests
{
    private readonly CalculService _service;

    // Constructeur : exécuté avant chaque test
    public CalculServiceTests()
    {
        _service = new CalculService();
    }

    [Fact] // Attribut indiquant que c'est un test
    public void Additionner_DeuxNombresPositifs_RetourneLaSomme()
    {
        // Arrange : Préparer les données
        int a = 5;
        int b = 3;

        // Act : Exécuter la méthode à tester
        int resultat = _service.Additionner(a, b);

        // Assert : Vérifier le résultat
        Assert.Equal(8, resultat);
    }

    [Theory] // Attribut pour tester avec plusieurs jeux de données
    [InlineData(2, true)]
    [InlineData(3, false)]
    [InlineData(0, true)]
    [InlineData(-4, true)]
    public void EstPair_AvecDifferentsNombres_RetourneLeResultatAttendu(int nombre, bool attendu)
    {
        // Act
        bool resultat = _service.EstPair(nombre);

        // Assert
        Assert.Equal(attendu, resultat);
    }
}
```

### Structure d'un test : AAA Pattern

1. **Arrange** : Préparer les données et les objets nécessaires
2. **Act** : Exécuter la méthode à tester
3. **Assert** : Vérifier que le résultat est correct

### Assertions courantes

```csharp
// Égalité
Assert.Equal(valeurAttendue, valeurObtenue);
Assert.NotEqual(valeurNonAttendue, valeurObtenue);

// Booléens
Assert.True(condition);
Assert.False(condition);

// Null
Assert.Null(objet);
Assert.NotNull(objet);

// Exceptions
Assert.Throws<TypeException>(() => methode());

// Collections
Assert.Empty(liste);
Assert.NotEmpty(liste);
Assert.Contains(element, liste);
```

### Tester un contrôleur

**Contrôleur à tester :**
```csharp
[ApiController]
[Route("api/[controller]")]
public class ProduitController : ControllerBase
{
    private readonly IProduitService _service;

    public ProduitController(IProduitService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<ProduitDto> GetById(int id)
    {
        var produit = _service.ObtenirProduit(id);
        if (produit == null)
            return NotFound();
        return Ok(produit);
    }
}
```

**Test du contrôleur avec Mock :**
```csharp
using Moq; // Package pour créer des faux objets
using Xunit;

public class ProduitControllerTests
{
    [Fact]
    public void GetById_ProduitExistant_RetourneOkAvecProduit()
    {
        // Arrange
        var mockService = new Mock<IProduitService>();
        var produitAttendu = new ProduitDto { Id = 1, Nom = "Chaise" };
        mockService.Setup(s => s.ObtenirProduit(1)).Returns(produitAttendu);
        var controller = new ProduitController(mockService.Object);

        // Act
        var resultat = controller.GetById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultat.Result);
        var produit = Assert.IsType<ProduitDto>(okResult.Value);
        Assert.Equal("Chaise", produit.Nom);
    }

    [Fact]
    public void GetById_ProduitInexistant_RetourneNotFound()
    {
        // Arrange
        var mockService = new Mock<IProduitService>();
        mockService.Setup(s => s.ObtenirProduit(999)).Returns((ProduitDto)null);
        var controller = new ProduitController(mockService.Object);

        // Act
        var resultat = controller.GetById(999);

        // Assert
        Assert.IsType<NotFoundResult>(resultat.Result);
    }
}
```

### Moq : Créer des faux objets pour les tests

**Moq** permet de simuler le comportement des dépendances sans avoir besoin de la vraie implémentation.

```csharp
// Installation
dotnet add package Moq

// Créer un mock
var mockRepository = new Mock<IProduitRepository>();

// Définir le comportement
mockRepository.Setup(r => r.GetById(1))
              .Returns(new Produit { Id = 1, Nom = "Table" });

// Vérifier qu'une méthode a été appelée
mockRepository.Verify(r => r.Add(It.IsAny<Produit>()), Times.Once);
```

### Exécuter les tests

```bash
# Exécuter tous les tests
dotnet test

# Exécuter les tests avec détails
dotnet test --verbosity detailed

# Exécuter les tests d'un fichier spécifique
dotnet test --filter "FullyQualifiedName~ProduitControllerTests"
```

### Bonnes pratiques des tests

1. **Un test = une seule vérification** : Ne pas tester trop de choses à la fois
2. **Noms explicites** : Le nom du test doit expliquer ce qu'on teste
   - Format : `MethodeName_Scenario_ExpectedResult`
   - Exemple : `GetById_ProduitInexistant_RetourneNotFound`
3. **Tests indépendants** : Un test ne doit pas dépendre d'un autre
4. **Tests rapides** : Les tests unitaires doivent être très rapides (< 1 seconde)
5. **Couvrir les cas limites** : Tester les cas normaux ET les cas d'erreur

### Organisation des tests

```
MonApi.Tests/
├── Controllers/
│   └── ProduitControllerTests.cs
├── Services/
│   └── ProduitServiceTests.cs
├── Repositories/
│   └── ProduitRepositoryTests.cs
└── MonApi.Tests.csproj
```

### Points à retenir sur les tests

- Les tests unitaires vérifient qu'une méthode fonctionne correctement
- Structure AAA : Arrange, Act, Assert
- xUnit est le framework de test standard pour .NET
- Moq permet de créer des faux objets (mocks) pour isoler le code testé
- Tester les cas normaux ET les cas d'erreur
- Les tests sont une documentation vivante du code