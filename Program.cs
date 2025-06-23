using System;
using System.Collections.Generic;
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
            while (drawCounter <= 16)
            {
                //We save the input from the functions GetPlayerRowInput & GetPlayerColumnInput in two ints.
                //index int for row and column.
                int r;
                int c;
                //We save the player inside an integer
                int player = 1;
                //Playersymbol saved as char. Player one uses X, while player two uses O.
                char playerSymbol = 'X';
                playerChoice = false;
                do
                {
                    
                    GameFunctions.GameFunctions.PlayingField(playerMark, player, playerSymbol);
                    int.TryParse(GameFunctions.GameFunctions.GetPlayerRowInput(player), out r);
                    c = GameFunctions.GameFunctions.GetPlayerColumnInput(player);
                   
                    // Wir prüfen mittels einer IF Abfrage ob das Spielfeld belegt ist.
                    // Falls der Fall true ist, gibt es eine Ausgabe an den Spieler.
                    if (playerMark[r, c] != " ")
                    {
                        Console.WriteLine("Field is already taken.");
                    }
                    // Falls das Spielfeld frei ist, also der Fall false, wird der failsafe Playerchoice
                    // true geschaltet, damit die DO-WHILE Schleife abbricht und das Spielersymbol X
                    // wird auf das Spielfeld mit dem Index gesetzt.
                    else
                    {
                        playerMark[r, c] = Convert.ToString(playerSymbol);
                        playerChoice = true;

                        GameFunctions.GameFunctions.VerticalCheck(player, playerMark, r, c, playerSymbol);
                        //GameFunctions.GameFunctions.HorizontalCheck(player, playerMark, r, c, playerSymbol);
                        //GameFunctions.GameFunctions.DiagonalCheck(player, playerMark,r, c, playerSymbol);
                        //GameFunctions.GameFunctions.Diagonal2Check(player, playerMark,r, c, playerSymbol);
                    }

                    //Erhöhung des drawCounters für abgeschlossene Spielerrunde
                    drawCounter++;
                }
                while (!playerChoice);
                // Operator, der zwischen den Spielern wechselt. Wenn Player 1 false, dann Player 1
                player = (player == 1) ? 2 : 1;
                playerSymbol = (playerSymbol == 'O') ? 'X' : 'O';
                GameFunctions.GameFunctions.PlayingField(playerMark, player, playerSymbol);
                playerChoice = false;
                do
                    {
                    GameFunctions.GameFunctions.PlayingField(playerMark, player, playerSymbol);
                    int.TryParse(GameFunctions.GameFunctions.GetPlayerRowInput(player), out r);
                    c = GameFunctions.GameFunctions.GetPlayerColumnInput(player);
                    
                // Wir prüfen mittels einer IF Abfrage ob das Spielfeld belegt ist.
                // Falls der Fall true ist, gibt es eine Ausgabe an den Spieler.
                if (playerMark[r, c] != " ")
                {
                    Console.WriteLine("Field is already taken.");
                }
                // Falls das Spielfeld frei ist, also der Fall false, wird der failsafe Playerchoice
                // true geschaltet, damit die DO-WHILE Schleife abbricht und das Spielersymbol X
                // wird auf das Spielfeld mit dem Index gesetzt.
                else
                {
                    playerMark[r, c] = Convert.ToString(playerSymbol);
                    playerChoice = true;

                    GameFunctions.GameFunctions.VerticalCheck(player, playerMark, r, c, playerSymbol);
                //    GameFunctions.GameFunctions.HorizontalCheck(player, playerMark, r, c, playerSymbol);
                //    GameFunctions.GameFunctions.DiagonalCheck(player, playerMark, r, c, playerSymbol);
                //    GameFunctions.GameFunctions.Diagonal2Check(player, playerMark, r, c, playerSymbol);
                }

                //Erhöhung des drawCounters für abgeschlossene Spielerrunde
                drawCounter++;
            }
            while (!playerChoice);

                // Operator, der zwischen den Spielern wechselt. Wenn Player 1 false, dann Player 1
                player = (player == 1) ? 2 : 1;

            }

            if (drawCounter >= 15)
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine($"Error - left while(drawCounter > 15) loop while drawCounter is {drawCounter}.");
            }
        }
    }
}
