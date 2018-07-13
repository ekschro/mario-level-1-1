using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class BrickBlockWithManyCoins : IBlock
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private IBlockSprite brickBlockSprite;
        //private Game1 myGame;
        private Vector2 blockLocation;

        private int coinsLeft;
        private Rectangle blockRectangle;
        private BlockUtilityClass utility;
        public int CoinsLeft { get => coinsLeft; set => coinsLeft = value; }

        public BrickBlockWithManyCoins(Game1 game, Vector2 location)
        {
            brickBlockSprite = new BrickBlockSprite(game, this);
            //myGame = game;
            blockLocation = location;
            utility = new BlockUtilityClass();
            coinsLeft = utility.CoinsLeft;
            blockRectangle = new Rectangle((int)location.X, (int)location.Y, utility.Width, utility.Height);
        }

        public void Draw()
        {
            brickBlockSprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return blockLocation;
        }

        public Rectangle BlockRectangle()
        {
            return blockRectangle;
        }

        public void Update()
        {
            brickBlockSprite.Update();
            
        }
        

        public void Bounce()
        {
            ((BrickBlockSprite)brickBlockSprite).Bounce();
        }
    }
}
