# Unity Project Template
A Unity Template with all you need to jumpstart your projects. (Especially useful for GameJams)
> This Template was created with 2019.2.8f1

## Prerequisits
1. Git (https://git-scm.com/downloads)
3. Unity Hub (https://unity3d.com/de/get-unity/download)
4. A Unity Version >= 2019.2.8f1 

## Using this Repo
### Cloning a local Version
1. Click on "Use this template" to create a new Repo
2. After you created the repository navigate to a place where you want your project folder to be
3. Right click and select "git bash here"
4. In your repository click on "Clone or Download" and copy the shown link
5. Type following inside the Git Bash (You can paste your link via "Shift + Einf"
```
git clone <Your link>
```
6. Now you have your local Version of the repo all setup

### Opening the Project in Unity
1. Open Unity Hub
2. If you haven't already install a Unity Version >= 2019.2.8f1
3. Switch to the "Projects"-Tab and select "Add"
4. Navigate to your repository folder and select the inner folder
5. Click on the Project to open it
> If Unity indicates that the project was created with an older version of Unity just continue

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

## Universal Tipps for Unity
- Always create a new Unity Scene to create Prefabs and other Assets
- Always open Unity after adding Assets to the project outside the Editor (This allows Unity to import them correctly)
- Always make sure that there is a meta file for each newly added asset

## Using Git [LFS](https://git-lfs.github.com/)
```
git lfs install
```
