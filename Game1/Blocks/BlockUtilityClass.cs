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
    public BlockUtilityClass()
    {

    }
    public int CoinsLeft { get => coinsLeft; set => coinsLeft = value; }
    public int Width { get => width; set => width = value; }
    public int Height { get => height; set => height = value; }
    public int PipeWidth { get => pipeWidth; set => pipeWidth = value; }
    public int PipeHeight { get => pipeHeight; set => pipeHeight = value; }
    public int QuestionCyclePosition { get => cyclePosition; set => cyclePosition = value; }
    public int QuestionCycleLength { get => cycleLength; set => cycleLength = value; }
    public int QuestionCoinLength { get => questionCoinLength; set => questionCoinLength = value; }
}
