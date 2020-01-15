# Unity Project Template
Unity Template mit allem was für einen Schnellen Start in neue Projekte benötigt wird. (Besonders nützlich für GameJams)
> Dieses Template wurde mit Version 2019.2.8f1 erstellt

## Inhalt
1. [Voraussetzungen](#voraussetzungen)
2. [Dieses Repo verwenden](#dieses-repo-verwenden)
3. [Git Workflow](#git-workflow)
4. [Universelle Tipps für Unity](#universelle-tipps-für-unity)
4. [Git LFS verwenden](#git-lfs-verwenden)

---

## Voraussetzungen
1. Git (https://git-scm.com/downloads)
3. Unity Hub (https://unity3d.com/de/get-unity/download)
4. Eine Unity Version >= 2019.2.8f1 

## Dieses Repo verwenden
### Lokale Version klonen
1. Klicke auf "Use this template", um ein neues Repository mit dieser Basis zu erstellen
2. Nachdem das Repository erstellt wurde, navigiere zu einem Ordner in dem sich das Projekt lokal befinden soll
3. Rechts click -> "git bash here"
4. Klicke im Repository "Clone or Download" und kopiere den angezeigten Link
5. Führe folgende Befehle in der Git Bash aus (Du kannst den Link mit "Shift + Einf" einfügen)
```
git clone <Your link>
```
6. Nun hast du eine lokale Version des Repositorys

### Projekt in Unity öffnen
1. Öffne Unity Hub
2. Wenn du noch keine hast, installiere eine Unity Version >= 2019.2.8f1
3. Wechsle zum Tab "Projects" und wähle "Add"
4. Navigiere zu deinem Repository-Ordner und wähle den inneren Ordner aus
5. Zurück in der Übersicht deiner Projekte in Unity Hub wähle das Projekt um es zu öffnen
> Falls Unity anmerkt, dass das Projekt mit einer älteren Version erstellt wurde, kannst du einfach fortfahren

## Git Workflow
1. Make sure to have your local repo clean (```git status```)
2. Check for remote changes (```git fetch```)
3. Get the newest version (```git pull```)
4. Create a new branch for your feature (```git checkout -b feature/<featureName>```)
5. Start working on the feature
6. Work on something to advance towards the goals of the feature
7. Whenever you have accomplished something individually complete, commit your changes (```git commit -m "<message>"```)
8. Repeat steps 6 and 7 until you completed the feature
9. Push your feature to the repo (```git push --set-upstream origin feature/<featureName>```) 
10. Apply your feature to the project
    1. Go to your repository on Github
    2. Click on **New pull request**
    3. Select **master** as base and **feature/\<featureName\>** as compare 
    4. Add at least on person as **Reviewer**
    5. Create the Pull Request
    6. Now wait till at least person has reviewed and accepted your pull request and confirm it
    7. Delete your branch **feature/\<featureName\>**
11. You're ready to start a new feature

## Universelle Tipps für Unity
- Always create a new Unity Scene to create Prefabs and other Assets
- Always open Unity after adding Assets to the project outside the Editor (This allows Unity to import them correctly)
- Always make sure that there is a meta file for each newly added asset

## Git LFS verwenden
Install Git LFS (https://git-lfs.github.com/)

```
git lfs install
```
