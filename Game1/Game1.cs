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

        public IEnemy KoopaSprite;
        public IEnemy GoombaSprite;

        ArrayList controllerList;
        //public int totalFrames = 8; <= might be better in indiviual classes? Since each item will have its own spritesheet
        public Vector2 startingLocation = new Vector2(400, 200); 
        public Vector2 currentLocation = new Vector2(400, 200); 
        public int totalPickupFrames = 14; //if there is individual class later will change later
        //public Vector2 startingLocation = new Vector2(400, 200); <= same here
        //public Vector2 currentLocation = new Vector2(400, 200);  <= same here
        public Texture2D marioTexture;
        public Texture2D PickupTexture;
        public Texture2D koopaTexture;
        public Texture2D goombaTexture;

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
            koopaTexture = Content.Load<Texture2D>("koopa1");
            goombaTexture = Content.Load<Texture2D>("goomba1");

            // INITIALIZE ALL SPRITES HERE
            marioSprite = new MarioSmallIdleRight(this);
            FireflowerSprite = new FireflowerSprite(this);
            CoinSprite = new CoinSprite(this);
            RedMushroomSprite = new RedMushroomSprite(this);
            GreenMushroomSprite = new GreenMushroomSprite(this);
            StarSprite = new StarSprite(this);
            KoopaSprite = new Koopa(this);
            GoombaSprite = new Goomba(this);
            
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

            KoopaSprite.BeStomped();
            GoombaSprite.BeStomped();
            KoopaSprite.Update();
            GoombaSprite.Update();
            
            

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

            KoopaSprite.Draw();
            GoombaSprite.Draw();
            

            base.Draw(gameTime);
        }
    }
}
