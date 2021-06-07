using System;

namespace RockPaperScissors1
{
    public class Player
    {
        public string fname;
        public string lname;
        public int wins = 0;
        public int choice;

        public void getName()
        {
            Console.WriteLine("What is your first name?");
            fname = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            lname = Console.ReadLine();
            return;
        }
    
    }

    // public class SomethingElse
    // {
    //     public int Id { get; set; }

    //     public string Name { get; set; }
    // }
}