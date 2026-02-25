# Cours : Controllers, Endpoints et DTOs - Comprendre les bases de l'API .NET

## Introduction

Quand tu développes une application web moderne, tu dois créer une **API** (Application Programming Interface) qui permet au frontend (React) de communiquer avec le backend (.NET).

Pour créer cette API, tu vas utiliser trois concepts fondamentaux :
- **Endpoint** : Une adresse (URL) que le frontend peut appeler
- **Controller** : Le fichier qui regroupe plusieurs endpoints
- **DTO** : Un objet pour transférer des données de manière sécurisée

**Analogie globale** : Imagine un **restaurant** :
- Les **endpoints** = les plats du menu
- Le **controller** = le chef de cuisine qui coordonne
- Les **DTOs** = les tickets de commande

---

## Section 1 : Qu''est-ce qu''un Endpoint ?

### Analogie du restaurant

Dans un restaurant, le **menu** liste tous les plats disponibles. Chaque plat a :
- Un **nom** (ex: "Pizza Margherita")
- Une **action** (ex: "Commander", "Annuler")
- Des **informations** nécessaires (ex: taille, options)

Un **endpoint**, c''est pareil :
- Une **URL** (ex: `/api/words`)
- Une **méthode HTTP** (ex: GET, POST)
- Des **données** optionnelles à envoyer

### Définition technique

Un **endpoint** est :
> Une adresse accessible sur le serveur qui permet au client (frontend) d''effectuer une action spécifique.

**Structure d''un endpoint :**
```
[Méthode HTTP] [URL] [Données optionnelles]
```

**Exemple concret :**
```
GET http://localhost:5000/api/words
```
- **GET** = méthode HTTP (récupérer)
- **http://localhost:5000** = adresse du serveur
- **/api/words** = chemin de l''endpoint

### Les méthodes HTTP (CRUD)

| Méthode | Action | Analogie restaurant | Exemple endpoint |
|---------|--------|---------------------|------------------|
| **GET** | Récupérer (Read) | Lire le menu | `GET /api/words` |
| **POST** | Créer (Create) | Commander un plat | `POST /api/words` |
| **PUT** | Modifier (Update) | Changer la commande | `PUT /api/words/1` |
| **DELETE** | Supprimer (Delete) | Annuler la commande | `DELETE /api/words/1` |

**CRUD** = **C**reate, **R**ead, **U**pdate, **D**elete (les 4 opérations de base)

### Structure détaillée d''un endpoint

```
Méthode: GET
URL: /api/words/5
Paramètres: id = 5
Headers: Content-Type: application/json
Body: (vide pour GET)
Réponse: 
{
  "id": 5,
  "frenchWord": "chat",
  "englishWord": "cat"
}
```

### Exemples concrets d''endpoints

#### Exemple 1 : Récupérer tous les mots
```http
GET /api/words
Réponse: Liste de tous les mots
```

#### Exemple 2 : Récupérer un mot spécifique
```http
GET /api/words/5
Réponse: Le mot avec l''ID 5
```

#### Exemple 3 : Créer un nouveau mot
```http
POST /api/words
Body: { "frenchWord": "maison", "englishWord": "house" }
Réponse: Le mot créé avec son ID
```

#### Exemple 4 : Modifier un mot
```http
PUT /api/words/5
Body: { "englishWord": "home" }
Réponse: Le mot modifié
```

#### Exemple 5 : Supprimer un mot
```http
DELETE /api/words/5
Réponse: Confirmation de suppression
```

#### Exemple 6 : Filtrer les mots
```http
GET /api/words?language=English
Réponse: Tous les mots en anglais
```

### Points à retenir sur les Endpoints

✅ Un endpoint = une URL + une méthode HTTP
✅ GET = récupérer, POST = créer, PUT = modifier, DELETE = supprimer
✅ On peut envoyer des données dans le body (POST, PUT) ou dans l''URL (GET)
✅ Chaque endpoint retourne une réponse (souvent en JSON)
✅ Les endpoints sont accessibles depuis le frontend

---

## Section 2 : Qu''est-ce qu''un Controller ?

### Analogie du restaurant

Le **chef de cuisine** dans un restaurant :
- Reçoit les commandes des clients
- Coordonne la préparation des plats
- Envoie les plats terminés aux clients
- Gère plusieurs plats différents (entrées, plats, desserts)

Un **controller**, c''est pareil :
- Reçoit les requêtes HTTP du frontend
- Coordonne le traitement des données
- Envoie les réponses au frontend
- Gère plusieurs endpoints liés (tous les endpoints pour "words")

### Définition technique

