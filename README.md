# Balloon-Game
This project is part of a group of Unity Engine built Oculus Rift VR games for stroke patient rehabilitation. 
-----
The objective of the game is for the player to pop balloons by poking them with his or her hands. 
Patients develop hand-eye coordination and practice arm extension movements needed for day-to-day activities.
-----

Once the player starts the game they begin a series of levels progressing in difficulty.
![alt text](https://github.com/StrokeVR/Balloon-Game/blob/master/Assets/Resources/MenuBalloon.PNG)

Each level has two balloon that can only be popped with a specific hand (yellow with left and blue with right)
The color on the needle the player is holding is the designation for that and it never swaps.

Once a player has popped a balloon the needle will disappear and the user will need to "reload" by bring their hands to their chest.
This is to prevent people form just holding their hands out and getting free points as we want this game to be excercise for patients.
This will give the extending movement they need to practice.
![alt text](https://github.com/StrokeVR/Balloon-Game/blob/master/Assets/Resources/BalloonGameCap.PNG)

The difficulty of the game is maintained based on the speed of the balloons as they ascend.
There are two ways to change the difficulty:
  • Through the physician view (not completed yet)
  • Most common is through playing the game. The game learn based on your score and updates the speed to keep you at the correct skill        level
  
  Example: The starting speed is 0.2 (20% is displayed to the user because it's cleaner and easier to read than a decimal)
           Each level has 10 balloon and if the player misses 0 the next level's speed is calculated like this 
           (totalBallons - (balloonsMissed or -1)) / totalBalloons * currentSpeed = (10 - (-1)) / 10 = 1.1 * 0.2 = 0.22 or 22%
           If the player missed no balloons then balloonsMissed is set to -1 to ensure we are increasing the speed. Otherwise it is the              number of balloons missed
           
           In other words the more balloons you miss the more your difficulty is affected. This keeps the user where they should be.
           This is also implemented in the plane game
