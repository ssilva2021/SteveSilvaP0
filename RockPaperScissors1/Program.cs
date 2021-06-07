using System;

namespace RockPaperScissors1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intro
            // Console.WriteLine("Welcome to Rock Paper Scissors");
            // Console.WriteLine("Paper defeats Rock");
            // Console.WriteLine("Rock defeats Scissors");
            // Console.WriteLine("Scissors defeats Paper");
            PlayGame currentGame = new PlayGame();
            Console.WriteLine(currentGame.Intro());

            Player player1 = new Player();
            player1.getName();
            Console.WriteLine($"Hello {player1.fname}");

            Player computer = new Player();
            computer.fname = "computer";


            int rounds = 0;
            // int computerChoice;
            string playAgain;
            
            do
            {   
                rounds = 0;  
                player1.wins = 0;
                computer.wins = 0;
                       
                do
                {
                    currentGame.playRound(player1, computer);
                    rounds++;
                } while (rounds < 3 && player1.wins < 2 && computer.wins < 2);
                Console.WriteLine($"wins for {player1.fname} = {player1.wins}");
                Console.WriteLine($"wins for {computer.fname} = {computer.wins}");
                Console.WriteLine("Do you want to play again? yes or no");
                playAgain = Console.ReadLine();
            } while (playAgain == "yes");

        }
    }
}
