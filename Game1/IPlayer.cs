using System;

public interface IPlayer
{
    float GetCurrentXPosition();
    void SetCurrentXPositon(float x);
    float GetCurrentYPosition();
    void SetCurrentYPosition(float y);
    void Draw();
    void UpHeld();
    void DownHeld();
    void RightHeld();
    void LeftHeld();
    void Update();
}
