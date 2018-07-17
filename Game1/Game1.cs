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
        public PersistentData persistentData;
        public GameTime temp;
        int counter = 0;
        private SoundWarehouse soundWarehouse;
        private ILevel currentLevel;
        private LevelTransition transitionLevel;
        private HeadsUpDisplay headsUpDisplay;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private bool pause;
        private bool allowControllerResponse;
        public enum GameScreenState { Transition, GamePlay }
        public GameScreenState GameState;
        private int cyclePosition = 0;
        private int cycleLength = 100;
        private int hudCounter = 0;
        private bool isEndSequence = false;
        private bool isPipeSequence = false;
        public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
        public SpriteFont SpriteFont { get => spriteFont; set => spriteFont = value; }
        public ILevel CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public HeadsUpDisplay HeadsUpDisplay { get => headsUpDisplay; set => headsUpDisplay = value; }
        public LevelTransition TransitionLevel { get => transitionLevel; set => transitionLevel = value; }
        internal SoundWarehouse SoundWarehouse { get => soundWarehouse; set => soundWarehouse = value; }
        public bool Pause { get => pause; set => pause = value; }
        public int HudCounter { get => hudCounter; set => hudCounter = value; }
        public bool AllowControllerResponse { get => allowControllerResponse; set => allowControllerResponse = value; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 230;
            graphics.ApplyChanges();
            pause = false;
            Content.RootDirectory = "Content";
            GameState = GameScreenState.Transition;
        }
      
        protected override void Initialize()
        {
            controllerList = new List<IController>();
            controllerHandler = new ControllerHandler();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamePadController(this));
            allowControllerResponse = true;
            persistentData = new PersistentData();
            //mouseController = new MouseController(this);
            
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TransitionLevel = new LevelTransition(this);
            HeadsUpDisplay = new HeadsUpDisplay(this);
            textureWarehouse = new TextureWarehouse(this);
            soundWarehouse = new SoundWarehouse(this);
            spriteFont = Content.Load<SpriteFont>("arial");
            CurrentLevel = new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
            MediaPlayer.Play(SoundWarehouse.main_theme);
        }

        public void Reset()
        {
            GameState = GameScreenState.Transition;
            cyclePosition = 0;
            allowControllerResponse = true;
            CurrentLevel = new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
            pause = false;
            currentLevel.PlayerObject.Invulnerability = false;
            MediaPlayer.Play(SoundWarehouse.main_theme);
        }

        public void GameReset()
        {
            GameState = GameScreenState.Transition;
            cyclePosition = 0;
            allowControllerResponse = true;
            persistentData = new PersistentData();
            CurrentLevel = new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
            pause = false;
            currentLevel.PlayerObject.Invulnerability = false;
            MediaPlayer.Play(SoundWarehouse.main_theme);
        }

        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList.ToArray())
            {
               controller.Update();
            }

            if (!Pause)
            {
                cyclePosition++;
                if (cyclePosition == cycleLength)
                {
                    GameState = GameScreenState.GamePlay;
                }

                delta = gameTime;
                PlatformerLevel level = (PlatformerLevel)currentLevel;
                if (counter == 60)
                {
                    level.DockTime();
                    counter = 0;
                }
                else
                {
                    counter++;
                }
                if (level.Time == 0)
                {
                    currentLevel.PlayerObject.TestMario.Downgrade();
                    currentLevel.PlayerObject.TestMario.Downgrade();
                    currentLevel.PlayerObject.TestMario.Downgrade();
                }
                //CurrentLevel.Update();
                HeadsUpDisplay.Update();
                switch (GameState)
                {
                    case GameScreenState.GamePlay:
                        CurrentLevel.Update();
                        break;
                }
                base.Update(gameTime);

            }
            
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            switch (GameState)
            {
                case GameScreenState.Transition:
                    transitionLevel.Draw();
                    break;
                case GameScreenState.GamePlay:
                    CurrentLevel.Draw();
                    break;
            }
            HeadsUpDisplay.Draw();
            base.Draw(gameTime);
        }
    }
}
