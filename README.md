# TheLastParkingSpot

Musical Chairs-inspired Unity 2D racing game w/ AI functionality. 214073 lines of code. Among the largest projects I've undertaken. Last updated: May 18, 2023.

## How to Play

Download and open the latest version game build file located in the 'Builds' folder.

## Objective

When the music stops, the first person to reach the parking spot wins!

## Condensed Rules

1. This is a **two-player game.**
2. **Player 1 chooses car colour,** while Player 2's car color is random.
3. **Click "Select" to start the race** with music. **Use the ramp to bounce over obstacles** briefly. **Use ramps outside the track to return to the track,** or you'll be unable to come back.
4. **Player 1 uses arrow keys, Player 2 uses W, A, S, and D keys.** Forward/Backward arrow keys (or W/S) move the car, and Left/Right arrow keys (or A/D) turn the car.
5. **Music stops randomly, and a parking spot spawns on the track. The first player to reach it wins!**

## Full Rules

1. This is a two-player game.
2. To the left, Player 1 may select the colour of their car. Player 2's car colour will be randomly generated.
3. After clicking the select button to the left, the race will start, and music will play. On the racetrack, there is a ramp that will launch players' cars into the air, allowing them to bounce on top of obstacles in the track for a short period. If you are launched outside the racetrack, there are 2 ramps outside the track which can be used to return to the track.
4. Player 1 can drive their car using the arrow keys, and Player 2 can drive their car using the W, A, S, and D keys. The forward and backward arrow keys (or W/S keys) move the car forward and backward, and the left and right arrow keys (or A/D keys) turn the car left and right.
5. Be ready for the music to stop after a random amount of time and for a parking spot to spawn in a random place on the track. The first player to reach it will win the game!

## Description of Scripts 

Note: The 'Scripts' subfolder containing the below scripts is found within the 'Assets' folder.

1. AI algorithms:
  - A Star Lite algorithm implementation and integration with map nodes: **AStarLite.cs, AStarNode.cs**
  - Integration with car movement, pathfinding in context to the maps waypoints using the node-based pathfinding system established in the prior scripts, and other details related to the algorithm’s implementation: **CarAIHandler.cs, DrawPathHandler.cs, Startup.cs, WaypointNode.cs**
2. Scripts related to the functioning of cars, the instantiation of two cars controlled by two players’ input via WASD and the arrow keys, and the trail creation mechanism behind car movement: **CarInputHandler.cs, CarLapCounter.cs, CarLayerHandler.cs, CarSFXHandler.cs, TopDownCarController.cs, WheelParticleHandler.cs, WheelTrailRendererHandler.cs, CarData.cs**
3. Scripts related to UI (the menu screen with the select car mechanism, the countdown, the game over sign, the timer, and more): **CarUIHandler.cs, CarUIInputHandler.cs, CountDownUIHandler.cs, InGameMenuUIHandler.cs, LeaderboardUIHandler.cs, RaceTimeUIHandler.cs, SelectCarUIHandler.cs, SetLeaderboardItemInfo.cs**
4. Other scripts related to various functions of the game (the state management system via Unity’s Game Manager script to transition between countdown, gameplay, and game over states, the music function which plays for a random amount of time before it will stop and spawn a parking spot, the collider system within the racetrack, the car instantiation function when cars are spawned, and more): **GameManager.cs, JumpData.cs, MusicController.cs, ParkingSign.cs, PositionHandler.cs, RaceTrack.cs, SpawnCars.cs**

## Details about Game Development

