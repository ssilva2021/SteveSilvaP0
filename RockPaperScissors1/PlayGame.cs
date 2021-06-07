using System;

namespace RockPaperScissors1
{
    public class PlayGame
    {
        public string Intro()
        {
            String Message = "Welcome to Rock Paper Scissors\n\n\tPaper defeats Rock\n\tRock defeats Scissors\n\tScissors defeats Paper\n\n";
            return Message;
        }
        public int getChoice()
        {
            //prompt for choice
            bool successfulConversion = false;
            int playerChoiceInt;

            do{
                    Console.WriteLine("Enter the number of your choice\n1. Rock\n2. Paper\n3.Scissors");
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
                        return playerChoiceInt;
                    }

            }while(true);
        }
        public void playRound(Player player1, Player player2)
        {
            //get a random number generator object
            Random rand = new Random();

            // play game
            player1.choice = getChoice();
            
            // computer selection (player 2 for now)
            // int computerChoice = rand.Next(1, 4);
            player2.choice = rand.Next(1, 4);
            Console.WriteLine($"The computer chose {player2.choice}");

            //check who won. copied from example code in class
            if ((player1.choice == 1 && player2.choice == 2)
                || (player1.choice == 2 && player2.choice == 3)
                || (player1.choice == 3 && player2.choice == 1)){
                    //player2 wins
                 Console.WriteLine("Computer Wins");
                 player2.wins += 1;
                }
            else if (player1.choice == player2.choice) Console.WriteLine("Tie Game!!");
            else 
            {
                // player 1 wins
                Console.WriteLine("Player Wins!!!");
                player1.wins +=1;
            }

        }
    }

    // public class SomethingElse
    // {
    //     public int Id { get; set; }

    //     public string Name { get; set; }
    // }
}