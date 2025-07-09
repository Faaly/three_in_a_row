using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

            const string C_HitEnter = "     Please press Enter.";
            //String to save mark of the player. 2D-Array will be initialized as emtpy "" via for-loop
            string[,] playerMark = new string[4, 4];
            for (int i = 0; i < playerMark.GetLength(0); i++)
            {
                for (int j = 0; j < playerMark.GetLength(1); j++)
                {
                    playerMark[i,j] = " ";
                }

            }
            //Failsafe if wrong input or selected playing field is taken
            bool playerChoice = false;
            //Counter that increases after every round
            int drawCounter = 0;
            //We save the player inside an integer
            int player = 1;
            //Playersymbol saved as char. Player one uses X, while player two uses O.
            char playerSymbol = 'X';
            while (drawCounter <= 16)
            {
                //We save the input from the functions GetPlayerRowInput & GetPlayerColumnInput in two ints.
                //index int for row and column.
                int r;
                int c;

                // First we expect that players input is wrong.
                playerChoice = false;
                do
                {
                    // Clean console, than show playing field. Ask player about input. More in GameFunctions.cs
                    Console.Clear();
                    GameFunctions.GameFunctions.PlayingField(playerMark, player, playerSymbol);
                    int.TryParse(GameFunctions.GameFunctions.GetPlayerRowInput(player), out r);
                    c = GameFunctions.GameFunctions.GetPlayerColumnInput(player);
                   
                    // Check via IF-Statement if field is already taken.
                    // If true, provide error output to player.
                    if (playerMark[r, c] != " ")
                    {
                        Console.WriteLine($"Field is already taken.\n{C_HitEnter}");
                        Console.ReadLine();
                    }

                    // If playing field isn't taken, PlayerChoice comes true.
                    // So Do-While loop breaks later. 
                    // Meanwhile we start into checking winning condition
                    else
                    {
                        playerMark[r, c] = Convert.ToString(playerSymbol);
                        playerChoice = true;

                        //Various checks to check if any player has lost. Contains player (1 or 2), playerSymbol (X or O) and Player Coordinates
                        GameFunctions.GameFunctions.VerticalCheck(player, playerMark, r, c, playerSymbol);
                        GameFunctions.GameFunctions.HorizontalCheck(player, playerMark, r, c, playerSymbol);
                        GameFunctions.GameFunctions.DiagonalCheck(player, playerMark,r, c, playerSymbol);
                        GameFunctions.GameFunctions.Diagonal2Check(player, playerMark,r, c, playerSymbol);
                    }

                    // increasing drawCounter +1
                    drawCounter++;
                }
                while (!playerChoice);
                // Operator, which switches from player one to two and back.
                player = (player == 1) ? 2 : 1;
                playerSymbol = (playerSymbol == 'O') ? 'X' : 'O';
            }

            // if drawCounter is greater or equal to 15, game ends w/o any winner in draw.
            if (drawCounter >= 15)
            {
                //First console will be cleared, then PlayingField will be shown for a final time and players will be notified it is draw
                Console.Clear();
                GameFunctions.GameFunctions.PlayingField(playerMark, player, playerSymbol);
                Console.WriteLine("\n\n!! DRAW !!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Warning! - Unexpected Error - left while(drawCounter > 15) loop while drawCounter is {drawCounter}.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
