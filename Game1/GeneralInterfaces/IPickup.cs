using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IPickup : IGameObject
    {
        //object GetStateMachine { get; set; }
        bool IsFalling { get; set; }

        //Vector2 GetGameObjectLocation();
        void SetGameObjectLocation(Vector2 x);
        void Collide();
        bool MovingRight();
    }
}
