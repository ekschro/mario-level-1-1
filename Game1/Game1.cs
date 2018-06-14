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
        public IController mouseController;
        public IList<IController> controllerList;
        public ILevel PlatformerLevel;
        //public int totalBlockFrames = 12;
        public TextureWareHouse warehouse;
        /*
        public Texture2D marioTexture;
        public Texture2D pickupTexture;
        public Texture2D koopaTexture;
        public Texture2D goombaTexture;
        public Texture2D blockTexture;
        */
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
      
        protected override void Initialize()
        {
            controllerList = new List<IController>();
            
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamePadController(this));
            mouseController = new MouseController(this);

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            warehouse = new TextureWareHouse(this);
            PlatformerLevel = new Level1("LevelInfo.csv", this);
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

            PlatformerLevel.Update();

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            PlatformerLevel.Draw();

            base.Draw(gameTime);
        }
    }
}
