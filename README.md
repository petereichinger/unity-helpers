# unity-helpers
Helper classes that are useful for Unity projects

I'll add helper classes that I often use in Unity projects

## Description

## Mass Set Tags Tool

This tool simply sets the tags of all selected objects and their children.
The class is `Scripts/EditorTools/Editor/MassSetTags.cs` and it can be accessed via `UnityHelpers -> Mass Set Tags`

## Apply Prefab Tool

Tool that applies changes to all selected prefabs. The class is located at `Scripts/EditorTools/Editor/ApplyPrefabTool.cs` and it can be accessed via `UnityHelpers -> Apply Selected Prefabs`.

## Open Git Bash Tool

Tool that opens git bash for this project. Only works on Windows and only if git bash is installed in the default location (either `C:\Program Files\Git\git-bash.exe` or `C:\Program Files(x86)\Git\git-bash.exe`). Code for this tool is found in `Scripts/EditorTools/Editor/OpenGitBashTool.cs`

## Singleton

A singleton pattern implemenation is found under `Scripts/Singleton/Singleton.cs` the full class name is `UnityHelpers.Singleton.Singleton<T>`.

## Component extensions

An extension for getting or adding a component to a gameobject is located in `Scripts/Components/ComponentExtensions`. This includes extension methods for `GameObject` and `Component`.

## SerializedProperty Array Helpers

In the folder `Assets/Scripts/EditorHelpers/Editor/` are the following classes that help with handling array SerializedProperties

- *ArrayHelpers*: Provides helper methods for adding elements to `SerializedProperty`-Objects that are arrays
- *ArrayIterator*: Iterator implementation for `SerializedProperty`-Arrays (you can use `foreach` with this)
