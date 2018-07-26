using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlippedBowser : ITemporary
    {
        public float CurrentXPos { get => koopaOriginalLocation.X; set => koopaOriginalLocation.X = value; }
        public float CurrentYPos { get => koopaOriginalLocation.Y; set => koopaOriginalLocation.Y = value; }
        private ITemporarySprite bowserSprite;
        public ITemporarySprite BowserSprite { get => bowserSprite; set => bowserSprite = value; }
        private Vector2 koopaOriginalLocation;

        public FlippedBowser(Game1 game, Vector2 location)
        {
            koopaOriginalLocation = location;
            BowserSprite = new FlippedBowserSprite(game, this);
        }


        public Vector2 GameObjectLocation => koopaOriginalLocation;

        public void Update()
        {
            bowserSprite.Update();
        }

        public void Draw()
        {
            bowserSprite.Draw();
        }
    }
}
