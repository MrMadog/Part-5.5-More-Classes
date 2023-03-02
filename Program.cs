namespace Part_5._5___More_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bet, roll1, roll2, sum;
            double betAmount, accountBalance;
            bool done;
            string answer;
            done = false;
            accountBalance = 100.00;

            Die die1 = new Die();

            Console.WriteLine("Dice Game --");
            Console.WriteLine();
            while (done != true)
            {
                Console.WriteLine("In this game, you will bet on the outcome of 2 dice being rolled.");
                Console.WriteLine();
                Console.WriteLine($"Your account balance is: ${accountBalance}");
                Console.WriteLine();
                Console.WriteLine("Your bet options are: ");
                Console.WriteLine("1 - Doubles, 2 - not Doubles, 3 - Even Sum, 4 - Odd Sum");
                Console.WriteLine();
                Console.Write("YOUR BET:  ");

                if (Int32.TryParse(Console.ReadLine(), out bet) && bet <= 4 && bet >= 1)
                {
                    Console.WriteLine();
                    Console.Write("YOUR BET AMOUNT:  $");
                    if (Double.TryParse(Console.ReadLine(), out betAmount))
                    {
                        betAmount = Math.Round(betAmount, 2);
                        if (betAmount < 0)
                        {
                            betAmount = 0.00;
                        }
                        else if (betAmount > accountBalance)
                        {
                            betAmount = accountBalance;
                        }

                        Console.WriteLine();
                        Console.Write("Press ENTER to roll ");
                        Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Rolling...");
                        Thread.Sleep(1500);
                        Console.WriteLine();

                        Console.WriteLine("Die 1: ");
                        die1.RollDie();
                        die1.DrawRoll();
                        roll1 = die1.Roll;
                        Thread.Sleep(1000);

                        Console.WriteLine("Die 2: ");
                        die1.RollDie();
                        die1.DrawRoll();
                        roll2 = die1.Roll;
                        Console.WriteLine();

                        sum = roll1 + roll2;

                        // DOUBLES ------------------------------------------------------------------------------------------------------------------------------
                        if (bet == 1)
                        {
                            Console.WriteLine("Your bet was Doubles: ");

                            if (roll1 == roll2)
                            {
                                Console.WriteLine("YOU WIN!");
                                accountBalance = accountBalance + betAmount * 2;
                                Console.WriteLine($"You bet ${betAmount} on Doubles, and won ${betAmount * 2}.");
                            }
                            else
                            {
                                Console.WriteLine("YOU LOSE!");
                                accountBalance = accountBalance - betAmount;
                                Console.WriteLine($"You bet ${betAmount} on Doubles, and lost ${betAmount}.");
                            }
                            Math.Round(accountBalance, 2);
                            Console.WriteLine($"Your account now stands at ${accountBalance}.");
                        }

                        // NOT DOUBLES --------------------------------------------------------------------------------------------------------------------------
                        else if (bet == 2)
                        {
                            Console.WriteLine("Your bet was Not Doubles: ");

                            if (roll1 != roll2)
                            {
                                Console.WriteLine("YOU WIN!");
                                accountBalance = accountBalance + betAmount * 0.5;
                                Console.WriteLine($"You bet ${betAmount} on Not Doubles, and won ${betAmount / 2}.");
                            }
                            else
                            {
                                Console.WriteLine("YOU LOSE!");
                                accountBalance = accountBalance - betAmount;
                                Console.WriteLine($"You bet ${betAmount} on Not Doubles, and lost ${betAmount}.");
                            }
                            Math.Round(accountBalance, 2);
                            Console.WriteLine($"Your account now stands at ${accountBalance}.");
                        }

                        // EVEN SUM -----------------------------------------------------------------------------------------------------------------------------
                        else if (bet == 3)
                        {
                            Console.WriteLine("Your bet was Even Sum: ");

                            if (sum % 2 == 0)
                            {
                                Console.WriteLine("YOU WIN!");
                                accountBalance = accountBalance + betAmount;
                                Console.WriteLine($"You bet ${betAmount} on Even Sum, and won ${betAmount}.");
                            }
                            else
                            {
                                Console.WriteLine("YOU LOSE!");
                                accountBalance = accountBalance - betAmount;
                                Console.WriteLine($"You bet ${betAmount} on Even Sum, and lost ${betAmount}.");
                            }
                            Math.Round(accountBalance, 2);
                            Console.WriteLine($"Your account now stands at ${accountBalance}.");
                        }

                        // ODD SUM ------------------------------------------------------------------------------------------------------------------------------
                        else if (bet == 4)
                        {
                            Console.WriteLine("Your bet was Odd Sum: ");

                            if (sum % 2 == 0)
                            {
                                Console.WriteLine("YOU LOSE!");
                                accountBalance = accountBalance - betAmount;
                                Console.WriteLine($"You bet ${betAmount} on Odd Sum, and lost ${betAmount}.");
                            }
                            else
                            {
                                Console.WriteLine("YOU WIN!");
                                accountBalance = accountBalance + betAmount;
                                Console.WriteLine($"You bet ${betAmount} on Odd Sum, and won ${betAmount}.");
                            }
                            Math.Round(accountBalance, 2);
                            Console.WriteLine($"Your account now stands at ${accountBalance}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }



                // QUIT -----------------------------------------------------------------------------------------------------------------------------------------
                Console.WriteLine();
                Console.Write("Would you like to quit?(Y/N) ");
                answer = Console.ReadLine().ToUpper();
                if (answer == "Y" || answer == "YES")
                {
                    Console.WriteLine();
                    Console.WriteLine("Game Over.");
                    Thread.Sleep(1000);
                    done = true;
                }
                else if (answer == "N" && accountBalance < 0 || answer == "NO" && accountBalance < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Insufficient funds");
                    Thread.Sleep(1000);
                    Console.WriteLine("Game Over.");
                    Thread.Sleep(1000);
                    done = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Okay, lets continue...");
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}