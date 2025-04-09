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
            //Failsafe if wrong input or selected playing field is taken
            bool playerChoice = false;
            //Counter that increases after every round
            int drawCounter = 0;
            //Playersymbol saved as char. Player one uses X, while player two uses O.
            char playerSymbol = ' ';
            //We save the input from the functions GetPlayerCharInput & GetPlayerIntInput in an String Array
            string[] playerInput = new string[2];

            //We save the player inside an integer
            int player = 1;

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

           
            while (drawCounter > 15)
            {
                do
                {
                    //                          Insert fuction that show playing field
                    playerSymbol = 'X';
                    playerInput[0] = Convert.ToString(GameFunctions.GameFunctions.GetPlayerCharInput(player));
                    playerInput[1] = Convert.ToString(GameFunctions.GameFunctions.GetPlayerIntInput(player));
                    int Index = (GameFunctions.GameFunctions.ConvertInputToIndex(playerInput[0], playerInput[1]));
                }
                while (!playerChoice);
            }



















            }
    }
}
