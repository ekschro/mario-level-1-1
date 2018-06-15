using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class QuestionBlockSprite : IBlockSprite
    {
        private QuestionBlock questionBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private int numberOfFrame = 13;

        public QuestionBlockSprite(Game1 game, IBlock questionBlock)
        {
            questionBlockObject = (QuestionBlock)questionBlock;
            myGame = game;
            startFrame = 4;
            endFrame = 7;
            currentFrame = startFrame;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWareHouse.blockTexture.Width / numberOfFrame;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle((int)questionBlockObject.GameObjectLocation().X, (int)questionBlockObject.GameObjectLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.spriteBatch.Begin();
            myGame.spriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.spriteBatch.End();
        }
    }
}