Un **controller** est :
> Une classe C# qui regroupe plusieurs endpoints liés à une même ressource (ex: Word, User, Product).

**Rôle du controller :**
1. **Recevoir** les requêtes HTTP
2. **Valider** les données reçues
3. **Traiter** la logique métier (ou appeler un service)
4. **Retourner** une réponse HTTP

### Structure d''un Controller

```csharp
[ApiController]                          // Indique que c''est un controller API
[Route("api/[controller]")]              // Définit l''URL de base
public class WordsController : ControllerBase
{
    // Endpoints ici (méthodes)
}
```

**Explication :**
- `[ApiController]` : Attribut qui active des comportements automatiques (validation, etc.)
- `[Route("api/[controller]")]` : Définit que tous les endpoints commencent par `/api/words`
- `ControllerBase` : Classe de base dont hérite ton controller

### Exemple complet de Controller

```csharp
using Microsoft.AspNetCore.Mvc;
using MonApi.Models;

namespace MonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    // Liste temporaire (en mémoire)
    private static List<Word> words = new();

    // ENDPOINT 1 : GET /api/words
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(words); // Retourne 200 OK + la liste
    }

    // ENDPOINT 2 : GET /api/words/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var word = words.FirstOrDefault(w => w.Id == id);
        if (word == null)
            return NotFound(); // Retourne 404 Not Found
        
        return Ok(word); // Retourne 200 OK + le mot
    }

    // ENDPOINT 3 : POST /api/words
    [HttpPost]
    public IActionResult Create([FromBody] CreateWordDto dto)
    {
        var word = new Word
        {
            Id = words.Count + 1,
            FrenchWord = dto.FrenchWord,
            EnglishWord = dto.EnglishWord
        };
        
        words.Add(word);
        return CreatedAtAction(nameof(GetById), 
                              new { id = word.Id }, 
                              word); // Retourne 201 Created
    }

    // ENDPOINT 4 : DELETE /api/words/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var word = words.FirstOrDefault(w => w.Id == id);
        if (word == null)
            return NotFound();
        
        words.Remove(word);
        return NoContent(); // Retourne 204 No Content
    }
}
```

### Décryptage du code

**Les attributs HTTP :**
- `[HttpGet]` : Endpoint accessible en GET
- `[HttpGet("{id}")]` : Endpoint GET avec paramètre dans l''URL
- `[HttpPost]` : Endpoint accessible en POST
- `[HttpDelete("{id}")]` : Endpoint DELETE avec paramètre

**Les codes de retour :**
- `Ok(data)` → 200 : Succès avec données
- `Created()` → 201 : Création réussie
- `NoContent()` → 204 : Succès sans données
- `NotFound()` → 404 : Ressource introuvable
- `BadRequest()` → 400 : Requête invalide

**Le paramètre `[FromBody]` :**
- Indique que les données viennent du body de la requête HTTP
- Utilisé pour POST et PUT

### Points à retenir sur les Controllers

✅ Un controller = une classe qui regroupe des endpoints
✅ Chaque méthode du controller = un endpoint
✅ Les attributs HTTP déterminent la méthode (GET, POST, etc.)
✅ Le controller retourne toujours une réponse HTTP
✅ Convention de nommage : `NomController` (ex: WordsController, UsersController)

---

## Section 3 : Qu''est-ce qu''un DTO (Data Transfer Object) ?

### Analogie du restaurant

Dans un restaurant, le **ticket de commande** :
- Ne contient que les informations nécessaires (plat, quantité, table)
- Ne montre PAS toutes les infos internes (prix d''achat, recette, stock)
- Format standard pour la communication cuisine ↔ serveur

Un **DTO**, c''est pareil :
- Contient uniquement les données à transférer
- Cache les données sensibles ou internes
- Format standardisé pour la communication frontend ↔ backend

### Définition technique

Un **DTO** est :
> Un objet simple qui contient uniquement les données nécessaires pour une opération spécifique (créer, modifier, afficher).

**Pourquoi utiliser des DTOs ?**

1. **Sécurité** : Ne pas exposer toutes les propriétés du modèle
2. **Validation** : Valider uniquement les champs nécessaires
3. **Séparation** : Le modèle interne peut changer sans casser l''API
4. **Clarté** : Chaque opération a son propre DTO

### Types de DTOs

| Type | Usage | Exemple |
|------|-------|---------|
| **CreateDTO** | Créer une ressource | `CreateWordDto` |
| **UpdateDTO** | Modifier une ressource | `UpdateWordDto` |
| **ResponseDTO** | Retourner une ressource | `WordResponseDto` |
| **FilterDTO** | Filtrer/rechercher | `WordFilterDto` |

