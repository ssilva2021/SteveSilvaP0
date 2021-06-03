using System;

namespace RockPaperScissors1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intro
            Console.WriteLine("Welcome to Rock Paper Scissors");
            Console.WriteLine("Paper defeats Rock");
            Console.WriteLine("Rock defeats Scissors");
            Console.WriteLine("Scissors defeats Paper");

            int rounds = 0;
            bool successfulConversion = false;
            int playerChoiceInt;
            // int computerChoice;
            //get a random number generator object
            Random rand = new Random();
            
            // do
            // {   
                rounds = 0;  
                       
                do
                {
                    
                    //prompt for choice
                    Console.WriteLine("Enter the number 0f your choice\n1. Rock\n2. Paper\n3.Scissors");
                    string playerChoice = Console.ReadLine();

                    successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                    if (!successfulConversion)
                    {
                        Console.WriteLine($" {playerChoice} is not a valid choice.");
                    } else if (playerChoiceInt > 3 || playerChoiceInt < 1)
                    {
                        Console.WriteLine($" {playerChoice} is not a valid choice. Number out of range");
                    } else
                    {
                        // play game
                        // computer selection
                        int computerChoice = rand.Next(1, 4);
                        // int computerChoice = 2;

                        //check who won. copied from example code in class
                        if ((playerChoiceInt == 1 && computerChoice == 2)
                            || (playerChoiceInt == 2 && computerChoice == 3)
                            || (playerChoiceInt == 3 && computerChoice == 1)) Console.WriteLine("Computer Wins");
                        else if (playerChoiceInt == computerChoice) Console.WriteLine("Tie Game!!");
                        else 
                        {
                            Console.WriteLine("Player Wins!!!");
                        }
                        rounds += 1;

                    }
                    
                    
                } while (rounds < 3);
            //     // string playAgain = "yes";
            //     string playAgain;
            //     Console.WriteLine("Do you want to play again? yes or no");
            //     string playAgain = Console.ReadLine();
            // } while (playAgain == "yes");

        }
    }
}
