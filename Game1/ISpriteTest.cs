using System;
namespace Game1 {
    public interface ISpriteTest : IGameObject
    {
        void ChangeFrame();
        void Update();
        void Draw();
    }
}
