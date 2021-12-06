# unity-bootstrap

What is this?
---

A sample Unity project that shows one way to set things up for scene loading, updates and game state management.


Why is this needed?
---

Unity is extremely flexible, but with so many ways to lay the foundation for a project it can be confusing for beginners.

This boilerplate project offers a way to set up a Unity project for ease of use and extensibility.


Key features
---

Boot scene is a traditional first scene to get something on screen as quick as possible.

All other scenes have a Main GameObject using Main.cs as an entry point. This allows game to be launched by loading any scene.

GameManager will manually invoke Awake/Start/Update functions for all systems, so game has full control over code sequencing.

GameStateManager provides a state machine to manage high level game states in a controlled fashion with Enter/Exit functions.