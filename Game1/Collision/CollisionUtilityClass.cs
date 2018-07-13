using System;

public class CollisionUtilityClass
{
    private int tileOffset = 16;
    private int mainHeight = 16;
    private int mainWidth = 16;
    private int smallWidth = 6;
    private int smallHeight = 6;
    private int two = 2;
    private int yMax = 800;
    private int size = 0;
    private int biggerHeight = 32;
    private int eight = 8;
    private int four = 4;
    private int lethalFall = 400;
    private int invulnerabilityFrames = 100;
    private int twentyfour = 24;
    private int one = 1;
    
	public CollisionUtilityClass()
	{
	}

    public int TileOffset { get => tileOffset; set => tileOffset = value; }
    public int MainHeight { get => mainHeight; set => mainHeight = value; }
    public int MainWidth { get => mainWidth; set => mainWidth = value; }
    public int SmallWidth { get => smallWidth; set => smallWidth = value; }
    public int SmallHeight { get => smallHeight; set => smallHeight = value; }
    public int Two { get => two; set => two = value; }
    public int YMax { get => yMax; set => yMax = value; }
    public int Size { get => size; set => size = value; }
    public int BiggerHeight { get => biggerHeight; set => biggerHeight = value; }
    public int Eight { get => eight; set => eight = value; }
    public int Four { get => four; set => four = value; }
    public int LethalFall { get => lethalFall; set => lethalFall = value; }
    public int InvulnerabilityFrames { get => invulnerabilityFrames; set => invulnerabilityFrames = value; }
    public int Twentyfour { get => twentyfour; set => twentyfour = value; }
    public int One { get => one; set => one = value; }
   
    
}
