using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFunctions;

namespace three_in_a_row
{
    class Program
    {
        static void Main(string[] args)
        {
            //Coordinate system for the game, from A-D and 1-4.
             
            string[] row = new string[]
            {
                "A","B", "C","D"
            };
            string[] coloumn = new string[]
            {
                "1","2","3","4"
            };

            //String to save mark of the player. Array will be initialized as emtpy "" via for-loop
            string[] playerMark = new string[16];
            for (int i = 0; i < playerMark.Length; i++)
            {
                playerMark[i] = "";
            }


















        }
    }
}
