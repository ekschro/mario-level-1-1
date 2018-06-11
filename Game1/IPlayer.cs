using System;

namespace Game1
{
    public interface IPlayer : IGameObject
    {
       
        void Draw();
        void Update();
        float GetCurrentXPosition();
        void SetCurrentXPositon(float x);
        float GetCurrentYPosition();
        void SetCurrentYPosition(float y);
        void UpHeld();
        void DownHeld();
        void RightHeld();
        void LeftHeld();
    }
}