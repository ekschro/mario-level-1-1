using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class CollisionRespond
    {
        public CollisionRespond()
        {

        }

        public void BlockCollisionRespondTop(IPlayer player, IBlock block)
        {
            
        }

        public void BlockCollisionRespondBottom(IPlayer player, IBlock block)
        {

        }

        public void BlockCollisionRespondRight(IPlayer player, IBlock block)
        {

        }

        public void BlockCollisionRespondLeft(IPlayer player, IBlock block)
        {

        }

        public void EnemyCollisionRespondTop(IPlayer player, IEnemy enemy)
        {

        }

        public void EnemyCollisionRespondBottom(IPlayer player, IEnemy enemy)
        {

        }

        public void EnemyCollisionRespondLeft(IPlayer player, IEnemy enemy)
        {
            
        }

        public void EnemyCollisionRespondRight(IPlayer player, IEnemy enemy)
        {

        }

        public void PickupCollisionRespondTop(IPlayer player, IPickup pickup)
        {
            pickup.Picked();
            
            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
        }

        public void PickupCollisionRespondBottom(IPlayer player, IPickup pickup)
        {
            pickup.Picked();

            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
        }

        public void PickupCollisionRespondLeft(IPlayer player, IPickup pickup)
        {
            pickup.Picked();

            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
        }

        public void PickupCollisionRespondRight(IPlayer player, IPickup pickup)
        {
            pickup.Picked();

            if (pickup is Fireflower)
            {
                Mario.marioSprite.FireMarioCommandCalled();
            }
        }

        public void Update()
        {

        }
    }
}
