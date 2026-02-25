# COURS GÉNÉRAL - TOUS LES COURS COMPILÉS

**Compilation complète de tous les cours dans l'ordre chronologique**

## 📚 Table des Matières Complète

1. **Créer une application .NET et React TypeScript**
2. **Structure de base d'une application**
3. **Structure et utilité des éléments du backend MonApi**
4. **Structure du dossier frontend MonFrontend**
5. **Cours : Mettre en place le versionning avec Git et GitHub**
6. **Guide complet : Agents, Skills et Instructions**

---

## ⏰ Cours 1/6 - Créer une application .NET et React TypeScript
**Créé le 20/02/2026**


# CrÃ©er une application .NET et React TypeScript avec Visual Studio Code

## Objectif
Comprendre les Ã©tapes pour crÃ©er une application web moderne composÃ©e dâ€™un backend .NET (API) et dâ€™un frontend React avec TypeScript, en utilisant Visual Studio Code.
Ce cours intÃ¨gre des dÃ©finitions et exemples pour chaque notion technique abordÃ©e.


## DÃ©finitions des notions clÃ©s

- **Backend**â€¯: Partie Â«â€¯cachÃ©eâ€¯Â» de lâ€™application, qui gÃ¨re les donnÃ©es, les calculs, la logique. Câ€™est le cerveau de lâ€™application.
- **API** (Application Programming Interface)â€¯: Â«â€¯Porte dâ€™entrÃ©eâ€¯Â» du backend, qui permet Ã  dâ€™autres programmes (comme le frontend) de demander ou dâ€™envoyer des informations. Lâ€™API fait partie du backend.
- **Serveur**â€¯: Ordinateur (ou programme) qui fait tourner le backend et lâ€™API. Il attend des demandes et y rÃ©pond. Exempleâ€¯: comme un serveur de restaurant qui prend les commandes et apporte les plats.
- **Frontend**â€¯: Partie visible de lâ€™application, celle avec laquelle lâ€™utilisateur interagit (boutons, textes, imagesâ€¦).
- **Terminal**â€¯: Outil (fenÃªtre noire) pour donner des instructions Ã  lâ€™ordinateur en tapant des commandes.

**DiffÃ©rence entre backend, API et serveur**â€¯:
- Le serveur est la machine (lâ€™ordinateur).
- Le backend est le programme qui tourne sur le serveur.
- Lâ€™API est la partie du backend qui communique avec lâ€™extÃ©rieur.

**Exemple dâ€™analogie**â€¯:
Dans un restaurantâ€¯:
- Le serveur (personne) prend la commande du client (frontend) et la transmet Ã  la cuisine (backend).
- La cuisine prÃ©pare le plat (donnÃ©es/rÃ©ponse) et le serveur lâ€™apporte au client.
- Lâ€™API, câ€™est le comptoir oÃ¹ le serveur vient chercher les plats.

---

## Ã‰tapes Ã  suivre

### 1. Installer les outils nÃ©cessaires
- **Visual Studio Code** (Ã©diteur de code)
- **.NET SDK** (pour crÃ©er lâ€™API)
- **Node.js et npm** (pour React)


### 2. CrÃ©er le backend .NET (API)
1. Ouvre un terminal (dans VS Code ou Windows).
2. Place-toi dans le dossier oÃ¹ tu veux crÃ©er ton projet (par exemple, Apprentissage).
3. Tape la commande suivanteâ€¯:
   ```bash
   dotnet new webapi -n MonApi
   ```
   â†’ Cela crÃ©e un dossier MonApi avec une API prÃªte Ã  lâ€™emploi.
4. Pour tester lâ€™APIâ€¯:
   ```bash
   cd MonApi
   dotnet run
   ```
   â†’ Lâ€™API sera accessible sur http://localhost:5000 ou http://localhost:5001.

**Ã€ retenir**â€¯: Le backend, câ€™est toi qui le dÃ©veloppesâ€¯! Tu Ã©cris le code qui gÃ¨re les donnÃ©es et les rÃ¨gles de lâ€™application. Lâ€™API est la partie de ce code qui permet Ã  dâ€™autres programmes (comme le frontend) de communiquer avec ton backend.


### 3. CrÃ©er le frontend React TypeScript
1. Reviens Ã  la racine de ton projet (dossier Apprentissage).
2. Tape la commande suivante dans le terminalâ€¯:
   ```bash
   npx create-react-app MonFrontend --template typescript
   ```
   â†’ Cela crÃ©e un dossier MonFrontend avec une application React prÃªte Ã  lâ€™emploi.
