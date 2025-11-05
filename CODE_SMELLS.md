# Code Smells - Hitta problemen!

## Vad är Code Smells?

Code smells är tecken på att koden behöver refactoreras. De är inte buggar, men indikerar dålig design.

## Smells i SlarvigKod

### 1. 🔴 Long Method
**Problem**: Main() är 150+ rader långt

**Varför det är dåligt**:
- Svårt att förstå
- Svårt att testa
- Svårt att återanvända
- Svårt att underhålla

**Exempel från koden**:
```csharp
static void Main(string[] args)
{
    // ... 150+ rader kod här ...
}
```

**Lösning**: Extrahera metoder
```csharp
static void Main(string[] args)
{
    var inventory = new InventoryManager();
    var menu = new MenuUI(inventory);
    menu.Run();
}
```

---

### 2. 🔴 Mysterious Name
**Problem**: Variabler heter `n`, `p`, `q`, `c`, `s`, `f`, `a`, `b`

**Varför det är dåligt**:
- Omöjligt att veta vad de betyder
- Måste läsa all omgivande kod
- Lätt att förväxla variabler

**Exempel från koden**:
```csharp
List<string> n = new List<string>();  // Vad är 'n'?
List<double> p = new List<double>();  // Vad är 'p'?
List<int> q = new List<int>();        // Vad är 'q'?
```

**Lösning**: Beskrivande namn
```csharp
List<Product> products = new List<Product>();
```

---

### 3. 🔴 Primitive Obsession
**Problem**: Använder tre separata listor istället för en klass

**Varför det är dåligt**:
- Risk för synkroniseringsfel
- Ingen relation mellan data
- Svårt att lägga till fler properties
- Ingen encapsulation

**Exempel från koden**:
```csharp
List<string> n = new List<string>();   // namn
List<double> p = new List<double>();   // pris
List<int> q = new List<int>();         // kvantitet

// Lägg till produkt på 3 ställen!
n.Add("Laptop");
p.Add(15999.99);
q.Add(5);
```

**Lösning**: Skapa en klass
```csharp
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

List<Product> products = new List<Product>();
products.Add(new Product { Name = "Laptop", Price = 15999.99, Quantity = 5 });
```

---

### 4. 🔴 Magic Numbers
**Problem**: Hårdkodade siffror utan förklaring

**Varför det är dåligt**:
- Oklart vad de betyder
- Svårt att ändra
- Samma tal kan ha olika betydelse
- Duplicerad kod

**Exempel från koden**:
```csharp
double m = t * 0.25;  // Vad är 0.25?

if (q[id] < 5)  // Varför 5?

double lp = 999999;  // Varför just 999999?
```

**Lösning**: Namngivna konstanter
```csharp
const double VAT_RATE = 0.25;
const int LOW_STOCK_THRESHOLD = 5;

double vatAmount = totalPrice * VAT_RATE;
if (product.Quantity < LOW_STOCK_THRESHOLD)
```

---

### 5. 🔴 Duplicated Code
**Problem**: Samma kod upprepas flera gånger

**Varför det är dåligt**:
- Måste ändra på flera ställen
- Risk för inkonsistens
- Mer kod att underhålla
- Bryter DRY-principen

**Exempel från koden**:
```csharp
// I alternativ 2:
double pp = double.Parse(Console.ReadLine());

// I alternativ 3:
int a = int.Parse(Console.ReadLine());

// I alternativ 4:
int a = int.Parse(Console.ReadLine());

// Ingen felhantering någonstans!
```

**Lösning**: Extrahera gemensam kod
```csharp
private int GetIntInput(string prompt)
{
    while (true)
    {
        try
        {
            Console.Write($"{prompt}: ");
            return int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Ogiltigt format!");
        }
    }
}
```

---

### 6. 🔴 Data Clumps
**Problem**: Samma grupp av data uppträder tillsammans överallt

**Varför det är dåligt**:
- Data hör ihop men är separerad
- Skulle vara en klass
- Svårt att hålla synkroniserat

**Exempel från koden**:
```csharp
// Dessa tre hör alltid ihop:
n[i]   // namn
p[i]   // pris
q[i]   // kvantitet
```

**Lösning**: Skapa en klass
```csharp
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
```

---

### 7. 🔴 Long Parameter List
**Problem**: (Inte i denna kod, men relaterat)

