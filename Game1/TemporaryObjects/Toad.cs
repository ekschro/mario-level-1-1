using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Toad : ITemporary
    {
        private Game1 myGame;

        private Vector2 position;
        private ToadSprite toadSprite;

        public float CurrentXPos { get => position.X; set => position.X = value; }
        public float CurrentYPos { get => position.Y; set => position.Y = value; }

        public Toad(Game1 game, Vector2 location)
        {
            myGame = game;
            position = location;
            toadSprite = new ToadSprite(game, this);
        }
       
        public Vector2 GetGameObjectLocation()
        {
            return position;
        }

        public void Update()
        {
            toadSprite.Update();
        }

        public void Draw()
        {
            toadSprite.Draw();
        }
    }
}
