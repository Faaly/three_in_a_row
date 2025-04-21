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
            //Int index will be needed index for playerMark.
            int index;

            while (drawCounter <= 16)
            {
                playerChoice = false;
                do
                {
                    //                          Insert fuction that show playing field
                    playerSymbol = 'X';
                    playerInput[0] = Convert.ToString(GameFunctions.GameFunctions.GetPlayerCharInput(player));
                    playerInput[1] = Convert.ToString(GameFunctions.GameFunctions.GetPlayerIntInput(player));

                    char charInput = playerInput[0][0];
                    int intInput = int.Parse(playerInput[1]);
                    index = (GameFunctions.GameFunctions.ConvertInputToIndex(charInput, intInput));

                    // Wir prüfen mittels einer IF Abfrage ob das Spielfeld belegt ist.
                    // Falls der Fall true ist, gibt es eine Ausgabe an den Spieler.
                    if (playerMark[index] != "")
                    {
                        Console.WriteLine("Field is already taken.");
                    }
                    // Falls das Spielfeld frei ist, also der Fall false, wird der failsafe Playerchoice
                    // true geschaltet, damit die DO-WHILE Schleife abbricht und das Spielersymbol X
                    // wird auf das Spielfeld mit dem Index gesetzt.
                    else
                    {
                        playerMark[index] = Convert.ToString(playerSymbol);
                        playerChoice = true;

                        GameFunctions.GameFunctions.VerticalCheck(index, player, playerMark[index], playerSymbol);
                        GameFunctions.GameFunctions.HorizontalCheck(index, player, playerMark[index], playerSymbol);
                        GameFunctions.GameFunctions.DiagonalCheck(index, player, playerMark[index], playerSymbol);
                        GameFunctions.GameFunctions.Diagonal2Check(index, player, playerMark[index], playerSymbol);
                    }

                    //Erhöhung des drawCounters für abgeschlossene Spielerrunde
                    drawCounter++;
                }
                while (!playerChoice);

                // Operator, der zwischen den Spielern wechselt. Wenn Player 1 false, dann Player 1
                player = (player == 1) ? 2 : 1;

                playerChoice = false;
                do
                {
                    //                          Insert fuction that show playing field
                    playerSymbol = 'O';
                    playerInput[0] = Convert.ToString(GameFunctions.GameFunctions.GetPlayerCharInput(player));
                    playerInput[1] = Convert.ToString(GameFunctions.GameFunctions.GetPlayerIntInput(player));

                    char charInput = playerInput[0][0];
                    int intInput = int.Parse(playerInput[1]);
                    index = (GameFunctions.GameFunctions.ConvertInputToIndex(charInput, intInput));

                    // Wir prüfen mittels einer IF Abfrage ob das Spielfeld belegt ist.
                    // Falls der Fall true ist, gibt es eine Ausgabe an den Spieler.
                    if (playerMark[index] != "")
                    {
                        Console.WriteLine("Field is already taken.");
                    }
                    // Falls das Spielfeld frei ist, also der Fall false, wird der failsafe Playerchoice
                    // true geschaltet, damit die DO-WHILE Schleife abbricht und das Spielersymbol X
                    // wird auf das Spielfeld mit dem Index gesetzt.
                    else
                    {
                        playerMark[index] = Convert.ToString(playerSymbol);
                        playerChoice = true;

                        GameFunctions.GameFunctions.VerticalCheck(index, player, playerMark[index], playerSymbol);
                        GameFunctions.GameFunctions.HorizontalCheck(index, player, playerMark[index], playerSymbol);
                        GameFunctions.GameFunctions.DiagonalCheck(index, player, playerMark[index], playerSymbol);
                        GameFunctions.GameFunctions.Diagonal2Check(index, player, playerMark[index], playerSymbol);
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
