using System;
using Unit04.Game.Casting;
using Unit04.Game.Services;
using System.Collections.Generic;

namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;

        private int _total = 0;
        private int numFO = 10;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the miner.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor miner = cast.GetFirstActor("miner");
            Point velocity = _keyboardService.GetDirection();
            velocity = new Point (velocity.GetX(), 0);
            miner.SetVelocity(velocity);
        }

        /// <summary>
        /// Updates the miner's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor miner = cast.GetFirstActor("miner");
            
            
            
            banner.SetText("Score ");
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            miner.MoveNext(maxX, maxY);

            // Creation of Falling obj
            // Randomizing spots

            Random random = new Random();


            int randomX = random.Next(1, 1000);
            Point start = new Point(randomX,0);
            start.Scale(15);
            int numOfFO = random.Next(10);

            for (int i = 0; i < numFO; i++)
            {
                int eitherRockOrGem = random.Next(1,2);

                // if (randomNum == 1)
                // {
                //     eitherRockOrGemChar = "Rock";
                // }
                // else if (randomNum == 2)
                // {
                //     eitherRockOrGemChar = "Gem";
                // }

                FallingObject f = new FallingObject();
                f.SetScore(eitherRockOrGem); /////// Using Random to generate Gem or Rock
                f.SetPosition(start);
                f.SetVelocity(new Point(0, 3));
                cast.AddActor("fallingObjects", f);
            }
            List<Actor> fallingObjects = cast.GetActors("fallingObjects");
            foreach (Actor actor in fallingObjects)
            {
                actor.MoveNext(maxX,maxY);
                if (miner.GetPosition() == actor.GetPosition()) //  if (miner.GetPosition().Equals(actor.GetPosition()))
                {
                FallingObject fallingObject = (FallingObject) actor;/////Where score is calculated
                    int score = fallingObject.GetValue();  
                    _total += score;
                    banner.SetText($"Score {_total}");
                    cast.RemoveActor("fallingObjects", fallingObject);
                }
            }

            foreach (Actor fallingObject in fallingObjects) ///////
            {
                if (fallingObject.GetPosition().GetY() == 900)
                {
                cast.RemoveActor("fallingObjects", fallingObject);
                }
            }
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

    }
}