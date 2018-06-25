using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IGameObject
    {
        void Update();
        void Draw();
        Vector2 GameObjectLocation();
        float CurrentXPos { get; set; }
        float CurrentYPos { get; set; }
    }
}
