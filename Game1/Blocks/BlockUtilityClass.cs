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
}
