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
       
        bool IsFalling { get; set; }

        
        void SetGameObjectLocation(Vector2 x);
        void Collide();
        bool MovingRight();
    }
}
