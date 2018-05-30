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
        
        public Vector2 startingLocation = new Vector2(400, 200); 
        public Vector2 currentLocation = new Vector2(400, 200); 
        public int totalPickupFrames = 14;
        public Texture2D marioTexture;
        public Texture2D PickupTexture;
        public Texture2D koopaTexture;
        public Texture2D goombaTexture;
        public Texture2D blockTexture;

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

            
            blockTexture = Content.Load<Texture2D>("tiles");
            
            marioSprite = new MarioSmallIdleRight(this);

            FireflowerSprite = new FireflowerSprite(this);
            CoinSprite = new CoinSprite(this);
            RedMushroomSprite = new RedMushroomSprite(this);
            GreenMushroomSprite = new GreenMushroomSprite(this);
            StarSprite = new StarSprite(this);

            KoopaSprite = new Koopa(this);
            GoombaSprite = new Goomba(this);

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
