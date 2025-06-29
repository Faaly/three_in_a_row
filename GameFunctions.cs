﻿using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace GameFunctions
{ 
    public class GameFunctions
    {
        const string C_HitEnter = "     Please press Enter.";
        public GameFunctions()
	    {
        }
        //Function that ask the player for input
        //Input will be checked if char input is valid.
        public static string GetPlayerRowInput(int player)
        {
            string rowInput;
            bool rowInputCheck = false;
            
            do
            {
                //We ask the player for input.
                //The Console presents meanwhile the playing field. 
                //Player will input between from A-D. Input will be converted to upper case Char
                Console.Write("Please choose a column: ");
                rowInput = Console.ReadLine();
                //Check if rowInput is between A-D & is not null or empty. 
                if (!string.IsNullOrEmpty(rowInput) && rowInput != " " && rowInput != "" )
                {
                    rowInput = rowInput.ToUpper();
                    rowInput = rowInput[0].ToString();

                    if (rowInput[0] >= 'A' && rowInput[0] <= 'D')
                    {
                        switch (rowInput)
                        {
                            case "A":
                                rowInput = "0";
                                break;
                            case "B":
                                rowInput = "1";
                                break;
                            case "C":
                                rowInput = "2";
                                break;
                            case "D":
                                rowInput = "3";
                                break;
                            default:
                                Console.WriteLine($"Warning! - Switch Case Exeption occured!\n{C_HitEnter}");
                                break;
                        }
                        rowInputCheck = true;
                    }
                    else //If checks are valid, player will leave loop.
                         //elsewise player has to enter again his input.
                    {
                        Console.WriteLine($"Error - Invalid Char Input.\n{C_HitEnter}");
                        Console.ReadLine();
                    }
                } else
                {
                    Console.WriteLine($"Error - Input is null or empty.\n{C_HitEnter}");
                    Console.ReadLine();

                }



            } while (rowInputCheck == false);
            return rowInput;
        }

        //Function that ask the player for int input
        //Input will be checked if int input is valid.
        public static int GetPlayerColumnInput(int player)
        {
            int columnInput;
            bool columnInputCheck = false;
            do
            {
                //We ask the player for input.
                //The Console presents meanwhile the playing field. 
                //Player will input between from 1-4. Input will be converted to int32
                Console.Write("Please choose a row: ");

                //Check if intInput is a int, is between 1-4. 
                if (int.TryParse(Console.ReadLine(), out columnInput))
                {
                    if (columnInput >= 1 && columnInput <= 4)
                    {
                        columnInputCheck = true;
                        columnInput -= 1;
                    }
                    else //If checks are valid, player will leave loop. Else Error
                    {
                        Console.WriteLine($"Error - Invalid Input\n{C_HitEnter}");
                        Console.ReadLine();
                    }
                }
                else //If checks are valid, player will leave loop. Else Error
                {
                    Console.WriteLine($"Error - Invalid Input\n{C_HitEnter}");
                    Console.ReadLine ();
                }
            } while (columnInputCheck == false);
            return columnInput;
        }

        //Function that checks if inside of the playing field in vertical way same symbols are found
        public static void VerticalCheck(int player, string[,] playerMark, int r, int c, char playerSymbol)
        {
            //Starting coords, saved as temp coords
            int temp_c = c;
            int temp_r = r;
            //initialized loseCounter with 0.
            int loseCounter = 0;
            //Check field above if playerSymbol is found on playerMark and c is greater or equal to 0
            while (c >= 0) //C means for column. 1-4
            {
                
                if (playerMark[r, c].Contains(Convert.ToString(playerSymbol)))
                {
                    loseCounter += 1;
                }
                else
                {
                    break;
                }

                //When condition true, increase loseCounter +1
                //move one field above
                if (c != 0)
                {
                    c--;
                }
                //Loop repeats if condition is true, else loop ends.
                else
                {
                    break;
                }
            }

            //Reset temp cords back to c and r.
            c = temp_c;
            r = temp_r;
            //Check field below if playerSymbol is found on playerMark and c is less or equal to 3
            while (c <= 3)
            {
                if (playerMark[r, c].Contains(Convert.ToString(playerSymbol)))
                {
                    loseCounter += 1;
                }
                else
                {
                    break;
                }
                //When condition true, increase loseCounter +1
                //move one field below
                if (c != 3)
                {
                    c += 1;
                }
                else
                {
                    break;
                }
                
                //Loop repeats if condition is true, else loop ends.
            }


            if (loseCounter >= 4)
            {
                PlayingField(playerMark, player, playerSymbol);
                Console.WriteLine($"Player {player} has lost the game!");
                Console.ReadLine();
                Environment.Exit(0);
                //Spielfeld anzeigen!
            }
        }


        //Function that checks if inside of the playing field in horizontal way same symbols are found
        public static void HorizontalCheck(int player, string[,] playerMark, int r, int c, char playerSymbol)
        {
            //Starting coords, saved as temp coords
            int temp_c = c;
            int temp_r = r;
            //initialized loseCounter with 1.
            int loseCounter = 0;

            //Check field to the left if playerSymbol is found on playerMark and c is greater or equal to 0 
            while (r >= 0)
            {
                if (playerMark[r, c].Contains(Convert.ToString(playerSymbol)))
                {
                    loseCounter += 1;
                }
                else
                {
                    break;
                }
                //When condition true, increase loseCounter +1

                //move one field to the left
                if (r != 0)
                {
                    r--;
                }
                else
                {
                    break;
                }
                //Loop repeats if condition is true, else loop ends.
            }


            //Reset temp cords back to c and r.
            c = temp_c;
            r = temp_r;
            //Check field to the right if playerSymbol is found on playerMark and c is less or equal to 3 
            while (r <= 3)
            {
                if(playerMark[r, c].Contains(Convert.ToString(playerSymbol)))
                {
                    loseCounter++;
                } else
                {
                    break;
                }
                //When condition true, increase loseCounter +1

                //move one field to the right
                if (r != 3)
                {
                    r++;
                } 
                else 
                { 
                    break; 
                }
                //Loop repeats if condition is true, else loop ends.
            }

            if (loseCounter >= 4)
            {
                PlayingField(playerMark, player, playerSymbol);
                Console.WriteLine($"Player {player} has lost the game!");
                Console.ReadLine();
                Environment.Exit(0);
                //Spielfeld anzeigen!
            }
        }

        //Function that checks if inside of the playing field in diagonal way same symbols are found
        public static void DiagonalCheck(int player, string[,] playerMark, int r, int c, char playerSymbol)
        {
            //Starting coords, saved as temp coords
            int temp_c = c;
            int temp_r = r;
            //initialized loseCounter with 0.
            int loseCounter = 0;

            //Check field to the right and up if playerSymbol is found on playerMark and r is greater or equal to 0 
            while (r <= 3 && c >= 0)
            {
                if (playerMark[r, c].Contains(Convert.ToString(playerSymbol)))
                {
                    
                    //When condition true, increase loseCounter +1
                    loseCounter++;
                }
                else
                {
                    break;
                }
                //move one field to the right and up
                if (r != 3 && c != 0)
                {
                    r++;
                    c--;
                }
                else
                {
                    break;
                }
                //Loop repeats if condition is true, else loop ends.
            }

            //Reset temp cords back to c and r.
            c = temp_c;
            r = temp_r;

            //Check field leftDown

            while (r >= 0 && c <= 3)
            {
                if (playerMark[r, c].Contains(Convert.ToString(playerSymbol)))
                {
                    
                    //When condition true, increase loseCounter +1
                    loseCounter++;}
                else 
                { 
                    break; 
                }   
                //move one field to the left and down
                if (c != 3 && r != 0)
                {
                    r--;
                    c++;
                }
                else
                {
                    break;
                }
                //Loop repeats if condition is true, else loop ends.
            }

            if (loseCounter >= 4)
            {
                PlayingField(playerMark, player, playerSymbol);
                Console.WriteLine($"Player {player} has lost the game!");
                Console.ReadLine();
                Environment.Exit(0);
            }

        }

        public static void Diagonal2Check(int player, string[,] playerMark, int r, int c, char playerSymbol)
        {
            //Starting coords, saved as temp coords
            int temp_c = c;
            int temp_r = r;
            //initialized loseCounter with 0.
            int loseCounter = 0;

            //Check field leftUp
            while (r >= 0 && c >= 0)
            {
                
                if (playerMark[r, c].Contains(Convert.ToString(playerSymbol))) { 
                //When condition true, increase loseCounter +1
                loseCounter++;
                }
                else { 
                    break;
                }
                //move one field to the left and up
                if (c != 0 && r != 0)
                {
                    r--;
                    c--;
                }
                else 
                {  
                    break;
                }
                //Loop repeats if condition is true, else loop ends.
            }

            //Reset temp cords back to c and r.
            c = temp_c;
            r = temp_r;

            //Check field rightDown
            while (r <= 3 && c <= 3)
            {
                if (playerMark[r, c].Contains(Convert.ToString(playerSymbol)))
                {
                    //When condition true, increase loseCounter +1
                    loseCounter++;
                }
                else { break;}
                //move one field to the right and down
                if (c != 3 && r != 3)
                {
                    r++;
                    c++;
                }
                else 
                {
                    break;
                }
                //Loop repeats if condition is true, else loop ends.
            }

            
            if (loseCounter >= 4)
            {
                PlayingField(playerMark, player, playerSymbol);
                Console.WriteLine($"Player {player} has lost the game!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        public static void PlayingField(string[,] playerMark, int player, char playerSymbol)
        {
            //Console.Clear();
            const string C_rows = "     A   B   C   D";
            const string C_playingfield = "   +---+---+---+---+";
            Console.WriteLine($"    Player {player} - your symbole: {playerSymbol}\n\n");
            Console.WriteLine(C_rows);
            Console.WriteLine(C_playingfield);
            for (int i = 0; i < 4; i++)
            {
                Console.Write($" {i + 1} |");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($" {playerMark[j, i]} |");
                    
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine(C_playingfield);
        }



    }
}
