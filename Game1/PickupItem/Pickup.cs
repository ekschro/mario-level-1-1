using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Pickup
    {
        private int cyclePosition = 0;
        private int cycleLength = 16;

        public static FireflowerSprite fireflowerSprite;
        public static GreenMushroomSprite greenMushroomSprite;
        public static RedMushroomSprite redMushroomSprite;
        public static StarSprite starSprite;
        public static CoinSprite coinSprite;

        public static FireflowerSprite FireflowerSprite { get => fireflowerSprite; set => fireflowerSprite = value; }
        public static GreenMushroomSprite GreenMushroomSprite { get => greenMushroomSprite; set => greenMushroomSprite = value; }
        public static RedMushroomSprite RedMushroomSprite { get => redMushroomSprite; set => redMushroomSprite = value; }
        public static StarSprite StarSprite { get => starSprite; set => starSprite = value; }
        public static CoinSprite CoinSprite { get => coinSprite; set => coinSprite = value; }


        private Game1 myGame;
        public Vector2 pickupLocation;

        public Pickup (Game1 game, Vector2 location)
        {
            FireflowerSprite = new FireflowerSprite(game, this);
            GreenMushroomSprite = new GreenMushroomSprite(game,this);
            RedMushroomSprite = new RedMushroomSprite(game, this);
            StarSprite = new StarSprite(game, this);
            CoinSprite = new CoinSprite(game, this);
            myGame = game;
            pickupLocation = location;
        }

        public void Draw()
        {
            cyclePosition++;
            if (cyclePosition == cycleLength)
            {
                cyclePosition = 0;
                FireflowerSprite.Draw();
                GreenMushroomSprite.Draw();
                RedMushroomSprite.Draw();
                StarSprite.Draw();
                CoinSprite.Draw();
            }
        }

        public Vector2 GetCurrentLocation()
        {
            return pickupLocation;
        }

        public void Update()
        {
            FireflowerSprite.Update();
            GreenMushroomSprite.Update();
            RedMushroomSprite.Update();
            StarSprite.Update();
            CoinSprite.Update();
        }
    }
}

