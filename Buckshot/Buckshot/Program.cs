﻿using GameEngine;
using System;

namespace Buckshot
{
    class Program
    {
        public string Name = "Gold";

        public bool Devkit = true;
        static void Main(string[] args)
        {
            Program program = new Program();
            MainEngine game = new("Gold", 5);

            //program.MainGame(game);
            program.Selector("s");//-------------------|||||||---------------------------->|| EZ A SZAR NEM AKAR MŰKÖDNI !!!!!!!! <------------||||||||------------------
            
        }

        public void Selector(string highlight)
        {
            string getted = highlight == "Shoot" ? "Player" : "Self"; // Ha Shoot, akkor Shoot, más esetben Self

            Console.WriteLine("Player");
            Console.WriteLine("Self");

            for (int i = 0; i < 10; i++) // 10 iteráció
            {
                // Visszalép két sorral
                Console.SetCursorPosition(0, Console.CursorTop - 2);

                if (i % 2 == 0) // Páros iteráció: Player kiemelve
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Player");
                    Console.ResetColor();
                    Console.WriteLine("Self"); // Az értékek nem változnak, csak a szín
                }
                else // Páratlan iteráció: Self kiemelve
                {
                    Console.WriteLine("Player");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Self"); // Az értékek nem változnak, csak a szín
                    Console.ResetColor();
                }

                Thread.Sleep(200); // Késleltetés
            }
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            if(getted == "Player")
            {
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine("Player");
                Console.ResetColor();
                Console.WriteLine("Self");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Player");
                Console.ResetColor();
                Console.WriteLine("Self");
            }
        }






        public void MainGame(MainEngine game)
        {
            

            void EnergyValid(string actor)
            {
                int Energy = game.Energys(actor);
                if (Energy > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                }
                else if (Energy == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; 
                }
                else if (Energy == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                }

            }

            void Displyer()
            {
                Console.Write($"{Name}\t\t\t{Name}: ");

                EnergyValid("player");
                Console.Write($"{game.Energys("player")}\n");
                Console.ResetColor();
                Console.Write($"Dealer\t\t\tDealer: ");
                EnergyValid("dealer");
                Console.Write($"{game.Energys("dealer")}\n");
                Console.ResetColor();
                if (Devkit == true)
                {

                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.Write($"Shells ({game.Shells.Count}): ");
                    for (int i = 0; i < game.Shells.Count; i++)
                    {
                        string item = game.Shells[i];
                        if (item == "Live")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }

                        // Utolsó elem után nincs vessző
                        if (i < game.Shells.Count - 1)
                        {
                            Console.Write($"{item},");
                        }
                        else
                        {
                            Console.Write($"{item}");
                        }
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }




            bool Current = true;
            while (game.Rounds < 4)
            {
                Console.Clear();
                game = new("Gold", 5);
                
                while (game.LowestEnergy() != 0)
                {
                    if (game.Shells.Count == 0)
                    {
                        game.NewShells();
                    }
                    bool run = true;
                    Displyer();
                    while (run)
                    {
                        string actor = Current == true ? "player" : "dealer";
                        if (actor == "player")
                        {


                            Console.Write($"Q Dealer | E  Self | Shells({game.Shells.Count}): {string.Join(',', game.Shells)} ");
                            ConsoleKeyInfo gomb = Console.ReadKey();
                            if (gomb.Key == ConsoleKey.Q)
                            {
                                game.Shoot(actor);
                                Current = !Current;
                                run = false;
                            }
                            else if (gomb.Key == ConsoleKey.E)
                            {
                                game.MeShoot(actor);
                                if (game.Last_P_Shot == "Live")
                                {
                                    Current = !Current;
                                }
                                run = false;
                            }
                        }
                        else
                        {
                            game.DealerRound("dealer", out string ChosedAction);
                            if (ChosedAction == "MeShoot")
                            {
                                if (game.Last_D_Shot == "Live")
                                {
                                    Current = !Current;
                                }
                            }
                            else if (ChosedAction == "Shoot")
                            {
                                Current = !Current;
                            }
                            //Console.WriteLine(ChosedAction);
                            Selector(ChosedAction);
                            run = false;
                        }

                    }


                    Console.WriteLine($"\nPlayer: {game.Energys("player")} Dealer: {game.Energys("dealer")} Lowest: {game.LowestEnergy()} ");
                    Console.ReadLine();
                }

            }
        }
    }
}