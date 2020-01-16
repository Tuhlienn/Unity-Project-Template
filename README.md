# Unity Project Template
Unity Template mit allem was für einen schnellen Start in neue Projekte benötigt wird. (Besonders nützlich für GameJams)
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

### Standard Vorgehen
1. Stelle sicher, dass du einen sauberen lokalen Stand hast (```git status```)
2. Prüfe, ob es Änderungen auf dem remote-Repository gibt (```git fetch```)
3. Hol dir den neuesten Stand des Repositorys (```git pull```)
4. Erstelle einen neuen branch für dein Feature (```git checkout -b feature/<featureName>```)
5. Beginne mit der Arbeit an deinem Feature
7. Sobald eine Teilaufgabe deines Features abgeschlossen ist solltest du deine Änderungen committen (```git commit -m "<message>"```)
9. Sobald dein Feature vollständig abgeschlossen ist, kannst du deine Änderungen pushen (```git push --set-upstream origin feature/<featureName>```) 
10. Um dein Feature in das Projekt einfließen zu lassen, sind folgende Schritte notwendig
    1. Rufe das Repository auf GitHub auf
    2. Wähle **New pull request**
    3. Wähle **master** als base und **feature/\<featureName\>** als compare 
    4. Wähle mindestens eine andere Person als **Reviewer** aus
    5. Erstelle den Pull Request
    6. Nun musst du darauf warten, dass mindestens einer der ausgewählten **Reviewer** den PullRequest genehmigt. Sobald dies geschehen ist, kannst du den PullRequest abschließen
    7. Lösche den Branch **feature/\<featureName\>**
11. Jetzt bist du bereit ein neues Feature zu beginnen

## Universelle Tipps für Unity
- Jeder, der an dem Projekt mitarbeitet, sollte seine eigene Szene besitzen, um Prefabs und Assets zu erstellen
- Öffne immer nachdem du außerhalb des Editors Assets zum Projekt hinzufügst einmal Unity (Dadurch kann Unity diese Dateien korrekt importieren)
- Achte beim Commit darauf, dass für jedes Asset eine .meta-datei existiert

## Git LFS verwenden
Installiere Git LFS (https://git-lfs.github.com/)

```
git lfs install
```
