using System;
namespace Game1 {
    public interface ITestMarioSprite //: IGameObject
    {
        void ChangeFrame(int start, int end);
        void Update();
        void Draw();
    }
}
