using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int coins = 50;
            Console.WriteLine("Welcome to the slot machine game!");
            Console.WriteLine("You have " + coins + " coins to start with.");
            while (coins > 0)
            {
                Console.WriteLine("Enter your bet: ");
                int bet = Convert.ToInt32(Console.ReadLine());
                if (bet > coins)
                {
                    Console.WriteLine("You do not have enough coins for that bet.");
                    continue;
                }
                coins -= bet;

                int[,] grid = new int[3, 3];
                Random random = new Random();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        grid[i, j] = random.Next(0, 2);
                    }
                }

                Console.WriteLine("Grid: ");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                bool win = false;
                for (int i = 0; i < 3; i++)
                {
                    if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
                    {
                        win = true;
                        break;
                    }
                    if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
                    {
                        win = true;
                        break;
                    }
                }
                if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
                {
                    win = true;
                }
                if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
                {
                    win = true;
                }
                if (win)
                {
                    Console.WriteLine("Congratulations! You won " + (bet * 2) + " coins!");
                    coins += bet * 2;
                }
                else
                {
                    Console.WriteLine("Sorry, you lost " + bet + " coins.");
                }
                Console.WriteLine("You now have " + coins + " coins.");
                Console.WriteLine("Would you like to play again? (y/n)");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }
            Console.WriteLine("Thanks for playing! You leave with " + coins + " coins.");
            Console.ReadLine();
        }
    }
}