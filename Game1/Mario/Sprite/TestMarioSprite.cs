﻿/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TestMarioSprite : ITestMarioSprite
    {
        private TestSmallMario marioObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        public IPlayer player2;

        public TestMarioSprite(Game1 game, TestSmallMario Mario, IPlayer player)
        {
            marioObject = Mario;
            myGame = game;
            startFrame = 14 + 28; //MarioSmllIdleRight
            endFrame = 2;
            currentFrame = startFrame;
            player2 = player;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }

        public void Update()
        {
            if (marioObject.GetStateMachine.FacingLeft())
            {
                currentFrame--;

            }
            else
            {
                currentFrame++;
            }
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWarehouse.marioTexture.Width / player2.TotalMarioColumns;
            int height = TextureWarehouse.marioTexture.Height / player2.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player2.TotalMarioColumns);
            int column = currentFrame % player2.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player2.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)player2.CurrentYPos, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, player2.MarioColor);
            myGame.SpriteBatch.End();
        }



        public Vector2 GetGameObjectLocation()
        {
            throw new NotImplementedException();
        }
    }
}
*/