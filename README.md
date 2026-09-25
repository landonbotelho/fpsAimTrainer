# FPS Aim Trainer

A first-person aim training game developed in Unity using C#.

The project focuses on core FPS mechanics including player movement, mouse-look camera control, shooting, target movement, door interactions, and game-state logic.

## Play the Game

Playable builds are available in the [Releases](../../releases) section.

### Windows
Download:

`fpsAimTrainer-Windows.zip`

Extract the ZIP and run the included `.exe` file.

### macOS
Download:

`fpsAimTrainer-Mac.app.zip`

Extract the ZIP and open the included `.app` bundle.

## Overview

This project was built in Unity as a small first-person shooting and aim-training environment.

The player can move through the environment, control the camera using the mouse, fire a weapon, interact with moving targets, and navigate through interactive elements such as doors.

The project was designed to practice FPS gameplay programming, player controls, object interaction, target behavior, and Unity-based game systems.

## Features

- First-person player movement
- Mouse-controlled camera look
- Shooting and projectile behavior
- Moving targets
- Interactive doors
- Game-state logic
- Collision-based gameplay
- Unity physics integration
- C# gameplay scripting

## Technologies

- Unity
- C#
- Object-Oriented Programming
- Unity Physics
- Unity Input
- GameObject and Component systems

## Code Overview

The project is divided into several gameplay scripts, each responsible for a specific system.

### `MovementControl.cs`

Handles first-person player movement.

Responsibilities include:

- reading player movement input
- moving the player character
- controlling movement speed
- coordinating player motion within the Unity scene

### `MouseControl.cs`

Handles first-person camera movement.

Responsibilities include:

- reading mouse input
- rotating the player horizontally
- rotating the camera vertically
- limiting vertical camera rotation where necessary

### `Gun.cs`

Controls weapon behavior.

Responsibilities include:

- detecting firing input
- creating or firing projectiles
- controlling shooting behavior
- interacting with the bullet system

### `Bullet.cs`

Controls projectile behavior after a shot is fired.

Responsibilities include:

- projectile movement
- collision detection
- target interaction
- removing or destroying bullets when necessary

### `TargetMovement.cs`

Controls moving targets within the aim-training environment.

Responsibilities include:

- target movement
- movement direction and behavior
- creating dynamic aiming challenges for the player

### `DoorBehavior.cs`

Controls interactive door objects.

Responsibilities include:

- opening and closing behavior
- responding to player interaction or triggers
- modifying door position or rotation

### `GameBehavior.cs`

Handles higher-level gameplay logic.

Responsibilities include:

- coordinating game-state behavior
- managing gameplay events
- controlling interactions between different game systems

## Project Structure

The main Unity project follows a standard Unity layout:

```text
fpsAimTrainer/
├── Assets/
│   ├── Scripts/
│   │   ├── Bullet.cs
│   │   ├── DoorBehavior.cs
│   │   ├── GameBehavior.cs
│   │   ├── Gun.cs
│   │   ├── MouseControl.cs
│   │   ├── MovementControl.cs
│   │   └── TargetMovement.cs
│   ├── Materials/
│   ├── Prefabs/
│   └── Scenes/
├── Packages/
├── ProjectSettings/
└── README.md
