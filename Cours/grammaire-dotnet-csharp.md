# Grammaire .NET et C#â€¯: notions indispensables

## Objectif
Comprendre et utiliser les bases de la grammaire C#/.NET pour développer des applications backend robustes, lisibles et modernes. Ce cours est pensé dans un ordre progressif : du plus simple au plus avancé.

---

## 1. Types primitifs et variables

Les types primitifs sont les types de base que C# propose pour stocker des données simples.

| Type     | Description                  | Exemple                     |
|----------|------------------------------|-----------------------------|
| `int`    | Nombre entier                | `int age = 18;`             |
| `double` | Nombre décimal               | `double prix = 9.99;`       |
| `bool`   | Vrai ou faux                 | `bool estActif = true;`     |
| `string` | ChaÃ®ne de caractÃ¨res         | `string nom = "Alice";`     |
| `char`   | Un seul caractÃ¨re            | `char lettre = 'A';`        |

```csharp
int age = 25;
string prenom = "Alice";
bool estAdmin = false;
double prix = 19.99;
```

---

## 2. Déclaration vs Instanciation

- **Déclaration** : on annonce qu'une variable existe, avec son type et son nom.
  ```csharp
  string message; // déclaration seule, message vaut null
  ```
- **Instanciation** : on crée un objet réel en mémoire et on l'assigne Ã  la variable.
  ```csharp
  message = "Bonjour !"; // instanciation (affectation d'une valeur)
  ```
- **Les deux en une seule ligne** :
  ```csharp
  string message = "Bonjour !";
  ```

Pour les objets complexes, on utilise le mot-clé `new` :
```csharp
List<string> noms = new List<string>(); // déclaration + instanciation d'une liste vide
```

**Ã€ retenir** :
- Déclarer = annoncer l'existence d'une variable.
- Instancier = créer un objet réel en mémoire avec `new`.

---

## 3. Constantes et readonly

- **const** : valeur fixée Ã  la compilation, ne peut jamais changer.
  ```csharp
  const double TVA = 0.20;
  ```
- **readonly** : valeur définie une seule fois (dans le constructeur), ne peut plus changer ensuite.
  ```csharp
  private readonly string _nom;
  public Produit(string nom) {
      _nom = nom; // on peut assigner ici, mais nulle part ailleurs
  }
  ```

---

## 4. Modificateurs d'accÃ¨s

Les modificateurs d'accÃ¨s contrÃ´lent qui peut voir ou utiliser une variable, méthode ou classe.

| Mot-clé     | Accessible depuis                              |
|-------------|------------------------------------------------|
| `public`    | Partout dans le projet                         |
| `private`   | Uniquement dans la classe actuelle             |
| `protected` | Dans la classe et ses classes filles (héritage)|
| `internal`  | Dans le même projet (assembly)                 |

```csharp
public class Produit {
    public string Nom { get; set; }       // accessible partout
    private int _stock;                   // accessible seulement dans Produit
    protected double Prix { get; set; }   // accessible dans Produit et ses héritiers
}
```

**Convention** : les variables privées sont nommées avec un underscore `_nomVariable`.

---

## 5. Opérateurs

- **Arithmétiques** : `+`, `-`, `*`, `/`, `%` (modulo = reste de division)
  ```csharp
  int somme = 5 + 3;    // 8
  int reste = 10 % 3;   // 1
  ```
- **Comparaison** : `==`, `!=`, `>`, `<`, `>=`, `<=`
  ```csharp
  bool estEgal = (5 == 5);   // true
  bool estDiff = (3 != 5);   // true
  ```
- **Logiques** : `&&` (ET), `||` (OU), `!` (NON)
  ```csharp
  bool resultat = (age >= 18 && estInscrit); // vrai si les deux sont vrais
  ```

---

## 6. Structures de contrÃ´le : if / else

Le `if/else` permet d'exécuter du code selon une condition.

```csharp
int age = 20;

if (age >= 18)
{
    Console.WriteLine("Majeur");
}
else if (age >= 13)
{
    Console.WriteLine("Adolescent");
}
else
{
    Console.WriteLine("Enfant");
}
```

**Expression ternaire** : version courte d'un if/else simple.
```csharp
// Syntaxe : condition ? valeurSiVrai : valeurSiFaux
string statut = age >= 18 ? "Majeur" : "Mineur";
```