### Exemples concrets de DTOs

#### Exemple 1 : CreateWordDto (pour POST)

```csharp
public class CreateWordDto
{
    public string FrenchWord { get; set; }
    public string EnglishWord { get; set; }
    public string Category { get; set; }
    public int Difficulty { get; set; }
}

// Utilisation dans le controller :
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    // On crée le modèle à partir du DTO
    var word = new Word
    {
        Id = GenerateId(), // Généré par le backend
        FrenchWord = dto.FrenchWord,
        EnglishWord = dto.EnglishWord,
        Category = dto.Category,
        Difficulty = dto.Difficulty,
        CreatedAt = DateTime.Now // Généré par le backend
    };
    // ...
}
```

**Pourquoi ?** Le client ne doit pas fournir `Id` ni `CreatedAt` (générés par le serveur).

#### Exemple 2 : UpdateWordDto (pour PUT)

```csharp
public class UpdateWordDto
{
    public string EnglishWord { get; set; }
    public int Difficulty { get; set; }
}

// Utilisation :
[HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] UpdateWordDto dto)
{
    var word = words.FirstOrDefault(w => w.Id == id);
    if (word == null)
        return NotFound();
    
    // On met à jour seulement les champs autorisés
    word.EnglishWord = dto.EnglishWord;
    word.Difficulty = dto.Difficulty;
    // word.Id ne change JAMAIS
    // word.CreatedAt ne change JAMAIS
    
    return Ok(word);
}
```

**Pourquoi ?** On ne peut modifier que certains champs (pas l''ID, pas la date de création).

#### Exemple 3 : WordResponseDto (pour GET)

```csharp
public class WordResponseDto
{
    public int Id { get; set; }
    public string FrenchWord { get; set; }
    public string EnglishWord { get; set; }
    public string Category { get; set; }
    public int Difficulty { get; set; }
    public string CreatedAt { get; set; } // Format simplifié
}

// Utilisation :
[HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var word = words.FirstOrDefault(w => w.Id == id);
    if (word == null)
        return NotFound();
    
    // Convertir le modèle en DTO
    var dto = new WordResponseDto
    {
        Id = word.Id,
        FrenchWord = word.FrenchWord,
        EnglishWord = word.EnglishWord,
        Category = word.Category,
        Difficulty = word.Difficulty,
        CreatedAt = word.CreatedAt.ToString("dd/MM/yyyy")
    };
    
    return Ok(dto);
}
```

**Pourquoi ?** On peut formater ou cacher certaines données avant de les envoyer au client.

### Différence Model vs DTO

| Aspect | Model | DTO |
|--------|-------|-----|
| **Rôle** | Représente les données en base | Représente les données en transit |
| **Localisation** | Dossier `Models/` | Dossier `DTOs/` ou dans le Controller |
| **Propriétés** | Toutes les propriétés | Uniquement celles nécessaires |
| **Annotations** | Annotations base de données | Annotations de validation |
| **Exemple** | `Word.cs` | `CreateWordDto.cs` |

**Exemple Model :**
```csharp
public class Word
{
    public int Id { get; set; }
    public string FrenchWord { get; set; }
    public string EnglishWord { get; set; }
    public string Category { get; set; }
    public int Difficulty { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } // Soft delete
    public int UserId { get; set; } // Foreign key
}
```

**Exemple DTO :**
```csharp
public class CreateWordDto
{
    public string FrenchWord { get; set; }
    public string EnglishWord { get; set; }
    public string Category { get; set; }
    public int Difficulty { get; set; }
}
```

**Différence clé :** Le DTO contient seulement ce que le client peut envoyer/recevoir.

### Points à retenir sur les DTOs

✅ Un DTO = un objet pour transférer des données
✅ JAMAIS exposer directement le modèle au client
✅ Un DTO par opération (Create, Update, Response)
✅ DTOs permettent validation et sécurité
✅ Convention de nommage : `NomOperationDto` (ex: CreateWordDto)

---

## Section 4 : Comment tout s''articule ensemble

### Le flow complet : De la requête à la réponse

