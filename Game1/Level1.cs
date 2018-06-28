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
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IPickup> pickups;
        private List<MarioFireBall> projectiles;
        public IPlayer PlayerObject { get => playerObject; set => playerObject = value; }
        public List<IBlock> BlockObjects { get => blocks; }
        public List<IEnemy> EnemyObjects { get => enemies; }
        public List<IPickup> PickupObjects { get => pickups; }
        public List<IGameObject> LevelObjects { get => levelObjects; }
        public List<MarioFireBall> ProjectileObjects { get => projectiles; set => projectiles = value; }

        public ICamera LevelCamera { get => levelCamera; set => levelCamera = value; }


        public Level1(string fileName, Game1 game)
        {
            myGame = game;
            levelObjects = new List<IGameObject>();
            ILoader loader = new LevelLoader(game);

            loader.Load(fileName, levelObjects);
            
            GetPlayerObjects();
            GetBlockObjects();
            GetEnemyObjects();
            GetPickupObjects();
            GeProjectileObjects();
            collisionDetect = new CollisionDetect(game,this);

            levelCamera = new Camera(this);
        }

        public void Update()
        {
            foreach (IGameObject GameObject in levelObjects)
            {
                if (GameObject.GetGameObjectLocation().X > levelCamera.CameraPosition - 16  && GameObject.GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    GameObject.Update();
            }

            collisionDetect.Update();
            levelCamera.Update();
            UpdateLevelObjects();
        }

        public void Draw()
        {
            foreach (IGameObject GameObject in levelObjects)
            {
                if (GameObject.GetGameObjectLocation().X > levelCamera.CameraPosition - 16 && GameObject.GetGameObjectLocation().X < levelCamera.CameraPosition + 400)
                    GameObject.Draw();
            }
        }

        private void GetPlayerObjects()
        {
            IPlayer playerObject = null;
            foreach(IGameObject player in levelObjects)
            {
                if (player is IPlayer)
                {
                    playerObject = (IPlayer)player;
                } break;
            }

            this.playerObject = playerObject;
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
        private void GeProjectileObjects()
        {
            List<MarioFireBall> projectiles = new List<MarioFireBall>();
            foreach (IGameObject projectile in levelObjects)
            {
                if (projectiles is MarioFireBall)
                    projectiles.Add((MarioFireBall)projectile);
            }
            this.projectiles = projectiles;
        }
        private void UpdateLevelObjects()
        {
            levelObjects = new List<IGameObject>();
            levelObjects.Add(PlayerObject);
            levelObjects.AddRange(BlockObjects);
            levelObjects.AddRange(PickupObjects);
            levelObjects.AddRange(EnemyObjects);
            levelObjects.AddRange(ProjectileObjects);
        }
    }
}
