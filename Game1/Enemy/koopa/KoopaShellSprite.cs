﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class KoopaShellSprite : IEnemySprite
    {
        private IEnemy koopaObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private EnemyUtilityClass utility;
        public KoopaShellSprite(Game1 game, IEnemy koopa)
        {
            utility = new EnemyUtilityClass();
            koopaObject = koopa;
            myGame = game;
            
            startFrame = utility.KoopaShellStartFrame;
            endFrame = utility.KoopaShellEndFrame;
            currentFrame = startFrame;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
            currentFrame = startFrame;
        }

        public void ChangeSpriteEffects(SpriteEffects effects)
        {
           
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWarehouse.KoopaTexture.Width / utility.KoopaColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(koopaObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.KoopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)koopaObject.GameObjectLocation.Y, width, TextureWarehouse.KoopaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.KoopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

    }
}
