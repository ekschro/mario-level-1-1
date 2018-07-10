using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class LevelLoader : ILoader
    {
        Game1 myGame;
        //private IGameObject mario;
       
        public LevelLoader(Game1 game)
        {
            myGame = game;
            
        }

        public void Load(string fileName, List<IGameObject> gameObjects)
        {
            StreamReader LoaderInput = new StreamReader(fileName);

            while (!LoaderInput.EndOfStream)
            {
                char NextChar;
                string GameObjectString = "";
                string PositionXString = "";
                string PositionYString = "";
                string SizeXString = "";
                string SizeYString = "";
                int PositionX = 0;
                int PositionY = 0;
                int SizeX = 16;
                int SizeY = 16;
                
                while(LoaderInput.Peek() >= 0 && (NextChar = (char)LoaderInput.Read()) != ',')
                {
                    GameObjectString = GameObjectString + NextChar;
                }

                while (LoaderInput.Peek() >= 0 && (NextChar = (char)LoaderInput.Read()) != ',')
                {
                    PositionXString = PositionXString + NextChar;
                }
                

                if(GameObjectString != "StoneBlock")
                {
                    while (LoaderInput.Peek() >= 0 && (NextChar = (char)LoaderInput.Read()) != '\n')
                    {
                        PositionYString = PositionYString + NextChar;
                    }

                } else
                {
                    while (LoaderInput.Peek() >= 0 && (NextChar = (char)LoaderInput.Read()) != ',')
                    {
                        PositionYString = PositionYString + NextChar;
                    }

                    while (LoaderInput.Peek() >= 0 && (NextChar = (char)LoaderInput.Read()) != ',')
                    {
                        SizeXString = SizeXString + NextChar;
                    }

                    while (LoaderInput.Peek() >= 0 && (NextChar = (char)LoaderInput.Read()) != '\n')
                    {
                        SizeYString = SizeYString + NextChar;
                    }

                    SizeX = Convert.ToInt32(SizeXString);
                    SizeY = Convert.ToInt32(SizeYString);
                }

                PositionX = Convert.ToInt32(PositionXString);
                PositionY = Convert.ToInt32(PositionYString);

                gameObjects.Add(GenerateObject(GameObjectString, PositionX, PositionY, SizeX, SizeY));
            }
        }


        public IGameObject GenerateObject(string objectName, int positionX, int positionY, int sizeX, int sizeY)
        {
            Vector2 Position = new Vector2((float)positionX, (float)positionY);
            Vector2 Size = new Vector2((float)sizeX, (float)sizeY);
            IGameObject GameObject = new Coin(myGame,Position);
            switch (objectName) {
                case "Mario" :
                    GameObject = new Mario(myGame, Position);
                    break;
                case "FireFlower":
                    GameObject = new Fireflower(myGame, Position);
                    break;
                case "Coin":
                    GameObject = new Coin(myGame, Position);
                    break;
                case "RedMushroom":
                    GameObject = new RedMushroom(myGame, Position);
                    break;
                case "GreenMushroom":
                    GameObject = new GreenMushroom(myGame, Position);
                    break;
                case "Star":
                    GameObject = new Star(myGame, Position);
                    break;
                case "Goomba":
                    GameObject = new Goomba(myGame, Position);
                    break;
                case "Koopa":
                    GameObject = new Koopa(myGame, Position);
                    break;
                case "HiddenBlockWith1Up":
                    GameObject = new HiddenGreenMushroomBlock(myGame, Position);
                    break;
                case "StairBlock":
                    GameObject = new StairBlock(myGame, Position);
                    break;
                case "UsedBlock":
                    GameObject = new UsedBlock(myGame, Position);
                    break;
                case "QuestionBlockWithPowerUp":
                    GameObject = new QuestionPowerUpBlock(myGame, Position);
                    break;
                case "QuestionBlockWithCoin":
                    GameObject = new QuestionCoinBlock(myGame, Position);
                    break;
                case "BrickBlock":
                    GameObject = new BrickBlock(myGame, Position);
                    break;
                case "BrickBlockWithStar":
                    GameObject = new BrickBlockWithStar(myGame, Position);
                    break;
                case "BrickBlockWithManyCoins":
                    GameObject = new BrickBlockWithManyCoins(myGame, Position);
                    break;
                case "StoneBlock":
                    GameObject = new StoneBlock(myGame, Position, Size);
                    break;
                case "BlueStoneBlock":
                    GameObject = new BlueStoneBlock(myGame, Position, Size);
                    break;
                case "BlueBrickBlock":
                    GameObject = new BlueBrickBlock(myGame, Position, Size);
                    break;
                case "TopLeftPipeBlock":
                    GameObject = new TopLeftPipeBlock(myGame, Position);
                    break;
                case "TopRightPipeBlock":
                    GameObject = new TopRightPipeBlock(myGame, Position);
                    break;
                case "BottomLeftPipeBlock":
                    GameObject = new BottomLeftPipeBlock(myGame, Position);
                    break;
                case "BottomRightPipeBlock":
                    GameObject = new BottomRightPipeBlock(myGame, Position);
                    break;
                case "Castle":
                    GameObject = new CastleBlock(myGame, Position);
                    break;
                case "Flagpole":
                    GameObject = new FlagpoleBlock(myGame, Position);
                    break;
                case "Flag":
                    GameObject = new FlagBlock(myGame, Position);
                    break;
            }
            return GameObject;
        }

    }
}