**Exempel**:
```csharp
void CreateProduct(string name, double price, int quantity, string category,
                   string supplier, DateTime addedDate, bool inStock)
```

**Lösning**: Parameter Object
```csharp
void CreateProduct(ProductData data)
```

---

### 8. 🔴 Feature Envy
**Problem**: En metod verkar mer intresserad av en annan klass data

**Exempel från koden**:
```csharp
// Main-metoden är besatt av produktdata:
for (int i = 0; i < n.Count; i++)
{
    tv = tv + (p[i] * q[i]);  // Borde vara i Product!
}
```

**Lösning**: Flytta metoden till rätt klass
```csharp
class Product
{
    public double GetTotalValue()
    {
        return Price * Quantity;
    }
}

// Sedan i Main:
totalValue = products.Sum(p => p.GetTotalValue());
```

---

### 9. 🔴 Inappropriate Intimacy
**Problem**: Klasser vet för mycket om varandra

**Exempel**:
```csharp
// Direktaccess till listor
if (inventory.products[0].quantity < 5)  // Dåligt!
```

**Lösning**: Encapsulation
```csharp
if (inventory.IsLowStock(0))  // Bra!
```

---

### 10. 🔴 Shotgun Surgery
**Problem**: En ändring kräver ändringar på många ställen

**Exempel från koden**:
```csharp
// Om moms ändras från 25% till 20%, måste du ändra:
double m = t * 0.25;  // Här
// Och överallt där 0.25 förekommer...
```

**Lösning**: Centralisera
```csharp
const double VAT_RATE = 0.25;
// Nu ändras det bara på ETT ställe
```

---

## Övning: Hitta alla smells

Gå igenom `Program.cs` och lista:
1. Alla magic numbers du hittar
2. Alla variabler med kryptiska namn
3. All duplicerad kod
4. All kod som borde vara en metod
5. All kod som borde vara en klass

## Refactoring-tekniker

### Extract Method
Gör en metod av kodblock:
```csharp
// Före
Console.WriteLine("=== BUTIKSSYSTEM ===");
Console.WriteLine("1. Visa produkter");
// ... mer ...

// Efter
DisplayMenu();
```

### Extract Class
Gör en klass av relaterad data:
```csharp
// Före
List<string> names;
List<double> prices;

// Efter
List<Product> products;
```

### Rename Variable
Ge bättre namn:
```csharp
// Före
string c = Console.ReadLine();

// Efter
string userChoice = Console.ReadLine();
```

### Replace Magic Number with Constant
```csharp
// Före
if (quantity < 5)

// Efter
if (quantity < LOW_STOCK_THRESHOLD)
```

### Introduce Parameter Object
```csharp
// Före
void AddProduct(string name, double price, int qty)

// Efter
void AddProduct(Product product)
```

## Verktyg som hjälper

### IDE-verktyg (Visual Studio / Rider)
- **Ctrl+R, M**: Extract Method
- **Ctrl+R, V**: Extract Variable
- **Ctrl+R, R**: Rename
- **Alt+Enter**: Quick fixes

### Code Analysis
- **SonarLint**: Hittar code smells
- **ReSharper**: Automatisk refactoring
- **StyleCop**: Kodstandarder

## När ska man refactorera?

✅ **Refactorera när**:
- Du måste lägga till ny funktionalitet
- Du hittar en bugg
- Du gör code review
- Du inte förstår koden

❌ **Refactorera INTE när**:
- Deadline imorgon
- Kod ska kastas bort ändå
- Du inte har tester
- Du inte förstår vad koden gör

## Boy Scout Rule

> "Lämna koden lite bättre än du hittade den"

Varje gång du rör koden, förbättra något litet:
- Byt namn på en variabel
- Extrahera en konstant
- Lägg till en kommentar

Små förbättringar blir stora över tid!

## Checklista: Är min kod clean?

- [ ] Inga variabler med 1-2 bokstäver
- [ ] Inga metoder över 30 rader
- [ ] Inga magic numbers
- [ ] Ingen duplicerad kod
- [ ] Varje klass har ett ansvar
- [ ] Varje metod gör en sak
- [ ] Namn förklarar avsikt
- [ ] Felhantering finns
- [ ] Koden är testbar

## Läs mer

- [Refactoring Guru - Code Smells](https://refactoring.guru/refactoring/smells)
- Martin Fowler - "Refactoring" (bok)
- Robert C. Martin - "Clean Code" (bok)
