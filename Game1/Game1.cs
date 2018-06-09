using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace Game1
{
    

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public ISprite marioSprite;

        public IPickupSprite fireflowerSprite;
        public IPickupSprite coinSprite;
        public IPickupSprite redMushroomSprite;
        public IPickupSprite greenMushroomSprite;
        public IPickupSprite starSprite;

        public IEnemy koopa;
        public IEnemy goomba;

        public IPlayer marioObject;

        public IBlockSprite blockStairSprite;
        public IBlockSprite blockUsedSprite;
        public IBlockSprite blockQuestionSprite;
        public IBlockSprite blockBrickSprite;
        public IBlockSprite blockStoneSprite;
        public IBlockSprite blockHiddenSprite;
        public IBlockSprite pipeBlockTopRightSprite;
        public IBlockSprite pipeBlockTopLeftSprite;
        public IBlockSprite pipeBlockBottomRightSprite;
        public IBlockSprite pipeBlockBottomLeftSprite;

        public IList<IController> controllerList;
        
        public Vector2 startingLocation = new Vector2(400, 200); 
        public Vector2 currentLocation = new Vector2(400, 200); 
        public int totalPickupFrames = 14;
        public int totalBlockFrames = 12;
        public Texture2D marioTexture;
        public Texture2D pickupTexture;
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

            controllerList = new List<IController>();
            
            controllerList.Add(new KeyboardController(this));

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            
            pickupTexture = Content.Load<Texture2D>("pickup");
            marioTexture = Content.Load<Texture2D>("mario");
            koopaTexture = Content.Load<Texture2D>("koopa1");
            goombaTexture = Content.Load<Texture2D>("goomba1");

            
            blockTexture = Content.Load<Texture2D>("tiles");
            
            marioSprite = new MarioSmallIdleRight(this);

            fireflowerSprite = new FireflowerSprite(this, new Vector2(100,100));
            coinSprite = new CoinSprite(this, new Vector2(150,100));
            redMushroomSprite = new RedMushroomSprite(this, new Vector2(200,100));
            greenMushroomSprite = new GreenMushroomSprite(this, new Vector2(250,100));
            starSprite = new StarSprite(this, new Vector2(300,100));

            koopa = new Koopa(this, new Vector2(400,100));
            goomba = new Goomba(this, new Vector2(450, 100));

            marioObject = new Mario(this, currentLocation);

            blockStairSprite = new StairBlockSprite(this, new Vector2(200, 200));
            blockUsedSprite = new UsedBlockSprite(this, new Vector2(220, 200));
            blockQuestionSprite = new QuestionBlockSprite(this, new Vector2(240, 200));
            blockBrickSprite = new BrickBlockSprite(this, new Vector2(260, 200));
            blockStoneSprite = new StoneBlockSprite(this, new Vector2(280, 200));
            blockHiddenSprite = new HiddenBlockSprite(this, new Vector2(300, 200));
            pipeBlockTopLeftSprite = new TopLeftPipeSprite(this, new Vector2(340, 200));
            pipeBlockTopRightSprite = new TopRightPipeSprite(this, new Vector2(356, 200));
            pipeBlockBottomLeftSprite = new BottomLeftPipeSprite(this, new Vector2(340, 216));
            pipeBlockBottomRightSprite = new BottomRightPipeSprite(this, new Vector2(356, 216));

    }

        public void Reset()
        {
            LoadContent();
        }

        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
                controller.Update();

            marioSprite.Update();


            fireflowerSprite.Update();
            coinSprite.Update();
            redMushroomSprite.Update();
            greenMushroomSprite.Update();
            starSprite.Update();

            koopa.Update();
            goomba.Update();

            blockStairSprite.Update();
            blockUsedSprite.Update();
            blockQuestionSprite.Update();
            blockBrickSprite.Update();
            blockStoneSprite.Update();
            blockHiddenSprite.Update();
            pipeBlockTopRightSprite.Update();
            pipeBlockTopLeftSprite.Update();
            pipeBlockBottomRightSprite.Update();
            pipeBlockBottomLeftSprite.Update();

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            marioSprite.Draw();
            fireflowerSprite.Draw();
            coinSprite.Draw();
            redMushroomSprite.Draw();
            greenMushroomSprite.Draw();
            starSprite.Draw();

            koopa.Draw();
            goomba.Draw();

            blockStairSprite.Draw();
            blockUsedSprite.Draw();
            blockQuestionSprite.Draw();
            blockBrickSprite.Draw();
            blockStoneSprite.Draw();
            blockHiddenSprite.Draw();
            pipeBlockTopRightSprite.Draw();
            pipeBlockTopLeftSprite.Draw();
            pipeBlockBottomRightSprite.Draw();
            pipeBlockBottomLeftSprite.Draw();

            base.Draw(gameTime);
        }
    }
}
