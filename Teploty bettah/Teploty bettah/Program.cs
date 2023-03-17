using Spectre.Console;
Dictionary<double, double> teploty = new Dictionary<double, double>();

bool cykl = true;
for (int den = 1; den <= 31; den++)
{
    while (cykl == true)
    {
        Console.Write($"Zadej teplotu na den {den}: ");
        if (int.TryParse(Console.ReadLine(), out int teplota))
        {
            teploty[den] = teplota;
            Console.Clear();

            string otazka = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Chcete vyhodnotit zadané teploty?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](pohybuj se šipkami)[/]")
                    .AddChoices(new[] {
                        "Ano", "Ne"
                    }));
            if (otazka.Equals("Ano"))
            {
                cykl = false;
            }
            else
            {
                den++;
            }
        }
        else
        {
            Console.WriteLine("Neplatný vstup, zkus to znovu.");
        }
    }
}

double prumer = teploty.Values.Average();
double max = teploty.Values.Max();
double min = teploty.Values.Min();
Console.WriteLine($"Průměrná teplota pro zadané dny je: {prumer}°C");
Console.WriteLine($"Nejvyšší teplota pro zadané dny je: {max}°C");
Console.WriteLine($"Nejnižší teplota pro zadané dny je: {min}°C");
