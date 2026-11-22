# Demolition Derby

**Unity version:** 6000.6.7f1 (see ProjectSettings/ProjectVersion.txt)

## Setup
1. Install Git and Git LFS, then run `git lfs install`
2. Clone the repo
3. Run `git config core.autocrlf input`
4. Open the folder in Unity Hub with the version above
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
