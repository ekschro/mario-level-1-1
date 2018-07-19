using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IEnemySprite
    {
        void Update();
        void ChangeFrame(int start, int endFrame);
        //void FlipSprite();
        //void ChangeDirectionSprite();
        void ChangeSpriteEffects(SpriteEffects effects);
        void Draw();
    }
}
