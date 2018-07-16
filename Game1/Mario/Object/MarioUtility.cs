using System;

public class MarioUtility
{
    private int cyclePosition = 0;
    private int cycleLength = 8;
	public MarioUtility()
	{
	}

    public int CycleLength { get => cycleLength; }
    public int CyclePosition { get => cyclePosition; set => cyclePosition = value; }
}
