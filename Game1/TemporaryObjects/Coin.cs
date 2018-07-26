using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Coin : ITemporary
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private ITemporarySprite coinSprite;
        private Game1 myGame;
        private Vector2 objectLocation;
        private int timeBeforeDisappearing;

        public Coin(Game1 game, Vector2 location)
        {
            coinSprite = new CoinSprite(game, this);
            myGame = game;
            objectLocation = location;
            timeBeforeDisappearing = 20;
        }

        public void Draw()
        {
                coinSprite.Draw();
        }

        public void Update()
        {
            objectLocation.Y -= 1;

            timeBeforeDisappearing--;

            if (timeBeforeDisappearing <= 0)
                myGame.CurrentLevel.TemporaryObjects.Remove(this);
        }

        public Vector2 GameObjectLocation => objectLocation;
    }
}
