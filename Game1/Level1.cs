using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Game1
{
    public class Level1 : ILevel
    {
        private List<IGameObject> levelObjects;
        private ICollision collisionDetect;
        private ICamera levelCamera;
        private Game1 myGame;

        private IPlayer playerObject;
        private IBackground backgroundObject;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IPickup> pickups;
        private List<MarioFireBall> projectiles;
        public IPlayer PlayerObject { get => playerObject; set => playerObject = value; }
        public IBackground BackgroundObject { get => backgroundObject; set => backgroundObject = value; }
        public List<IBlock> BlockObjects { get => blocks; }
        public List<IEnemy> EnemyObjects { get => enemies; }
        public List<IPickup> PickupObjects { get => pickups; }
        public List<IGameObject> LevelObjects { get => levelObjects; }
        

        public ICamera LevelCamera { get => levelCamera; set => levelCamera = value; }


        public Level1(string fileName, Game1 game)
        {
            myGame = game;
            levelObjects = new List<IGameObject>();
            ILoader loader = new LevelLoader(game);

            loader.Load(fileName, levelObjects);
            
            GetPlayerObject();
            GetBackgroundObject();
            GetBlockObjects();
            GetEnemyObjects();
            GetPickupObjects();
            
            collisionDetect = new CollisionDetect(game,this);

            levelCamera = new Camera(this);
            backgroundObject = new Level1Background(myGame, new Vector2(0,0));
        }

        public void Update()
        {
            PlayerObject.Update();
            foreach (IGameObject GameObject in BlockObjects)
            {
                if (GameObject.GetGameObjectLocation().X > levelCamera.CameraPosition - 16  && GameObject.GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    GameObject.Update();
                else if (GameObject is StoneBlock)
                    GameObject.Update();
            }
            foreach (IGameObject GameObject in EnemyObjects)
            {
                if (GameObject.GetGameObjectLocation().X > levelCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    GameObject.Update();
            }
            IGameObject[] pickupObjectArray = PickupObjects.ToArray();
            for(int i = 0; i < pickupObjectArray.Length; i++)
            {
                if (pickupObjectArray[i].GetGameObjectLocation().X > levelCamera.CameraPosition - 16 && pickupObjectArray[i].GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    pickupObjectArray[i].Update();
            }

            levelCamera.Update();

            collisionDetect.Update();
            //UpdateLevelObjects();
        }

        public void Draw()
        {
            BackgroundObject.Draw();
            PlayerObject.Draw();
            foreach (IGameObject GameObject in BlockObjects)
            {
                if (GameObject.GetGameObjectLocation().X > levelCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    GameObject.Draw();
                else if (GameObject is StoneBlock)
                    GameObject.Update();
            }
            foreach (IGameObject GameObject in EnemyObjects)
            {
                if (GameObject.GetGameObjectLocation().X > levelCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    GameObject.Draw();
            }
            foreach (IGameObject GameObject in PickupObjects)
            {
                if (GameObject.GetGameObjectLocation().X > levelCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    GameObject.Draw();
            }
        }

        private void GetPlayerObject()
        {
            IPlayer playerObject = null;
            foreach(IGameObject player in levelObjects)
            {
                if (player is IPlayer)
                {
                    playerObject = (IPlayer)player;
                } 
            }

            this.playerObject = playerObject;
        }
        private void GetBackgroundObject()
        {
            IBackground backgroundObject = null;
            foreach (IGameObject background in levelObjects)
            {
                if (background is IBackground)
                {
                    backgroundObject = (IBackground)background;
                }
            }

            this.backgroundObject = backgroundObject;
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
        
        private void UpdateLevelObjects()
        {
            levelObjects = new List<IGameObject>();
            levelObjects.Add(PlayerObject);
            levelObjects.Add(BackgroundObject);
            levelObjects.AddRange(BlockObjects);
            levelObjects.AddRange(PickupObjects);
            levelObjects.AddRange(EnemyObjects);
            
        }
    }
}
