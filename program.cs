using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 25;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Miner Finds Kitten";
        private static string DATA_PATH = "Data/messages.txt";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ARTIFACTS = 40;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            // List<Actor> fallingObjects = cast.GetActors("fallingObjects");


            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the miner
            Actor miner = new Actor();
            miner.SetText("#");
            miner.SetFontSize(FONT_SIZE);
            miner.SetColor(WHITE);
            miner.SetPosition(new Point(MAX_X / 2, 500)); // Had to hard code this as it wasn't low enough and for some reason will go higher if y > 500. Don't ask me why but the code did it that way.
            cast.AddActor("miner", miner);

            // load the messages
            //List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();

            // Create the falling objects

            FallingObject f = new FallingObject();
            
            Random rd = new Random();

            
            int numFO = rd.Next(1,2);

            


            // for (int i = 0; i < numFO; i++)
            //     {
            //         int eitherRockOrGem = rd.Next(1,100);
                    



            //         f.SetScore(eitherRockOrGem);
            //     }


            // create the artifacts
            Random random = new Random();
            for (int i = 0; i < DEFAULT_ARTIFACTS; i++)
            {
                string text = ((char)random.Next(33, 126)).ToString();
                //string message = messages[i];

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                // Artifact artifact = new Artifact();
            //     artifact.SetText(text);
            //     artifact.SetFontSize(FONT_SIZE);
            //     artifact.SetColor(color);
            //     artifact.SetPosition(position);
            //     artifact.SetMessage(message);
            //     cast.AddActor("artifacts", artifact);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);
        }
    }
}