```
┌─────────────┐      (1) Requête HTTP        ┌─────────────┐
│   FRONTEND  │─────── POST /api/words ─────→│  CONTROLLER │
│   (React)   │        + CreateWordDto        │  (Backend)  │
└─────────────┘                               └─────────────┘
                                                     │
                                                     │ (2) Validation
                                                     │     du DTO
                                                     ↓
                                              ┌─────────────┐
                                              │   SERVICE   │
                                              │  (Logique)  │
                                              └─────────────┘
                                                     │
                                                     │ (3) Création
                                                     │     du Model
                                                     ↓
                                              ┌─────────────┐
                                              │   DATABASE  │
                                              │  (Stockage) │
                                              └─────────────┘
                                                     │
                                                     │ (4) Retour
                                                     │     du Model
                                                     ↓
┌─────────────┐      (5) Réponse HTTP        ┌─────────────┐
│   FRONTEND  │←────── 201 Created ─────────│  CONTROLLER │
│   (React)   │        + WordResponseDto     │  (Backend)  │
└─────────────┘                               └─────────────┘
```

### Exemple étape par étape : Créer un mot

**Étape 1 : Le frontend envoie une requête**
```javascript
// React frontnd
fetch(''http://localhost:5000/api/words'', {
  method: ''POST'',
  headers: { ''Content-Type'': ''application/json'' },
  body: JSON.stringify({
    frenchWord: ''chat'',
    englishWord: ''cat'',
    category: ''Noun'',
    difficulty: 1
  })
});
```

**Étape 2 : Le controller reçoit la requête**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    // dto.FrenchWord = "chat"
    // dto.EnglishWord = "cat"
    // dto.Category = "Noun"
    // dto.Difficulty = 1
```

**Étape 3 : Le controller crée le modèle**
```csharp
    var word = new Word
    {
        Id = words.Count + 1,              // Généré
        FrenchWord = dto.FrenchWord,       // Depuis DTO
        EnglishWord = dto.EnglishWord,     // Depuis DTO
        Category = dto.Category,           // Depuis DTO
        Difficulty = dto.Difficulty,       // Depuis DTO
        CreatedAt = DateTime.Now           // Généré
    };
```

**Étape 4 : Le controller sauvegarde**
```csharp
    words.Add(word);
```

**Étape 5 : Le controller retourne la réponse**
```csharp
    return CreatedAtAction(nameof(GetById), 
                          new { id = word.Id }, 
                          word);
}
```

**Étape 6 : Le frontend reçoit la réponse**
```javascript
// React frontend
.then(response => response.json())
.then(data => {
  console.log(data); 
  // { id: 1, frenchWord: "chat", englishWord: "cat", ... }
});
```

### Diagramme de séquence complet

```
Frontend          Controller          Service          Database
   │                  │                  │                 │
   │─── POST /api ───→│                  │                 │
   │   + DTO          │                  │                 │
   │                  │                  │                 │
   │                  │── Validate DTO   │                 │
   │                  │                  │                 │
   │                  │─── Process ─────→│                 │
   │                  │                  │                 │
   │                  │                  │─── Save ───────→│
   │                  │                  │                 │
   │                  │                  │←─── Model ──────│
   │                  │                  │                 │
   │                  │←─── Model ───────│                 │
   │                  │                  │                 │
   │←── 201 + DTO ────│                  │                 │
   │                  │                  │                 │
```

---

## Section 5 : Cas pratiques (Dictionnaire)

### Cas 1 : Récupérer tous les mots

**Requête frontend :**
```javascript
fetch(''http://localhost:5000/api/words'')
  .then(res => res.json())
  .then(words => console.log(words));
```

**Code controller :**
```csharp
[HttpGet]
public IActionResult GetAll()
{
    return Ok(words); // Retourne la liste complète
}
```

**Requête HTTP :**
```http
GET /api/words
```

**Réponse :**
```json
[
  {
    "id": 1,
    "frenchWord": "chat",
    "englishWord": "cat",
    "category": "Noun",
    "difficulty": 1,
    "createdAt": "2026-02-24T10:30:00"
  },
  {
    "id": 2,
    "frenchWord": "maison",
    "englishWord": "house",
    "category": "Noun",
    "difficulty": 2,
    "createdAt": "2026-02-24T10:35:00"
  }
]
```

---

### Cas 2 : Créer un nouveau mot

**Requête frontend :**
```javascript
fetch(''http://localhost:5000/api/words'', {
  method: ''POST'',
  headers: { ''Content-Type'': ''application/json'' },
  body: JSON.stringify({
    frenchWord: ''chien'',
    englishWord: ''dog'',
    category: ''Noun'',
    difficulty: 1
  })
});
```

**DTO :**
```csharp
public class CreateWordDto
{
    public string FrenchWord { get; set; }
    public string EnglishWord { get; set; }
    public string Category { get; set; }
    public int Difficulty { get; set; }
}
```

**Code controller :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    // Validation
    if (string.IsNullOrEmpty(dto.FrenchWord) || 
        string.IsNullOrEmpty(dto.EnglishWord))
    {
        return BadRequest("Les mots français et anglais sont obligatoires");
    }

    // Création du modèle
    var word = new Word
    {
        Id = words.Count + 1,
        FrenchWord = dto.FrenchWord,
        EnglishWord = dto.EnglishWord,
        Category = dto.Category,
        Difficulty = dto.Difficulty,
        CreatedAt = DateTime.Now
    };

    // Sauvegarde
    words.Add(word);

    // Retour
    return CreatedAtAction(nameof(GetById), 
                          new { id = word.Id }, 
                          word);
}
```

