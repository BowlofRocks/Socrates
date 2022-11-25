using System;
using Unit04.Game.Casting;


namespace Unit04
{
    class FallingObject : Actor
    {
        Random rd = new Random();
        private int ValueOfObject = 0;
        // Sets score per object.
        public int GetValue()
        {
            Random random = new Random();
            int eitherRockOrGem = random.Next(1,100);
            
            if (eitherRockOrGem % 2 == 0)
            {
                ValueOfObject = rd.Next(-100, -1);
            }
            else
            {
                ValueOfObject = rd.Next(1, 100);
            }
            return ValueOfObject;
        }




        public void SetShape(int objectPoints)
        {

            if (objectPoints > 0)
                {
                    
                    Color color = new Color(0,0,255);
                    SetText("G");
                    SetColor(color);
                }
            else
                {
                    Color color = new Color(255,0,0);
                    SetText("R");
                    SetColor(color);
                }

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