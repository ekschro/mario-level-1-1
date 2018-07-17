using System;

public class BlockUtilityClass
{
    private int coinsLeft = 10;
    private int width = 16;
    private int height = 16;
    private int pipeWidth = 48;
    private int pipeHeight = 32;
    private int cyclePosition = 0;
    private int cycleLength = 8;
    private int questionCoinLength = 16;
    private int blockColumn = 13;
    private int zero = 0;
    private int ten = 10;
    private int eleven = 11;
    private int two = 2;
    private int four = 4;
    private int seven = 7;
    private int thirteen = 13;
    private int one = 1;
    private int eight = 8;
    private int three = 3;
    public BlockUtilityClass()
    {

    }
    public int CoinsLeft { get => coinsLeft; set => coinsLeft = value; }
    public int Width { get => width; }
    public int Height { get => height; }
    public int PipeWidth { get => pipeWidth; }
    public int PipeHeight { get => pipeHeight; }
    public int QuestionCyclePosition { get => cyclePosition; set => cyclePosition = value; }
    public int QuestionCycleLength { get => cycleLength; }
    public int QuestionCoinLength { get => questionCoinLength; }
    public int BlockColumn { get => blockColumn; }
    public int jumpDistanceOrCurrentFrame { get => ten; set => ten = value; }
    public int InitialFrame { get => zero; set => zero = value; }
    public int CurrentFrame { get => eleven; set => eleven = value; }
    public int Two { get => two; set => two = value; }
    public int StartFrame { get => four; set => four = value; }
    public int EndFrame { get => seven; set => seven = value; }
    public int Thirteen { get => thirteen; set => thirteen = value; }
    public int CurrentFrame2 { get => one; set => one = value; }
    public int CurrentFrame3 { get => eight; set => eight = value; }
    public int CurrentFrame4 { get => three; set => three = value; }
}