3. Pour lancer le frontendâ€¯:
   ```bash
   cd MonFrontend
   npm start
   ```
   â†’ Lâ€™application sâ€™ouvre dans ton navigateur Ã  lâ€™adresse http://localhost:3000.


### 4. Ouvrir le projet dans Visual Studio Code
- Ouvre le dossier racine (Apprentissage) dans VS Code.
- Tu verras les deux dossiersâ€¯: MonApi (backend/API) et MonFrontend (frontend).
- Tu peux ainsi travailler sur les deux parties dans le mÃªme espace de travail.


### 5. DÃ©velopper et connecter les deux parties
- DÃ©veloppe lâ€™API dans MonApi (backend).
- DÃ©veloppe lâ€™interface utilisateur dans MonFrontend (frontend).
- Pour que le frontend communique avec lâ€™API, il faut utiliser lâ€™adresse de lâ€™API (par exemple, http://localhost:5000) dans le code React, avec des outils comme fetch ou axios.


## Points Ã  retenir
- Un projet moderne sÃ©pare le backend (API) et le frontend (interface).
- Le backend, lâ€™API et le serveur sont liÃ©s mais diffÃ©rentsâ€¯: le backend est le programme, lâ€™API est la porte dâ€™entrÃ©e, le serveur est la machine.
- Chaque partie a ses propres outils et commandes.
- Visual Studio Code permet de tout gÃ©rer dans un mÃªme espace de travail.


## Conseils pratiques
- Tester chaque partie sÃ©parÃ©ment avant de les connecter.
- Lire les messages dâ€™erreurâ€¯: ils donnent souvent la solution.
- Utiliser le terminal intÃ©grÃ© de VS Code pour exÃ©cuter les commandes.
- Nâ€™hÃ©site pas Ã  demander la dÃ©finition dâ€™un terme ou une explication Ã  chaque Ã©tape.




---

## ⏰ Cours 2/6 - Structure de base d'une application
**Créé le 20/02/2026**

# Structure de base dâ€™une application

## Objectif
Comprendre comment une application moderne est organisÃ©e en deux parties principalesâ€¯: le backend (MonApi) et le frontend (MonFrontend).

## Explications dÃ©taillÃ©es

- **Projet**â€¯: Un ensemble de fichiers et de dossiers qui servent Ã  dÃ©velopper une partie dâ€™une application.
- **MonApi**â€¯:
  - Projet backend (arriÃ¨re-plan)
  - GÃ¨re la logique, les donnÃ©es, les Ã©changes avec la base de donnÃ©es
  - AppelÃ© aussi Â«â€¯APIâ€¯Â»
- **MonFrontend**â€¯:
  - Projet frontend (interface utilisateur)
  - Affiche ce que voit lâ€™utilisateur, gÃ¨re les interactions (boutons, formulairesâ€¦)
  - RÃ©alisÃ© ici avec React

## Points Ã  retenir

- Une application moderne est souvent divisÃ©e en deux projetsâ€¯: backend (API) et frontend (interface).
- Chaque projet a son propre dossier et ses propres fichiers.
- Le backend sâ€™occupe des donnÃ©es et de la logiqueâ€¯; le frontend sâ€™occupe de lâ€™affichage et des interactions.

## Conseils pratiques

- Toujours bien sÃ©parer le code backend et frontend pour une meilleure organisation.
- Utiliser les dossiers pour ranger les fichiers selon leur rÃ´le.


---

## ⏰ Cours 3/6 - Structure et utilité des éléments du backend MonApi
**Créé le 20/02/2026**

# Structure et utilitÃ© des Ã©lÃ©ments du backend MonApi

## Objectif
Comprendre le rÃ´le de chaque dossier et fichier du projet backend MonApi, et apprendre Ã  tester lâ€™API avec MonApi.http.

## Explications dÃ©taillÃ©es

- **bin** : Dossier oÃ¹ sont stockÃ©s les fichiers compilÃ©s (exÃ©cutables, DLL). GÃ©rÃ© automatiquement.
- **obj** : Dossier temporaire pour la compilation. GÃ©rÃ© automatiquement.
- **Properties** : Contient les paramÃ¨tres de lancement du projet (ex : launchSettings.json).
- **appsettings.Development.json** : Fichier de configuration spÃ©cifique Ã  lâ€™environnement de dÃ©veloppement.
- **appsettings.json** : Fichier de configuration principal de lâ€™application.
- **MonApi.csproj** : Fichier de projet .NET, dÃ©crit les dÃ©pendances et options de compilation.
- **MonApi.http** : Fichier pour tester lâ€™API avec des requÃªtes HTTP.
- **Program.cs** : Fichier principal du code source, point dâ€™entrÃ©e de lâ€™application.

## Utilisation de MonApi.http pour tester lâ€™API

### Exemple de requÃªte GET
GET http://localhost:5000/weatherforecast
Accept: application/json

- Clique sur Â«â€¯Send Requestâ€¯Â» dans VS Code pour obtenir la rÃ©ponse.

### Exemple de requÃªte POST
POST http://localhost:5000/api/users
Content-Type: application/json

{
  "name": "Alice",
  "email": "alice@example.com"
}

- Clique sur Â«â€¯Send Requestâ€¯Â» pour envoyer des donnÃ©es Ã  lâ€™API.

### Explication sur la rÃ©ponse
- La rÃ©ponse sâ€™affiche dans VS Codeâ€¯: code HTTP, donnÃ©es renvoyÃ©es ou message dâ€™erreur.
- Permet de vÃ©rifier le bon fonctionnement de lâ€™API directement dans lâ€™Ã©diteur.

## Points Ã  retenir
- Chaque dossier/fichier a un rÃ´le prÃ©cisâ€¯: organisation, configuration, code, tests.
- MonApi.http permet de tester facilement lâ€™API sans outil externe.

## Conseils pratiques
- Ne pas modifier bin et obj.
- Utiliser MonApi.http pour tester tous les endpoints de lâ€™API.
- Lire les rÃ©ponses pour comprendre le fonctionnement ou dÃ©tecter les erreurs.


---

## ⏰ Cours 4/6 - Structure du dossier frontend MonFrontend
**Créé le 20/02/2026**

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

## ⏰ Cours 5/6 - Mettre en place le versionning avec Git et GitHub
**Créé le 20/02/2026 - Mis à jour le 23/02/2026**

# Cours : Mettre en place le versionning avec Git et GitHub

## Introduction
Git est un outil indispensable pour suivre l’évolution d’un projet informatique. Il permet de sauvegarder chaque étape, de revenir en arrière en cas d’erreur, de collaborer à plusieurs et de garder une trace de tout ce qui a été modifié. Le suivi des versions évite de perdre du travail, facilite la correction des bugs et permet de travailler sereinement, même en équipe.

## Objectif
Apprendre à gérer les versions de son application, ignorer les fichiers inutiles, et connecter le projet à un dépôt distant sur GitHub.

## Explications détaillées

### 1. Initialiser Git
- Ouvre un terminal dans le dossier racine du projet.
- Tape :
  git init
- Cela crée un dossier .git pour suivre les modifications.

### 2. Créer un fichier .gitignore
- Ce fichier indique à Git quels fichiers/dossiers ne pas suivre.
- Pour le créer automatiquement, tape :
  echo node_modules/
 bin/
 obj/
 *.log
 *.tmp > .gitignore
- Exemple de contenu :

node_modules/
bin/
obj/
*.log
*.tmp

### 3. Enregistrer les changements
- Pour enregistrer une modification :
  git add .
  git commit -m "Premier commit"

### 4. Créer un dépôt sur GitHub
- Va sur github.com et crée un nouveau repository (dépôt).
- Copie l’URL du dépôt (ex : https://github.com/mon-compte/mon-repo.git)

### 5. Lier le projet à GitHub
- Dans le terminal, tape :
  git remote add origin https://github.com/mon-compte/mon-repo.git
  git branch -M main
  git push -u origin main

### 6. Synchroniser avec git pull

#### Pourquoi faire des git pull régulièrement ?

Faire `git pull origin main` régulièrement est **important** pour plusieurs raisons :

**1. Éviter les gros conflits**
- Si tu travailles seul ou en équipe, d'autres modifications peuvent arriver sur GitHub
- Plus tu attends avant de récupérer ces changements, plus les conflits risquent d'être complexes
- C'est comme synchroniser ton téléphone avec le cloud : si tu le fais régulièrement, ça prend 2 secondes

**2. Travailler sur la version la plus récente**
- Tu évites de perdre du temps à coder quelque chose qui a déjà été fait ou modifié
- Tu bénéficies des corrections et améliorations des autres

**3. Détecter rapidement les problèmes**
- Mieux vaut découvrir un conflit après 1 heure de travail qu'après 3 jours !

#### Quand faire git pull origin main ?

**TOUJOURS faire un pull dans ces situations :**

✅ **Au début de chaque session de travail** (dès que tu ouvres VS Code)
  git status
  git pull origin main
  git log --oneline -5

✅ **Avant de créer une nouvelle branche**
  git pull origin main
  git checkout -b ma-nouvelle-feature

✅ **Avant de faire un push** (surtout si tu travailles en équipe)
  git pull origin main
  git push origin main

✅ **Après une longue absence** (plusieurs heures/jours sans coder)

**PAS besoin de pull toutes les 5 minutes si :**
- ❌ Tu travailles seul sur le projet
- ❌ Personne d'autre ne push sur main
- ❌ Tu viens juste de faire un pull il y a 10 minutes

#### Risques de ne pas faire de pull régulièrement

Si tu ne fais pas de pull pendant longtemps et que tu essaies de push :
  git push origin main
  # ❌ Erreur : ! [rejected] main -> main (fetch first)

Git te bloque car il y a des modifications sur GitHub que tu n'as pas. Tu dois alors :
  git pull origin main
  # ⚠️ Conflit possible ! Tu dois alors résoudre manuellement

Plus tu attends, plus c'est compliqué à résoudre.

#### Fréquence recommandée selon la situation

| Situation | Fréquence du pull |
|-----------|------------------|
| **Tu travailles seul** | 1x par session (au début) |
| **Tu travailles en équipe** | Début de session + avant chaque push |
| **Projet très actif (plusieurs devs)** | Toutes les heures ou avant chaque push |
| **Tu reviens après plusieurs jours** | IMMÉDIATEMENT avant de coder |

### 7. Points à retenir
- Git garde l'historique des modifications.
- .gitignore évite d'enregistrer des fichiers inutiles.
- GitHub permet de sauvegarder et partager le projet.
- `git pull` au début de chaque session évite les conflits.
- Plus tu synchronises souvent, moins tu as de problèmes.

### 8. Workflow quotidien recommandé

**🌅 Début de session (le matin ou quand tu commences) :**
  git status                    # Vérifier l'état local
  git pull origin main          # Récupérer les nouveautés
  git log --oneline -5          # Voir les derniers commits

**💻 Pendant le travail (toutes les 30 min - 1h) :**
  # ... tu codes ...
  git add .
  git commit -m "feat: ajoute X"

**🔄 Push régulièrement (après quelques commits) :**
  git pull origin main          # Au cas où (surtout en équipe)
  git push origin main          # Envoyer ton travail

**🌙 Fin de session :**
  git status                    # Rien ne doit être en attente
  git push origin main          # Tout est sauvegardé

### 9. Conseils pratiques
- Faire des commits réguliers avec des messages clairs (toutes les 30 minutes).
- Ne jamais ajouter node_modules, bin, obj.
- Utiliser GitHub pour collaborer ou sauvegarder à distance.
- Faire un `git pull` au début de chaque session.
- Committer souvent = ne jamais perdre son travail.


---

## ⏰ Cours 6/6 - Guide complet : Agents, Skills et Instructions
**Créé le 23/02/2026**

# Guide complet : Agents, Skills et Instructions

## Introduction

Dans l'environnement de développement VS Code, tu peux créer trois types de fichiers pour améliorer ton workflow :
- **Agents** (.agent.md) : Assistants spécialisés que tu actives manuellement
- **Skills** (.skill.md) : Compétences automatiques sur certains fichiers
- **Instructions** (.instruction.md) : Règles automatiques dans certains contextes

Ces fichiers t'aident à structurer ton travail, à ne pas oublier les bonnes pratiques et à gagner du temps.

**Analogie simple** : 
- Un **agent** = un professeur que tu appelles quand tu as besoin
- Une **skill** = un pense-bête qui s'affiche automatiquement quand tu ouvres certains cahiers
- Une **instruction** = des règles affichées sur le mur de certaines salles de classe

---

## Structure commune : Le Front Matter

**Tous ces fichiers commencent par un bloc YAML** entre trois tirets :

```yaml
---
description: 'Une phrase décrivant le fichier'
propriété: 'valeur'
---
```

### Règles importantes du Front Matter

1. ✅ **Toujours en PREMIER** dans le fichier (ligne 1)
2. ✅ Commence et finit par ---
3. ✅ La description est **obligatoire** pour tous
4. ✅ Utilise des **guillemets simples** : 'texte'
5. ✅ Une description **claire et concise** (1 phrase)

**Exemple correct** :
```yaml
---
description: 'Agent pour guider les débutants en Git'
tools: ['edit/editFiles']
---
```

**Exemple incorrect** :
```yaml
# Mon Agent

---
description: Agent Git
---
```
❌ Le front matter n'est pas au début
❌ Pas de guillemets
❌ Description trop courte

---

## Les Agents (.agent.md)

### Définition

Un **agent** est un assistant spécialisé avec une personnalité et un contexte spécifique. Tu l'actives **manuellement** quand tu en as besoin.

**Exemples** : Agent formateur, Agent Git, Agent de debug, Agent pour tests

### Structure complète

```yaml
---
description: 'Description claire de l'agent en une phrase'
tools: ['outil1', 'outil2', 'outil3']
---

# Nom de l'Agent – Sous-titre

Introduction courte (1-2 phrases).

## Mission principale
Ce que fait l'agent concrètement.

## Fonctionnement
Étapes détaillées...

## Exemples de prompts
1. « Exemple 1 »
2. « Exemple 2 »

## Bonnes pratiques
- Conseil 1
- Conseil 2
```

### Propriétés du Front Matter

| Propriété | Obligatoire ? | Rôle |
|-----------|--------------|------|
| description | ✅ OUI | Résumé en une phrase |
| 	ools | 🟡 Recommandé | Liste des outils utilisables |
| pply_to | ❌ NON | Les agents ne s'appliquent pas automatiquement |

### Liste des outils courants

```yaml
tools: [
  'edit/editFiles',           # Modifier des fichiers
  'search/codebase',          # Chercher dans le code
  'search',                   # Recherche générale
  'execute/runInTerminal',    # Exécuter des commandes
  'execute/getTerminalOutput',# Lire la sortie du terminal
  'read/problems',            # Lire les erreurs
  'read/terminalSelection',   # Lire la sélection terminal
  'search/changes',           # Voir les changements Git
  'search/usages',            # Voir les utilisations de code
  'web/fetch',                # Chercher sur le web
  'markdown'                  # Travailler avec markdown
]
```

### Quand utiliser un Agent ?

✅ **Utilise un agent quand :**
- Tu veux un assistant spécialisé que tu actives manuellement
- Tu as besoin d'un workflow complexe avec plusieurs étapes
- Tu veux un accompagnement pédagogique ou méthodologique
- Tu as besoin d'un contexte spécifique (débutant, expert, etc.)

**Exemples concrets** :
- **Agent Formateur** : Pour créer des cours et expliquer des notions
- **Agent Git** : Pour guider dans les commandes Git
- **Agent Debug** : Pour t'aider à résoudre des bugs
- **Agent Refactoring** : Pour améliorer la qualité du code

### Exemple complet d'Agent

```markdown
---
description: 'Agent Git pour développeurs débutants : accompagnement pas-à-pas, rappels de commit, workflow GitHub'
tools: ['edit/editFiles', 'execute/runInTerminal', 'search/changes']
---

# Agent Git – Accompagnement pour Développeurs Débutants

Cet agent est un mentor Git qui t'accompagne dans l'apprentissage du versionning. Il détecte quand tu oublies de committer, te guide étape par étape, et t'aide à développer de bonnes habitudes Git/GitHub.

## Mission principale

Aider les développeurs débutants à ne jamais perdre leur travail en développant des réflexes Git solides.

## Workflow recommandé

### Au début de chaque session
\\\ash
git status
git pull origin main
\\\

### Pendant le développement (toutes les 30 minutes)
\\\ash
git add .
git commit -m "feat: description"
git push origin main
\\\

## Exemples de prompts

1. « Aide-moi à committer mes changements »
2. « Je ne comprends pas ce conflit Git »
3. « Comment créer une nouvelle branche ? »

## Bonnes pratiques
- Committer toutes les 30 minutes
- Messages de commit clairs
- Toujours pull avant push
```

---

## Les Skills (.skill.md)

### Définition

Une **skill** est une compétence qui s'active **automatiquement** quand tu travailles sur certains types de fichiers. Elle rappelle les bonnes pratiques et conventions.

**Exemples** : Skill React, Skill TypeScript, Skill SQL, Skill CSS

### Structure complète

```yaml
---
description: 'Compétence pour X'
apply_to:
  - '**/*.extension'
  - '**/dossier/**'
---

# Nom de la Skill

Description de la compétence.

## Rappels automatiques
- Bonne pratique 1
- Bonne pratique 2

## Exemples
Code exemples...
```

### Propriétés du Front Matter

| Propriété | Obligatoire ? | Rôle |
|-----------|--------------|------|
| description | ✅ OUI | Résumé en une phrase |
| pply_to | ✅ OUI | Patterns de fichiers où s'applique la skill |
| 	ools | ❌ NON | Les skills n'ont pas d'outils |

### La propriété pply_to

C'est une **liste de patterns de fichiers** (glob patterns) :

```yaml
apply_to:
  - '**/*.tsx'           # Tous les fichiers .tsx
  - '**/*.ts'            # Tous les fichiers .ts
  - '**/components/**'   # Tout dans le dossier components
  - 'src/**/*.js'        # Fichiers .js dans src/
```

**Patterns courants** :
- **/*.ext = tous les fichiers avec extension .ext
- **/dossier/** = tous les fichiers dans un dossier
- *.ext = fichiers .ext à la racine seulement
- src/** = tout dans le dossier src

### Quand utiliser une Skill ?

✅ **Utilise une skill quand :**
- Tu veux des rappels automatiques sur certains types de fichiers
- Tu as des conventions spécifiques à un langage ou framework
- Tu veux que les bonnes pratiques s'affichent sans y penser
- Tu travailles avec plusieurs technologies différentes

**Exemples concrets** :
- **Skill React** : Rappelle les règles des Hooks quand tu codes en .tsx
- **Skill SQL** : Rappelle la sécurité (SQL injection) quand tu écris des requêtes
- **Skill CSS** : Rappelle les conventions de nommage BEM
- **Skill TypeScript** : Rappelle d'éviter ny et de typer correctement

### Exemple complet de Skill

```markdown
---
description: 'Compétence React avec TypeScript pour rappeler les bonnes pratiques et conventions'
apply_to:
  - '**/*.tsx'
  - '**/*.ts'
  - '**/src/components/**'
---

# Skill React + TypeScript

Cette compétence s'active automatiquement quand tu travailles sur des fichiers React TypeScript.

## Rappels automatiques

### Règles des Hooks
- ✅ Toujours appeler les Hooks au niveau supérieur
- ❌ Jamais dans des conditions, boucles ou fonctions imbriquées
- ✅ Utiliser \useEffect\ avec array de dépendances

### Typage TypeScript
- ✅ Toujours typer les props des composants
- ❌ Éviter \ny\, préférer \unknown\
- ✅ Utiliser des interfaces pour les props

### Conventions de nommage
- Composants : \PascalCase\ (ex: \MonComposant.tsx\)
- Hooks personnalisés : \useNomDuHook\
- Constantes : \UPPER_SNAKE_CASE\

## Exemple de composant typé

\\\	sx
interface ButtonProps {
  label: string;
  onClick: () => void;
  disabled?: boolean;
}

export const Button: React.FC<ButtonProps> = ({ 
  label, 
  onClick, 
  disabled = false 
}) => {
  return (
    <button onClick={onClick} disabled={disabled}>
      {label}
    </button>
  );
};
\\\
```

---

## Les Instructions (.instruction.md)

### Définition

Une **instruction** est un ensemble de règles qui s'appliquent **automatiquement** dans certains contextes (dossiers, projets). Elles définissent des contraintes architecturales ou des conventions.

**Exemples** : Instructions backend, Instructions tests, Instructions API

### Structure complète

```yaml
---
description: 'Instructions pour X'
apply_to:
  - '**/dossier/**'
  - '**/src/**'
---

# Instructions pour X

Description des règles à suivre.

## Règles obligatoires
- Règle 1
- Règle 2

## Architecture
Structure à respecter...
```

### Propriétés du Front Matter

| Propriété | Obligatoire ? | Rôle |
|-----------|--------------|------|
| description | ✅ OUI | Résumé en une phrase |
| pply_to | ✅ OUI | Contextes où s'appliquent les instructions |
| 	ools | ❌ NON | Les instructions n'ont pas d'outils |

### La propriété pply_to pour Instructions

Cible généralement des **dossiers entiers** ou des **contextes larges** :

```yaml
apply_to:
  - '**/MonApi/**'           # Tout le backend
  - '**/Controllers/**'      # Dossier Controllers
  - '**/tests/**'            # Dossier de tests
  - '**/src/backend/**'      # Backend dans src
```

### Quand utiliser des Instructions ?

✅ **Utilise des instructions quand :**
- Tu veux définir des règles globales pour un dossier entier
- Tu as des conventions d'équipe ou d'architecture à respecter
- Tu veux des contraintes sur la structure du projet
- Tu veux rappeler des règles de sécurité ou de performance

**Exemples concrets** :
- **Instructions Backend** : Toujours valider les entrées, utiliser le pattern Repository
- **Instructions Tests** : Toujours mocker les appels API, nommer les tests en français
- **Instructions Frontend** : Toujours utiliser des imports absolus, respecter l'atomic design
- **Instructions API** : Toujours documenter les endpoints, gérer les erreurs

### Exemple complet d'Instructions

```markdown
---
description: 'Instructions pour le développement backend avec ASP.NET Core'
apply_to:
  - '**/MonApi/**/*.cs'
  - '**/Controllers/**'
  - '**/Services/**'
---

# Instructions Backend – API ASP.NET Core

Ces règles s'appliquent automatiquement quand tu travailles sur le backend.

## Architecture obligatoire

### Pattern Repository
- Séparer la logique métier (Services) de l'accès aux données (Repositories)
- Un service par domaine métier
- Un repository par entité

### Structure des dossiers
\\\
MonApi/
├── Controllers/    # Endpoints API
├── Services/       # Logique métier
├── Repositories/   # Accès données
├── Models/         # Entités
└── DTOs/          # Data Transfer Objects
\\\

## Règles de sécurité

### Validation des entrées
- ✅ TOUJOURS valider les données utilisateur
- ✅ Utiliser les Data Annotations : \[Required]\, \[MaxLength]\
- ❌ JAMAIS faire confiance aux données entrantes

### Gestion des erreurs
- ✅ Toujours utiliser try-catch dans les controllers
- ✅ Retourner des codes HTTP appropriés (200, 400, 404, 500)
- ✅ Logger les erreurs avec ILogger

## Conventions de code

### Nommage
- Controllers : \NomController.cs\
- Services : \INomService.cs\ (interface) et \NomService.cs\
- Méthodes async : suffixe \Async\ (ex: \GetUsersAsync\)

### Exemple de Controller
\\\csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la récupération des utilisateurs");
            return StatusCode(500, "Erreur serveur");
        }
    }
}
\\\

