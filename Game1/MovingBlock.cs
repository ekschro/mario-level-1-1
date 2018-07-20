using System;
using Microsoft.Xna.Framework;

namespace Game1 {
    public class MovingBlock : IBlock
    {
        Game1 myGame;
        Vector2 start;
        float max;
        float min;
        bool forward;
        IBlockSprite sprite;
        public MovingBlock(Vector2 startLocation,int length, Game1 game)
        {
            start = startLocation;
            max = startLocation.X + length;
            min = startLocation.X - length;
            myGame = game;
            forward = true;
            sprite = new MovingBlockSprite(game, this);

        }

        public float CurrentXPos { get => start.X; set => start.X = value; }
        public float CurrentYPos { get => start.Y; set => start.Y = value; }

        public Rectangle BlockRectangle()
        {
            return new Rectangle((int) start.X, (int)start.Y, TextureWarehouse.movingPlatform.Width, TextureWarehouse.movingPlatform.Height);
        }

        public void Draw()
        {
            sprite.Draw();
        }

        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(start.X, start.Y);
        }

        public void Update()
        {
            if (forward)
            {
                start.X += 1;
            } else
            {
                start.X -= 1;
            }
            if (start.X == max)
            {
                forward = false;
            } else if (start.X == min)
            {
                forward = true;
            }
        }
    }
}
