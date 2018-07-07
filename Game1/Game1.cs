using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Media;

[assembly:CLSCompliant(true)]
namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public GameTime delta;
        public IController mouseController;
        public IList<IController> controllerList;
        public IControllerHandler controllerHandler;
        public TextureWarehouse textureWarehouse;

        private SoundWarehouse soundWarehouse;
        private ILevel currentLevel;
        private SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
        public ILevel CurrentLevel { get => currentLevel; set => currentLevel = value; }
        internal SoundWarehouse SoundWarehouse { get => soundWarehouse; set => soundWarehouse = value; }

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
            
            controllerHandler = new ControllerHandler();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamePadController(this));
            //mouseController = new MouseController(this);
            
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CurrentLevel = new Level1("../../../../Content/LevelInfo.csv", this);

            textureWarehouse = new TextureWarehouse(this);
            soundWarehouse = new SoundWarehouse(this);

            MediaPlayer.Play(SoundWarehouse.main_theme);
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

            CurrentLevel.Draw();

            base.Draw(gameTime);
        }
    }
}
