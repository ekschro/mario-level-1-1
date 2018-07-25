﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class MarioLight
    {
        private Game1 myGame;
        private int xPosition;
        private int yPosition;
        public MarioLight(Game1 game)
        {
            myGame = game;
        }
        public void Update()
        {
            xPosition = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(myGame.CurrentLevel.PlayerObject.TestMario.CurrentXPos);
            yPosition = (int)myGame.CurrentLevel.PlayerObject.TestMario.CurrentYPos;
            
        }
        public void Draw()
        {
            
            Rectangle lightRectangle = new Rectangle(xPosition-436, yPosition-302, TextureWarehouse.light.Width, TextureWarehouse.light.Height);
            Rectangle lightSourceRectangle = new Rectangle(0, 0, TextureWarehouse.light.Width, TextureWarehouse.light.Height);
            myGame.SpriteBatch.Begin();
           
            myGame.SpriteBatch.Draw(TextureWarehouse.light, lightRectangle, lightSourceRectangle,Color.White);
            myGame.SpriteBatch.End();
        }
    }
}