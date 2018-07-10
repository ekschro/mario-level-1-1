using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Level1Background : IBackground
    {
        private Game1 myGame;
        private Vector2 backgroundLocation;

        public Level1Background(Game1 game, Vector2 location)
        {
            myGame = game;
            backgroundLocation = location;
        }

        public float CurrentXPos { get => backgroundLocation.X; set => backgroundLocation.X = value; }
        public float CurrentYPos { get => backgroundLocation.Y; set => backgroundLocation.Y = value; }

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(CurrentXPos);

            Rectangle sourceRectangle = new Rectangle(0, 0, TextureWarehouse.backgroundTexture.Width, TextureWarehouse.backgroundTexture.Height);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)GetGameObjectLocation().Y, TextureWarehouse.backgroundTexture.Width, TextureWarehouse.backgroundTexture.Height);

            myGame.SpriteBatch.Begin();
            //myGame.SpriteBatch.DrawString(myGame.SpriteFont, "Hello World", new Vector2(100, 100), Color.Black);
            myGame.SpriteBatch.Draw(TextureWarehouse.backgroundTexture, destinationRectangle, sourceRectangle, Color.White);
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
