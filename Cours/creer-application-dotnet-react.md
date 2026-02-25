
# Créer une application .NET et React TypeScript avec Visual Studio Code

## Objectif
Comprendre les étapes pour créer une application web moderne composée d’un backend .NET (API) et d’un frontend React avec TypeScript, en utilisant Visual Studio Code.
Ce cours intègre des définitions et exemples pour chaque notion technique abordée.


## Définitions des notions clés

- **Backend** : Partie « cachée » de l’application, qui gère les données, les calculs, la logique. C’est le cerveau de l’application.
- **API** (Application Programming Interface) : « Porte d’entrée » du backend, qui permet à d’autres programmes (comme le frontend) de demander ou d’envoyer des informations. L’API fait partie du backend.
- **Serveur** : Ordinateur (ou programme) qui fait tourner le backend et l’API. Il attend des demandes et y répond. Exemple : comme un serveur de restaurant qui prend les commandes et apporte les plats.
- **Frontend** : Partie visible de l’application, celle avec laquelle l’utilisateur interagit (boutons, textes, images…).
- **Terminal** : Outil (fenêtre noire) pour donner des instructions à l’ordinateur en tapant des commandes.

**Différence entre backend, API et serveur** :
- Le serveur est la machine (l’ordinateur).
- Le backend est le programme qui tourne sur le serveur.
- L’API est la partie du backend qui communique avec l’extérieur.

**Exemple d’analogie** :
Dans un restaurant :
- Le serveur (personne) prend la commande du client (frontend) et la transmet à la cuisine (backend).
- La cuisine prépare le plat (données/réponse) et le serveur l’apporte au client.
- L’API, c’est le comptoir où le serveur vient chercher les plats.

---

## Étapes à suivre

### 1. Installer les outils nécessaires
- **Visual Studio Code** (éditeur de code)
- **.NET SDK** (pour créer l’API)
- **Node.js et npm** (pour React)


### 2. Créer le backend .NET (API)
1. Ouvre un terminal (dans VS Code ou Windows).
2. Place-toi dans le dossier où tu veux créer ton projet (par exemple, Apprentissage).
3. Tape la commande suivante :
   ```bash
   dotnet new webapi -n MonApi
   ```
   → Cela crée un dossier MonApi avec une API prête à l’emploi.
4. Pour tester l’API :
   ```bash
   cd MonApi
   dotnet run
   ```
   → L’API sera accessible sur http://localhost:5000 ou http://localhost:5001.

**À retenir** : Le backend, c’est toi qui le développes ! Tu écris le code qui gère les données et les règles de l’application. L’API est la partie de ce code qui permet à d’autres programmes (comme le frontend) de communiquer avec ton backend.


### 3. Créer le frontend React TypeScript
1. Reviens à la racine de ton projet (dossier Apprentissage).
2. Tape la commande suivante dans le terminal :
   ```bash
   npx create-react-app MonFrontend --template typescript
   ```
   → Cela crée un dossier MonFrontend avec une application React prête à l’emploi.
3. Pour lancer le frontend :
   ```bash
   cd MonFrontend
   npm start
   ```
   → L’application s’ouvre dans ton navigateur à l’adresse http://localhost:3000.


### 4. Ouvrir le projet dans Visual Studio Code
- Ouvre le dossier racine (Apprentissage) dans VS Code.
- Tu verras les deux dossiers : MonApi (backend/API) et MonFrontend (frontend).
- Tu peux ainsi travailler sur les deux parties dans le même espace de travail.


### 5. Développer et connecter les deux parties
- Développe l’API dans MonApi (backend).
- Développe l’interface utilisateur dans MonFrontend (frontend).
- Pour que le frontend communique avec l’API, il faut utiliser l’adresse de l’API (par exemple, http://localhost:5000) dans le code React, avec des outils comme fetch ou axios.


## Points à retenir
- Un projet moderne sépare le backend (API) et le frontend (interface).
- Le backend, l’API et le serveur sont liés mais différents : le backend est le programme, l’API est la porte d’entrée, le serveur est la machine.
- Chaque partie a ses propres outils et commandes.
- Visual Studio Code permet de tout gérer dans un même espace de travail.


## Conseils pratiques
- Tester chaque partie séparément avant de les connecter.
- Lire les messages d’erreur : ils donnent souvent la solution.
- Utiliser le terminal intégré de VS Code pour exécuter les commandes.
- N’hésite pas à demander la définition d’un terme ou une explication à chaque étape.


