﻿using Microsoft.Xna.Framework;
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
        public IGameObject mario;
       
        public LevelLoader(Game1 game)
        {
            myGame = game;
            
        }

        public void Load(string fileName, List<IGameObject> gameObjects)
        {
            StreamReader LoaderInput = new StreamReader(fileName);

            while (!LoaderInput.EndOfStream)
            {
                int NextChar;
                string GameObjectString = "";
                int PositionX;
                int PositionY;
                
                while((NextChar = LoaderInput.Read()) != ',' && !LoaderInput.EndOfStream)
                {
                    GameObjectString = GameObjectString + NextChar;
                }

                if (LoaderInput.EndOfStream)
                    break;

                PositionX = Convert.ToInt32(LoaderInput.Read());
                LoaderInput.Read();
                PositionY = Convert.ToInt32(LoaderInput.Read());
                LoaderInput.Read();

                gameObjects.Add(GenerateObject(GameObjectString, PositionX, PositionY));
            }
        }

        public IGameObject GenerateObject(string objectName, int positionX, int positionY)
        {
            Vector2 Position = new Vector2(positionX, positionY);
            IGameObject GameObject = new Mario(myGame, Position);
            switch (objectName) {
                case "Mario" :
                    GameObject = new Mario(myGame, Position);
                    mario = GameObject;
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
                case "HiddenBlock":
                    GameObject = new HiddenBlock(myGame, Position);
                    break;
                case "StairBlock":
                    GameObject = new StairBlock(myGame, Position);
                    break;
                case "UsedBlock":
                    GameObject = new UsedBlock(myGame, Position);
                    break;
                case "QuestionBlockWithPowerUp":
                    GameObject = new QuestionBlock(myGame, Position);
                    break;
                case "QuestionBlockWithCoin":
                    GameObject = new QuestionBlock(myGame, Position);
                    break;
                case "BrickBlock":
                    GameObject = new BrickBlock(myGame, Position);
                    break;
                case "StoneBlock":
                    GameObject = new StoneBlock(myGame, Position);
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
            }
            return GameObject;
        }

    }
}
