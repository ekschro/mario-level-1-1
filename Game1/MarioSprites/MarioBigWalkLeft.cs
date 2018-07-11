﻿/*
using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    public class MarioBigWalkLeft : ISprite
    {
        public float CurrentXPos { get; set; }
        public float CurrentYPos { get; set; }

        private Game1 myGame;
        private IPlayer player;


        //private int currentFrame = 11;
        private int startFrame = 11;
        private int endFrame = 8;
        private int currentFrame;
        

        public MarioBigWalkLeft(Game1 game,IPlayer player)
        {
            myGame = game;
            this.player = player;
            currentFrame = startFrame;
        }


        public void Draw()
        {
            int width = TextureWarehouse.marioTexture.Width / player.TotalMarioColumns;
            int height = TextureWarehouse.marioTexture.Height / player.TotalMarioRows;
            int row = (int)((float)currentFrame / (float)player.TotalMarioColumns);
            int column = currentFrame % player.TotalMarioColumns;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(player.CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(width * column, (height * row), width, height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)player.CurrentYPos, width, height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.marioTexture, destinationRectangle, sourceRectangle, player.MarioColor);
            myGame.SpriteBatch.End();
        }

        public void UpCommandCalled()
        {
            player.MarioSprite = new MarioBigJumpingLeft(myGame, player);
        }

        public void DownCommandCalled()
        {
            player.MarioSprite = new MarioBigCrouchingLeft(myGame, player);
        }

        public void LeftCommandCalled()
        {
            currentFrame--;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
            //player.marioSprite = new MarioBigWalkLeftPart2(myGame);
        }

        public void RightCommandCalled()
        {
            player.MarioSprite = new MarioBigIdleLeft(myGame, player);
        }

        public void SmallMarioCommandCalled()
        {
            player.MarioSprite = new MarioSmallWalkLeft(myGame, player);
        }

        public void BigMarioCommandCalled()
        {

        }

        public void FireMarioCommandCalled()
        {
            player.MarioSprite = new MarioFireWalkLeft(myGame, player);
        }

        public void DeadMarioCommandCalled()
        {
            if (!(player.MarioSprite is MarioDead))
                player.MarioSprite = new MarioDead(myGame, player);
        }

        public void Update()
        {
            
        }
        public bool isSmall()
        {
            return false;
        }

        public bool isFire()
        {
            return false;
        }

        public bool isCrouching()
        {
            return false;
        }

        public Vector2 GetGameObjectLocation()
        {
            return new Vector2(player.CurrentXPos, player.CurrentYPos);
        }
    }
}*/