**Requête HTTP :**
```http
POST /api/words
Content-Type: application/json

{
  "frenchWord": "chien",
  "englishWord": "dog",
  "category": "Noun",
  "difficulty": 1
}
```

**Réponse :**
```json
{
  "id": 3,
  "frenchWord": "chien",
  "englishWord": "dog",
  "category": "Noun",
  "difficulty": 1,
  "createdAt": "2026-02-24T11:00:00"
}
```

---

### Cas 3 : Modifier un mot

**Requête frontend :**
```javascript
fetch(''http://localhost:5000/api/words/1'', {
  method: ''PUT'',
  headers: { ''Content-Type'': ''application/json'' },
  body: JSON.stringify({
    englishWord: ''kitty'',
    difficulty: 2
  })
});
```

**DTO :**
```csharp
public class UpdateWordDto
{
    public string EnglishWord { get; set; }
    public int Difficulty { get; set; }
}
```

**Code controller :**
```csharp
[HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] UpdateWordDto dto)
{
    // Recherche du mot
    var word = words.FirstOrDefault(w => w.Id == id);
    if (word == null)
    {
        return NotFound($"Le mot avec l''ID {id} n''existe pas");
    }

    // Mise à jour (uniquement les champs autorisés)
    word.EnglishWord = dto.EnglishWord;
    word.Difficulty = dto.Difficulty;
    word.UpdatedAt = DateTime.Now;

    // Retour
    return Ok(word);
}
```

**Requête HTTP :**
```http
PUT /api/words/1
Content-Type: application/json

{
  "englishWord": "kitty",
  "difficulty": 2
}
```

**Réponse :**
```json
{
  "id": 1,
  "frenchWord": "chat",
  "englishWord": "kitty",
  "category": "Noun",
  "difficulty": 2,
  "createdAt": "2026-02-24T10:30:00",
  "updatedAt": "2026-02-24T11:15:00"
}
```

---

## Section 6 : Bonnes pratiques

### Nommage des Controllers

✅ **Bon :**
```csharp
WordsController          // Pluriel
UsersController
ProductsController
```

❌ **Mauvais :**
```csharp
WordController           // Singulier
Word_Controller          // Underscore
wordController           // Minuscule
```

**Règle :** Toujours au **pluriel** + suffixe `Controller`

---

### Nommage des Endpoints

✅ **Bon :**
```http
GET    /api/words              # Collection
GET    /api/words/1            # Ressource spécifique
POST   /api/words              # Créer
PUT    /api/words/1            # Modifier tout
PATCH  /api/words/1            # Modifier partiellement
DELETE /api/words/1            # Supprimer
```

❌ **Mauvais :**
```http
GET    /api/GetAllWords        # Verbe dans l''URL
POST   /api/CreateWord         # Verbe dans l''URL
GET    /api/words/get/1        # Verbe dans l''URL
DELETE /api/words/delete/1     # Verbe dans l''URL
```

**Règle :** Utiliser les verbes HTTP, pas dans l''URL

---

### Nommage des DTOs

✅ **Bon :**
```csharp
CreateWordDto            # Création
UpdateWordDto            # Modification
WordResponseDto          # Réponse
WordFilterDto            # Filtrage
```

❌ **Mauvais :**
```csharp
WordDto                  # Trop vague
NewWord                  # Pas explicite
WordInput                # Pas clair
```

**Règle :** `[Action][Nom][Dto]` (ex: CreateWordDto)

---

### Organisation des fichiers

```
MonApi/
├── Controllers/
│   ├── WordsController.cs
│   └── UsersController.cs
├── Models/
│   ├── Word.cs
│   └── User.cs
├── DTOs/
│   ├── Word/
│   │   ├── CreateWordDto.cs
│   │   ├── UpdateWordDto.cs
│   │   └── WordResponseDto.cs
│   └── User/
│       ├── CreateUserDto.cs
│       └── UserResponseDto.cs
├── Services/
│   ├── IWordService.cs
│   └── WordService.cs
└── Program.cs
```

