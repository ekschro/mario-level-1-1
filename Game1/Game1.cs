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
        public IBlockSprite Block6Sprite;
        public IBlockSprite PipeBlock1Sprite;
        public IBlockSprite PipeBlock2Sprite;
        public IBlockSprite PipeBlock3Sprite;
        public IBlockSprite PipeBlock4Sprite;

        public Vector2 Block1Location = new Vector2(200, 200);
        public Vector2 Block2Location = new Vector2(220, 200);
        public Vector2 Block3Location = new Vector2(240, 200);
        public Vector2 Block4Location = new Vector2(260, 200);
        public Vector2 Block5Location = new Vector2(280, 200);
        public Vector2 Block6Location = new Vector2(300, 200);

        public Vector2 Pipe1Location = new Vector2(340, 200);
        public Vector2 Pipe2Location = new Vector2(356, 200);
        public Vector2 Pipe3Location = new Vector2(340, 216);
        public Vector2 Pipe4Location = new Vector2(356, 216);

        public ArrayList controllerList;
        
        public Vector2 startingLocation = new Vector2(400, 200); 
        public Vector2 currentLocation = new Vector2(400, 200); 
        public int totalPickupFrames = 14;
        public int totalBlockFrames = 12;
        public Texture2D marioTexture;
        public Texture2D PickupTexture;
        public Texture2D koopaTexture;
        public Texture2D goombaTexture;
        public Texture2D blockTexture;

        public bool LeftPressed;
        public bool RightPressed;
        public bool UpPressed;
        public bool DownPressed;

        public int totalMarioColumns = 28;
        public int totalMarioRows = 3;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            LeftPressed = false;
            RightPressed = false;
            UpPressed = false;
            DownPressed = false;
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
            Block6Sprite = new HiddenBlockSprite(this);
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

            marioSprite.Update();


            FireflowerSprite.Update();
            CoinSprite.Update();
            RedMushroomSprite.Update();
            GreenMushroomSprite.Update();
            StarSprite.Update();

            //KoopaSprite.BeStomped();
            //GoombaSprite.BeStomped();
            KoopaSprite.Update();
            GoombaSprite.Update();

            Block1Sprite.Update();
            Block2Sprite.Update();
            Block3Sprite.Update();
            Block4Sprite.Update();
            Block5Sprite.Update();
            Block6Sprite.Update();
            PipeBlock1Sprite.Update();
            PipeBlock2Sprite.Update();
            PipeBlock3Sprite.Update();
            PipeBlock4Sprite.Update();

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

            Block1Sprite.Draw(Block1Location);
            Block2Sprite.Draw(Block2Location);
            Block3Sprite.Draw(Block3Location);
            Block4Sprite.Draw(Block4Location);
            Block5Sprite.Draw(Block5Location);
            Block6Sprite.Draw(Block6Location);
            PipeBlock1Sprite.Draw(Pipe1Location);
            PipeBlock2Sprite.Draw(Pipe2Location);
            PipeBlock3Sprite.Draw(Pipe3Location);
            PipeBlock4Sprite.Draw(Pipe4Location);


            base.Draw(gameTime);
        }
    }
}
