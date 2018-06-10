using System;

namespace Game1
{
    public interface IPlayer : IGameObject
    {
       
        void Draw();
        void Update();
    }
}