---

### Convention de routing

✅ **Bon :**
```csharp
[ApiController]
[Route("api/[controller]")]     // api/words
public class WordsController : ControllerBase
{
    [HttpGet]                    // GET /api/words
    public IActionResult GetAll() { }

    [HttpGet("{id}")]            // GET /api/words/5
    public IActionResult GetById(int id) { }

    [HttpPost]                   // POST /api/words
    public IActionResult Create([FromBody] CreateWordDto dto) { }
}
```

❌ **Mauvais :**
```csharp
[Route("words")]                 # Pas de "api/"
[Route("api/word")]              # Singulier
[Route("GetWords")]              # Verbe dans la route
```

---

## Section 7 : Erreurs courantes à éviter

### Erreur 1 : Exposer directement le Model

❌ **Mauvais :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] Word word)
{
    // Le client peut modifier l''Id, CreatedAt, etc.
    words.Add(word);
    return Ok(word);
}
```

✅ **Bon :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    var word = new Word
    {
        Id = GenerateId(),           // Contrôlé par le serveur
        FrenchWord = dto.FrenchWord,
        EnglishWord = dto.EnglishWord,
        CreatedAt = DateTime.Now     // Contrôlé par le serveur
    };
    words.Add(word);
    return Ok(word);
}
```

**Pourquoi ?** Le client ne doit pas contrôler `Id` et `CreatedAt`.

---

### Erreur 2 : Ne pas valider les données

❌ **Mauvais :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    var word = new Word { FrenchWord = dto.FrenchWord };
    words.Add(word);
    return Ok(word);
}
```

✅ **Bon :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    if (string.IsNullOrEmpty(dto.FrenchWord))
    {
        return BadRequest("Le mot français est obligatoire");
    }

    var word = new Word { FrenchWord = dto.FrenchWord };
    words.Add(word);
    return Ok(word);
}
```

**Pourquoi ?** Toujours valider avant de traiter.

---

### Erreur 3 : Mauvais codes de retour HTTP

❌ **Mauvais :**
```csharp
[HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var word = words.FirstOrDefault(w => w.Id == id);
    return Ok(word); // Retourne 200 même si word est null !
}
```

✅ **Bon :**
```csharp
[HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var word = words.FirstOrDefault(w => w.Id == id);
    if (word == null)
        return NotFound(); // 404

    return Ok(word); // 200
}
```

**Pourquoi ?** Utiliser les bons codes HTTP (200, 404, 400, etc.).

---

### Erreur 4 : Logique métier dans le Controller

❌ **Mauvais :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    // Logique métier complexe dans le controller
    var word = new Word { ... };
    
    if (word.Difficulty > 5)
        word.Difficulty = 5;
    
    if (word.Category == "Verb")
        word.FrenchWord = word.FrenchWord.ToLower();
    
    // Validation complexe
    // Transformation complexe
    // ...
    
    words.Add(word);
    return Ok(word);
}
```

✅ **Bon :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    // Le controller délègue au service
    var word = _wordService.CreateWord(dto);
    return CreatedAtAction(nameof(GetById), 
                          new { id = word.Id }, 
                          word);
}
```

**Pourquoi ?** Le controller doit rester simple, la logique va dans un Service.

---

### Erreur 5 : Oublier [FromBody]

❌ **Mauvais :**
```csharp
[HttpPost]
public IActionResult Create(CreateWordDto dto)
{
    // dto sera null !
}
```

✅ **Bon :**
```csharp
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    // dto contient les données du body
}
```

**Pourquoi ?** `[FromBody]` indique que les données viennent du body HTTP.

---

### Erreur 6 : Routes en doublon

❌ **Mauvais :**
```csharp
[HttpGet]
public IActionResult GetAll() { }

[HttpGet]
public IActionResult GetAllActive() { }
// ERREUR : Deux endpoints avec la même route !
```

✅ **Bon :**
```csharp
[HttpGet]
public IActionResult GetAll() { }

[HttpGet("active")]
public IActionResult GetAllActive() { }
// /api/words/active
```

**Pourquoi ?** Chaque endpoint doit avoir une route unique.

---

## Section 8 : Tableau récapitulatif complet

### Comparaison des 3 concepts

