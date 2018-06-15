using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CollisionDetect : ICollision
    {
        private Game1 game;
        private ILevel level1;
        private IGameObject player;
        private List<IGameObject> blocks;
        private List<IGameObject> enemies;
        private List<IGameObject> pickups;
        private CollisionRespond collision;

        public CollisionDetect(Game1 game,ILevel Level1)
        {
            level1 = Level1;
            this.game = game;
            collision = new CollisionRespond();
        }

        public void BlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;

            Rectangle playerBox = new Rectangle(playerX, playerY, 16, 16);

            foreach (IGameObject block in blocks)
            {
                int blockX = (int)block.GameObjectLocation().X;
                int blockY = (int)block.GameObjectLocation().Y;

                Rectangle blockBox = new Rectangle(blockX, blockY, 16, 16);

                if (playerBox.Intersects(blockBox))
                {
                    collision.BlockCollisonRespond();
                }
            }
        }

        public void EnemyCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;

            Rectangle playerBox = new Rectangle(playerX, playerY, 16, 16);

            foreach (IGameObject enemy in enemies)
            {
                int enemyX = (int)enemy.GameObjectLocation().X;
                int enemyY = (int)enemy.GameObjectLocation().Y;

                Rectangle enemyBox = new Rectangle(enemyX, enemyY, 16, 16);

                if (playerBox.Intersects(enemyBox))
                {
                    collision.EnemyCollisionRespond();
                }
            }
        }

        public void PickupBlockCollisionDetect()
        {
            int playerX = (int)player.GameObjectLocation().X;
            int playerY = (int)player.GameObjectLocation().Y;

            Rectangle playerBox = new Rectangle(playerX, playerY, 16, 16);

            foreach (IGameObject pickup in pickups)
            {
                int pickupX = (int)pickup.GameObjectLocation().X;
                int pickupY = (int)pickup.GameObjectLocation().Y;

                Rectangle pickupBox = new Rectangle(pickupX, pickupY, 16, 16);

                if (playerBox.Intersects(pickupBox))
                {
                    collision.PickupCollisionRespond();
                }
            }
        }

        public void Update()
        {

        }
    }
}
