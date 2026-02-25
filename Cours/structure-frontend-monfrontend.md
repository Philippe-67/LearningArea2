# Structure du dossier frontend MonFrontend

## Objectif
Comprendre le rôle de chaque dossier et fichier principal d’un projet React/TypeScript moderne.

## Explications détaillées

- **public/** : Fichiers accessibles directement par le navigateur (images, favicon, index.html).
- **src/** : Code source de l’application React (App.tsx, main.tsx, assets/…).
- **App.tsx, main.tsx** : Fichiers principaux pour démarrer et afficher l’application.
- **App.css, index.css** : Fichiers de styles pour personnaliser l’apparence.
- **package.json** : Décrit le projet, liste les dépendances et scripts.
- **tsconfig.json, tsconfig.app.json, tsconfig.node.json** : Configurations pour TypeScript.
- **vite.config.ts** : Configuration de l’outil Vite (lancement/optimisation).
- **README.md** : Documentation du projet.
- **node_modules/** : Dossier généré automatiquement, contient toutes les bibliothèques installées (ne jamais modifier à la main).

## Points à retenir
- Ne jamais modifier node_modules à la main.
- Le code source est dans src/.
- Les dépendances sont gérées via package.json et installées dans node_modules/.

## Conseils pratiques
- Utiliser npm install pour régénérer node_modules si besoin.
- Ne pas supprimer ou modifier les fichiers de configuration sans comprendre leur utilité.

---

## Concepts fondamentaux de React

### Qu'est-ce qu'un composant ?

Un **composant** est une brique réutilisable de l'interface. C'est comme un LEGO : tu assembles plusieurs composants pour construire ton application.

**Exemple simple :**
```tsx
// Composant fonctionnel (le plus courant)
function Bouton() {
  return <button>Cliquez-moi</button>;
}

// Utilisation
function App() {
  return (
    <div>
      <Bouton />
      <Bouton />
    </div>
  );
}
```

### Les Props : passer des données aux composants

Les **props** (propriétés) permettent de passer des données d'un composant parent à un composant enfant.

```tsx
// Composant avec props
interface BoutonProps {
  texte: string;
  couleur: string;
}

function Bouton({ texte, couleur }: BoutonProps) {
  return <button style={{ background: couleur }}>{texte}</button>;
}

// Utilisation
function App() {
  return (
    <div>
      <Bouton texte="Valider" couleur="green" />
      <Bouton texte="Annuler" couleur="red" />
    </div>
  );
}
```

**Règle importante** : Les props sont en lecture seule (immutables).

---

## L'état (State) : rendre l'application dynamique

L'**état** permet de stocker des données qui peuvent changer au fil du temps.

```tsx
import { useState } from 'react';

function Compteur() {
  // useState retourne [valeur, fonction pour modifier la valeur]
  const [compteur, setCompteur] = useState(0);

  return (
    <div>
      <p>Compteur : {compteur}</p>
      <button onClick={() => setCompteur(compteur + 1)}>
        Incrémenter
      </button>
    </div>
  );
}
```

**Points clés** :
- `useState` crée une variable d'état
- Quand l'état change, React re-rend le composant automatiquement
- Ne jamais modifier l'état directement : utiliser la fonction setter (`setCompteur`)

---

## Les événements

React gère les événements (clics, saisies, etc.) avec une syntaxe simple.

```tsx
function Formulaire() {
  const [nom, setNom] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault(); // Empêche le rechargement de la page
    alert(`Bonjour ${nom} !`);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input 
        type="text" 
        value={nom} 
        onChange={(e) => setNom(e.target.value)}
        placeholder="Votre nom"
      />
      <button type="submit">Envoyer</button>
    </form>
  );
}
```

**Événements courants** :
- `onClick` : clic sur un élément
- `onChange` : changement dans un input
- `onSubmit` : soumission d'un formulaire
- `onMouseEnter`, `onMouseLeave` : survol de la souris

---

## useEffect : exécuter du code à certains moments

`useEffect` permet d'exécuter du code quand le composant se charge ou quand certaines valeurs changent.

```tsx
import { useState, useEffect } from 'react';

function Utilisateur() {
  const [user, setUser] = useState(null);

  // S'exécute au chargement du composant
  useEffect(() => {
    fetch('https://api.example.com/user')
      .then(res => res.json())
      .then(data => setUser(data));
  }, []); // [] = s'exécute une seule fois au chargement

  if (!user) return <p>Chargement...</p>;

  return <p>Bonjour {user.name}</p>;
}
```

**Cas d'usage** :
- Appels API au chargement
- Abonnements à des événements
- Timers, intervals

---

## Appels API avec fetch

Pour communiquer avec le backend, on utilise `fetch`.

```tsx
import { useState, useEffect } from 'react';

interface Produit {
  id: number;
  nom: string;
  prix: number;
}

function ListeProduits() {
  const [produits, setProduits] = useState<Produit[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetch('http://localhost:5000/api/produits')
      .then(res => {
        if (!res.ok) throw new Error('Erreur réseau');
        return res.json();
      })
      .then(data => {
        setProduits(data);
        setLoading(false);
      })
      .catch(err => {
        setError(err.message);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Chargement...</p>;
  if (error) return <p>Erreur : {error}</p>;

  return (
    <ul>
      {produits.map(produit => (
        <li key={produit.id}>
          {produit.nom} - {produit.prix}€
        </li>
      ))}
    </ul>
  );
}
```

---

## Rendu de listes

Pour afficher une liste d'éléments, on utilise `map()`.

```tsx
const fruits = ['Pomme', 'Banane', 'Orange'];

function ListeFruits() {
  return (
    <ul>
      {fruits.map((fruit, index) => (
        <li key={index}>{fruit}</li>
      ))}
    </ul>
  );
}
```

**⚠️ Important** : Toujours mettre un attribut `key` unique sur chaque élément d'une liste.

---

## Rendu conditionnel

Afficher du contenu selon certaines conditions.

```tsx
function Message({ estConnecte }: { estConnecte: boolean }) {
  if (estConnecte) {
    return <p>Bienvenue !</p>;
  }
  return <p>Veuillez vous connecter</p>;
}

// Ou avec l'opérateur ternaire
function Message2({ estConnecte }: { estConnecte: boolean }) {
  return (
    <p>{estConnecte ? 'Bienvenue !' : 'Veuillez vous connecter'}</p>
  );
}

// Ou avec &&
function Alerte({ afficher }: { afficher: boolean }) {
  return (
    <div>
      {afficher && <p>Attention !</p>}
    </div>
  );
}
```

---

## TypeScript dans React

TypeScript ajoute des types pour éviter les erreurs.

```tsx
// Typer les props
interface BoutonProps {
  texte: string;
  onClick: () => void;
  disabled?: boolean; // ? = optionnel
}

function Bouton({ texte, onClick, disabled = false }: BoutonProps) {
  return (
    <button onClick={onClick} disabled={disabled}>
      {texte}
    </button>
  );
}

// Typer l'état
const [count, setCount] = useState<number>(0);
const [user, setUser] = useState<User | null>(null);
const [items, setItems] = useState<string[]>([]);
```

---

## Organisation des composants

**Structure recommandée :**
```
src/
├── components/           # Composants réutilisables
│   ├── Bouton.tsx
│   ├── Navbar.tsx
│   └── Card.tsx
├── pages/               # Pages de l'application
│   ├── Home.tsx
│   ├── About.tsx
│   └── Contact.tsx
├── services/            # Appels API
│   └── api.ts
├── types/               # Types TypeScript
│   └── index.ts
├── App.tsx
└── main.tsx
```

---

## Points à retenir (complément)
- Un composant = une brique réutilisable de l'interface
- Props = données passées d'un parent à un enfant (lecture seule)
- State = données qui peuvent changer (avec `useState`)
- `useEffect` = exécuter du code au chargement ou sur changement
- `map()` = afficher des listes avec `key`
- TypeScript = ajouter des types pour éviter les erreurs
- Créer des composants petits et réutilisables
- Séparer la logique (appels API) des composants d'affichage
