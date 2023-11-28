
class Program
{
    static void Main()
    {
        int wiersze = 0;
        int kolumny = 0;
        char[,] labirynt = new char[wiersze, kolumny];
        List<string> nazwaLabs = new List<string>();
        List<char[,]> labirynty = new List<char[,]>();
        Console.WriteLine("LEGENDA :\np-puste\n#-sciana\n.-sciezka");
        while (true)
        {
            bool czyMaWiersze = labirynt.GetLength(0) == 0;
            if (czyMaWiersze == false)
            {
                Console.WriteLine("oto twoj obecny labirynt(ostatnio pomyslnie zaladowany): ");
                for (int i = 0; i < wiersze; i++)
                {
                    for (int j = 0; j < kolumny; j++)
                    {
                        Console.Write(labirynt[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("stworz swoj pierwszy labirynt");
            }

            Console.WriteLine("*menu:*");
            Console.WriteLine("1. dodaj nowy labirynt");
            Console.WriteLine("2. modyfikuj element w labiryncie");
            Console.WriteLine("3. zapisz labirynt");
            Console.WriteLine("4. wczytaj labirynt");
            Console.WriteLine("5. wyjscie");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.WriteLine("podaj liczbe wierszy labiryntu(max 15): ");
                    string wierszeStr = Console.ReadLine();
                    Console.WriteLine("podaj liczbe kolumn labiryntu(max15): ");
                    string kolumnyStr = Console.ReadLine();

                    if ((int.TryParse(wierszeStr, out int wierszeP) && (int.TryParse(kolumnyStr, out int kolumnyP))))
                    {
                        if ((wierszeP <= 15 && wierszeP > 0) && (kolumnyP <= 15 && kolumnyP > 0))
                        {
                            wiersze = wierszeP;
                            kolumny = kolumnyP;
                            labirynt = new char[wiersze, kolumny];
                            for (int i = 0; i < wiersze; i++)
                            {
                                for (int j = 0; j < kolumny; j++)
                                {
                                    labirynt[i, j] = 'p';
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("BŁĄD! labirynt nie zostal utworzony. podano bledna ilosc wierszy lub kolumn");
                        }
                    }
                    else
                    {
                        Console.WriteLine("BŁĄD! labirynt nie zostal utworzony. podano bledny typ wierszy lub kolumn");
                    }
                    break;
                case "2":
                    bool czyjestLab = labirynt.GetLength(0) == 0;
                    if (czyjestLab == false)
                    {
                        Console.WriteLine("podaj wspolrzedne do modyfikacji");
                        Console.WriteLine("numer wiersza: ");
                        string wierszStr = Console.ReadLine();
                        Console.WriteLine("numer kolumny: ");
                        string kolumnaStr = Console.ReadLine();
                        if ((int.TryParse(wierszStr, out int wiersz) && (int.TryParse(kolumnaStr, out int kolumna))))
                        {
                            wiersz = wiersz - 1;
                            kolumna = kolumna - 1;
                            if ((wiersz < wiersze && wiersz >= 0) && (kolumna < kolumny && kolumna >= 0))
                            {
                                Console.WriteLine("wybierz zawartosc:");
                                Console.WriteLine("1. pusty");
                                Console.WriteLine("2. sciana");
                                Console.WriteLine("3. sciezka");

                                string wybor1 = Console.ReadLine();
                                switch (wybor1)
                                {
                                    case "1":
                                        labirynt[wiersz, kolumna] = 'p';
                                        break;
                                    case "2":
                                        labirynt[wiersz, kolumna] = '#';
                                        break;
                                    case "3":
                                        labirynt[wiersz, kolumna] = '.';
                                        break;
                                    default:
                                        Console.WriteLine("BŁĄD! labirynt nie zostal zmodyfikowany. podano bledne wypelnienie komorki");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("BŁĄD! labirynt nie zostal zmodyfikowany. podano bleda komorke do modyfikacji");
                            }
                        }
                        else
                        {
                            Console.WriteLine("BŁĄD! labirynt nie zostal zmodyfikowany. podano bledny typ wiersza lub kolumny");
                        }
                    }
                    else
                    {
                        Console.WriteLine("BŁĄD! nie posiadasz zadnego labiryntu do edycji :(");
                    }
                    break;
                case "3":
                    Console.WriteLine("podaj nazwe pliku do zapisu: ");
                    string nazwaPliku = Console.ReadLine();
                    using (StreamWriter writer = new StreamWriter(nazwaPliku + ".txt"))
                    {
                        for(int i = 0; i < wiersze; i++)
                        {
                            for(int j = 0; j < kolumny; j++)
                            {
                                writer.Write(labirynt[i, j] + " ");
                            }
                            writer.WriteLine();
                        }
                        Console.WriteLine("labirynt zostal pomyslnie zapisany do pliku txt");
                    }
                        break;
                case "4":
                   
                    break;
                case "5":
                    Console.WriteLine("wyjscie! pa"); Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("BŁĄD! podaj prawidlowy wybor");
                    break;
            }
        }
    }
}
/*
            zapis stary

                    bool czyjestLabDoZap = labirynt.GetLength(0) == 0;
                    if (czyjestLabDoZap == false)
                    {
                        Console.WriteLine("podaj nazwe labiryntu: ");
                        string nazwaLab = Console.ReadLine();
                        nazwaLabs.Add(nazwaLab);
                        char[,] zapis = new char[wiersze, kolumny];
                        Array.Copy(labirynt, zapis, labirynt.Length);
                        labirynty.Add(zapis);
                        Console.WriteLine("labirynt zostal pomyslnie zapisany");
                    }
                    else
                    {
                        Console.WriteLine("BŁĄD! nie posiadasz zadnego labiryntu do zapisu :(");
                    } 

            wczytanie stary

             bool czyJestZapis = labirynty.Any();
                    if (czyJestZapis == true)
                    {
                        Console.WriteLine("wybierz element do wyswietlenia: ");
                        int y = 0;
                        foreach (char[,] id in labirynty)
                        { 
                            Console.WriteLine("labirynt " + nazwaLabs[y] + ":");
                            y++;
                            for (int i = 0; i < id.GetLength(0); i++)
                            {
                                for (int j = 0; j < id.GetLength(1); j++)
                                {
                                    Console.Write(id[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        try
                        {
                            int wybranyLab = Convert.ToInt32(Console.ReadLine()) - 1;
                            wiersze = labirynty[wybranyLab].GetLength(0);
                            kolumny = labirynty[wybranyLab].GetLength(1);
                            labirynt = new char[wiersze, kolumny];
                            Array.Copy(labirynty[wybranyLab], labirynt, labirynt.Length);

                        }
                        catch
                        {
                            Console.WriteLine("BŁĄD! labirynt nie zostal wczytany. podano bledny wybor labiryntu");

                        }
                    }
                    else
                    {
                        Console.WriteLine("BŁĄD! nie posiadasz zadnego labiryntu do wczytania :(");
                    }
 */
