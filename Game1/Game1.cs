using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[assembly:CLSCompliant(true)]
namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public GameTime delta;
        private SpriteBatch spriteBatch;
        public IController mouseController;
        public IList<IController> controllerList;
        private ILevel currentLevel;
        //public int totalBlockFrames = 12;
        public TextureWareHouse warehouse;

        public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
        public ILevel CurrentLevel { get => currentLevel; set => currentLevel = value; }

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
            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 230;
            graphics.ApplyChanges();
            
            Content.RootDirectory = "Content";
        }
      
        protected override void Initialize()
        {
            controllerList = new List<IController>();
            
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamePadController(this));
            mouseController = new MouseController();

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            warehouse = new TextureWareHouse(this);
            CurrentLevel = new Level1("../../../../Content/LevelInfo.csv", this);
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
            foreach (IController controller in controllerList.ToArray())
                controller.Update();

            delta = gameTime;

            CurrentLevel.Update();

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(TextureWareHouse.backgroundTexture, new Rectangle(0, 0, 800, 480), Color.White);

            spriteBatch.End();

            CurrentLevel.Draw();

            base.Draw(gameTime);
        }
    }
}
