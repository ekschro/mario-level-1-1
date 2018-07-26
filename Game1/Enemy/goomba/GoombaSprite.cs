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
        
        private EnemyUtilityClass utility;
        public GoombaSprite(Game1 game,Goomba goomba)
        {
            utility = new EnemyUtilityClass();
            goombaObject = goomba;
            myGame = game;
            startFrame = utility.GoombaStartFrame;
            endFrame = utility.GoombaEndFrame;
            
            currentFrame = startFrame;
            GoombaSpriteEffects = SpriteEffects.None;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }

        public void ChangeSpriteEffects(SpriteEffects effects)
        {
            GoombaSpriteEffects = effects;
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWarehouse.GoombaTexture.Width / utility.GoombaColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(goombaObject.GameObjectLocation.X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.GoombaTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)goombaObject.GameObjectLocation.Y, width, TextureWarehouse.GoombaTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.GoombaTexture, destinationRectangle, sourceRectangle, Color.White,0,new Vector2(0,0), GoombaSpriteEffects, 0);
            myGame.SpriteBatch.End();
        }

        
    }
}
