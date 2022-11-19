using System;
using Unit04.Game.Casting;


namespace Unit04
{
    class FallingObject : Actor
    {
        Random rd = new Random();
        private int ValueOfObject = 0;
        // Sets score per object.
        public int SetScore(int someRandomNumber)
        {
            
            int FallenObject = someRandomNumber;
            
            FallenObject = rd.Next(1,2);

            if (FallenObject == 1)
                {
                    ValueOfObject = rd.Next(-100,-1);
                    SetText("R");
                }
            else if (FallenObject == 2)
                {
                    ValueOfObject = rd.Next(1,100);
                    SetText("G");
                }
            else 
                {
                    Console.WriteLine($"Object is neither 'Rock' or 'Gem' and cannot gert a score assigned to it. Fallen Object is {FallenObject}");
                }
            return ValueOfObject;

        }    

        public int GetValue()
        {
            return ValueOfObject;
        }


//         public string SetText(string eitherRockOrGemChar) 
// // Displays score.... to banner
// // Chooses rock or gem and draws rocks or gems, return shape of rock or gem. Displays score on banner
//         {
            
//             // SetText("R");
//             // SetColor(Constants.BROWN);


//             string FallenObject = "";
//             int RandomizeRockAndGem = rd.Next(0,1);

//             string ObjectShape = "";
//             if (RandomizeRockAndGem == 0)
//                 {
//                     FallenObject = "Rock";
                    
//                 }
//             else if (RandomizeRockAndGem == 1)
//                 {
//                     FallenObject = "Gem";
                    
//                 }
//             else
//                 {
//                     Console.WriteLine($"Random number must be 1 or 0 for decision of Rock or Gem. Number was {RandomizeRockAndGem}");
//                 }

//             return FallenObject; 
//         }
    }

}