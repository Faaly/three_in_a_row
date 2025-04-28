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
                    Console.WriteLine($"AFT P1 GetPlayerRow/Column      LOG: Player:{player} - r: {r} - c: {c} - DrawCounter: {drawCounter}\n      ");

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
                        GameFunctions.GameFunctions.HorizontalCheck(player, playerMark, r, c, playerSymbol);
                        GameFunctions.GameFunctions.DiagonalCheck(player, playerMark,r, c, playerSymbol);
                        GameFunctions.GameFunctions.Diagonal2Check(player, playerMark,r, c, playerSymbol);
                    }

                    //Erhöhung des drawCounters für abgeschlossene Spielerrunde
                    drawCounter++;
                }
                while (!playerChoice);
                Console.WriteLine($" Btwn while/do - - - LOG: Player:{player} - r: {r} - c: {c} - DrawCounter: {drawCounter}\n      ");
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
                    Console.WriteLine($"AFT P2 GetPlayerRow/Column      LOG: Player:{player} - r: {r} - c: {c} - DrawCounter: {drawCounter}\n      ");

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
                    GameFunctions.GameFunctions.HorizontalCheck(player, playerMark, r, c, playerSymbol);
                    GameFunctions.GameFunctions.DiagonalCheck(player, playerMark, r, c, playerSymbol);
                    GameFunctions.GameFunctions.Diagonal2Check(player, playerMark, r, c, playerSymbol);
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













            /*


                                VerticalCheck(Index, Player, PlayerSymbol)
                                HorizontalCheck(Index, Player, PlayerSymbol)
                                Diagonal1Check(Index, Player, PlayerSymbol)
                                Diagonal2Check(Index, Player, PlayerSymbol)


                                DrawCounter++
                            END DO(!Playerchoice) //Beenden die DO Schleife

                            // Operator, der zwischen den Spielern wechselt. Wenn Player 1 true, dann Player 2
                            Player = (Player == 1) ? 2 : 1

                            DO
                                // Hier eine Funktion, die das Spielfeld anzeigt.

                                CHAR PlayerSymbol = "O"
                                // Eingabe Spieler 2
                                PlayerInput = GetPlayerInput(2)
                                Int Index = ConvertInputToIndex(PlayerInput[1], PlayerInput[2])

                                // Wir prüfen mittels einer IF Abfrage ob das Spielfeld belegt ist.
                                // Falls der Fall true ist, gibt es eine Ausgabe an den Spieler.
                                IF PlayerMark[Index] != "" THEN
                                    OUTPUT "Spielfeld nicht frei!"
                                ELSE
                                    // Falls das Spielfeld frei ist, also der Fall false, wird der failsafe Playerchoice
                                    // true geschaltet, damit die DO-WHILE Schleife abbricht und das Spielersymbol "O"
                                    // wird auf das Spielfeld mit dem Index gesetzt.
                                    PlayerMark[Index] = "PlayerSymbol"
                                    Playerchoice = true
                                END IF

                                VerticalCheck(Index, Player, PlayerSymbol)
                                HorizontalCheck(Index, Player, PlayerSymbol)
                                Diagonal1Check(Index, Player, PlayerSymbol)
                                Diagonal2Check(Index, Player, PlayerSymbol)


                                DrawCounter++
                            END DO(!Playerchoice) //Beenden die DO Schleife
                            // Operator, der zwischen den Spielern wechselt. Wenn Player 1 false, dann Player 1
                            Player = (Player == 1) ? 2 : 1


                        END WHILE

                        //DrawCounter ist größer als 15, WHILE LOOP wird beendet und Spiel endet Unentschieden
                        OUTPUT "Spiel Unentschieden!"



                        */













        }
    }
}
