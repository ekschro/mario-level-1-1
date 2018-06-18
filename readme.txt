If solution does not run at first, copy "LevelInfo.csv" into both "Game1\bin\Windows\x86\Debug" and "Game1\bin\Windows\x86\Debug\Content" and the solution should build.

The star should work, but there is no visual indication of Mario being in the star state, as there was not enough time to implement it.

When passing through the hidden block from above, the block will trigger when Mario is about to exit the block, as this represents the state for a valid collision from below. However, once Mario physics are established, we can check if Mario is falling, and stop the trigger from occurring when Mario is falling.