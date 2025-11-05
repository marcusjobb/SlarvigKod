# Refactoring Playground - Slarvig Butikskod

## Syfte
Detta projekt innehåller **avsiktligt dålig kod** för att träna refactoring-tekniker.

## Vad är fel med koden?

### 🔴 Kodkvalitetsproblem

1. **Enbokstavs variabler**
   - `n`, `p`, `q`, `c`, `s`, `f`, `a`, `b`, `t`, `m`, `id`, `tv`, `tp`, `hp`, `lp`
   - Omöjligt att förstå vad variablerna representerar

2. **Allt i Main-metoden**
   - 150+ rader i en enda metod
   - Ingen separation of concerns
   - Omöjligt att testa

3. **Tre parallella listor**
   - `List<string> n`, `List<double> p`, `List<int> q`
   - Ingen datamodell/klass
   - Risk för synkroniseringsfel mellan listorna

4. **Duplicerad kod**
   - Samma valideringslogik upprepas överallt
   - Ingen DRY-princip

5. **Magic numbers**
   - `0.25` (moms)
   - `0.9`, `0.85`, `0.8`, `0.75`, `0.7`, `0.5` (rabatter)
   - `5` (låg lagernivå)
   - `999999` (initialt lågt pris)

6. **Ingen felhantering**
   - `Parse()` utan try-catch
   - Krasch vid felaktig input

7. **Hårdkodad data**
   - Produkter hårdkodade i Main
   - Ingen filhantering eller databas

8. **UI-logik och affärslogik ihop**
   - Console.WriteLine blandat med beräkningar
   - Omöjligt att återanvända logik

## Refactoring-övningar

### Steg 1: Skapa Product-klass
- Ersätt tre listor med `List<Product>`
- Properties: Name, Price, Quantity

### Steg 2: Extrahera metoder
- `DisplayProducts()`
- `AddProduct()`
- `SellProduct()`
- `AddStock()`
- `SearchProducts()`
- `CalculateDiscount()`
- `ShowStatistics()`

### Steg 3: Skapa InventoryManager-klass
- Hantera produktlistan
- Affärslogik för försäljning, lager, sökning

### Steg 4: Extrahera konstanter
```csharp
const double VAT_RATE = 0.25;
const int LOW_STOCK_THRESHOLD = 5;
```

### Steg 5: Lägg till felhantering
- Try-catch för Parse-operationer
- Validering av input

### Steg 6: Skapa UI-klass
- Separera presentation från affärslogik
- Menu-klass för navigation

### Steg 7: Lägg till filhantering
- Spara/ladda produkter från CSV/JSON

## Köra projektet

```bash
dotnet run
```

## Bonus: Design Patterns
- **Repository Pattern** för produkthantering
- **Factory Pattern** för att skapa produkter
- **Strategy Pattern** för olika rabattstrategier
- **Command Pattern** för menyval
