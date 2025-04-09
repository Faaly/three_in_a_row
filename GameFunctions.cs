using System;
using System.Security.Cryptography.X509Certificates;

namespace GameFunctions
{ 
    public class GameFunctions
    {
	    public GameFunctions()
	    {
        }


        //Function that ask the player for input
        //Input will be checked if char input is valid.
        public static char GetPlayerCharInput(int player)
        {
            char charInput;
            bool charInputCheck = false;
            do
            {
                //We ask the player for input.
                //The Console presents meanwhile the playing field. 
                //Player will input between from A-D. Input will be converted to upper case Char
                Console.Write("Please choose a row: ");
                charInput = Convert.ToChar(Console.ReadLine());
                charInput = char.ToUpper(charInput);
                //Check if CharInput is a Char, is between A-D, is not null or empty. 
                if (charInput != ' ' || charInput != null)
                {
                    if (charInput >= 'A' && charInput <= 'D')
                    {
                        Console.WriteLine("Error - Please choose a row: ");
                    }
                }
                else //If checks are valid, player will leave loop.
                     //elsewise player has to enter again his input.
                {
                    charInputCheck = true;
                }
            } while (charInputCheck == false);
            return charInput;
        }

        //Function that ask the player for int input
        //Input will be checked if int input is valid.
        public static int GetPlayerIntInput(int player)
        {
            int intInput;
            bool intInputCheck = false;
            do
            {
                //We ask the player for input.
                //The Console presents meanwhile the playing field. 
                //Player will input between from 1-4. Input will be converted to int32
                Console.Write("Please choose a coloumn: ");

                //Check if intInput is a int, is between 1-4. 
                if (int.TryParse(Console.ReadLine(), out intInput))
                {
                    if (intInput >= 1 && intInput <= 4)
                    {
                        Console.WriteLine("Error - Please choose a coloumn: ");
                    }
                }
                else //If checks are valid, player will leave loop.
                {
                    intInputCheck = true;
                }
            } while (intInputCheck == false);
            return intInput;
        }

        //Function that transforms containing value of string into a Index
        public static int ConvertInputToIndex(char CharInput, int IntInput)
        {
            int rowIndex = CharInput - 'A';
            int coloumnIndex = IntInput - 1;
            int index = ((rowIndex * 4) + coloumnIndex);
            return index;
        }

        //Function that checks if inside of the playing field in vertical way same symbols are found
        public static void VerticalCheck(int index, int player, string playerMark, int playerSymbol)
        {
            //initialized loseCounter with 0.
            int loseCounter = 0;
            int checkedField;

            //Check field above
            checkedField = index - 4;
            while (checkedField >= 0 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field above
                checkedField -= 4;
                //Loop repeats if condition is true, else loop ends.
            }

            //Check field below
            checkedField = index + 4;
            while (checkedField < 16 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field below
                checkedField += 4;
                //Loop repeats if condition is true, else loop ends.
            }

            if (loseCounter >= 2)
            {
                Console.WriteLine($"Player {player} has lost the game!");
                Console.ReadLine();
            }
        }


        //Function that checks if inside of the playing field in horizontal way same symbols are found
        public static void HorizontalCheck(int index, int player, string playerMark, int playerSymbol)
        {
            //initialized loseCounter with 0.
            int loseCounter = 0;
            int checkedField;

            //Check field above
            checkedField = index - 1;
            while (checkedField >= 0 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field to the left
                checkedField -= 1;
                //Loop repeats if condition is true, else loop ends.
            }

            //Check field below
            checkedField = index + 1;
            while (checkedField < 16 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field to the right
                checkedField += 1;
                //Loop repeats if condition is true, else loop ends.
            }

            if (loseCounter >= 2)
            {
                Console.WriteLine($"Player {player} has lost the game!");
                Console.ReadLine();
            }
        }

        //Function that checks if inside of the playing field in diagonal way same symbols are found
        public static void DiagonalCheck(int index, int player, string playerMark, int playerSymbol)
        {
            //initialized loseCounter with 0.
            int loseCounter = 0;
            int checkedField;

            //Check field RightUp
            checkedField = index + 3;
            while (checkedField >= 0 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field to the right and up
                checkedField += 3;
                //Loop repeats if condition is true, else loop ends.
            }

            //Check field leftDown
            checkedField = index - 3;
            while (checkedField < 16 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field to the left and down
                checkedField -= 3;
                //Loop repeats if condition is true, else loop ends.
            }

            if (loseCounter >= 2)
            {
                Console.WriteLine($"Player {player} has lost the game!");
                Console.ReadLine();
            }





        }


    }
}
