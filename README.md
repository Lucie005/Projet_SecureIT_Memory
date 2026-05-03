# 🛡️ SecurIT - Mission Memory

**Projet de C# / WinForms - Salon de l'Innovation Tech**

Bienvenue dans le dépôt du projet **SecurIT Memory**. Ce mini-jeu interactif a été développé pour le stand de la start-up SecurIT lors du prochain Salon de l'Innovation Tech. L'objectif est d'attirer les visiteurs et de tester leur mémoire à travers des concepts clés de la cybersécurité.

## 🚀 Fonctionnalités
* **Interface intuitive** : Menu principal propre avec options pour lancer le jeu ou paramétrer l'expérience.
* **Thème Cybersécurité** : Cartes illustrées avec du vocabulaire du domaine (Pare-feu, Virus, Cryptographie, Cloud, etc.).
* **Mécanique de jeu complète** : 
  * Mélange aléatoire des cartes.
  * Retournement avec délai (Timer) en cas d'erreur.
  * Blocage des clics pendant l'animation pour éviter la triche.
* **Suivi de la performance** : Chronomètre en temps réel et compteur d'essais.
* **Architecture MVC** : Séparation stricte entre la logique métier (`Modeles`) et l'interface utilisateur (`Vues`).
* **Sons immersifs** : Effets sonores lors des clics et musique de victoire.

## 📁 Architecture du Projet
Le projet respecte les principes de la Programmation Orientée Objet (POO) avec la structure suivante :
* `/Modeles` : Contient la logique du jeu (`Carte.cs`, `JeuMemory.cs`).
* `/Vues` : Contient les interfaces graphiques (`FormMenu`, `FormJeu`, `FormOptions`).
* `/Ressources` : Banque d'images et d'effets sonores.

## 🛠️ Prérequis et Installation
1. Avoir **Visual Studio** (avec la charge de travail *Développement Desktop .NET*) installé.
2. Cloner ce dépôt GitHub sur votre machine locale.
3. Ouvrir le fichier `Projet C#.csproj` avec Visual Studio.
4. Appuyer sur `F5` ou cliquer sur "Démarrer" pour lancer la compilation et l'exécution du jeu.

## 👥 Équipe de Développement
Projet réalisé en binôme par :
* **Thibaud TABARD** : Logique métier, Modèles de données, et refactoring de l'architecture.
* **Lucie BARREZ** : Interfaces WinForms, intégration des ressources, et timers.