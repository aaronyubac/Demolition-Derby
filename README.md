# Demolition Derby

# Group Members: Aaron Yubac, Luis Torres, Henry Parubrub

# Description of Current Target for the Game: 
We want to create a first-person demolition derby type game that will have the player go against other bots in different vehicles. The goal of the game is to wreck the other cars before your own car gets wrecked, the last one vehicle to survive wins the game. 

# General Goals: 
Henry: Creating the vehicles and setting up vehicle behaviors. 
Aaron: Setting up the arena and creating the bots to go against and their behaviors.
Luis: Implementing audio and visual assets. 
UI will be split between the three of us. 

**Unity version:** 6000.6.7f1 (see ProjectSettings/ProjectVersion.txt)

## Setup
1. Install Git and Git LFS, then run `git lfs install`
2. Clone the repo
3. Run `git config core.autocrlf input`
4. Add project from disk in Unity Hub with the version above
5. Wait for the first import to finish

## Workflow
- Branch from `main`, open a PR to merge
- Pull before starting work and before pushing
- Save the scene and project before committing.
- Move/rename assets inside Unity only (so .meta files follow)

## Git Workflow
DO NOT push commits to the main branch

```
# View local branches
git branch
# View all branches (include origin)
git branch -a 
# Delete a local branch
git branch -d <branch-name>

# Switch to main branch to branch off of (can branch off of other branches)
git switch main

# Update branch before operating on it
git fetch origin
git pull

# Create a branch to work on (Recommended format: <feature|fix|docs>/quick-description)
git switch -c <branch-name>

# View what files are being tracked
git status

# Add files (changes git status)
git add . # stage all changed files
git add <directory>/<filename> # stage individual file

# Save staged changes locally
git commit -m "<commit message>"

# Push to github
git push -u origin <branch-name> # First time pushing to branch
git push # Other pushes after origin has been setup
```

## Pull Request Workflow
To merge the changes on your feature branch to main, we need to open up a pull request on github

1. Open a pull request
- On the github main code page, on your branch there will be a shortcut key to open a pull request
- Otherwise, go to the pull request section and select and select `New Pull Request`
2. Point your branch to main
3. Add a concise title of what your pr is doing
4. In your description, go into detail of all of the changes you have made on your branch. Note key changes and deployment considerations
5. Now you can open the pull request
6. Github may notify you of merge conflicts
