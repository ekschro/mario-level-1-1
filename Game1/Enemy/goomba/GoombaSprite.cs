using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class GoombaSprite : IEnemySprite
    {
        private Goomba goombaObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private SpriteEffects GoombaSpriteEffects;

        public GoombaSprite(Game1 game,Goomba goomba)
        {
            goombaObject = goomba;
            myGame = game;
            startFrame = 0;
            endFrame = 2;
            currentFrame = startFrame;
            GoombaSpriteEffects = SpriteEffects.None;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }
        public void FlipSprite()
        {
            GoombaSpriteEffects = SpriteEffects.FlipVertically;
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWareHouse.goombaTexture.Width / 4;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(goombaObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWareHouse.goombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)goombaObject.GetGameObjectLocation().Y, width, TextureWareHouse.goombaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWareHouse.goombaTexture, destinationRectangle, sourceRectangle, Color.White,0,new Vector2(0,0), GoombaSpriteEffects, 0);
            myGame.SpriteBatch.End();
        }
    }
}
