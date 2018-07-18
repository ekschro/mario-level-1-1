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
    public class QuestionCoinBlockSprite : IBlockSprite
    {
        private IBlock questionCoinBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        //private int numberOfFrame;
        private BlockUtilityClass utility;

        public QuestionCoinBlockSprite(Game1 game, IBlock questionCoinBlock)
        {
            utility = new BlockUtilityClass();
            questionCoinBlockObject = (QuestionCoinBlock)questionCoinBlock;
            myGame = game;
            startFrame = utility.StartFrame;
            endFrame = utility.EndFrame;
            currentFrame = startFrame;
            //numberOfFrame = utility.Thirteen;
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
            int width = TextureWarehouse.blockTexture.Width / utility.BlockColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(questionCoinBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, utility.InitialFrame, width, TextureWarehouse.blockTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)questionCoinBlockObject.GetGameObjectLocation().Y, width, TextureWarehouse.blockTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.blockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
        /*
        public bool isJumping()
        {
            throw new NotImplementedException();
        }
        */
    }
}