**Avantages du ternaire** :
- Remplace un if/else court
- Rend le code plus concis et lisible pour des choix simples

---

## 7. Structures de contrÃ´le : switch / case

Le `switch/case` permet de tester plusieurs valeurs d'une même variable.

```csharp
string jour = "lundi";

switch (jour)
{
    case "lundi":
        Console.WriteLine("Début de semaine");
        break;
    case "samedi":
    case "dimanche":
        Console.WriteLine("Week-end");
        break;
    default:
        Console.WriteLine("Jour ordinaire");
        break;
}
```

- `case` : teste une valeur
- `break` : termine le bloc courant (obligatoire aprÃ¨s chaque case)
- `default` : valeur par défaut si aucun case ne correspond

---

## 8. Boucles : for, foreach, while

Les boucles permettent de répéter des instructions.

- **for** : quand on connaÃ®t le nombre de répétitions.
  ```csharp
  for (int i = 0; i < 5; i++)
  {
      Console.WriteLine(i); // affiche 0, 1, 2, 3, 4
  }
  ```

- **foreach** : pour parcourir tous les éléments d'une liste ou collection.
  ```csharp
  List<string> noms = new List<string> { "Alice", "Bob", "Charlie" };
  foreach (string nom in noms)
  {
      Console.WriteLine(nom);
  }
  ```

- **while** : répÃ¨te tant qu'une condition est vraie.
  ```csharp
  int compteur = 0;
  while (compteur < 3)
  {
      Console.WriteLine(compteur);
      compteur++;
  }
  ```

---

## 9. Classes, propriétés, constructeurs

- **Classe** : plan de construction d'un objet.
  ```csharp
  public class Produit {
      public int Id { get; set; }
      public string Nom { get; set; }
      public double Prix { get; set; }

      // Constructeur : appelé au moment du new
      public Produit(int id, string nom, double prix) {
          Id = id;
          Nom = nom;
          Prix = prix;
      }
  }
  ```
- **Instanciation** d'une classe :
  ```csharp
  Produit p = new Produit(1, "Chaise", 49.99);
  Console.WriteLine(p.Nom); // affiche "Chaise"
  ```
- **Propriété** : variable d'une classe avec accÃ¨s contrÃ´lé via `get` et `set`.
  ```csharp
  public string Nom { get; set; }            // lecture et écriture
  public string Code { get; private set; }   // lecture publique, écriture privée
  ```

---

## 10. Méthodes et types de retour

- **void** : la méthode ne retourne rien.
- **Type classique** (ex : `int`, `string`, `Produit`) : la méthode retourne une valeur.
- **Task** et **Task<T>** : pour les méthodes asynchrones (voir section 12).

```csharp
// Retourne un int
public int Addition(int a, int b) {
    return a + b;
}

// Ne retourne rien
public void AfficherMessage(string message) {
    Console.WriteLine(message);
}
```

---

## 11. Types nullables

Un type nullable peut contenir soit une valeur, soit `null` (rien).

```csharp
int age = 20;    // ne peut pas être null
int? ageOpt = null;  // peut être null (le ? indique qu'il est nullable)

string? nom = null;  // string nullable
```

**AccÃ¨s conditionnel** `?.` : accÃ¨de Ã  une propriété seulement si l'objet n'est pas null.
```csharp
string? nom = produit?.Nom; // si produit est null, nom sera null au lieu de crasher
```

**Null-coalescing** `??` : valeur par défaut si null.
```csharp
string nom = produit?.Nom ?? "Inconnu";
// Si produit est null ou si Nom est null, on utilise "Inconnu"
```

---

## 12. Interfaces et implémentation

- **Interface** : définit un contrat (liste de méthodes/propriétés Ã  implémenter), sans écrire le code de ces méthodes.
  ```csharp
  public interface IProduitService {
      void AjouterProduit(Produit p);
      List<Produit> ObtenirTous();
  }
  ```
- **Implémentation** : une classe qui respecte ce contrat en écrivant le code des méthodes.
  ```csharp
  public class ProduitService : IProduitService {
      private List<Produit> _produits = new List<Produit>();

      public void AjouterProduit(Produit p) {
          _produits.Add(p);
          Console.WriteLine($"Produit ajouté : {p.Nom}");
      }

      public List<Produit> ObtenirTous() {
          return _produits;
      }
  }
  ```

