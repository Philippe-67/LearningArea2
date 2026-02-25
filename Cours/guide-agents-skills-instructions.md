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
