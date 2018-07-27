In Sprint 6 we added different feature. Including selecting which level to start and what kind of mode to play. The dark mode will limit mario vision and it can only see inside the circle. When player has select dark mode to play at level 1-1, the dark mode will continue after it went to level1-4.

We also added a level1-4. Inside level1-4, Bowser, Fire Chain enemy is also added. For Bowser, it will follow Mario and its action with a delay. If mario jump it will also jump and Bowser will regularly fire fireball. In order to win in level 1-4, Mario will need to pass through all obstacle, kill Bowser and get the axes to win the game.

Due to limited time, our team were not able to fix all the grader's comments.

In addition, the game is not that maintainable. There are still some magic numbers and strings all over.

--Warning Explaination--
CA1801 
Although location is never used it is use to separate two different parameter when creating a block

CA1823 
The BowserFireBall.dummyBool is needed as there are some methods that BowserFireBall don't have, so it is never used.

CA1822
There is no 'this' or 'me' parameter to be seen.  This warning was not understood.