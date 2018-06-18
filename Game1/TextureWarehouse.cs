using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1 {
    public class TextureWareHouse
    {
        public static Texture2D marioTexture;
        public static Texture2D pickupTexture;
        public static Texture2D koopaTexture;
        public static Texture2D goombaTexture;
        public static Texture2D blockTexture;
        public static Texture2D backgroundTexture;

        Game1 myGame;
        public TextureWareHouse(Game1 game)
        {
            myGame = game;

            pickupTexture = myGame.Content.Load<Texture2D>("pickup");
            marioTexture = myGame.Content.Load<Texture2D>("marioRedux");
            koopaTexture = myGame.Content.Load<Texture2D>("koopa1");
            goombaTexture = myGame.Content.Load<Texture2D>("goomba1");
            blockTexture = myGame.Content.Load<Texture2D>("tiles");
            backgroundTexture = myGame.Content.Load<Texture2D>("background");

        }
    }
}