My initial idea for this game was that of a Musical Chairs-style 3D Racing Game. The objective was for players to compete against each other to secure the last available parking spots across a town in a format inspired by the game Musical Chairs, featuring brutal collision physics to add an extra challenge. However, I had to simplify many elements due to my limited experience with Unity and time constraints. The final game was done in a 2D interface with only two players and one round. The envisioned parking mechanic was reduced to having the car make contact with an image of a parking sign that spawns in a randomized location in the racetrack when the music stops. While the final game still offers realistic physics, the collision mechanics also did not turn out as intense as initially envisioned. Despite the simplifications made from the original idea, the game's final version remains highly complex, with a total of nearly 3000 lines of code. One of the most complicated aspects of the game was the implementation of an AI computer pathfinding algorithm. Originally designed to allow the player to play against computer-run cars rather than other players, the algorithm uses the A* algorithm for car pathfinding amidst a grid of nodes embedded in the racetrack map environment. This algorithm calculates the optimal path through the nodes for the car by heuristically evaluating the cost of each node in the track based on the distance from the current node the car occupies to the destination node as well as several other variables, including the placement of obstacles in the track, the relative location of other vehicles, and the car’s maximum speed. Ultimately, I decided to make the game a player vs. player experience rather than a player vs. computer experience. The described AI algorithm is now used to make the winning car do victory laps after reaching the parking spot. Other notable features, and learning points for me, included state control, component usage, sound effects, time tracking, object positioning, animation, and more.

## Languages
| language | files | code | comment | blank | total |
| :--- | ---: | ---: | ---: | ---: | ---: |
| Ini | 9 | 119,295 | 2,466 | 31,059 | 152,820 |
| HTML | 27 | 43,038 | 756 | 7,560 | 51,354 |
| XML | 10 | 5,522 | 277 | 559 | 6,358 |
| C# | 34 | 1,767 | 662 | 584 | 3,013 |
| Markdown | 8 | 548 | 0 | 52 | 600 |
| JSON | 22 | 496 | 0 | 11 | 507 |
| Log | 2 | 17 | 0 | 6 | 23 |

## Directories
| path | files | code | comment | blank | total |
| :--- | ---: | ---: | ---: | ---: | ---: |
| . | 112 | 170,683 | 4,161 | 39,831 | 214,675 |
| . (Files) | 1 | 797 | 7 | 1 | 805 |
| .VSCodeCounter | 10 | 550 | 0 | 52 | 602 |
| .VSCodeCounter/2024-03-27_17-06-08 | 5 | 275 | 0 | 26 | 301 |
| .VSCodeCounter/2024-03-27_17-08-26 | 5 | 275 | 0 | 26 | 301 |
| Assets | 34 | 1,767 | 662 | 584 | 3,013 |
| Assets/Scripts | 34 | 1,767 | 662 | 584 | 3,013 |
| Assets/Scripts (Files) | 8 | 237 | 83 | 65 | 385 |
| Assets/Scripts/AI | 6 | 567 | 142 | 219 | 928 |
| Assets/Scripts/AI (Files) | 4 | 293 | 86 | 104 | 483 |
| Assets/Scripts/AI/Astar | 2 | 274 | 56 | 115 | 445 |
| Assets/Scripts/Car | 7 | 512 | 205 | 166 | 883 |
| Assets/Scripts/Scriptable objects | 1 | 25 | 0 | 6 | 31 |
| Assets/Scripts/ScriptsNotUsedInGame | 4 | 79 | 163 | 24 | 266 |
| Assets/Scripts/ScriptsNotUsedInGame/Ghost car | 4 | 79 | 163 | 24 | 266 |
| Assets/Scripts/UI | 8 | 347 | 69 | 104 | 520 |
| Builds | 63 | 167,076 | 3,492 | 39,186 | 209,754 |
| Builds/LastParkingSpotBeta1.0Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.0Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.4Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.4Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.5Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.5Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.6Build .app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.6Build .app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.7Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.7Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.8Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.8Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.9Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta1.9Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta2.0Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta2.0Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta2.1Build.app | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents | 7 | 18,564 | 388 | 4,354 | 23,306 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge/etc | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge/etc/mono | 5 | 18,562 | 388 | 4,353 | 23,303 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge/etc/mono (Files) | 1 | 13,255 | 274 | 3,451 | 16,980 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge/etc/mono/2.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge/etc/mono/4.0 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge/etc/mono/4.5 | 1 | 1,594 | 28 | 280 | 1,902 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/MonoBleedingEdge/etc/mono/mconfig | 1 | 525 | 30 | 62 | 617 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/Resources | 2 | 2 | 0 | 1 | 3 |
| Builds/LastParkingSpotBeta2.1Build.app/Contents/Resources/Data | 2 | 2 | 0 | 1 | 3 |
| Logs | 2 | 17 | 0 | 6 | 23 |
| Packages | 2 | 476 | 0 | 2 | 478 |