## Points à retenir
- Architecture en couches obligatoire
- Toujours valider et gérer les erreurs
- Respecter les conventions de nommage
```

---

## Tableau comparatif complet

| Critère | Agent | Skill | Instruction |
|---------|-------|-------|-------------|
| **Fichier** | .agent.md | .skill.md | .instruction.md |
| **Activation** | Manuelle | Automatique | Automatique |
| **Portée** | Tout le projet | Fichiers spécifiques | Dossiers/contextes |
| **description** | ✅ Obligatoire | ✅ Obligatoire | ✅ Obligatoire |
| **	ools** | ✅ Oui | ❌ Non | ❌ Non |
| **pply_to** | ❌ Non | ✅ Obligatoire | ✅ Obligatoire |
| **Usage** | Assistant spécialisé | Rappels automatiques | Règles contextuelles |
| **Exemple** | Agent Git | Skill React | Instructions Backend |

### Activation : Manuelle vs Automatique

**Manuelle (Agent)** :
- Tu choisis quand l'activer
- Tu lui parles explicitement : "Agent Git, aide-moi"
- Il ne s'active pas tout seul

**Automatique (Skill et Instruction)** :
- S'active dès que tu ouvres le bon fichier/dossier
- Tu n'as rien à faire
- Rappels permanents pendant que tu codes

### Propriétés requises

```yaml
# AGENT
---
description: 'Description'  # ✅ Obligatoire
tools: ['liste']            # 🟡 Recommandé
---

