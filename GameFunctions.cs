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
                string placeHolder = Console.ReadLine();




                
                //Check if CharInput is a Char, is between A-D, is not null or empty. 
                if (string.IsNullOrEmpty(placeHolder))
                {
                    Console.WriteLine("Error - Invalid Input - Please choose a row: ");
                    Console.ReadLine();
                }

                if(placeHolder.Length != 1)
                {
                    Console.WriteLine("Error - Only one char allowed. - Please choose a row: ");
                }

                charInput = Convert.ToChar(placeHolder[0]);
                charInput = char.ToUpper(charInput);


                if (charInput >= 'A' && charInput <= 'D')
                {
                    charInputCheck = true;
                }
                else //If checks are valid, player will leave loop.
                     //elsewise player has to enter again his input.
                {
                    Console.WriteLine("Error - Invalid Char Input - Please choose a row: ");
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
                        intInputCheck = true;
                    }
                }
                else //If checks are valid, player will leave loop.
                {
                    
                    Console.WriteLine("Error - Please choose a coloumn: ");
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
            Console.WriteLine($"Index is: {index}");
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
                //Environment.Exit(0);
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
            while (checkedField <= 16 && playerMark[checkedField] == playerSymbol)
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
                //Environment.Exit(0);
            }
        }

        //Function that checks if inside of the playing field in diagonal way same symbols are found
        public static void DiagonalCheck(int index, int player, string playerMark, int playerSymbol)
        {
            //initialized loseCounter with 0.
            int loseCounter = 0;
            int checkedField;

            //Check field RightUp
            checkedField = index - 3;
            while (checkedField >= 0 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field to the right and up
                checkedField += 3;
                //Loop repeats if condition is true, else loop ends.
            }

            //Check field leftDown
            checkedField = index + 3;
            while (checkedField <= 16 && playerMark[checkedField] == playerSymbol)
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
                //Environment.Exit(0);
            }





        }

        public static void Diagonal2Check(int index, int player, string playerMark, int playerSymbol)
        {
            //initialized loseCounter with 0.
            int loseCounter = 0;
            int checkedField;

            //Check field leftUp
            checkedField = index - 5;
            while (checkedField >= 0 && playerMark[checkedField] == playerSymbol)
            {
                //When condition true, increase loseCounter +1
                loseCounter++;
                //move one field to the right and up
                checkedField += 3;
                //Loop repeats if condition is true, else loop ends.
            }

            //Check field rightDown
            checkedField = index + 5;
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
                //Environment.Exit(0);
            }





        }

    }
}