**Pourquoi utiliser une interface ?**
- Séparer le contrat (ce que Ã§a doit faire) de l'implémentation (comment Ã§a le fait).
- Faciliter les tests en remplaÃ§ant l'implémentation réelle par un faux service.

---

## 13. Collections : List et Dictionary

- **List<T>** : liste ordonnée d'éléments du même type.
  ```csharp
  List<string> noms = new List<string>();
  noms.Add("Alice");
  noms.Add("Bob");
  noms.Remove("Alice");
  Console.WriteLine(noms[0]); // Bob
  ```

- **Dictionary<K, V>** : collection de paires clé/valeur, idéale pour retrouver un élément par sa clé.
  ```csharp
  Dictionary<int, string> produits = new Dictionary<int, string>();
  produits.Add(1, "Chaise");
  produits.Add(2, "Table");
  Console.WriteLine(produits[1]); // Chaise
  ```

---

## 14. Les méthodes LINQ indispensables

LINQ permet de manipuler facilement des listes et collections avec des méthodes expressives.

- **FirstOrDefault** : retourne le premier élément qui correspond Ã  une condition, ou `null` si aucun.
  ```csharp
  var produit = produits.FirstOrDefault(p => p.Id == 1);
  ```
- **Where** : filtre une liste selon une condition.
  ```csharp
  var produitsEnStock = produits.Where(p => p.Stock > 0).ToList();
  ```
- **Select** : transforme chaque élément d'une liste.
  ```csharp
  var noms = produits.Select(p => p.Nom).ToList();
  ```
- **Any** : vérifie si au moins un élément correspond Ã  une condition.
  ```csharp
  bool existe = produits.Any(p => p.Prix > 100);
  ```
- **Count** : compte le nombre d'éléments.
  ```csharp
  int nombre = produits.Count();
  ```
- **OrderBy** : trie une liste.
  ```csharp
  var triés = produits.OrderBy(p => p.Prix).ToList();
  ```

**Expression lambda** : syntaxe courte utilisée avec LINQ, de la forme `x => condition`.
```csharp
produits.Where(p => p.Prix > 10) // p représente chaque produit de la liste
```

---

## 15. Exceptions et gestion des erreurs

- **try/catch/finally** : protÃ¨ge le code en cas d'erreur, sans faire planter l'application.
  ```csharp
  try {
      var produit = produits.First(p => p.Id == 1); // peut lever une exception si vide
  }
  catch (InvalidOperationException ex) {
      Console.WriteLine("Produit introuvable : " + ex.Message);
  }
  catch (Exception ex) {
      Console.WriteLine("Erreur inattendue : " + ex.Message);
  }
  finally {
      Console.WriteLine("Cette ligne s'exécute toujours");
  }
  ```
  - `try` : contient le code risqué
  - `catch` : gÃ¨re l'erreur si elle survient (on peut en avoir plusieurs pour différents types)
  - `finally` : s'exécute toujours, qu'il y ait une erreur ou non

---

## 16. Programmation asynchrone : async, await, Task

Par défaut, le code s'exécute ligne par ligne. `async/await` permet d'attendre une opération longue (ex : appel Ã  une base de données) sans bloquer tout le programme.

- **async** : indique qu'une méthode est asynchrone.
- **await** : attend la fin d'une opération asynchrone.
- **Task** : représente une opération asynchrone qui ne retourne rien.
- **Task<T>** : représente une opération asynchrone qui retourne un résultat de type T.

```csharp
// Méthode asynchrone qui retourne une liste de produits
public async Task<List<Produit>> ObtenirProduitsAsync() {
    List<Produit> produits = await _repository.GetAllAsync(); // attend la réponse de la BDD
    return produits;
}
```

**RÃ¨gle** : si une méthode utilise `await`, elle doit être marquée `async`.

---

## 17. Attributs dans les contrÃ´leurs d'API

Les attributs (entre `[ ]`) donnent des instructions au framework sur le comportement d'une classe ou méthode.

