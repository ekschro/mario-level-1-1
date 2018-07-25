using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class PlatformerLevelBackground : IBackground
    {
        private Game1 myGame;
        private Vector2 backgroundLocation;

        public PlatformerLevelBackground(Game1 game, Vector2 location)
        {
            myGame = game;
            backgroundLocation = location;
        }

        public float CurrentXPos { get => backgroundLocation.X; set => backgroundLocation.X = value; }
        public float CurrentYPos { get => backgroundLocation.Y; set => backgroundLocation.Y = value; }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWarehouse.BackgroundTexture.Width, TextureWarehouse.BackgroundTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)GetGameObjectLocation().Y, TextureWarehouse.BackgroundTexture.Width, TextureWarehouse.BackgroundTexture.Height);

            myGame.SpriteBatch.Begin();
            myGame.SpriteBatch.Draw(TextureWarehouse.BackgroundTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }

        public Vector2 GetGameObjectLocation()
        {
            return backgroundLocation;
        }

        public void Update()
        {
            
        }
    }
}