| Aspect | Endpoint | Controller | DTO |
|--------|----------|------------|-----|
| **Qu''est-ce ?** | Une URL accessible | Une classe regroupant endpoints | Un objet de transfert |
| **Analogie** | Plat du menu | Chef de cuisine | Ticket de commande |
| **Rôle** | Permettre une action | Coordonner le traitement | Transférer des données |
| **Exemple** | `GET /api/words` | `WordsController` | `CreateWordDto` |
| **Méthodes** | GET, POST, PUT, DELETE | Plusieurs méthodes | Propriétés seulement |
| **Localisation** | Dans un controller | `Controllers/` | `DTOs/` ou dans Controller |
| **Nommage** | Verbe HTTP + URL | `XxxController` | `ActionXxxDto` |

### CRUD complet

| Opération | Méthode HTTP | Endpoint | DTO | Code retour |
|-----------|--------------|----------|-----|-------------|
| **Create** | POST | `/api/words` | CreateWordDto | 201 Created |
| **Read All** | GET | `/api/words` | - | 200 OK |
| **Read One** | GET | `/api/words/1` | - | 200 OK / 404 |
| **Update** | PUT | `/api/words/1` | UpdateWordDto | 200 OK / 404 |
| **Delete** | DELETE | `/api/words/1` | - | 204 No Content / 404 |

### Codes HTTP principaux

| Code | Signification | Quand l''utiliser |
|------|---------------|-------------------|
| **200 OK** | Succès | GET, PUT réussi |
| **201 Created** | Création réussie | POST réussi |
| **204 No Content** | Succès sans données | DELETE réussi |
| **400 Bad Request** | Requête invalide | Validation échouée |
| **404 Not Found** | Ressource introuvable | GET/PUT/DELETE sur ID inexistant |
| **500 Internal Server Error** | Erreur serveur | Exception non gérée |

---

## Section 9 : Checklist avant de créer ton API

### ✅ Checklist Model

- [ ] Le modèle est dans `Models/`
- [ ] Toutes les propriétés nécessaires sont présentes
- [ ] Il y a une propriété `Id`
- [ ] Il y a une propriété `CreatedAt`
- [ ] Les types sont corrects (string, int, DateTime, etc.)

### ✅ Checklist Controller

- [ ] Le controller est dans `Controllers/`
- [ ] Nom du controller au pluriel + `Controller`
- [ ] Attribut `[ApiController]` présent
- [ ] Attribut `[Route("api/[controller]")]` présent
- [ ] Hérite de `ControllerBase`
- [ ] Tous les endpoints CRUD sont présents

### ✅ Checklist Endpoint

- [ ] Attribut HTTP correct (`[HttpGet]`, `[HttpPost]`, etc.)
- [ ] Route explicite si besoin (`[HttpGet("{id}")]`)
- [ ] Paramètres corrects (`int id`, `[FromBody] Dto`)
- [ ] Validation des données
- [ ] Code de retour HTTP correct
- [ ] Gestion des erreurs (404, 400, etc.)

### ✅ Checklist DTO

- [ ] Le DTO est clairement nommé (`CreateXxxDto`, `UpdateXxxDto`)
- [ ] Contient uniquement les propriétés nécessaires
- [ ] PAS de propriétés sensibles ou internes
- [ ] PAS de propriétés calculées par le serveur (Id, CreatedAt)
- [ ] Annotations de validation si nécessaire

---

## Section 10 : Exercices pratiques

### Exercice 1 : Identifier les erreurs

**Code donné :**
```csharp
[Route("words")]
public class WordController
{
    [Get]
    public void GetAll()
    {
        var words = GetWords();
        return words;
    }
}
```

**Questions :**
1. Quelles sont les 5 erreurs dans ce code ?
2. Comment les corriger ?

<details>
<summary>Voir la solution</summary>

**Erreurs :**
1. ❌ Pas de `[ApiController]`
2. ❌ Route incorrecte (manque `api/`)
3. ❌ Nom singulier (`WordController` au lieu de `WordsController`)
4. ❌ `[Get]` au lieu de `[HttpGet]`
5. ❌ Type de retour `void` au lieu de `IActionResult`
6. ❌ Pas d''héritage de `ControllerBase`

**Code corrigé :**
```csharp
[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var words = GetWords();
        return Ok(words);
    }
}
```
</details>

---

### Exercice 2 : Créer un DTO

**Scénario :**
Tu dois permettre à l''utilisateur de modifier uniquement la traduction anglaise et la difficulté d''un mot. Il ne doit PAS pouvoir modifier l''ID, le mot français, ou la date de création.

**Questions :**
1. Quel type de DTO créer ?
2. Quelles propriétés inclure ?
3. Écrire le code du DTO

<details>
<summary>Voir la solution</summary>

**Type :** `UpdateWordDto`

**Code :**
```csharp
public class UpdateWordDto
{
    public string EnglishWord { get; set; }
    public int Difficulty { get; set; }
}
```

