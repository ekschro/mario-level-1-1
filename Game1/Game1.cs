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
        private GameTime delta;
        public GameTime Delta { get => delta; }
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
        private LevelGameOver gameOverLevel;
        private LevelOpeningScreen openingLevel;
        private LevelSelect selectLevel;
        private MarioLight light;
        private HeadsUpDisplay headsUpDisplay;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private bool pause;
        private bool allowControllerResponse;
        public enum GameScreenState { Transition, GamePlay, Dead, Opening, LevelSelect, DarkLevel11 }
        private GameScreenState gameState;
        public GameScreenState GameState { get => gameState; set => gameState = value; }
        private int cyclePosition = 0;
        private int cycleLength = 200;
        private int hudCounter = 0;
        public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
        public SpriteFont SpriteFont { get => spriteFont; set => spriteFont = value; }
        public ILevel CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public HeadsUpDisplay HeadsUpDisplay { get => headsUpDisplay; set => headsUpDisplay = value; }
        //internal SoundWarehouse SoundWarehouse { get => soundWarehouse; set => soundWarehouse = value; }
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
            gameState = GameScreenState.Opening;
        }
      
        protected override void Initialize()
        {
            controllerList = new List<IController>();
            controllerHandler = new ControllerHandler();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamePadController(this));
            allowControllerResponse = true;
            persistentData = new PersistentData(this);
            //mouseController = new MouseController(this);
            
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            transitionLevel = new LevelTransition(this);
            selectLevel = new LevelSelect(this);
            gameOverLevel = new LevelGameOver(this);
            openingLevel = new LevelOpeningScreen(this);
            light = new MarioLight(this);
            HeadsUpDisplay = new HeadsUpDisplay(this);
            textureWarehouse = new TextureWarehouse(this);
            soundWarehouse = new SoundWarehouse(this);
            spriteFont = Content.Load<SpriteFont>("arial");
            CurrentLevel = new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
            MediaPlayer.Play(SoundWarehouse.main_theme);
        }

        public void Reset()
        {
            gameState = GameScreenState.Transition;
            cyclePosition = 0;
            allowControllerResponse = true;
            CurrentLevel = new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
            pause = false;
            currentLevel.PlayerObject.Invulnerability = false;
            if (persistentData.Lives > 1)
                MediaPlayer.Play(SoundWarehouse.main_theme);
            else
                MediaPlayer.Play(SoundWarehouse.game_over_theme);
        }

        public void GameReset()
        {
            LoadTransition();
            cyclePosition = 0;
            allowControllerResponse = true;
            persistentData = new PersistentData(this);
            CurrentLevel = new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
            pause = false;
            currentLevel.PlayerObject.Invulnerability = false;
            MediaPlayer.Play(SoundWarehouse.main_theme);
        }

        public void CheckGameOver(PlatformerLevel level)
        {
            if (persistentData.Lives == 0)
            {
                gameState = GameScreenState.Dead;
            }
            else if (level.Time == 0)
            {
                currentLevel.PlayerObject.TestMario.GoDie();
            }

        }
        public void LoadTransition()
        {
            cyclePosition = 0;
            gameState = GameScreenState.Transition;
        }
        public void DarkStage()
        {
            GameState = GameScreenState.DarkLevel11;
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
            switch (gameState)
            {
                case GameScreenState.Opening:
                    openingLevel.Update();
                    break;
                case GameScreenState.LevelSelect:
                    selectLevel.Update();   
                    break;
                case GameScreenState.GamePlay:
                    if (!pause)
                    {
                        CurrentLevel.Update();
                    }
                    break;
                case GameScreenState.DarkLevel11:
                    if (!pause)
                    {
                        CurrentLevel.Update();
                        light.Update();
                    }
                    break;
            }
            if (!Pause&& gameState!=GameScreenState.Opening && gameState != GameScreenState.LevelSelect )
            {
                cyclePosition++;
                if (cyclePosition == cycleLength && gameState == GameScreenState.Transition)
                {
                    gameState = GameScreenState.GamePlay;
                }
                
                delta = gameTime;
                PlatformerLevel level = (PlatformerLevel)currentLevel;
                if (counter == 60 && !level.TimerStop)
                {
                    level.DockTime();
                    counter = 0;
                }
                else
                    counter++;
                CheckGameOver(level);
                HeadsUpDisplay.Update();
                base.Update(gameTime);
            }            
        }
       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            switch (gameState)
            {
                case GameScreenState.Opening:
                    HeadsUpDisplay.Draw();
                    openingLevel.Draw();
                    break;
                case GameScreenState.Transition:
                    transitionLevel.Draw();
                    HeadsUpDisplay.Draw();
                    break;
                case GameScreenState.GamePlay:
                    currentLevel.Draw();
                    HeadsUpDisplay.Draw();
                    break;
                case GameScreenState.Dead:
                    gameOverLevel.Draw();
                    break;
                case GameScreenState.LevelSelect:
                    selectLevel.Draw();
                    break;
                case GameScreenState.DarkLevel11:
                    currentLevel.Draw();
                    light.Draw();
                    HeadsUpDisplay.Draw();
                    break;
            }
            
            base.Draw(gameTime);
        }
    }
}
