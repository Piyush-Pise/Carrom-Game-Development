# Nudge Carrom Project ReadMe

This ReadMe document provides an overview of the Carrom game developed in Unity for Android devices. It includes information about the game, its features, installation instructions, the development process, and other relevant details.

## Game Description

The Carrom game is a single-player game designed to simulate the popular board game Carrom. The objective of the game is to pocket all the pucks before the timer runs out. The player can control the striker by dragging it to charge the power of the shot and release it in the desired direction. The game follows general physics rules, including puck-striker collisions and boundary bouncing. Scoring is based on the number of pucks pocketed, with additional points awarded for pocketing the red queen. The game includes a 2-minute timer, and when the time elapses, a "Game Over" banner is displayed.

## Features

The Carrom game includes the following features:

1. Drag and release mechanics to control the striker's power and direction.
2. Realistic physics simulation for puck-striker collisions.
3. Boundary bouncing for both the striker and pucks.
4. Scoring system with points awarded for pocketing pucks and the red queen.
5. A 2-minute game timer with a "Game Over" banner when time runs out.
6. Single-player mode with an AI opponent capable of taking simple shots.

## Installation

To install and run the Carrom game, follow these steps:

1. Create a new Unity project, preferably version Unity 2021.3.23f1.
2. Go to the build settings and change the build settings to Android.
4. Import the downloaded assets into the Unity project by copying them into the project's Assets folder.
5. Open the scene named "SampleScene" from the project's Assets folder.
6. Set the scene aspect ratio to portrait orientation to optimize for mobile devices.
7. Ensure the game is configured to target the desired platform (Android).
8. Build and run the game on your target device or emulator.

Note: Additional configurations may be required depending on your specific development environment.

## Development Process

The Carrom game was developed using the Unity game engine version 2021.3.23f1 for Android devices. The development process involved the following steps:

1. **Requirements Analysis:** Reviewed the task requirements and identified the key elements, mechanics, and features required for the Carrom game. Decided to develop a 2D game for Android mobile platforms.

2. **Asset Integration:** Downloaded the provided game assets and imported them into the Unity project. This included the striker, black and white pucks, red queen, game board, and other required visual and reference videos.

3. **Scene Setup:** Created a new scene in Unity and set up the game environment, including the board, pockets, pucks, and boundaries. Positioned, scaled, and parented the elements properly. Added components like 2D colliders and Rigidbody2D. Set up UI elements such as the 2-minute timer, score text, countdown timers for each player, and a striker bar slider.

4. **Conceptualizing the Game:** Figured out how the gameplay should look and broke it down into different states. Developed states such as Idle state, charge state, free state, score UI update state, and game end state. This helped in coding the game logic more easily.

5. **Programming:** Utilized the finite state machine (FSM) programming pattern to handle the different states of the game and their corresponding logic. This improved code organization and scalability.

6. **Drag and Release Mechanic:** Implemented the drag and release mechanic to control the striker's power and direction based on a UI slider. Handled touch input, calculated the shot power based on the drag distance, and applied force to the striker upon release.

7. **Physics Simulation:** Utilized Unity's physics engine to handle the interactions between the striker, pucks, and the board. Configured rigid body components and colliders for accurate collision detection and response.

8. **Boundary Bouncing:** Implemented boundary bouncing using a polygon collider for the carrom board to ensure that the striker and pucks stay within the game board and respond realistically when hitting the boundaries. Created a script that simulates friction force on the pucks and the striker.

9. **Scoring System:** Created a scoring system that increments the score when a puck is pocketed and awards additional points for pocketing the red queen. Integrated the scoring system with the user interface (UI) to display the current score.

10. **Timer Implementation:** Programmed a timer for the game using Coroutines, set to 2 minutes, and integrated it with the corresponding UI text element. The timer counts down, and when it reaches zero, a "Game Over" banner is displayed, indicating the end of the game.

11. **AI Functionality:** Implemented a primary AI opponent capable of taking simple shots. The AI analyzes the game state and makes decisions based on predefined rules and strategies. The AI strategy involves calculating a potential position for the striker, where the striker, puck, and pocket are aligned in a straight line. The shot power is then determined based on the distance between the puck and the striker. In cases where no such position exists, the AI randomly selects a position for the striker and applies a random force for the shot.

12. **Testing and Refinement:** Extensively tested the game to ensure that the mechanics, physics, scoring, and AI functionality worked as intended. Addressed any bugs, issues, or inconsistencies that arose during testing.

13. **Optimization and Scalability:** Optimized the game for portrait screen orientation and ensured smooth performance on various devices with different screen sizes and resolutions.

14. **Documentation and Submission:** Created the ReadMe document, recorded a video showcasing the game, and prepared the code repository for submission.

## Controls

The controls for the Carrom game are as follows:

- Drag the striker behind to charge the power of the shot.
- Release the striker to shoot it in the desired direction.
- Use the touch input on the screen to interact with the game elements.

## Video Showcase

A video showcasing the Carrom game can be found at the following link: [Video][https://drive.google.com/file/d/1Ky4dN4oHA1Eomy03DDRM5rODTPNCT8jI/view?usp=share_link]

## Repository

The source code for the Carrom game can be accessed from the following GitHub repository: [Nudge Carrom Game Repository][(https://github.com/Piyush-Pise/Nudge-Carrom-Project)]

## Credits

The Carrom game was developed by Piyush Narhari Pise. It utilizes the provided assets and references to create an engaging single-player Carrom experience in Unity.

If you have any questions or feedback, please raise issues in the repository.

Thank you for playing the Carrom game!
