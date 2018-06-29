using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlippedGoomba : ITemporary
    {
        public float CurrentXPos { get => goombaOriginalLocation.X; set => goombaOriginalLocation.X = value; }
        public float CurrentYPos { get => goombaOriginalLocation.Y; set => goombaOriginalLocation.Y = value; }
        private ITemporarySprite goombaSprite;
        public ITemporarySprite GoombaSprite { get => goombaSprite; set => goombaSprite = value; }
        private Vector2 goombaOriginalLocation;

        public FlippedGoomba(Game1 game, Vector2 location)
        {
            goombaOriginalLocation = location;
            GoombaSprite = new FlippedGoombaSprite(game, this);
        }
        

        public Vector2 GetGameObjectLocation()
        {
            return goombaOriginalLocation;
        }

        public void Update()
        {
            GoombaSprite.Update();
        }

        public void Draw()
        {
            GoombaSprite.Draw();
        }
    }
}
