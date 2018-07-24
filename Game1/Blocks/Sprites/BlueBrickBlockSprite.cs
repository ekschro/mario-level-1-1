using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class BlueBrickBlockSprite : IBlockSprite
    {
        private BlueBrickBlock blueBrickBlockObject;
        private Game1 myGame;
        
        private BlockUtilityClass utility;
        public BlueBrickBlockSprite(Game1 game, IBlock blueBrickBlock)
        {
            utility = new BlockUtilityClass();
            blueBrickBlockObject = (BlueBrickBlock)blueBrickBlock;
            myGame = game;
            
        }

        public void Update(){}

        public void Draw()
        {
            int drawLocationX = (int)myGame.CurrentLevel.LevelCamera.PositionRelativeToCamera(blueBrickBlockObject.GetGameObjectLocation().X);

            Rectangle sourceRectangle = new Rectangle(utility.InitialFrame,utility.InitialFrame,(int)blueBrickBlockObject.BlockSize.X,(int)blueBrickBlockObject.BlockSize.Y);
            Rectangle destinationRectangle = new Rectangle(drawLocationX, (int)blueBrickBlockObject.GetGameObjectLocation().Y, (int)blueBrickBlockObject.BlockSize.X, (int)blueBrickBlockObject.BlockSize.Y);

            myGame.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            myGame.SpriteBatch.Draw(TextureWarehouse.blueBrickBlockTexture, destinationRectangle, sourceRectangle, Color.White);
            myGame.SpriteBatch.End();
        }
    }
}