If solution does not run at first, copy "LevelInfo.csv" into both "Game1\bin\Windows\x86\Debug" 
and "Game1\bin\Windows\x86\Debug\Content" and the solution should build.

The star should work, but there is no visual indication of Mario being in the star state, as 
there was not enough time to implement it.

When passing through the hidden block from above, the block will trigger when Mario is about 
to exit the block, as this represents the state for a valid collision from below. However, 
once Mario physics are established, we can check if Mario is falling, and stop the trigger 
from occurring when Mario is falling.

The team plan on taking all of the grader's comments into consideration for Sprint 4.  Due to a shortage 
of time (one day) the team was unable to make some of the drastic changes required to satisfy them all.

-- Warning Explaination --

CA1002:
    The compiler wants all cases where we use the List<T> conatiner to be changed to Collection<T>,
    ReadOnlyCollection<T>, or KeyedCollection<K,V>.  We've been told that we can use List<T> so we've 
    disregarded this warning.

CA1030:
    The compiler wants the FireMarioCommandCalled() method to be made into an event.  For the sake of 
    consistency we've decided to ignore this for the time being.  But this has been taken into consider-
    ation for Sprint 4.

CA1051:
    Plans to modify how the fields are accessed are planned for Sprint 4 to remove these warnings.

CA1500:
    This same name warning comes up.  We have made plans for Sprint 4 to rework our naming convention.

CA1822:
    There is no 'this' or 'me' parameter to be seen.  This warning was not understood.

CA1823:
    Graphic is used by the framework, the compiler is just not aware.

CA2211:
    The MarioColor feild is currently being shared as a public static field to dependent classes.  To get
    rid of this warning we plan to share this as a property and protect the field itself by making it 
    private.
    