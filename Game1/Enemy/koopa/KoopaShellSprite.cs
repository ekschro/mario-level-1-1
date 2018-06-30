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
        public KoopaShellSprite(Game1 game, IEnemy koopa)
        {
            koopaObject = koopa;
            myGame = game;
            currentFrame = 3;
        }
        public void ChangeFrame(int start, int end)
        {
        }
        public void FlipSprite()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
            int width = TextureWareHouse.koopaTexture.Width / 6;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(koopaObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.koopaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)koopaObject.GetGameObjectLocation().Y, width, TextureWareHouse.koopaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.koopaTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}
