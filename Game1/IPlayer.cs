using System;

namespace Game1
{
    public interface IPlayer : IGameObject
    {
        float GetCurrentXPosition();
        void SetCurrentXPositon(float x);
        float GetCurrentYPosition();
        void SetCurrentYPosition(float y);
        void Update();
        void Draw();
        void UpdHeld();
        void DownHeld();
        void RightHeld();
        void LeftHeld();
    }
}