# MiniGames

<!-- TOC depthFrom:1 depthTo:6 withLinks:1 updateOnSave:1 orderedList:0 -->

- [MiniGames](#minigames)
- [1	Introduction](#1-introduction)
	- [1.1	Cadre et Description](#11-cadre-et-description)
	- [1.2	Organisation](#12-organisation)
	- [1.3	Planification initiale](#13-planification-initiale)
- [2	Analyse](#2-analyse)
	- [2.1	Cahier des charges détaillé](#21-cahier-des-charges-dtaill)
	- [2.2	Stratégie de test](#22-stratgie-de-test)
		- [2.2.1	Test Unitaire](#221-test-unitaire)
		- [2.2.2	Test Performance](#222-test-performance)
		- [2.2.3	Test de Validation](#223-test-de-validation)
	- [2.3	Planification](#23-planification)
	- [2.4 Explication des jeux](#24-explication-des-jeux)
	- [2.4.1 Bataille](#241-bataille)
	- [2.4.2 Solitaire](#242-solitaire)
	- [2.4.3 Morpion / Tic-Tac-Toe](#243-morpion-tic-tac-toe)
	- [2.5 Analyse concurentiel](#25-analyse-concurentiel)
	- [2.5.1 Tic-tac-toe](#251-tic-tac-toe)
	- [2.5.2 Le solitaire](#252-le-solitaire)
	- [2.5.3 La bataille](#253-la-bataille)
- [3 Conception](#3-conception)

<!-- /TOC -->

# 1	Introduction
## 1.1	Cadre et Description

Ce projet consiste à développer une application en C#. Le sujet est totalement libre.


Notre application est un regroupement de mini-jeux. De base l’application contiendra trois jeux ; La bataille, le morpion et le solitaire. L’objectif est d’intégrer ces trois jeux sous forme de formulaires et si possible implémenter de nouvelles fonctionnalitées et jeux.  

## 1.2	Organisation

| Nom        | Fonction          | Mail  |
| :-------------: |:-------------:| :-----:|
|Ilan Ruiz De Porras | Eleve | Ilan.ruiz-de-porras@cpnv.ch|
|Cyril Goldenschue | Eleve | Cyrile.Goldenschue@cpnv.ch |
|Julien Ithurbide | Expert | Julien.Ithurbide@cpnv.ch |
|Frederique Andolfatto | Expert | Frederique.Andolfatto@cpnv.ch |


## 1.3	Planification initiale

# 2	Analyse
## 2.1	Cahier des charges détaillé

1. Nous devons travailler en binome et choisir le sujet de l'application.

2. L'application devra introduire une notion de programmation avancé tel qu'une connexion a une basse de donnée ou pouvoir communiquer sur le réseau

3. Implemantation de l'anayse et conception de l'application: Après validation du chef de projet,
rédiger un documents (markdown, docx, ...) contenant un chapitre analyse et conception. Il faut prendre le template de documentation pour application comme template de base.

4. Implemantation de l'application: Tout en implementant, rédiger les chapitres nécessaire à cette étape.

5. Phase de validation: Derrnière phase du projet qui consiste à livrer le produit final au chef de projet. Le rendu comportera:
  - l'application (tous les fichiers)
  - Documentation final contenant:
    - toutes les phase d'analyse, de conception et d'Implemantation de l'application

## 2.2	Stratégie de test

Nous ferons trois type de testes:
- Test unitaire
- Test de performance
- Test de validation.

### 2.2.1	Test Unitaire

Ces tests seront les plus fréquents et ne sont pas effectué par les testeurs. Il s’agit de testes qui déterminerons si tel et tel chose fonctionne correctement.

Exemple : tester le traitement de string, Correction du code, etc…

### 2.2.2	Test Performance

Ces tests sont effectué afin de déterminer les performances nécessaires afin de faire tourner notre application.

Ils seront simplement effectué à l’aide de l’interface de Visual studio et la vitesse d’exécution de l’application.

Ces tests montre également si l'application est optimisé ou non.

### 2.2.3	Test de Validation

Ces tests permettront de valider une fonctionnalité de l’application. Ces tests serons effectuer à l’aide d’une liste de testes à effectuer pour valider la fonctionnalité.

## 2.3	Planification

La planification se trouve sur github, dans le répertoire du projet:

[Lien du répertoire du projet](https://github.com/ICMiniGames/MiniGames)

## 2.4 Explication des jeux

## 2.4.1 Bataille

![](Images/Bataille.jpg)

La battaile est une jeu de carte relativement basique se jouant à deux joueur.

les règles sont assez simple. On divise un paquet de 52 cartes en deux et on distribue la moitié au deux joueur. Chaqun va poser la carte se trouvant au dessus du tas et le poser face visible. le but est que votre carte sois d'une valeur supérieur a celle de votre adversaire. Celui qui aura obetenu le plus grand score gagne.

Pour plus d'information : https://fr.wikipedia.org/wiki/Bataille_(jeu)

## 2.4.2 Solitaire

![](Images/solitaire.png)

Le solitaire est un jeu de carte que on retrouve sur de nombreux navigateur et il est égalmeent de base dans le systeme d'exploitation windows.

Le but est de formé ce qui s'appel des familles. Une famile est composé de toutes les cartes allant de l'as au roi du même symbole. Il s'agit d'un jeux en continue et le but est d'avoir formé toutes les familles de tous les symboles.

Pour plus d'information : https://fr.wikipedia.org/wiki/Solitaire_(patience)

## 2.4.3 Morpion / Tic-Tac-Toe

![](Images/tic-tac-toe.png)

Le morpion aussi applé le Tic-Tac-Toe, est un jeux très basique se jouant a deux.

le but est de formé une ligne grâce au placement de symbole dans un plateau. le jeu se joue au tour par tour. chaque joueur placera son symbole dans une des case du plateau et ainsi de suite jusqua ce qu'une ligne se forme ou qu'il y ai aucune.

Pour plus d'information : https://fr.wikipedia.org/wiki/Tic-tac-toe

## 2.5 Analyse concurentiel

La plus part des jeux proposé par notre application se trouve sur navigateur web tel que **Chrome**. La bataille est le seul jeu de la liste n'y figurant pas.

## 2.5.1 Tic-tac-toe

il existe un tic-tac-toe sur google. il suffit simplement de tapper **tic tac toe** dans la barre de recherche google pour y accèder. il se présente sous cette forme:

![](Images/tic-google.png)

## 2.5.2 Le solitaire

![](Images/solitaire-google.png)

## 2.5.3 La bataille

# 3 Conception