- `[ApiController]` : indique que la classe est un contrÃ´leur d'API.
- `[Route("api/[controller]")]` : définit l'URL de base du contrÃ´leur.
- `[HttpGet]` : la méthode répond aux requêtes GET.
- `[HttpPost]` : la méthode répond aux requêtes POST.
- `[HttpPut]` : la méthode répond aux requêtes PUT (modification).
- `[HttpDelete]` : la méthode répond aux requêtes DELETE.

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProduitController : ControllerBase {

    [HttpGet]
    public ActionResult<List<ProduitDto>> GetTous() { ... }

    [HttpGet("{id}")]
    public ActionResult<ProduitDto> GetById(int id) { ... }

    [HttpPost]
    public ActionResult<ProduitDto> Creer(ProduitDto dto) { ... }

    [HttpDelete("{id}")]
    public IActionResult Supprimer(int id) { ... }
}
```

---

## 18. Types de retour des contrÃ´leurs d'API

- **IActionResult** : type de retour générique, adapté quand on ne sait pas encore le type exact.
- **ActionResult<T>** : retourne un objet de type T ou un résultat HTTP.

Méthodes de réponse courantes :

| Méthode               | Code HTTP | Signification                       |
|-----------------------|-----------|-------------------------------------|
| `Ok(objet)`           | 200       | SuccÃ¨s, avec un objet en réponse    |
| `NotFound()`          | 404       | Ressource introuvable               |
| `BadRequest()`        | 400       | Requête invalide                    |
| `Created(url, objet)` | 201       | Ressource créée avec succÃ¨s         |
| `NoContent()`         | 204       | SuccÃ¨s, sans contenu Ã  retourner    |

```csharp
[HttpGet("{id}")]
public ActionResult<ProduitDto> GetProduit(int id) {
    var produit = _service.ObtenirProduit(id);
    if (produit == null)
        return NotFound();
    return Ok(produit);
}
```

---

## 19. Injection de dépendances

L'injection de dépendances permet de donner Ã  une classe les objets dont elle a besoin, sans qu'elle ait Ã  les créer elle-même. C'est le framework qui s'en charge.

**Ã‰tape 1 : déclarer la dépendance dans le constructeur**
```csharp
public class ProduitController : ControllerBase {
    private readonly IProduitService _service;

    public ProduitController(IProduitService service) {
        _service = service; // le framework injecte automatiquement ProduitService
    }
}
```

**Ã‰tape 2 : enregistrer l'implémentation dans Program.cs**
```csharp
// On dit au framework : quand quelqu'un demande IProduitService, donne-lui ProduitService
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
```

**Les types d'enregistrement :**
| Méthode          | Durée de vie                                    |
|------------------|-------------------------------------------------|
| `AddScoped`      | Une instance par requête HTTP (le plus courant) |
| `AddSingleton`   | Une seule instance pour toute la durée de vie   |
| `AddTransient`   | Une nouvelle instance Ã  chaque utilisation      |

---

## 20. Notions avancées utiles

- **using** : importe un espace de noms (namespace) pour utiliser ses classes sans tout réécrire.
  ```csharp
  using System.Collections.Generic;
  ```
- **var** : laisse le compilateur deviner le type automatiquement.
  ```csharp
  var liste = new List<string>(); // le compilateur sait que c'est une List<string>
  ```
- **string interpolation** `$"..."` : insÃ¨re des variables dans une chaÃ®ne de caractÃ¨res.
  ```csharp
  string message = $"Bonjour {prenom}, tu as {age} ans.";
  ```

---

## Points Ã  retenir
- MaÃ®triser les types primitifs et la déclaration/instanciation de variables
- Comprendre les modificateurs d'accÃ¨s (public, private, protected)
- Utiliser les structures de contrÃ´le : if/else, switch, ternaire
- Utiliser les boucles : for, foreach, while
- Savoir écrire et utiliser des classes, interfaces, méthodes et propriétés
- Comprendre les collections List et Dictionary
- MaÃ®triser les méthodes LINQ courantes pour manipuler les collections
- Savoir gérer les erreurs avec try/catch/finally
- Comprendre la programmation asynchrone avec async/await et Task
- Utiliser les attributs ([HttpGet], [Route]...) et les types de retour adaptés dans les contrÃ´leurs d'API
- Mettre en place l'injection de dépendances pour un code flexible et testable


---

## 21. Commentaires

Les commentaires permettent d'expliquer le code sans qu'il soit execute.

```csharp
// Ceci est un commentaire sur une seule ligne

/*
   Ceci est un commentaire
   sur plusieurs lignes
*/

