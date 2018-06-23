﻿using System.Collections.Generic;

namespace Game1
{
    public class Level1 : ILevel
    {
        private List<IGameObject> levelObjects;
        private ICollision collisionDetect;

        private IPlayer playerObject;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IPickup> pickups;

        public IPlayer PlayerObject { get => playerObject; set => playerObject = value; }
        public List<IBlock> BlockObjects { get => blocks; }
        public List<IEnemy> EnemyObjects { get => enemies; }
        public List<IPickup> PickupObjects { get => pickups; }

        public Level1(string fileName, Game1 game)
        {
            levelObjects = new List<IGameObject>();
            ILoader loader = new LevelLoader(game);

            loader.Load(fileName, levelObjects);

            GetPlayerObjects();
            GetBlockObjects();
            GetEnemyObjects();
            GetPickupObjects();

            collisionDetect = new CollisionDetect(game,this);
        }

        public void Update()
        {
            foreach (IGameObject GameObject in levelObjects)
            {
                GameObject.Update();
            }

            
            collisionDetect.Update();
        }

        public void Draw()
        {
            foreach (IGameObject GameObject in levelObjects)
            {
                GameObject.Draw();
            }
        }

        private void GetPlayerObjects()
        {
            IPlayer playerObject = null;
            foreach(IGameObject player in levelObjects)
            {
                if(player is IPlayer)
                    playerObject = (IPlayer)player;
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
    }
}
