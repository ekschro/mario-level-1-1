using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class BowserSprite : IEnemySprite
    {
        private Bowser boswerObject;
        private Game1 myGame;
        private int currentFrame;
        private int startFrame;
        private int endFrame;
        private SpriteEffects boswerSpriteEffects;
        private EnemyUtilityClass utility;

        public SpriteEffects BoswerSpriteEffects { get => boswerSpriteEffects; set => boswerSpriteEffects = value; }
        public BowserSprite(Game1 game, Bowser bowser)
        {
            utility = new EnemyUtilityClass();
            boswerObject = bowser;
            myGame = game;
            startFrame = utility.BoswerStartFrame;
            endFrame = utility.BoswerEndFrame;
            currentFrame = startFrame;
            boswerSpriteEffects = SpriteEffects.None;
        }
        public void ChangeFrame(int start, int end)
        {
            startFrame = start;
            endFrame = end;
        }
        public void ChangeSpriteEffects(SpriteEffects effects)
        {
            boswerSpriteEffects = effects;
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == endFrame)
                currentFrame = startFrame;
        }

        public void Draw()
        {
            int width = TextureWarehouse.bowserTexture.Width / utility.BoswerColumn;

            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(boswerObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, TextureWarehouse.bowserTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)boswerObject.GetGameObjectLocation().Y, width, TextureWarehouse.bowserTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.bowserTexture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), boswerSpriteEffects, 0);
            myGame.SpriteBatch.End();
        }

        public void ChangeSpriteEffects()
        {
            throw new NotImplementedException();
        }
    }
}
