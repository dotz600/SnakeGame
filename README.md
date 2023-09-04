# Snake Game

Snake Game is a simple console-based game where the player controls a snake that moves around the screen, eating food to grow while avoiding collisions with the walls and itself.
Here is my humble verzion.
![alt text](https://github.com/dotz600/SnakeGame/blob/master/PL/Image/3.png)

## Table of Contents
- [More Visual Examples](#More_Visual_Examples )
- [Introduction](#introduction)
- [Features](#features)
- [Key Programming Aspects Demonstrated](#Key_Programming_Aspects_Demonstrated)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [How to Play](#how-to-play)
- [Game Controls](#game-controls)
- [Game Rules](#game-rules)

## Introduction

Snake Game is a classic and fun game where the player's goal is to control the snake, navigate it around the screen,
and eat as much food as possible without colliding with the boundaries of the screen or the snake's own body.
The game becomes more challenging as the snake grows longer with each piece of food eaten.

## Features

- Simple and addictive gameplay.
- Colorful graphics and a user-friendly interface.
- Progressive Difficulty: Game speed increases over time for added challenge.
- Singleton pattern for data management.
- Event handling for candy-eaten events.
- Exception handling for robust code.
- Object-oriented design principles.
  
## Key Programming Aspects Demonstrated

**Singleton Pattern:** The project effectively uses the Singleton pattern to ensure a single instance of critical data management components, promoting efficient resource usage and centralized control over data.

**Multithreading:** Multi-threading is employed to enhance the game's performance. This allows for parallel execution of tasks such as snake movement, candy generation, and screen updates, ensuring a smoother and more responsive gaming experience.

**Event Handling:** Event handling is utilized to manage interactions within the game. Notably, events are employed to trigger actions when the snake consumes a candy, contributing to the game's dynamic behavior.

**Exception Handling:** The code incorporates exception handling mechanisms to handle exceptional situations gracefully, promoting code robustness and preventing unexpected crashes.

**Object-Oriented Design Principles:** The project adheres to object-oriented design principles, facilitating code organization and maintainability. Concepts like encapsulation, inheritance, and polymorphism are applied to create a structured and modular codebase.


## Getting Started

### Prerequisites

Before you begin, ensure you have met the following requirements:

- A C# development environment like Visual Studio

### Installation

1. Clone this repository to your local machine.
2. Open the project in Visual Studio.
3. Build and run the project to start the Snake Game.

## How to Play
Launch the game using the provided instructions in the "Installation" section.

Once the game starts, you will control a snake represented by a series of connected circle on the screen.

## Game Controls
Use the arrow keys (Up, Down, Left, Right) to control the direction of the snake.
Press the "Esc" key to pause or exit the game at any time.

## Game Rules
The snake moves continuously in the direction you specify.
The goal is to eat as much food (represented by dollars) as possible to increase your score.
If the snake collides with the boundaries of the screen or with itself, the game is over.
The game speed increases over time.


## More Visual Examples
![alt text](https://github.com/dotz600/SnakeGame/blob/master/PL/Image/1.png)
![alt text](https://github.com/dotz600/SnakeGame/blob/master/PL/Image/2.png)
![alt text](https://github.com/dotz600/SnakeGame/blob/master/PL/Image/4.png)
