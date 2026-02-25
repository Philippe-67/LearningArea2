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
