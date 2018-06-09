using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface ISprite : IGameObject
    {
        void Update();
        void Draw();
        void UpCommandCalled();
        void DownCommandCalled();
        void LeftCommandCalled();
        void RightCommandCalled();
        void SmallMarioCommandCalled();
        void BigMarioCommandCalled();
        void FireMarioCommandCalled();
        void DeadMarioCommandCalled();
    }  
}