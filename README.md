# Nudge-Carrom-Project ReadMe

This ReadMe document provides an overview of the Carrom game developed in Unity. It includes information about the game, its features, installation instructions, the development process, and other relevant details.

## Game Description

The Carrom game is a single-player game designed to simulate the popular board game Carrom. The objective of the game is to pocket all the pucks before the timer runs out. The player can control the striker by dragging it to charge the power of the shot and release it in the desired direction. The game follows general physics rules, including puck-striker collisions and boundary bouncing. Scoring is based on the number of pucks pocketed, with additional points awarded for pocketing the red queen. The game includes a 2-minute timer, and when the time elapses, a "Game Over" banner is displayed.

## Features

The Carrom game includes the following features:

1. Drag and release mechanic to control the striker's power and direction.
2. Realistic physics simulation for puck-striker collisions.
3. Boundary bouncing for both the striker and pucks.
4. Scoring system with points awarded for pocketing pucks and the red queen.
5. A 2-minute game timer with a "Game Over" banner when time runs out.
6. Single-player mode with an AI opponent capable of taking simple shots.

## Installation

To install and run the Carrom game, follow these steps:

1. Download the game assets from the following link: [Assets](https://drive.google.com/drive/folders/1IrjWe2swTRSlMy4zucnxs1S5XqMKnFK2?usp=share_link).
2. Download and install Unity, preferably version [Unity 2019.4.24f1](https://unity3d.com/unity/whats-new/2019.4.24).
3. Create a new Unity project.
4. Import the downloaded assets into the Unity project by copying them into the project's Assets folder.
5. Open the scene named "CarromScene" from the project's Assets folder.
6. Set the scene aspect ratio to portrait orientation to optimize for mobile devices.
7. Ensure the game is configured to target the desired platform (e.g., Android or iOS).
8. Build and run the game on your target device or emulator.

Note: Additional configurations may be required depending on your specific development environment.

## Development Process

The Carrom game was developed using the following process:

1. **Requirements Analysis:** I reviewed the given task requirements and identified the key elements, mechanics, and features required for the Carrom game.
2. **Asset Integration:** I downloaded the provided game assets and imported them into the Unity project. This included the striker, black and white pucks, red queen, game board, and other required visual and audio assets.
3. **Scene Setup:** I created a new scene in Unity and set up the game environment, including the board, pockets, and boundaries. I positioned the game elements, such as the striker and pucks, within the scene.
4. **Drag and Release Mechanic:** I implemented the drag and release mechanic for controlling the striker's power and direction. This involved handling touch input, calculating the shot power based on the drag distance, and applying force to the striker upon release.
5. **Physics Simulation:** I utilized Unity's physics engine to handle the interactions between the striker and pucks. I configured rigidbody components and colliders for accurate collision detection and response.
6. **Boundary Bouncing:** I implemented boundary bouncing for both the striker and pucks to ensure they stay within the game board and respond realistically when hitting the boundaries.
7. **Scoring System:** I created a scoring system that increments the score when a puck is pocketed and awards additional points for pocketing the red queen. I integrated the scoring system with the user interface (UI) to display the current score.
8. **Timer Implementation:** I added a timer to the game, set to 2 minutes. The timer counts down, and when it reaches zero, a "Game Over" banner is displayed, indicating the end of the game.
9. **AI Functionality:** I implemented a basic AI opponent capable of taking simple shots. The AI analyzes the game state and makes decisions based on predefined rules and strategies.
10. **Testing and Refinement:** I extensively tested the game, ensuring that the mechanics, physics, scoring, and AI functionality work as intended. I addressed any bugs, issues, or inconsistencies that arose during testing.
11. **Optimization and Scalability:** I optimized the game for portrait screen orientation and made sure it can run smoothly on various devices with different screen sizes and resolutions.
12. **Documentation and Submission:** I created the ReadMe document, recorded a video showcasing the game, and prepared the code repository for submission.

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

The Carrom game was developed by [Your Name]. It utilizes the provided assets and references to create an engaging single-player Carrom experience in Unity.

If you have any questions or feedback, please contact [Your Email Address].

Thank you for playing the Carrom game!
