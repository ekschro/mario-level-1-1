In Sprint 6 we added several different features. Included are a level select, and a unique way to play for veteran players: dark mode. The dark mode will limit mario's vision by only allowing him to see inside the circle.

We also added Level 1-4. Inside Level 1-4, Bowser and the Fire Chain enemy are also added. Bowser will follow Mario and its action with a delay. If mario jumps, he will also jump will regularly fire fireball. In order to win in Level 1-4, Mario will need to pass through all obstacles, kill Bowser and get the axe to win the game.

Due to limited time, our team were not able to fix all the grader's comments.

In addition, the game has maintainability issues. There are still some magic numbers and strings in the code.

--Warning Explaination--
CA1801 
Although location is never used it is use to separate two different parameter when creating a block

CA1823 
The BowserFireBall.dummyBool is needed as there are some methods that BowserFireBall don't have, so it is never used. To alter code so these methods wouldn't be called would result in very tight coupling.

CA1822
While 'this' is never used explicitly, it is used implicitly for particular instances.