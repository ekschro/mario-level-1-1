using System;
using Microsoft.Xna.Framework;

namespace Game1 {
    public class MovingBlock : IBlock
    {
        //Game1 myGame;
        Vector2 start;
        float max;
        float min;
        bool forward;
        IBlockSprite sprite;
        int length = 24;

        public MovingBlock(Game1 game, Vector2 startLocation)
        {
            start = startLocation;
            max = startLocation.X + length;
            min = startLocation.X - length;
            //myGame = game;
            forward = true;
            sprite = new MovingBlockSprite(game, this);

        }

        public float CurrentXPos { get => start.X; set => start.X = value; }
        public float CurrentYPos { get => start.Y; set => start.Y = value; }

        public Rectangle BlockRectangle()
        {
            return new Rectangle((int) start.X, (int)start.Y, TextureWarehouse.MovingPlatform.Width, TextureWarehouse.MovingPlatform.Height);
        }

        public void Draw()
        {
            sprite.Draw();
        }

        public Vector2 GameObjectLocation => new Vector2(start.X, start.Y);

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
