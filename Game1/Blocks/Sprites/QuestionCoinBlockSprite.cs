﻿using System;

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
        private QuestionCoinBlock questionCoinBlockObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private int numberOfFrame = 13;

        public QuestionCoinBlockSprite(Game1 game, IBlock questionCoinBlock)
        {
            questionCoinBlockObject = (QuestionCoinBlock)questionCoinBlock;
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
            int width = TextureWarehouse.blockTexture.Width / numberOfFrame;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(questionCoinBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.blockTexture.Height);
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