using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    
    
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
        
        public Vector2 startingLocation = new Vector2(400, 200); 
        public Vector2 currentLocation = new Vector2(400, 200); 
        public int totalPickupFrames = 14;
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

        
        protected override void Initialize()
        {
            
            controllerList = new ArrayList();
            
            controllerList.Add(new KeyboardController(this));

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            
            PickupTexture = Content.Load<Texture2D>("pickup");
            marioTexture = Content.Load<Texture2D>("mario");
            koopaTexture = Content.Load<Texture2D>("koopa1");
            goombaTexture = Content.Load<Texture2D>("goomba1");

            
            marioSprite = new MarioSmallIdleRight(this);
            FireflowerSprite = new FireflowerSprite(this);
            CoinSprite = new CoinSprite(this);
            RedMushroomSprite = new RedMushroomSprite(this);
            GreenMushroomSprite = new GreenMushroomSprite(this);
            StarSprite = new StarSprite(this);
            KoopaSprite = new Koopa(this);
            GoombaSprite = new Goomba(this);
            
        }

        
        protected override void UnloadContent()
        {
            
        }

        
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