**Utilisation :**
```csharp
[HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] UpdateWordDto dto)
{
    var word = words.FirstOrDefault(w => w.Id == id);
    if (word == null)
        return NotFound();
    
    word.EnglishWord = dto.EnglishWord;
    word.Difficulty = dto.Difficulty;
    
    return Ok(word);
}
```
</details>

---

### Exercice 3 : Créer un endpoint complet

**Scénario :**
Crée un endpoint pour récupérer tous les mots d''une langue spécifique (ex: tous les mots en anglais).

**Questions :**
1. Quelle méthode HTTP utiliser ?
2. Quelle sera l''URL ?
3. Écrire le code complet

<details>
<summary>Voir la solution</summary>

**Méthode :** GET

**URL :** `/api/ words?language=English`

**Code :**
```csharp
[HttpGet]
public IActionResult GetByLanguage([FromQuery] string language)
{
    if (string.IsNullOrEmpty(language))
    {
        return BadRequest("Le paramètre ''language'' est obligatoire");
    }

    var filteredWords = words
        .Where(w => w.Language.Equals(language, 
                    StringComparison.OrdinalIgnoreCase))
        .ToList();

    return Ok(filteredWords);
}
```

**Test :**
```http
GET /api/words?language=English
```
</details>

---

## Section 11 : Pour aller plus loin

### Concepts avancés (optionnels)

#### 1. Services et Repository Pattern
Pour séparer la logique métier du controller :
```csharp
public interface IWordService
{
    Task<List<Word>> GetAllAsync();
    Task<Word> GetByIdAsync(int id);
    Task<Word> CreateAsync(CreateWordDto dto);
}
```

#### 2. AutoMapper
Pour convertir automatiquement Model ↔ DTO :
```csharp
var wordDto = _mapper.Map<WordResponseDto>(word);
```

#### 3. FluentValidation
Pour valider les DTOs de manière avancée :
```csharp
public class CreateWordDtoValidator : AbstractValidator<CreateWordDto>
{
    public CreateWordDtoValidator()
    {
        RuleFor(x => x.FrenchWord).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Difficulty).InclusiveBetween(1, 5);
    }
}
```

#### 4. Pagination
Pour ne pas retourner des milliers de résultats :
```csharp
[HttpGet]
public IActionResult GetAll([FromQuery] int page = 1, 
                            [FromQuery] int pageSize = 10)
{
    var paginatedWords = words
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    
    return Ok(new { 
        page, 
        pageSize, 
        total = words.Count, 
        data = paginatedWords 
    });
}
```

#### 5. Authentification et Autorisation
Pour sécuriser tes endpoints :
```csharp
[Authorize] // Nécessite une authentification
[HttpPost]
public IActionResult Create([FromBody] CreateWordDto dto)
{
    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    // ...
}
```

---

## Récapitulatif final

### Ce que tu dois retenir

🎯 **Endpoint** :
- Une URL + méthode HTTP (GET, POST, PUT, DELETE)
- Permet au frontend d''effectuer des actions
- Exemple : `GET /api/words`

🎯 **Controller** :
- Une classe qui regroupe des endpoints liés
- Reçoit les requêtes, traite, retourne les réponses
- Exemple : `WordsController`

🎯 **DTO** :
- Un objet pour transférer des données
- Sécurise et valide les données
- Exemple : `CreateWordDto`, `UpdateWordDto`

### Relation entre les 3

```
Controller (WordsController)
    ├── Endpoint 1 : GET /api/words
    ├── Endpoint 2 : GET /api/words/{id}
    ├── Endpoint 3 : POST /api/words → utilise CreateWordDto
    ├── Endpoint 4 : PUT /api/words/{id} → utilise UpdateWordDto
    └── Endpoint 5 : DELETE /api/words/{id}
```

### Prochaines étapes

Maintenant que tu comprends ces concepts, tu peux :
1. ✅ Créer ton premier controller pour le dictionnaire
2. ✅ Définir les DTOs nécessaires
3. ✅ Implémenter les endpoints CRUD
4. ✅ Tester avec MonApi.http
5. ✅ Connecter le frontend React

---

## Fin du cours

**Tu es maintenant prêt à créer ta première API .NET !** 🚀

**Questions à te poser avant de commencer :**
- Quel modèle de données as-tu besoin ? (Word, User, Product, etc.)
- Quels endpoints vas-tu créer ? (GET, POST, PUT, DELETE)
- Quels DTOs sont nécessaires ? (Create, Update, Response)

**Bon courage pour ton projet de dictionnaire !** 📚
