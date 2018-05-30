using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    
    /// Tim was here
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public ISprite marioSprite;

        public IPickupSprite FireflowerSprite;
        public IPickupSprite CoinSprite;
        public IPickupSprite RedMushroomSprite;
        public IPickupSprite GreenMushroomSprite;
        public IPickupSprite StarSprite;

        public IBlockSprite Block1Sprite;
        public IBlockSprite Block2Sprite;
        public IBlockSprite Block3Sprite;
        public IBlockSprite Block4Sprite;
        public IBlockSprite Block5Sprite;
        public IBlockSprite PipeBlock1Sprite;
        public IBlockSprite PipeBlock2Sprite;
        public IBlockSprite PipeBlock3Sprite;
        public IBlockSprite PipeBlock4Sprite;


        ArrayList controllerList;
        //public int totalFrames = 8; <= might be better in indiviual classes? Since each item will have its own spritesheet
        public Vector2 startingLocation = new Vector2(400, 200); 
        public Vector2 currentLocation = new Vector2(400, 200); 
        public int totalPickupFrames = 14; //if there is individual class later will change later
        //public Vector2 startingLocation = new Vector2(400, 200); <= same here
        //public Vector2 currentLocation = new Vector2(400, 200);  <= same here
        public Texture2D marioTexture;
        public Texture2D PickupTexture;
        public Texture2D blockTexture;

        public int totalMarioColumns = 28;
        public int totalMarioRows = 3;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controllerList = new ArrayList();
            //controllerList.Add(new GamePadController(this));
            controllerList.Add(new KeyboardController(this));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // LOAD ALL TEXTURES HERE
            
            PickupTexture = Content.Load<Texture2D>("pickup");
            marioTexture = Content.Load<Texture2D>("mario");
            blockTexture = Content.Load<Texture2D>("tiles");

            // INITIALIZE ALL SPRITES HERE
            marioSprite = new MarioSmallIdleRight(this);

            FireflowerSprite = new FireflowerSprite(this);
            CoinSprite = new CoinSprite(this);
            RedMushroomSprite = new RedMushroomSprite(this);
            GreenMushroomSprite = new GreenMushroomSprite(this);
            StarSprite = new StarSprite(this);


            Block1Sprite = new StairBlockSprite(this);
            Block2Sprite = new UsedBlockSprite(this);
            Block3Sprite = new QuestionBlockSprite(this);
            Block4Sprite = new BrickBlockSprite(this);
            Block5Sprite = new StoneBlockSprite(this);
            PipeBlock1Sprite = new TopLeftPipeSprite(this);
            PipeBlock2Sprite = new TopRightPipeSprite(this);
            PipeBlock3Sprite = new BottomLeftPipeSprite(this);
            PipeBlock4Sprite = new BottomRightPipeSprite(this);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
                controller.Update();

            //marioSprite.Update();
            FireflowerSprite.Update();
            CoinSprite.Update();
            RedMushroomSprite.Update();
            GreenMushroomSprite.Update();
            StarSprite.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            marioSprite.Draw();
            FireflowerSprite.Draw();
            CoinSprite.Draw();
            RedMushroomSprite.Draw();
            GreenMushroomSprite.Draw();
            StarSprite.Draw();

            base.Draw(gameTime);
        }
    }
}
