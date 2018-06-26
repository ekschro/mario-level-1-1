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
    public class QuestionPowerUpBlockSprite : IBlockSprite
    {
        private QuestionPowerUpBlock questionPowerUpBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private int numberOfFrame = 13;

        public QuestionPowerUpBlockSprite(Game1 game, IBlock questionPowerUpBlock)
        {
            questionPowerUpBlockObject = (QuestionPowerUpBlock)questionPowerUpBlock;
            myGame = game;
            startFrame = 4;
            endFrame = 7;
            currentFrame = startFrame;
            //jumpig = true;
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

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(questionPowerUpBlockObject.GameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)questionPowerUpBlockObject.GameObjectLocation().Y, width, TextureWareHouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public bool isJumping()
        {
            throw new NotImplementedException();
        }
    }
}