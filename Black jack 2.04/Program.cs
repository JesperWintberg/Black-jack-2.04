namespace ____
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            string[] suits = { "Klöver", "Spader", "Knäckt", "Hjärter" };


            Random random = new Random();

            Console.ForegroundColor = ConsoleColor.Blue;

            // Startar Spelet
            bool spel = true;

            //bool som startar player while loopen
            bool sant = true;

            //bool som i steg 1 visar spelregler
            bool spelregler = false;

            //bool som stänger av spelet
            bool avslutning = false;

            //Skapar bool som väljer vinnare 
            bool vinnare = true;

            //Bool som används om användaren skriven en felinmatning
            bool felinmatning = false;  

            //Lista för förra spelets vinnare
            List<string> vin = new List<string>();

            int rndmvalue = number[random.Next(0, 11)];
            int rndmvalue2 = number[random.Next(0, 11)];

            string rndmsuits = suits[random.Next(0, 4)];
            string rndmsuits2 = suits[random.Next(0, 4)];
            //----------------------------------------------//
            while (spel)
            {
                try
                {
                    //Start medelande
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Välkommen till Black jack!");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine();
                    Console.WriteLine("1. Spela Black Jack");
                    Console.WriteLine("2. See förra vinnaren");
                    Console.WriteLine("3. Spelets regler");
                    Console.WriteLine("4. Stänga av programet");
                    Console.WriteLine();
                    Console.Write("Skriv här: "); string start = Console.ReadLine();
                    int start2 = int.Parse(start);
                    Console.Clear();

                    switch (start2)
                    {
                        case 1:
                            sant = true;
                            break;
                        case 2:
                            Console.WriteLine("Den förra vinnaren var");
                            Console.WriteLine("----------------------");
                            for (int i = 0; i < vin.Count; i++)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(vin[i]);
                                Console.WriteLine();
                            }
                            Console.ForegroundColor = ConsoleColor.Blue; Console.Write("Vil du starta spelet (y/n): "); string val5 = Console.ReadLine();
                            Console.Clear();
                            if (val5 == "y")
                            {
                                spel = true;
                                avslutning = false;
                            }
                            else if (val5 == "n")
                            {
                                spel = false;
                                avslutning = true;
                            }
                            else
                            {
                                felinmatning = true;
                            }

                            break;
                        case 3:
                            spelregler = true;
                            avslutning = false;
                            break;
                        case 4:
                            avslutning = true;
                            sant = false;
                            break;

                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error: 501");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Spelet kommer starta om");
                    Console.Clear();
                    spel = true;
                }

 


               
                //--------------------------------------------------------------------------------------------//

                //Gör så att om man får två ess (11) så blir ett av essen värt 1 
                //Denna if funkar bara på första draget ej alla
                int round1 = rndmvalue + rndmvalue2;
                if (round1 >= 22)
                {
                    rndmvalue2 = 1;
                }


                //spelarens första två kort
                Console.WriteLine($"Dina startkort kommer att vara {rndmsuits} {rndmvalue} och {rndmsuits2} {rndmvalue2}");
                Console.WriteLine($"Du kommer nu att ha {rndmvalue + rndmvalue2} poäng");
                Console.Write("Vill du ta ett nytt kort (y/n): "); string val = Console.ReadLine();
                val.ToLower();
                Console.WriteLine();

                if (val == "y")
                {
                    sant = true;
                }

                else if (val == "n")
                {
                    sant = false;
                }

                else
                {
                    felinmatning = true;
                }

                int startplayer = rndmvalue + rndmvalue2;
                int endplayer = startplayer;

                if (startplayer > 21)
                {
                    vinnare = true;
                }


                try
                {
                    //Spelarens While loop
                    while (sant)
                    {
                        int rndmvalue5 = number[random.Next(0, 11)];
                        string rndmsuits5 = suits[random.Next(0, 4)];

                        if (endplayer == startplayer)
                        {
                            endplayer = startplayer + rndmvalue5;
                        }

                        else
                        {
                            endplayer = endplayer + rndmvalue5;
                        }


                        //inför 11 reglen i main loopen
                        if (rndmvalue5 == 11 && endplayer > 21)
                        {
                            rndmvalue5 = 1;
                        }


                        else if (endplayer > 21)
                        {
                            vinnare = false;
                            sant = false;
                            break;
                        }

                        else if (endplayer == 21)
                        {
                            vinnare = true;
                            sant = false;
                            break;
                        }

                        Console.WriteLine($"Du fick ett {rndmsuits5} {rndmvalue5}");
                        Console.WriteLine($"Du har nu {endplayer} poäng");
                        Console.Write("Vill du dra ett nytt kort? (y/n): "); string val2 = Console.ReadLine();
                        val2.ToLower();
                        Console.WriteLine();

                        if (val2 == "n")
                        {
                            sant = false;
                        }
                    }
                }

                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error: 504");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Spelet kommer starta om");
                    Console.Clear();
                    spel = true;
                }
                int rndmvalue3 = number[random.Next(0, 11)];
                int rndmvalue4 = number[random.Next(0, 11)];

                int PCstart = rndmvalue3 + rndmvalue4;

                //Infogar reglen med ess(11)
                if (PCstart > 21)
                {
                    rndmvalue4 = 1;
                }

                if (vinnare)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Grattis du har Vunnit!");
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("Skriv in ditt namn: "); vin.Add(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("Vill du köra igen (y/n): "); string val3 = Console.ReadLine();

                    if (val3 == "y")
                    {
                        spel = true;
                        avslutning = false;
                    }

                    else if (val3 == "n")
                    {
                        spel = false;
                        avslutning = true;
                    }

                    else
                    {
                        felinmatning = true;
                    }
                    Console.Clear();
                }

                if (!vinnare)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Du Förlorade");
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("Vill du köra igen (y/n): "); string val4 = Console.ReadLine();

                    if (val4 == "y")
                    {
                        spel = true;
                        avslutning = false;
                    }

                    else if (val4 == "n")
                    {
                        spel = false;
                        avslutning = true;
                    }
                    else
                    {
                        felinmatning = true;
                    }
                    Console.Clear();
                }
                try
                {
                    //Datrons while loop || avslutning
                    while (!sant)
                    {
                        int rndmvalue5 = number[random.Next(0, 11)];

                        int PCend = rndmvalue5 + PCstart;

                        //Infogar reglen med ess(11)
                        if (PCend > 21 && rndmvalue5 == 11)
                        {
                            rndmvalue5 = 1;
                        }


                        if (PCend >= 17)
                        {
                            if (PCend > 21)
                            {
                                vinnare = true;
                                break;
                            }

                            if (PCend == 21)
                            {
                                vinnare = false;
                                break;
                            }

                            else if (endplayer > PCend)
                            {
                                vinnare = true;
                                break;
                            }

                            else if (PCend > endplayer)
                            {
                                vinnare = false;
                                break;
                            }


                        }

                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error: 505");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Spelet kommer starta om");
                    Console.Clear();
                    spel = true;
                }
                //-----------------------------spelmedelande-------------------------------------------------//
                try
                {
                    // Visar spelregler 
                    while (spelregler)
                    {
                        Console.WriteLine("Spelregler");
                        Console.WriteLine("----------");
                        Console.WriteLine();
                        Console.WriteLine("I Black Jack så är ditt mål att nå 21 poäng eller så nära du bara kan.");
                        Console.WriteLine("Du får inte komma över 21 poäng för du förlorar du");
                        Console.WriteLine("Du kommer börja dra kort när du känner dig klar så kommer datorn att dra sinna kort");
                        Console.WriteLine("Lycka till");
                        Console.WriteLine();
                        Console.Write("Vill du starta spelet (y/n): "); string val4 = Console.ReadLine();
                        Console.Clear();

                        if (val4 == "y")
                        {
                            sant = true;
                        }
                        else if (val4 == "n")
                        {
                            avslutning = true;
                        }
                        else
                        {
                            felinmatning = true;
                        }
                        break;
                    }
                }

                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error: 503");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Spelet kommer starta om");
                    Console.Clear();
                    spel = true;
                }

                try
                {
                    //Avslutnings medelande
                    if (avslutning)
                    {
                        Console.WriteLine("Spelet avslutas nu!");
                        Console.WriteLine("------------------");
                        Console.WriteLine();
                        Console.WriteLine("Tack för du har spelat");
                        Console.WriteLine("Ha en bra dag");
                        Environment.Exit(1);
                    }

                }

                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error: 502");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Spelet kommer starta om");
                    Console.Clear();
                    spel = true;
                }

                if (felinmatning)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Felaktig inmatning, försök igen");
                    Console.Clear();
                    spel = true;
                    break;
                }
            }
        }
    }
}


