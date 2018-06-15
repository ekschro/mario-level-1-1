using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IBlock : IGameObject
    {
        //Vector2 GameObjectLocation();
        void TopCollision();
        void BottomCollision();
        void LeftCollision();
        void RightCollision();

    }
}
