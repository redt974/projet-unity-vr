# 🎯 **Projet Unity VR – Parcours Physique Interactif**

## 📌 Objectif

Ce projet consiste à créer un jeu en réalité virtuelle en deux phases :

- **Phase de placement** : Le joueur place des objets physiques dans un environnement 3D.
- **Phase de résolution** : Les objets interagissent avec le Colis pour tenter de l'amener à une **cible**.

Le but est de concevoir un parcours où le **Colis** atteint l’objectif tout en générant un maximum de **points** grâce aux interactions physiques.

---

## 🧩 Fonctionnalités principales

### 🔀 Gameplay
- 🛠 Placement d’objets physiques dans l’environnement
- ▶️ Résolution automatique avec comportements physiques
- 🎯 Objectif : amener le Colis à la cible
- 🏆 Score généré par les interactions physiques (distance, rotation, etc.)

### 🧱 Objets physiques (10 minimum)
- Comportements variés, réalistes ou fantaisistes
- Exemples : canon, trampoline, tapis roulant, aigle volant...
- Chaque objet a :
  - 🔧 Un paramètre modifiable (angle, vitesse, etc.)
  - 🧮 Un système de score
  - 🔄 Un comportement physique actif

### 🧠 Élément IA
- Interagit avec la scène ou le Colis
- Utilise un **NavMesh** pour se déplacer
- Exemples :
  - Robot qui transporte ou lance le Colis
  - Robot qui active/désactive des objets après le passage du Colis

---

## 🗺 Navigation en VR

Différents modes de navigation possibles :
- Déplacement libre
- Téléportation
- Monde miniature dans la main
- Plateforme mobile ou tournante
- Combinaison de ces modes

---

## 📦 Placement d’objet

- 🎮 Manipulation intuitive en VR
- 📏 Rotation libre de l’objet
- ⚙️ Paramétrage spécifique (ex. angle d’un canon)
- ✅ Indication de validité du placement
- 🔄 Prévisualisation (ex. trajectoire d’un projectile)
- 📉 Limitation du nombre d’objets placés

---

## 🎮 Niveaux

Le projet contient **5 niveaux**. Chaque niveau comprend :
- 🟫 Un Colis (forme variable selon le niveau)
- 🎯 Une cible à atteindre
- ⚙️ Des éléments physiques prédéfinis
- 📦 Des objets physiques sélectionnables
- 🧱 Des éléments statiques pour le décor et la structure
- 🤖 Un élément IA

---

## 📈 Système de score

Le joueur marque des points selon :
- La distance parcourue par le Colis entre chaque interaction
- Le nombre de tours effectués par des objets rotatifs
- Tout autre critère lié au comportement des objets

---

## 🚀 Présentation attendue

**Durée :** 10 minutes  
**Contenu :**
1. Présentation générale du projet
2. Choix de design & gameplay
3. Code dont chaque membre est fier
4. Limites et pistes d’amélioration
5. Démonstration en temps réel (préparée et fluide)

---

## 🧪 Démonstration attendue

- Présente tous les objets et mécaniques créés
- Cache les bugs connus
- Laisse une **marge de 4 minutes** pour la démo dans les 10 minutes totales

---

## 👥 Équipe

- *Nom 1* – Développement
- *Nom 2* – Design / VR
- *Nom 3* – IA / Gameplay
- *(À compléter selon votre équipe)*

---

## 🛠 Technologies utilisées

- **Unity** (version XX.XX)
- **XR Interaction Toolkit**
- **NavMesh** pour l’IA
- **PhysX** pour les interactions physiques
- **SteamVR / OpenXR** selon le casque utilisé