var produktName = new List<string>();
var productPrice = new List<double>();
var productQuantity = new List<int>();

const double MOMS = .25;

produktName.Add("Laptop");
productPrice.Add(15999.99);
productQuantity.Add(5);
produktName.Add(item: "Mus");
productPrice.Add(299.50);
productQuantity.Add(15);
produktName.Add("Tangentbord");
productPrice.Add(899.00);
productQuantity.Add(8);
produktName.Add("Skärm");
productPrice.Add(3499.99);
productQuantity.Add(3);
produktName.Add("Hörlurar");
productPrice.Add(599.00);
productQuantity.Add(12);

while (true)
{
    Console.WriteLine("=== BUTIKSSYSTEM ===");
    Console.WriteLine("1. Visa produkter");
    Console.WriteLine("2. Lägg till produkt");
    Console.WriteLine("3. Sälj produkt");
    Console.WriteLine("4. Lägg till lager");
    Console.WriteLine("5. Sök produkt");
    Console.WriteLine("6. Rabattkalkylator");
    Console.WriteLine("7. Statistik");
    Console.WriteLine("8. Avsluta");
    Console.Write("Välj: ");

    var userInput = GetInput();

    if (userInput == "1")
    {
        Console.WriteLine("\nproduktName--- PRODUKTLISTA ---");
        for (var i = 0; i < produktName.Count; i++)
        {
            Console.WriteLine($"ID: {i} | Namn: {produktName[i]} | Pris: {productPrice[i]} kr | Lager: {productQuantity[i]} st");
        }

        Console.WriteLine();
    }
    else if (userInput == "2")
    {
        Console.Write("Produktnamn: ");
        var nn = GetInput();
        Console.Write("Pris: ");
        var pp = double.Parse(GetInput());
        Console.Write("Antal: ");
        var qq = int.Parse(GetInput());

        produktName.Add(nn);
        productPrice.Add(pp);
        productQuantity.Add(qq);
        Console.WriteLine("Produkt tillagd!\nproduktName");
    }
    else if (userInput == "3")
    {
        Console.Write("Produkt ID: ");
        var id = int.Parse(GetInput());

        if (id >= 0 && id < produktName.Count)
        {
            Console.Write("Antal att sälja: ");
            var a = int.Parse(GetInput());

            if (productQuantity[id] >= a)
            {
                productQuantity[id] = productQuantity[id] - a;
                var t = productPrice[id] * a;
                var moms = t * MOMS;
                Console.WriteLine("Sålt " + a + " st " + produktName[id]);
                Console.WriteLine("Totalpris: " + t + " kr");
                Console.WriteLine("Varav moms: " + moms + " kr");

                if (productQuantity[id] < 5)
                {
                    Console.WriteLine("VARNING: Lågt lager (" + productQuantity[id] + " st kvar)!");
                }
            }
            else
            {
                Console.WriteLine("FEL: Inte tillräckligt i lager!");
            }
        }
        else
        {
            Console.WriteLine("FEL: Produkten finns inte!");
        }

        Console.WriteLine();
    }
    else if (userInput == "4")
    {
        Console.Write("Produkt ID: ");
        var id = int.Parse(GetInput());

        if (id >= 0 && id < produktName.Count)
        {
            Console.Write("Antal att lägga till: ");
            var a = int.Parse(GetInput());
            productQuantity[id] = productQuantity[id] + a;
            Console.WriteLine("Lagt till " + a + " st " + produktName[id] + ". Nytt lager: " + productQuantity[id] + " st\nproduktName");
        }
        else
        {
            Console.WriteLine("FEL: Produkten finns inte!\nproduktName");
        }
    }
    else if (userInput == "5")
    {
        Console.Write("Sök produktnamn: ");
        var s = GetInput().ToLower();
        var f = false;

        for (var i = 0; i < produktName.Count; i++)
        {
            if (produktName[i].Contains(s, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Hittade: ID " + i + " - " + produktName[i] + " (" + productPrice[i] + " kr, " + productQuantity[i] + " st)");
                f = true;
            }
        }

        if (!f)
        {
            Console.WriteLine("Hittade inga produkter!");
        }

        Console.WriteLine();
    }
    else if (userInput == "6")
    {
        ShowDiscountList();
    }
    else if (userInput == "7")
    {
        ShowStats(produktName, productPrice, productQuantity);
    }
    else if (userInput == "8")
    {
        Console.WriteLine("Hejdå!");
        break;
    }
    else
    {
        Console.WriteLine("Ogiltigt val!\nproduktName");
    }
}

static string GetInput() => Console.ReadLine() ?? "";

static void ShowStats(List<string> produktName, List<double> productPrice, List<int> productQuantity)
{
    double tv = 0;
    var tp = 0;
    double hp = 0;
    double lp = 999999;
    var hn = "";
    var ln = "";

    for (var i = 0; i < produktName.Count; i++)
    {
        tv += productPrice[i] * productQuantity[i];
        tp += productQuantity[i];

        if (productPrice[i] > hp)
        {
            hp = productPrice[i];
            hn = produktName[i];
        }

        if (productPrice[i] < lp)
        {
            lp = productPrice[i];
            ln = produktName[i];
        }
    }

    var ap = tv / produktName.Count;

    Console.WriteLine("\nproduktName--- STATISTIK ---");
    Console.WriteLine("Totalt lagervärde: " + tv + " kr");
    Console.WriteLine("Totala produkter i lager: " + tp + " st");
    Console.WriteLine("Antal olika produkter: " + produktName.Count);
    Console.WriteLine("Genomsnittspris: " + ap + " kr");
    Console.WriteLine("Dyraste produkt: " + hn + " (" + hp + " kr)");
    Console.WriteLine("Billigaste produkt: " + ln + " (" + lp + " kr)");
    Console.WriteLine();
}

static void ShowDiscountList()
{
    Console.Write("Ange belopp: ");
    var b = double.Parse(GetInput());

    Console.WriteLine("\nRabatter:");
    Console.WriteLine("10%: " + (b * 0.9) + " kr (spara " + (b * 0.1) + " kr)");
    Console.WriteLine("15%: " + (b * 0.85) + " kr (spara " + (b * 0.15) + " kr)");
    Console.WriteLine("20%: " + (b * 0.8) + " kr (spara " + (b * 0.2) + " kr)");
    Console.WriteLine("25%: " + (b * 0.75) + " kr (spara " + (b * 0.25) + " kr)");
    Console.WriteLine("30%: " + (b * 0.7) + " kr (spara " + (b * 0.3) + " kr)");
    Console.WriteLine("50%: " + (b * 0.5) + " kr (spara " + (b * 0.5) + " kr)");
    Console.WriteLine();
}