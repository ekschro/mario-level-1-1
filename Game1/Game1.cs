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
        private TextureWarehouse textureWarehouse;
        public PersistentData persistentData;
        
        int counter = 0;
        private SoundWarehouse soundWarehouse;
        private ILevel currentLevel;
        private LevelTransition transitionLevel;
        private LevelGameOver gameOverLevel;
        private LevelOpeningScreen openingLevel;
        private LevelSelect selectLevel;
        private MarioLight Light;
        private HeadsUpDisplay headsUpDisplay;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private bool pause;
        private bool allowControllerResponse;
        public enum GameScreenState { Transition, GamePlay, Dead, Opening, LevelSelect, DarkLevel11 }
        private bool timerStop = false;
        private GameScreenState gameState;
        private GameScreenState lastGameState;
        private bool nextLevel = false;
        public GameScreenState GameState { get => gameState; set => gameState = value; }
        private int cyclePosition = 0;
        private int cycleLength = 200;
        private int hudCounter = 0;
        public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
        public SpriteFont SpriteFont { get => spriteFont; set => spriteFont = value; }
        public ILevel CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public HeadsUpDisplay HeadsUpDisplay { get => headsUpDisplay; set => headsUpDisplay = value; }
        
        public bool TimerStop { get => timerStop; set => timerStop = value; }
        public bool Pause { get => pause; set => pause = value; }
        public int HudCounter { get => hudCounter; set => hudCounter = value; }
        public bool AllowControllerResponse { get => allowControllerResponse; set => allowControllerResponse = value; }
        public bool NextLevel1 { get => nextLevel; set => nextLevel = value; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 230;
            graphics.ApplyChanges();
            pause = false;
            Content.RootDirectory = "Content";
            gameState = GameScreenState.Opening;
            lastGameState = GameScreenState.GamePlay;
        }
      
        protected override void Initialize()
        {
            controllerList = new List<IController>();
            controllerHandler = new ControllerHandler();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamePadController(this));
            allowControllerResponse = true;
            persistentData = new PersistentData(this);
            
            
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            transitionLevel = new LevelTransition(this);
            selectLevel = new LevelSelect(this);
            gameOverLevel = new LevelGameOver(this);
            openingLevel = new LevelOpeningScreen(this);
            Light = new MarioLight(this);
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
            CurrentLevel = GetNewLevel();
            pause = false;
            currentLevel.PlayerObject.Invulnerability = false;
            if (persistentData.Lives > 1) { }
                //MediaPlayer.Play(SoundWarehouse.main_theme);
            else
                MediaPlayer.Play(SoundWarehouse.game_over_theme);
        }

        public void GameReset()
        {
            gameState = GameScreenState.Opening;
            lastGameState = GameScreenState.GamePlay;
            NextLevel1 = false;
            cyclePosition = 0;
            allowControllerResponse = true;
            persistentData = new PersistentData(this);
            CurrentLevel = new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
            pause = false;
            currentLevel.PlayerObject.Invulnerability = false;
            MediaPlayer.Play(SoundWarehouse.main_theme);
            selectLevel = new LevelSelect(this);
            openingLevel = new LevelOpeningScreen(this);
        }

        public void CheckGameOver(ILevel level)
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
            gameState = GameScreenState.DarkLevel11;
            lastGameState = gameState;
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
                    lastGameState = GameScreenState.GamePlay;
                    break;
                case GameScreenState.DarkLevel11:
                    if (!pause)
                    {
                        CurrentLevel.Update();
                        Light.Update();
                    }
                    lastGameState = GameScreenState.DarkLevel11;
                    break;
            }
            if (!Pause&& gameState!=GameScreenState.Opening && gameState != GameScreenState.LevelSelect )
            {
                cyclePosition++;
                if (cyclePosition == cycleLength && gameState == GameScreenState.Transition)
                {
                    gameState = lastGameState;
                }
                
                delta = gameTime;
                if (counter == 60 && !TimerStop)
                {
                    currentLevel.DockTime();
                    counter = 0;
                }
                else
                    counter++;
                CheckGameOver(currentLevel);
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
                    
                    openingLevel.Draw();
                    HeadsUpDisplay.Draw();
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
                    Light.Draw();
                    HeadsUpDisplay.Draw();
                    break;
            }
            
            base.Draw(gameTime);
        }

        public void NextLevel()
        {
            if (currentLevel is PlatformerLevel)
            {
                currentLevel = new BossLevel("../../../../Content/BossLevelInfo.csv", this, persistentData);
                NextLevel1 = true;
            }

        }

        private ILevel GetNewLevel()
        {
            if (currentLevel is PlatformerLevel)
            {
                NextLevel1 = false;
                MediaPlayer.Play(SoundWarehouse.main_theme);
                return new PlatformerLevel("../../../../Content/LevelInfo.csv", this, persistentData);
                
            }
            else
            {
                NextLevel1 = true;
                MediaPlayer.Play(SoundWarehouse.castle_theme);
                return new BossLevel("../../../../Content/BossLevelInfo.csv", this, persistentData);
                
            }
        }
    }
}
