using System;

public interface IPlayer : IGameObject
{
    int GetCurrentXPosition();
    void SetCurrentXPositon(int x);
    int GetCurrentYPosition();
    void SetCurrentYPosition(int y);
    
}