# SKILL
---
description: 'Description'  # ✅ Obligatoire
apply_to: ['patterns']      # ✅ Obligatoire
---

# INSTRUCTION
---
description: 'Description'  # ✅ Obligatoire
apply_to: ['patterns']      # ✅ Obligatoire
---
```

---

## Erreurs courantes à éviter

### ❌ Erreur 1 : Front Matter mal placé

**Mauvais** :
```markdown
# Mon Agent

---
description: 'Agent'
---
```

**Bon** :
```markdown
---
description: 'Agent'
---

# Mon Agent
```

### ❌ Erreur 2 : Guillemets manquants

**Mauvais** :
```yaml
---
description: Agent Git
---
```

**Bon** :
```yaml
---
description: 'Agent Git pour débutants'
---
```

### ❌ Erreur 3 : Confusion Agent / Skill

**Mauvais** (agent avec apply_to) :
```yaml
---
description: 'Agent React'
tools: ['edit/editFiles']
apply_to: ['**/*.tsx']      # ❌ Un agent n'a pas apply_to !
---
```

**Bon** (skill sans tools) :
```yaml
---
description: 'Skill React'
apply_to: ['**/*.tsx']       # ✅ Une skill a apply_to
---
```

### ❌ Erreur 4 : Description trop vague

**Mauvais** :
- description: 'Agent utile'
- description: 'Pour le code'
- description: 'Helper'

**Bon** :
- description: 'Agent Git pour accompagner les débutants dans le versionning'
- description: 'Skill React pour rappeler les règles des Hooks'
- description: 'Instructions backend pour l'architecture ASP.NET Core'

### ❌ Erreur 5 : Pattern apply_to incorrect

**Mauvais** :
```yaml
apply_to:
  - '*.tsx'          # ❌ Seulement à la racine
  - 'components'     # ❌ Pas de /**
