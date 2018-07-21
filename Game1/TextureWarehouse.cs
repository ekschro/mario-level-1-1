using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1 {
    public class TextureWarehouse
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
        public static Texture2D blueStoneBlockTexture;
        public static Texture2D blueBrickBlockTexture;
        public static Texture2D pipeOnSideBlockTexture;
        public static Texture2D bowserTexture;
        public static Texture2D openTexture;
        public static Texture2D movingPlatform;
        public static Texture2D enterTexture;
        public static Texture2D levelSelectTexture;
        public static Texture2D level11;


        Game1 myGame;
        public TextureWarehouse(Game1 game)
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
            blueStoneBlockTexture = myGame.Content.Load<Texture2D>("blueStone");
            blueBrickBlockTexture = myGame.Content.Load<Texture2D>("blueBrick");
            pipeOnSideBlockTexture = myGame.Content.Load<Texture2D>("pipeOnSide");
            bowserTexture = myGame.Content.Load<Texture2D>("Bowser");
            movingPlatform = myGame.Content.Load<Texture2D>("movingPlatform");
            openTexture = myGame.Content.Load<Texture2D>("Open");
            enterTexture = myGame.Content.Load<Texture2D>("Enter");
            levelSelectTexture = myGame.Content.Load<Texture2D>("LevelSelect");
            level11 = myGame.Content.Load<Texture2D>("level1");
        }
    }
}
