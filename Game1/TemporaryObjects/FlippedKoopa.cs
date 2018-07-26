using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FlippedKoopa : ITemporary
    {
        public float CurrentXPos { get => koopaOriginalLocation.X; set => koopaOriginalLocation.X = value; }
        public float CurrentYPos { get => koopaOriginalLocation.Y; set => koopaOriginalLocation.Y = value; }
        private ITemporarySprite koopaSprite;
        public ITemporarySprite KoopaSprite { get => koopaSprite; set => koopaSprite = value; }
        private Vector2 koopaOriginalLocation;

        public FlippedKoopa(Game1 game, Vector2 location)
        {
            koopaOriginalLocation = location;
            KoopaSprite = new FlippedKoopaSprite(game, this);
        }


        public Vector2 GameObjectLocation => koopaOriginalLocation;

        public void Update()
        {
            KoopaSprite.Update();
        }

        public void Draw()
        {
            KoopaSprite.Draw();
        }
    }
}