/// <summary>
/// Documentation XML : apparait dans l'aide de VS Code
/// </summary>
public void MaMethode() { }
```

**Conseil** : commenter les parties complexes, mais eviter les commentaires evidents.

---

## 22. Tableaux (arrays)

Un tableau est une collection de taille fixe, contenant des elements du meme type.

```csharp
// Declaration et initialisation
int[] nombres = new int[3];      // tableau de 3 entiers (valeurs par defaut : 0)
nombres[0] = 10;
nombres[1] = 20;
nombres[2] = 30;

// Declaration + initialisation directe
string[] jours = { "Lundi", "Mardi", "Mercredi" };

// Acces par index (commence a 0)
Console.WriteLine(jours[0]); // Lundi

// Parcours avec foreach
foreach (string jour in jours)
{
    Console.WriteLine(jour);
}

// Longueur du tableau
int taille = jours.Length; // 3
```

**Difference tableau vs List** :
- Tableau : taille fixe, plus performant pour des donnees de taille connue.
- List : taille dynamique, on peut ajouter/supprimer des elements.

---

## 23. Enumerations (enum)

Un `enum` definit un ensemble de valeurs nommees, utile pour representer des choix limites.

```csharp
public enum Statut
{
    EnAttente,    // = 0 par defaut
    EnCours,      // = 1
    Termine,      // = 2
    Annule        // = 3
}

// Utilisation
Statut etatCommande = Statut.EnCours;

if (etatCommande == Statut.Termine)
{
    Console.WriteLine("Commande terminee");
}

// Dans un switch
switch (etatCommande)
{
    case Statut.EnAttente:
        Console.WriteLine("En attente...");
        break;
    case Statut.EnCours:
        Console.WriteLine("En cours de traitement");
        break;
    default:
        Console.WriteLine("Autre statut");
        break;
}
```

**Avantages** :
- Plus lisible que des nombres magiques (0, 1, 2...)
- Autocompletion dans l'editeur
- Moins d'erreurs (on ne peut pas mettre une valeur invalide)

---

## 24. Mots-cles dans les boucles : break et continue

- **break** : sort immediatement de la boucle.
- **continue** : passe a l'iteration suivante sans executer le reste du code.

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 3)
        continue; // saute l'iteration quand i == 3

    if (i == 7)
        break; // arrete la boucle quand i == 7

    Console.WriteLine(i); // affiche 0, 1, 2, 4, 5, 6
}
```

---

## 25. Heritage (notion de base)

L'heritage permet a une classe enfant de recuperer les proprietes et methodes d'une classe parent.

```csharp
// Classe parent (de base)
public class Animal
{
    public string Nom { get; set; }

    public void Manger()
    {
        Console.WriteLine($"{Nom} mange.");
    }
}

// Classe enfant (herite de Animal)
public class Chien : Animal
{
    public void Aboyer()
    {
        Console.WriteLine($"{Nom} aboie !");
    }
}

// Utilisation
Chien monChien = new Chien();
monChien.Nom = "Rex";
monChien.Manger();  // herite de Animal
monChien.Aboyer();  // propre a Chien
```

**Mots-cles lies** :
- `: NomParent` : indique l'heritage
- `virtual` : permet a une methode d'etre redefinie dans une classe enfant
- `override` : redefinit une methode heritee
- `base` : appelle le constructeur ou une methode du parent

```csharp
public class Animal
{
    public virtual void Parler()
    {
        Console.WriteLine("L'animal fait un bruit.");
    }
}

public class Chat : Animal
{
    public override void Parler()
    {
        Console.WriteLine("Le chat miaule.");
    }
}
```

---

## Recapitulatif final
- Maitriser les types primitifs et la declaration/instanciation de variables
- Comprendre les modificateurs d'acces (public, private, protected)
- Utiliser les structures de controle : if/else, switch, ternaire
- Utiliser les boucles : for, foreach, while (+ break/continue)
- Savoir ecrire et utiliser des classes, interfaces, methodes et proprietes
- Comprendre les tableaux (arrays) et les collections List/Dictionary
- Utiliser les enumerations (enum) pour les choix limites
- Maitriser les methodes LINQ courantes pour manipuler les collections
- Savoir gerer les erreurs avec try/catch/finally
- Comprendre la programmation asynchrone avec async/await et Task
- Utiliser les attributs ([HttpGet], [Route]...) et les types de retour adaptes dans les controleurs d'API
- Mettre en place l'injection de dependances pour un code flexible et testable
- Connaitre les bases de l'heritage pour structurer le code
