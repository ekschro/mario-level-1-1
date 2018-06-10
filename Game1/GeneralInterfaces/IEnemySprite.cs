using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IEnemySprite
    {
        void Update();
        void ChangeFrame(int start, int end);
        void Draw();
    }
}
