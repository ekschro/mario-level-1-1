﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class FlippedBowserSprite : ITemporarySprite
    {
        private FlippedBowser koopaObject;
        private Game1 myGame;

        private float bouncePosition;
        private float bounceVelocity;
        private float bounceGravity;
       

        public FlippedBowserSprite(Game1 game, FlippedBowser koopa)
        {
            koopaObject = koopa;
            myGame = game;

            bouncePosition = 0f;
            bounceVelocity = -3.0f;
            bounceGravity = .07f;
           
        }

        public void Update()
        {
            Bounce();
        }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(koopaObject.CurrentXPos);
            int drawLocationY = (int)(koopaObject.CurrentYPos + bouncePosition);

            Rectangle sourceRectangle = new Rectangle(0,0,(int)TextureWarehouse.FlippedGoomba.Width, (int)TextureWarehouse.FlippedGoomba.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, drawLocationY, (int)TextureWarehouse.FlippedGoomba.Width, (int)TextureWarehouse.FlippedGoomba.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.FlippedGoomba, destinationRectangle, sourceRectangle, Color.DarkGray, 0, new Vector2(0, 0), SpriteEffects.None, 0);
            myGame.SpriteBatch.End();
        }
        public void Bounce()
        {
            bounceVelocity += bounceGravity;
            bouncePosition += bounceVelocity;
        }
    }
}
