using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Game1
{
    public class PlatformerLevel : ILevel
    {
        private const int secretRoomLocation = 3408;

        private List<IGameObject> levelObjects;
        private ICollision collisionDetect;
        private ICamera movingCamera;
        private ICamera staticCamera;
        private ICamera currentCamera;
        private Game1 myGame;
        private PersistentData persistentData;
        private IPlayer playerObject;
        private IBackground backgroundObject;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IPickup> pickups;
        private List<ITemporary> temporaries;
        private bool timerStop = false;
        private Vector2 secretEntrance;
        private Vector2 secretExit;

        public IPlayer PlayerObject { get => playerObject; set => playerObject = value; }
        public IBackground BackgroundObject { get => backgroundObject; set => backgroundObject = value; }
        public List<IBlock> BlockObjects { get => blocks; }
        public List<IEnemy> EnemyObjects { get => enemies; }
        public List<IPickup> PickupObjects { get => pickups; }
        public List<ITemporary> TemporaryObjects { get => temporaries; }
        public List<IGameObject> LevelObjects { get => levelObjects; }
        private int time;
        public int Time { get => time; }
        public ICamera LevelCamera { get => currentCamera; set => currentCamera = value; }
        public PersistentData PersistentData { get => persistentData; }
        public int EndLocation { get => 3292; }
        public bool TimerStop { get => timerStop; set => timerStop = value; }

        public PlatformerLevel(string fileName, Game1 game, PersistentData persistantData)
        {
            myGame = game;
            this.persistentData = persistantData;
            levelObjects = new List<IGameObject>();
            ILoader loader = new LevelLoader(game);

            secretEntrance = new Vector2(3432, 14);
            secretExit = new Vector2(2616, 142);

        
            time = 365;
            loader.Load(fileName, levelObjects);
            
            GetPlayerObject();
            GetBackgroundObject();
            GetBlockObjects();
            GetEnemyObjects();
            GetPickupObjects();
            GetTemporaryObjects();


            collisionDetect = new CollisionDetect(game,this);

            currentCamera = movingCamera = new Camera(this);
            staticCamera = new CameraStatic(this, secretRoomLocation);

            /*
             * DEBUG
             */
            //currentCamera = staticCamera;
            /*
             * DEBUG
             */

            backgroundObject = new PlatformerLevelBackground(myGame, new Vector2(0,0));
        }

        public void Update()
        {
            PlayerObject.Update();
            foreach (IGameObject GameObject in BlockObjects)
            {
                if (GameObject.GetGameObjectLocation().X > currentCamera.CameraPosition - 16  && GameObject.GetGameObjectLocation().X < currentCamera.CameraPosition + 400)
                    GameObject.Update();
                else if (GameObject is StoneBlock)
                    GameObject.Update();
            }
            foreach (IGameObject GameObject in EnemyObjects)
            {
                if (GameObject.GetGameObjectLocation().X > currentCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < currentCamera.CameraPosition + 400)
                    GameObject.Update();
            }
            IGameObject[] pickupObjectArray = PickupObjects.ToArray();
            for(int i = 0; i < pickupObjectArray.Length; i++)
            {
                if (pickupObjectArray[i].GetGameObjectLocation().X > currentCamera.CameraPosition - 16 && pickupObjectArray[i].GetGameObjectLocation().X < currentCamera.CameraPosition + 400)
                    pickupObjectArray[i].Update();
            }
            IGameObject[] temporaryObjectArray = TemporaryObjects.ToArray();
            for (int i = 0; i < temporaryObjectArray.Length; i++)
            {
                if (temporaryObjectArray[i].GetGameObjectLocation().X > currentCamera.CameraPosition - 16 && temporaryObjectArray[i].GetGameObjectLocation().X < currentCamera.CameraPosition + 400)
                    temporaryObjectArray[i].Update();
            }

            currentCamera.Update();

            collisionDetect.Update();
        }

        public void Draw()
        {
            BackgroundObject.Draw();
            PlayerObject.Draw();
            foreach (IGameObject GameObject in BlockObjects)
            {
                if (GameObject.GetGameObjectLocation().X > currentCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < currentCamera.CameraPosition + 400)
                    GameObject.Draw();
                else if (GameObject is StoneBlock)
                    GameObject.Draw();
            }
            foreach (IGameObject GameObject in EnemyObjects)
            {
                if (GameObject.GetGameObjectLocation().X > currentCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < currentCamera.CameraPosition + 400)
                    GameObject.Draw();
            }
            foreach (IGameObject GameObject in PickupObjects)
            {
                if (GameObject.GetGameObjectLocation().X > currentCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < currentCamera.CameraPosition + 400)
                    GameObject.Draw();
            }
            IGameObject[] temporaryObjectArray = TemporaryObjects.ToArray();
            for (int i = 0; i < temporaryObjectArray.Length; i++)
            {
                temporaryObjectArray[i].Draw();
            }
        }

        private void GetPlayerObject()
        {
            foreach(IGameObject player in levelObjects)
            {
                if (player is IPlayer)
                {
                    playerObject = (IPlayer)player;
                } 
            }
        }
        private void GetBackgroundObject()
        {
            foreach (IGameObject background in levelObjects)
            {
                if (background is IBackground)
                {
                    backgroundObject = (IBackground)background;
                }
            }
        }
        private void GetBlockObjects()
        {
            List<IBlock> blockObjects = new List<IBlock>();
            foreach (IGameObject block in levelObjects)
            {
                if(block is IBlock)
                    blockObjects.Add((IBlock)block);
            }
            this.blocks = blockObjects;
        }
        private void GetEnemyObjects()
        {
            List<IEnemy> enemyObjects = new List<IEnemy>();
            foreach (IGameObject enemy in levelObjects)
            {
                if(enemy is IEnemy)
                    enemyObjects.Add((IEnemy)enemy);
            }
            this.enemies = enemyObjects;
        }
        private void GetPickupObjects()
        {
            List<IPickup> pickupObjects = new List<IPickup>();
            foreach (IGameObject pickup in levelObjects)
            {
                if(pickup is IPickup)
                    pickupObjects.Add((IPickup)pickup);
            }
            this.pickups = pickupObjects;
        }

        private void GetTemporaryObjects()
        {
            List<ITemporary> temporaryObjects = new List<ITemporary>();
            foreach (IGameObject temporary in levelObjects)
            {
                if (temporary is ITemporary)
                    temporaryObjects.Add((ITemporary)temporary);
            }
            this.temporaries = temporaryObjects;
        }
        /*
        private void UpdateLevelObjects()
        {
            levelObjects = new List<IGameObject>();
            levelObjects.Add(PlayerObject);
            levelObjects.Add(BackgroundObject);
            levelObjects.AddRange(BlockObjects);
            levelObjects.AddRange(PickupObjects);
            levelObjects.AddRange(EnemyObjects);
            LevelObjects.AddRange(TemporaryObjects);
        }
        */
        public void WarpToSecret()
        {
            playerObject.CurrentXPos = secretEntrance.X;
            playerObject.CurrentYPos = secretEntrance.Y;
            currentCamera = staticCamera;
        }

        public void WarpFromSecret()
        {
            playerObject.CurrentXPos = secretExit.X;
            playerObject.CurrentYPos = secretExit.Y;
            currentCamera = movingCamera;
        }
        public void DockTime()
        {
            time--;
        }

    }
}
