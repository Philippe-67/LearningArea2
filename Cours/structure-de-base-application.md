# Structure de base d'une application

## Objectif
Comprendre comment une application moderne est organisée en deux parties principales : le backend (MonApi) et le frontend (MonFrontend), et comment elles communiquent entre elles.

---

## 1. Vue d'ensemble

Une application web moderne est généralement divisée en deux projets distincts :

```
Mon Projet/
├── MonApi/          (Backend - Serveur)
└── MonFrontend/     (Frontend - Interface utilisateur)
```

---

## 2. Le Backend (MonApi) - Le cerveau de l'application

### Rôle du backend
- **Gère les données** : stockage, récupération, modification dans une base de données
- **Applique la logique métier** : calculs, règles de gestion, validations
- **Sécurise l'application** : authentification, autorisations, protection des données
- **Expose une API** : fournit des endpoints pour que le frontend puisse communiquer

### Technologie utilisée
- **.NET** (C#) : framework robuste pour créer des APIs
- **Entity Framework** : pour communiquer avec la base de données
- **ASP.NET Core** : pour le web et les APIs REST

### Exemple de structure
```
MonApi/
├── Controllers/      # Gère les requêtes HTTP
├── Services/         # Logique métier
├── Models/           # Structure des données
├── Repositories/     # Accès à la base de données
├── DTOs/             # Objets de transfert
├── Program.cs        # Point d'entrée
└── appsettings.json  # Configuration
```

### Ce que fait le backend concrètement
```csharp
// Exemple : Récupérer une liste de produits
[HttpGet]
public async Task<ActionResult<List<ProduitDto>>> GetProduits()
{
    var produits = await _service.ObtenirTousProduits();
    return Ok(produits);
}
```

---

## 3. Le Frontend (MonFrontend) - L'interface utilisateur

### Rôle du frontend
- **Affiche l'interface** : boutons, formulaires, images, textes
- **Gère les interactions** : clics, saisies, navigation
- **Communique avec le backend** : envoie des requêtes HTTP pour récupérer ou envoyer des données
- **Améliore l'expérience utilisateur** : animations, feedbacks visuels, responsive design

### Technologie utilisée
- **React** : bibliothèque JavaScript pour créer des interfaces
- **TypeScript** : JavaScript avec des types pour éviter les erreurs
- **Vite** : outil de build et de développement rapide

### Exemple de structure
```
MonFrontend/
├── src/
│   ├── components/   # Composants réutilisables
│   ├── pages/        # Pages de l'application
│   ├── services/     # Appels API
│   ├── App.tsx       # Composant principal
│   └── main.tsx      # Point d'entrée
├── public/           # Fichiers statiques
└── package.json      # Dépendances
```

### Ce que fait le frontend concrètement
```tsx
// Exemple : Afficher une liste de produits
function ListeProduits() {
  const [produits, setProduits] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5000/api/produits')
      .then(res => res.json())
      .then(data => setProduits(data));
  }, []);

  return (
    <ul>
      {produits.map(p => <li key={p.id}>{p.nom}</li>)}
    </ul>
  );
}
```

---

## 4. Communication entre Frontend et Backend

### Le cycle complet d'une requête

```
1. Utilisateur clique sur un bouton dans le Frontend
   ↓
2. Le Frontend envoie une requête HTTP au Backend
   GET http://localhost:5000/api/produits
   ↓
3. Le Backend (Contrôleur) reçoit la requête
   ↓
4. Le Service applique la logique métier
   ↓
5. Le Repository récupère les données de la base
   ↓
6. Le Backend renvoie la réponse (JSON)
   ↓
7. Le Frontend reçoit les données et les affiche
```

### Exemple concret

**Frontend envoie :**
```http
GET http://localhost:5000/api/produits
```

**Backend répond :**
```json
[
  { "id": 1, "nom": "Chaise", "prix": 49.99 },
  { "id": 2, "nom": "Table", "prix": 199.99 }
]
```

**Frontend affiche :**
```
- Chaise : 49.99€
- Table : 199.99€
```

---

## 5. Les ports de développement

Par défaut, chaque partie tourne sur un port différent :

| Application | Port par défaut | URL |
|-------------|-----------------|-----|
| Backend (API) | 5000 ou 5001 | http://localhost:5000 |
| Frontend (React) | 3000 | http://localhost:3000 |

**Important** : Le frontend doit connaître l'adresse du backend pour communiquer avec lui.

---

## 6. Avantages de cette séparation

### 🎯 Séparation des responsabilités
- Le frontend s'occupe uniquement de l'affichage
- Le backend s'occupe uniquement de la logique et des données
- Chaque équipe peut travailler indépendamment

### 🔄 Réutilisabilité
- Le même backend peut servir plusieurs frontends (web, mobile, desktop)
- Le même frontend peut communiquer avec plusieurs backends

### 🚀 Scalabilité
- On peut déployer frontend et backend séparément
- On peut multiplier les instances selon les besoins

### 🛠️ Technologies adaptées
- Utiliser les meilleurs outils pour chaque partie
- Faciliter la maintenance et les évolutions

---

## 7. Workflow de développement

### Démarrer le backend
```bash
cd MonApi
dotnet run
# API accessible sur http://localhost:5000
```

### Démarrer le frontend
```bash
cd MonFrontend
npm start
# Application accessible sur http://localhost:3000
```

### Développer en parallèle
- Ouvrir deux terminaux (un pour chaque partie)
- Les deux applications tournent en même temps
- Le frontend communique avec le backend en temps réel

---

## 8. Termes clés

| Terme | Définition | Exemple |
|-------|------------|---------|
| **Backend** | Partie serveur qui gère la logique et les données | MonApi (.NET) |
| **Frontend** | Partie client qui affiche l'interface | MonFrontend (React) |
| **API** | Interface qui permet au frontend de communiquer avec le backend | Endpoints HTTP |
| **Endpoint** | Une URL spécifique de l'API | `/api/produits` |
| **HTTP** | Protocole de communication | GET, POST, PUT, DELETE |
| **JSON** | Format d'échange de données | `{"nom": "Chaise"}` |
| **Port** | Numéro identifiant une application sur la machine | 5000, 3000 |

---

## Points à retenir

- Une application moderne = Backend + Frontend
- **Backend (MonApi)** : gère les données, la logique, expose une API
- **Frontend (MonFrontend)** : affiche l'interface, gère les interactions
- Communication via **HTTP** avec des requêtes/réponses **JSON**
- Chaque partie a son propre dossier et tourne sur son propre port
- La séparation facilite le travail en équipe et la maintenance

## Conseils pratiques

- Toujours bien séparer le code backend et frontend
- Ne jamais mélanger la logique métier dans le frontend
- Utiliser les dossiers pour organiser chaque partie
- Documenter les endpoints de l'API
- Tester chaque partie séparément avant de les connecter
- Utiliser des variables d'environnement pour les URLs