```

**Bon** :
```yaml
apply_to:
  - '**/*.tsx'               # ✅ Tous les .tsx
  - '**/components/**'       # ✅ Dossier components partout
```

---

## Points à retenir

### Concepts clés

1. **Trois types de fichiers** : Agent (manuel), Skill (auto sur fichiers), Instruction (auto sur contextes)
2. **Front Matter obligatoire** : Toujours en premier, avec description entre guillemets
3. **	ools uniquement pour agents** : Les skills et instructions n'ont pas d'outils
4. **pply_to pour auto-activation** : Obligatoire pour skills et instructions, interdit pour agents
5. **Patterns glob** : **/*.ext pour fichiers, **/dossier/** pour dossiers

### Checklist avant de créer un fichier

#### ✅ Agent (.agent.md)
- [ ] Front matter en ligne 1
- [ ] description claire entre guillemets
- [ ] Liste 	ools adaptée aux besoins
- [ ] PAS de pply_to
- [ ] Contenu pédagogique et structuré

#### ✅ Skill (.skill.md)
- [ ] Front matter en ligne 1
- [ ] description claire entre guillemets
- [ ] pply_to avec patterns de fichiers corrects
- [ ] PAS de 	ools
- [ ] Rappels de bonnes pratiques

#### ✅ Instruction (.instruction.md)
- [ ] Front matter en ligne 1
- [ ] description claire entre guillemets
- [ ] pply_to avec patterns de dossiers/contextes
- [ ] PAS de 	ools
- [ ] Règles et contraintes architecturales

### Quand utiliser quoi ?

| Je veux... | J'utilise... |
|-----------|-------------|
| Un assistant que j'active quand je veux | **Agent** |
| Des rappels sur certains fichiers | **Skill** |
| Des règles dans certains dossiers | **Instruction** |
| Exécuter des commandes | **Agent** (avec 	ools) |
| Rappeler des conventions React | **Skill** sur *.tsx |
| Imposer une architecture backend | **Instruction** sur **/MonApi/** |

### Workflow de création

1. **Identifier le besoin** : Manuel → Agent, Auto → Skill ou Instruction
2. **Choisir le type** : Fichiers spécifiques → Skill, Dossiers → Instruction
3. **Créer le fichier** : .agent.md, .skill.md ou .instruction.md
4. **Structurer le front matter** : description + (	ools ou pply_to)
5. **Rédiger le contenu** : Clair, concis, avec exemples

### Bonnes pratiques générales

- ✅ Description en une phrase claire et complète
- ✅ Exemples concrets dans le contenu
- ✅ Structure markdown cohérente (titres, listes, code)
- ✅ Patterns pply_to précis et testés
- ✅ Outils (	ools) adaptés au besoin de l'agent
- ❌ Pas de front matter dupliqué
- ❌ Pas de confusion entre les trois types
- ❌ Pas de description vague

---

## Conseils pratiques

### Organisation des fichiers

Crée un dossier .github/ à la racine de ton projet :

\\\
MonProjet/
├── .github/
│   ├── agents/
│   │   ├── formateur.agent.md
│   │   ├── git.agent.md
│   │   └── debug.agent.md
│   ├── skills/
│   │   ├── react.skill.md
│   │   ├── typescript.skill.md
│   │   └── css.skill.md
│   └── instructions/
│       ├── backend.instruction.md
│       ├── frontend.instruction.md
│       └── tests.instruction.md
├── src/
└── ...
\\\

### Commencer simple

1. **Premier agent** : Crée un agent simple pour une tâche que tu fais souvent
2. **Première skill** : Crée une skill pour le langage que tu utilises le plus
3. **Première instruction** : Définis les règles de ton dossier principal (src/ ou backend/)

### Itérer et améliorer

- Teste tes fichiers en situation réelle
- Ajuste les patterns pply_to si nécessaire
- Enrichis le contenu au fur et à mesure
- Demande des retours si tu travailles en équipe

### Rester cohérent

- Utilise toujours la même structure
- Garde un niveau de détail similaire
- Documente les spécificités de ton projet
- Mets à jour quand les pratiques évoluent

---

## Récapitulatif final

| Type | Extension | Activation | description | 	ools | pply_to |
|------|-----------|------------|--------------|---------|-----------|
| **Agent** | .agent.md | Manuelle | ✅ | ✅ | ❌ |
| **Skill** | .skill.md | Auto (fichiers) | ✅ | ❌ | ✅ |
| **Instruction** | .instruction.md | Auto (contextes) | ✅ | ❌ | ✅ |

**Règle d'or** : Si tu dois l'activer toi-même → Agent. Si ça s'active tout seul → Skill ou Instruction.

**Tu as maintenant toutes les clés pour créer et utiliser efficacement des agents, skills et instructions !** 🎯


---

## 🎓 Fin du cours général

Ce document reprend l'intégralité de tes apprentissages dans l'ordre chronologique.

**Total : 6 cours + 1 sommaire = 1 fichier complet** 📖
