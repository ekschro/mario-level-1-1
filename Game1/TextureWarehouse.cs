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
        public static Texture2D stoneBlockTexture;
        public static Texture2D backgroundTexture;
        public static Texture2D fireballs;
        public static Texture2D flippedGoomba;
        public static Texture2D flippedKoopa;
        public static Texture2D castleTexture;
        public static Texture2D flagpoleTexture;
        public static Texture2D flagTexture;


        Game1 myGame;
        public TextureWareHouse(Game1 game)
        {
            myGame = game;

            pickupTexture = myGame.Content.Load<Texture2D>("pickup");
            marioTexture = myGame.Content.Load<Texture2D>("marioRedux");
            koopaTexture = myGame.Content.Load<Texture2D>("koopa1");
            goombaTexture = myGame.Content.Load<Texture2D>("goomba1");
            blockTexture = myGame.Content.Load<Texture2D>("tiles");
            stoneBlockTexture = myGame.Content.Load<Texture2D>("stone");
            backgroundTexture = myGame.Content.Load<Texture2D>("1-1");
            fireballs = myGame.Content.Load<Texture2D>("fireball");
            flippedGoomba = myGame.Content.Load<Texture2D>("flippedGoomba");
            flippedKoopa = myGame.Content.Load<Texture2D>("flippedKoopa");
            castleTexture = myGame.Content.Load<Texture2D>("castle");
            flagpoleTexture = myGame.Content.Load<Texture2D>("flagpole");
            flagTexture = myGame.Content.Load<Texture2D>("flag");
        }
    }
}
