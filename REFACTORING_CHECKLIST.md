# Refactoring Checklist

## Innan du börjar
- [ ] Läs igenom hela koden
- [ ] Identifiera alla problem
- [ ] Planera i vilken ordning du ska refactorera
- [ ] Testa original-koden så du vet hur den fungerar

## Fas 1: Grundläggande struktur

### Skapa Product-klass
- [ ] Skapa `Product.cs`
- [ ] Properties: `Name`, `Price`, `Quantity`
- [ ] Constructor
- [ ] ToString() för utskrift

### Konvertera datastruktur
- [ ] Ersätt `List<string> n` med `List<Product>`
- [ ] Ta bort `List<double> p` och `List<int> q`
- [ ] Uppdatera all kod som använder de gamla listorna
- [ ] Testa att programmet fortfarande fungerar

## Fas 2: Extrahera metoder ur Main

- [ ] `void DisplayProducts(List<Product> products)`
- [ ] `void AddProduct(List<Product> products)`
- [ ] `void SellProduct(List<Product> products)`
- [ ] `void AddStock(List<Product> products)`
- [ ] `void SearchProducts(List<Product> products)`
- [ ] `void ShowDiscount()`
- [ ] `void ShowStatistics(List<Product> products)`
- [ ] `void DisplayMenu()`
- [ ] `string GetUserChoice()`

## Fas 3: Byt namn på variabler

- [ ] `c` → `userChoice`
- [ ] `n`, `p`, `q` → `products`
- [ ] `nn`, `pp`, `qq` → `newName`, `newPrice`, `newQuantity`
- [ ] `a` → `amount`
- [ ] `s` → `searchTerm`
- [ ] `f` → `found`
- [ ] `b` → `baseAmount`
- [ ] `t` → `totalPrice`
- [ ] `m` → `vatAmount`
- [ ] `tv` → `totalValue`
- [ ] `tp` → `totalProducts`
- [ ] `hp` → `highestPrice`
- [ ] `lp` → `lowestPrice`

## Fas 4: Extrahera konstanter

```csharp
const double VAT_RATE = 0.25;
const int LOW_STOCK_THRESHOLD = 5;
const string MENU_TITLE = "=== BUTIKSSYSTEM ===";
```

- [ ] Ersätt alla magic numbers med konstanter
- [ ] Gruppera relaterade konstanter

## Fas 5: Skapa InventoryManager-klass

```csharp
class InventoryManager
{
    private List<Product> products;

    public void AddProduct(Product product)
    public void RemoveProduct(int id)
    public bool SellProduct(int id, int quantity)
    public void AddStock(int id, int quantity)
    public List<Product> SearchProducts(string searchTerm)
    public Product GetProductById(int id)
    public List<Product> GetAllProducts()
}
```

- [ ] Skapa klass
- [ ] Flytta produktlista till klassen
- [ ] Flytta affärslogik till klassen
- [ ] Uppdatera Main att använda InventoryManager

## Fas 6: Felhantering

- [ ] Try-catch runt alla `Parse()`-anrop
- [ ] Validera input (negativa tal, tomma strängar)
- [ ] Användarvänliga felmeddelanden
- [ ] Loops för att be om ny input vid fel

```csharp
while (true)
{
    try
    {
        double price = double.Parse(Console.ReadLine());
        if (price < 0) throw new ArgumentException("Priset kan inte vara negativt");
        return price;
    }
    catch (FormatException)
    {
        Console.WriteLine("Fel format! Ange ett giltigt pris:");
    }
}
```

## Fas 7: UI-separation

- [ ] Skapa `MenuUI.cs`
- [ ] Metoder för att visa menyer
- [ ] Metoder för att hämta användarinput
- [ ] Separera ALL Console-logik från affärslogik

## Fas 8: Statistik-klass (Bonus)

```csharp
class InventoryStatistics
{
    public double TotalValue { get; set; }
    public int TotalQuantity { get; set; }
    public Product MostExpensive { get; set; }
    public Product Cheapest { get; set; }
    public double AveragePrice { get; set; }
}
```

## Fas 9: Rabattkalkylator (Bonus)

```csharp
class DiscountCalculator
{
    public double CalculateDiscount(double amount, double percentage)
    public void ShowAllDiscounts(double amount)
}
```

## Fas 10: Filhantering (Bonus)

- [ ] Skapa `DataManager.cs`
- [ ] `SaveToFile(List<Product> products, string filename)`
- [ ] `LoadFromFile(string filename)` → `List<Product>`
- [ ] CSV eller JSON format

## Efter varje fas

- [ ] Kompilera - inga fel
- [ ] Testa manuellt - samma funktionalitet
- [ ] Commit till git (om du använder versionshantering)

## Kvalitetskontroll (slutet)

- [ ] Inga variabler med 1-2 bokstäver
- [ ] Inga metoder över 30 rader
- [ ] Inga magic numbers
- [ ] Alla klasser följer Single Responsibility
- [ ] DRY - ingen duplicerad kod
- [ ] Felhantering överallt där det behövs
- [ ] Kod är läsbar och självdokumenterande

## Design Patterns (Avancerat)

- [ ] Repository Pattern för produkthantering
- [ ] Factory Pattern för Product-skapande
- [ ] Strategy Pattern för olika rabattstrategier
- [ ] Command Pattern för menyoperationer
