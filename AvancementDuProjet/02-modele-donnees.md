# Étape 02 – Modèle de données

## 🎯 Objectif
Définir les entités principales, leurs relations et préparer les DTOs pour garantir une base de données MongoDB adaptée à l’apprentissage personnalisé du vocabulaire.

## 📌 Statut
- [ ] À faire
- [ ] En cours
- [x] ✅ Terminé (partiel : entités Models/ créées)


## ✅ Tâches réalisées
- [x] Lister les entités principales (Utilisateur, Mot, RevisionHistory, Dictionnaire, MongoDbSettings)
- [x] Créer les classes C# dans Models/ (Utilisateur, Mot, RevisionHistory, Dictionnaire, MongoDbSettings)
- [x] Créer les DTOs dans DTOs/ (11 fichiers : Create/Update/Read pour chaque entité)

## 🔄 En cours
- [ ] Définir les interfaces IRepository<T> et IService<T>

## 📅 Tâches restantes
- [ ] Définir les interfaces IRepository<T> et IService<T>
- [ ] Créer les implémentations de base pour une entité

## 🧱 Choix techniques
| Choix | Raison |
|-------|--------|
| MongoDB | Base NoSQL adaptée à la personnalisation et à la flexibilité |
| DTOs | Sécurité et découplage entre API et modèle interne |
| Interfaces génériques | Respect du SOLID, testabilité |

## 🐛 Problèmes rencontrés & solutions
| Problème | Solution apportée |
|----------|-------------------|
| Aucun à ce stade |  |

## 🌿 Branche Git utilisée
- Branche : feature/modele-donnees

## 🗓️ Dates
- Début : 25/02/2026
- Fin :

---
> Ce fichier est géré par l’agent conseiller. Il est mis à jour après chaque tâche accomplie et versionné avec le code source.
