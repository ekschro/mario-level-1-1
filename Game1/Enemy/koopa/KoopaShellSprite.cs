using System;
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
        public KoopaShellSprite(Game1 game, IEnemy koopa)
        {
            koopaObject = koopa;
            myGame = game;
            startFrame = 4;
            endFrame = 6;
            currentFrame = startFrame;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
            currentFrame = startFrame;
        }
        public void FlipSprite()
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
            int width = TextureWarehouse.koopaTexture.Width / 6;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(koopaObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.koopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)koopaObject.GetGameObjectLocation().Y, width, TextureWarehouse.koopaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
