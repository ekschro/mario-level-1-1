using System;
namespace Game1 {
    public interface ITestMarioSprite //: IGameObject
    {
        void ChangeFrame(int startFrame, int endFrame);
        void Update();
        void Draw();
        void Draw(int xOffset, int yOffset);
    }
}
