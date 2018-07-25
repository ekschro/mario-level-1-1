using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1 {
    public class TextureWarehouse
    {
        private static Texture2D marioTexture;
        private static Texture2D pickupTexture;
        private static Texture2D koopaTexture;
        private static Texture2D goombaTexture;
        private static Texture2D blockTexture;
        private static Texture2D stoneBlockTexture;
        private static Texture2D backgroundTexture;
        private static Texture2D fireballTexture;
        private static Texture2D flippedGoomba;
        private static Texture2D flippedKoopa;
        private static Texture2D castleTexture;
        private static Texture2D flagpoleTexture;
        private static Texture2D flagTexture;
        private static Texture2D blueStoneBlockTexture;
        private static Texture2D blueBrickBlockTexture;
        private static Texture2D pipeOnSideBlockTexture;
        private static Texture2D bowserTexture;
        private static Texture2D toadTexture;
        private static Texture2D anotherCastleTexture;
        private static Texture2D axeTexture;
        private static Texture2D openTexture;
        private static Texture2D movingPlatform;
        private static Texture2D enterTexture;
        private static Texture2D levelSelectTexture;
        private static Texture2D level11;
        private static Texture2D level14;
        private static Texture2D light;
        private static Texture2D darkMode;
        private static Texture2D normalMode;
        private static Texture2D bossLevelBackgroundTexture;
        private static Texture2D grayBrickBlockTexture;
        private static Texture2D bridgeBlockTexture;
        private static Texture2D bowserFireballTexture;

        public static Texture2D MarioTexture { get => marioTexture; }
        public static Texture2D PickupTexture { get => pickupTexture; }
        public static Texture2D KoopaTexture { get => koopaTexture; }
        public static Texture2D GoombaTexture { get => goombaTexture; }
        public static Texture2D BlockTexture { get => blockTexture; }
        public static Texture2D StoneBlockTexture { get => stoneBlockTexture; }
        public static Texture2D BackgroundTexture { get => backgroundTexture; }
        public static Texture2D FireballTexture { get => fireballTexture; }
        public static Texture2D FlippedGoomba { get => flippedGoomba; }
        public static Texture2D FlippedKoopa { get => flippedKoopa; }
        public static Texture2D CastleTexture { get => castleTexture; }
        public static Texture2D FlagpoleTexture { get => flagpoleTexture; }
        public static Texture2D FlagTexture { get => flagTexture; }
        public static Texture2D BlueStoneBlockTexture { get => blueStoneBlockTexture; }
        public static Texture2D BlueBrickBlockTexture { get => blueBrickBlockTexture; }
        public static Texture2D PipeOnSideBlockTexture { get => pipeOnSideBlockTexture; }
        public static Texture2D BowserTexture { get => bowserTexture; }
        public static Texture2D ToadTexture { get => toadTexture; }
        public static Texture2D AnotherCastleTexture { get => anotherCastleTexture; }
        public static Texture2D AxeTexture { get => axeTexture; }
        public static Texture2D OpenTexture { get => openTexture; }
        public static Texture2D MovingPlatform { get => movingPlatform; }
        public static Texture2D EnterTexture { get => enterTexture; }
        public static Texture2D LevelSelectTexture { get => levelSelectTexture; }
        public static Texture2D Level11 { get => level11; }
        public static Texture2D Level14 { get => level14; }
        public static Texture2D Light { get => light; }
        public static Texture2D DarkMode { get => darkMode; }
        public static Texture2D NormalMode { get => normalMode; }
        public static Texture2D BossLevelBackgroundTexture { get => bossLevelBackgroundTexture; }
        public static Texture2D GrayBrickBlockTexture { get => grayBrickBlockTexture; }
        public static Texture2D BridgeBlockTexture { get => bridgeBlockTexture; }
        public static Texture2D BowserFireballTexture { get => bowserFireballTexture; }

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
            fireballTexture = myGame.Content.Load<Texture2D>("fireball");
            flippedGoomba = myGame.Content.Load<Texture2D>("FlippedGoomba");
            flippedKoopa = myGame.Content.Load<Texture2D>("FlippedKoopa");
            castleTexture = myGame.Content.Load<Texture2D>("castle");
            flagpoleTexture = myGame.Content.Load<Texture2D>("flagpole");
            flagTexture = myGame.Content.Load<Texture2D>("flag");
            blueStoneBlockTexture = myGame.Content.Load<Texture2D>("blueStone");
            blueBrickBlockTexture = myGame.Content.Load<Texture2D>("blueBrick");
            pipeOnSideBlockTexture = myGame.Content.Load<Texture2D>("pipeOnSide");
            bowserTexture = myGame.Content.Load<Texture2D>("Bowser");
            toadTexture = myGame.Content.Load<Texture2D>("toad");
            anotherCastleTexture = myGame.Content.Load<Texture2D>("toadText");
            bossLevelBackgroundTexture = myGame.Content.Load<Texture2D>("1-4Background");
            grayBrickBlockTexture = myGame.Content.Load<Texture2D>("grayStone");
            bridgeBlockTexture = myGame.Content.Load<Texture2D>("bridge");
            movingPlatform = myGame.Content.Load<Texture2D>("MovingPlatform");
            openTexture = myGame.Content.Load<Texture2D>("Open");
            enterTexture = myGame.Content.Load<Texture2D>("Enter");
            levelSelectTexture = myGame.Content.Load<Texture2D>("LevelSelect");
            level11 = myGame.Content.Load<Texture2D>("level1");
            level14 = myGame.Content.Load<Texture2D>("Level14");
            light = myGame.Content.Load<Texture2D>("Light");
            darkMode = myGame.Content.Load<Texture2D>("DarkMode");
            normalMode = myGame.Content.Load<Texture2D>("NormalMode");
            axeTexture = myGame.Content.Load<Texture2D>("axe");
            bowserFireballTexture = myGame.Content.Load<Texture2D>("bowserFire");
        }
    }
}
