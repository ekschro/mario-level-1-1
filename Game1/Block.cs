using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Block : IGameObject
    {
        private Vector2 blockPosition;
        private IBlockSprite blockType;
        private Game1 myGame;
        public Block(Vector2 position, Game1 game, IBlockSprite block)
        {
            blockPosition = position;
            blockType = block;
            myGame = game;
        }

        public void Update()
        {
            blockType.Update();
        }

        public void Draw()
        { 
            int width = myGame.blockTexture.Width / myGame.totalBlockFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, myGame.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)blockObject.BlockLocation().X, (int)blockObject.BlockLocation().X, width, myGame.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(myGame.blockTexture, destinationRectangle, sourceRectangle, Color.Transparent);
            myGame.spriteBatch.End();
        }

        public Vector2 BlockLocation()
        {
            return blockPosition;
        }
    }
}
