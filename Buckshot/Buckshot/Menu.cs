﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckshot
{
    internal class Menu
    {

        Loader GetLoader = new Loader();   
        public void SetName(out string name)
        {

            static void AnimateText(string text)
            {
                Random random = new Random();
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Console.Write("\t\t\t\t");
                foreach (char targetChar in text)
                {
                    if (targetChar == ' ') // Ha szóköz, ne animáljunk
                    {
                        Console.Write(' ');
                        Thread.Sleep(90);
                        continue;
                    }

                    for (int i = 0; i < 5; i++) // Pörgetés
                    {
                        char randomChar = chars[random.Next(chars.Length)];
                        Console.Write(randomChar); // Véletlenszerű karakter
                        Thread.Sleep(50);         // Idő a pörgetéshez
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // Visszalép a kurzor
                    }

                    Console.Write(targetChar); // Megjeleníti a célt
                    Thread.Sleep(150); // Rövid szünet a következő karakter előtt
                }
                Console.WriteLine(); // Új sor a végén
            }
            
            void ContractPaper(string NameChar)
            {

                Console.SetCursorPosition(0, 1);
                string tab = "\t\t\t";
                string text = $"{tab}--------------------------------" +
                               "\n| GENERAL RELEASE OF LIABILITY |" +
                               "\n|                              |" +
                               "\n| &%$ @#$!@ !@$ $*#^@%@! $*@$! |" +
                               "\n| * %^#$ &#^$ !%^ &&^ %$@^$#$^ |" +
                               "\n| @#$ %&^ %$# @!@# $%^& &^% *^ |" +
                               "\n| !#! $@% #@* %&# %$@! %$^&%&* |" +
                               "\n| % $%$ $%^%$ #*& @!@# $%^& &^ |" +
                              $"\n| sign here: {NameChar.PadRight(6, ' ')};             |" +
                               "\n|                              |" +
                               "\n--------------------------------" +
                               "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\n')
                    {
                        Console.Write("\n" + tab);
                        continue;

                    }
                    else if (text[i] == ':')
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        continue;
                    }
                    else if (text[i] == ';')
                    {
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write(text[i]);
                }
                //Console.WriteLine(text);

            }

            string NameChar = "";

            bool run = true;
            string text = "Sign the waiver!";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            AnimateText(text);
            Console.ResetColor();
            while (run)
            {
                ContractPaper(NameChar);
                ConsoleKeyInfo gomb = Console.ReadKey(true);

                if (char.IsLetter(gomb.KeyChar) && gomb.KeyChar is >= 'A' and <= 'Z' or >= 'a' and <= 'z')
                {
                    if (NameChar.Count() + 1 != 7)
                    {


                        NameChar += gomb.Key.ToString();

                    }
                }
                else if(gomb.Key == ConsoleKey.Backspace && NameChar.Count()-1 >= 0)
                {
                    NameChar = NameChar.Remove(NameChar.Length - 1);
                }
                else if(gomb.Key == ConsoleKey.Enter && NameChar.Count() >= 2)
                {
                    run = false;
                }
            }
            name = NameChar;
            


            //Console.WriteLine("\n--------------------------------" +
            //                  "\n| GENERAL RELEASE OF LIABILITY |" +
            //                  "\n|                              |" +
            //                  "\n| &%$ @#$!@ !@$ $*#^@%@! $*@$! |" +
            //                  "\n| * %^#$ &#^$ !%^ &&^ %$@^$#$^ |" +
            //                  "\n| @#$ %&^ %$# @!@# $%^& &^% *^ |" +
            //                  "\n| !#! $@% #@* %&# %$@! %$^&%&* |" +
            //                  "\n| % $%$ $%^%$ #*& @!@# $%^& &^ |" +
            //                  "\n| sign here ______             |" +
            //                  "\n|                              |" +
            //                  "\n--------------------------------" +
            //                  "");


        }

        public int[] Valasz = { 3, 3, 9, 5, 3 };
        void Settings()
        {
            bool exit = true;
            int Diff = 0;
            string[] Szintek = { "StarterItemsCount", "MinShells", "MaxShells", "MaxRound", "StarterHealth" };
            
            while (exit)
            {
                string spacing = "\t\t\t";
                const string author = "██████╗ ██╗   ██╗ ██████╗██╗  ██╗███████╗██╗  ██╗ ██████╗ ████████╗\r\n██╔══██╗██║   ██║██╔════╝██║ ██╔╝██╔════╝██║  ██║██╔═══██╗╚══██╔══╝\r\n██████╔╝██║   ██║██║     █████╔╝ ███████╗███████║██║   ██║   ██║   \r\n██╔══██╗██║   ██║██║     ██╔═██╗ ╚════██║██╔══██║██║   ██║   ██║   \r\n██████╔╝╚██████╔╝╚██████╗██║  ██╗███████║██║  ██║╚██████╔╝   ██║   \r\n╚═════╝  ╚═════╝  ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝ ╚═════╝    ╚═╝   ";

                Console.Clear();
                DisplayIntro(author, spacing);

                Print(spacing);
                ConsoleKeyInfo gomb = Console.ReadKey();
                if (gomb.Key == ConsoleKey.Escape || gomb.Key == ConsoleKey.Enter)
                {
                    exit = false;
                    
                }
                else if (gomb.Key == ConsoleKey.S || gomb.Key == ConsoleKey.DownArrow)
                {
                    if (Diff + 1 < Szintek.Length)
                    {
                        Diff++;
                    }
                }
                else if (gomb.Key == ConsoleKey.W || gomb.Key == ConsoleKey.UpArrow)
                {
                    if (Diff - 1 >= 0)
                    {
                        Diff--;
                    }
                }
                else if(gomb.Key == ConsoleKey.LeftArrow)
                {
                    if (Valasz[Diff]-1 != 0)
                    {
                        if (Diff == 2 && Valasz[Diff]-1 > Valasz[1]) //"MaxShells"
                        {
                            Valasz[Diff]--;
                        }
                        else if(Diff != 2)
                        {
                            Valasz[Diff]--;
                        }
                    }
                }
                else if (gomb.Key == ConsoleKey.RightArrow)
                {
                    switch (Diff)
                    {
                        //"StarterItemsCount", "MinShells", "MaxShells", "MaxRound", "StarterHealth"
                        case 0:
                            if (Valasz[Diff] < 8) //"StarterItemsCount"
                            {
                                Valasz[Diff]++;
                            };
                            continue;
                        case 1:
                            if (Valasz[Diff] <= 5 && Valasz[Diff]+1 < Valasz[2]) //"MinShells"
                            {
                                Valasz[Diff]++;
                            };
                            continue;
                        case 2:
                            if (Valasz[Diff] <= 9 ) //"MaxShells"
                            {
                                Valasz[Diff]++;
                            };
                            continue;
                        case 3:
                            if (Valasz[Diff] <= 9)
                            {
                                Valasz[Diff]++;
                            };
                            continue;
                        case 4:
                            if (Valasz[Diff] <= 7)
                            {
                                Valasz[Diff]++;
                            };
                            continue;
                    }
                }
            }


            void Print(string spaceing)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{spaceing}\t\t     \x1b[3mJáték módosítási opciók\x1b[0m\n");

                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╭".PadRight(30, '─')}╮");

                for (int i = 0; i < Szintek.Length; i++)
                {
                    Console.Write(spaceing + "\t\t  ");
                    if (i == Diff)
                    {

                        Console.Write($"\u001b[91m│   \x1b[93m> \x1b[92m{Szintek[i]}:{Valasz[i].ToString().PadLeft(21 - Szintek[i].Length, ' ')  }\u001b[91m  │");
                    }
                    else
                    {
                        Console.Write($"\u001b[91m│   \x1b[39m{Szintek[i]}:{Valasz[i].ToString().PadLeft(23 - Szintek[i].Length, ' ')}\u001b[91m  │");
                    }
                    Console.WriteLine();
                    Console.ResetColor();

                }
                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╰".PadRight(30, '─')}╯");
                Console.ResetColor();
            }
        }
        public void MainMenu(out int[] ConfigData)
        {
            ConfigData = Valasz;
            string[] Szintek = { "Settings", "Indítás" };
            Action[] funkciok = { Settings , Inditas };

            #region menu

            bool exit = true;
            int Diff = 0;
            while (exit)
            {

                string spacing = "\t\t\t";
                const string author = "██████╗ ██╗   ██╗ ██████╗██╗  ██╗███████╗██╗  ██╗ ██████╗ ████████╗\r\n██╔══██╗██║   ██║██╔════╝██║ ██╔╝██╔════╝██║  ██║██╔═══██╗╚══██╔══╝\r\n██████╔╝██║   ██║██║     █████╔╝ ███████╗███████║██║   ██║   ██║   \r\n██╔══██╗██║   ██║██║     ██╔═██╗ ╚════██║██╔══██║██║   ██║   ██║   \r\n██████╔╝╚██████╔╝╚██████╗██║  ██╗███████║██║  ██║╚██████╔╝   ██║   \r\n╚═════╝  ╚═════╝  ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝ ╚═════╝    ╚═╝   ";

                Console.Clear();
                DisplayIntro(author, spacing);

                Print(spacing);
                ConsoleKeyInfo gomb = Console.ReadKey();
                if (gomb.Key == ConsoleKey.Escape || gomb.Key == ConsoleKey.Enter)
                {
                    if (Szintek[Diff] == "Indítás")
                    {
                        exit = false;
                    }
                    try
                    {
                        funkciok[Diff].Invoke();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Hiányos funkció lista: {e.Message}");
                    }
                }
                
                else if (gomb.Key == ConsoleKey.S || gomb.Key == ConsoleKey.DownArrow)
                {
                    if (Diff + 1 < Szintek.Length)
                    {
                        Diff++;
                    }
                }
                else if (gomb.Key == ConsoleKey.W || gomb.Key == ConsoleKey.UpArrow)
                {
                    if (Diff - 1 >= 0)
                    {
                        Diff--;
                    }
                }

            }

            void Print(string spaceing)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{spaceing}\t\t     \x1b[3mFőmenu indítási opciók\x1b[0m\n");

                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╭".PadRight(30, '─')}╮");

                for (int i = 0; i < Szintek.Length; i++)
                {
                    Console.Write(spaceing + "\t\t  ");
                    if (i == Diff)
                    {

                        Console.Write($"\u001b[91m│\t   \x1b[93m> \x1b[92m{Szintek[i]}\x1b[39m{"".PadRight(19 - Szintek[i].Length, ' ')}\u001b[91m│");
                    }
                    else
                    {
                        Console.Write($"\u001b[91m│\t   \x1b[39m{Szintek[i]}{"".PadRight(21 - Szintek[i].Length, ' ')}\u001b[91m│");
                    }
                    Console.WriteLine();
                    Console.ResetColor();

                }
                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╰".PadRight(30, '─')}╯");
                Console.ResetColor();
            }
            #endregion
        }





        void DisplayIntro(string intro, string spacing)
        {
            Console.Clear();
            string[] lines = intro.Split('\n');
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (string line in lines)
            {
                Console.WriteLine(spacing+"  " + line);
            }
            Console.ResetColor();
        }


        void Inditas()
        {
            Console.Clear();
            //SetName(out string name);
            GetLoader.LoadingAnimation(Random.Shared.Next(2,5));
            Thread.Sleep(500);
            Console.Clear();
            
        }



    }
}
