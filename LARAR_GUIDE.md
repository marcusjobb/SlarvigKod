# Lärarguide - Refactoring Playground

## Översikt

Detta projekt innehåller en komplett refactoring-övning för advanced OOP-studenter.

## Innehåll

```
refactoring_playground/
├── Program.cs                      # Slarvig original-kod
├── SlarvigKod.csproj              # Projektfil
├── README.md                       # Studentinstruktioner
├── REFACTORING_CHECKLIST.md       # Steg-för-steg checklista
├── LARAR_GUIDE.md                 # Denna fil
└── solution/                       # Färdig lösning (visa EJ förrän övningen är klar)
    ├── Program.cs                  # 4 rader entry point
    ├── Product.cs                  # Produktmodell
    ├── InventoryManager.cs         # Affärslogik
    ├── MenuUI.cs                   # UI-separation
    ├── DiscountCalculator.cs       # Rabattlogik
    ├── InventoryStatistics.cs      # Statistikmodell
    ├── Constants.cs                # Konstanter
    └── README.md                   # Lösningsförklaring
```

## Lärandemål

Studenten ska:
1. ✅ Identifiera code smells i befintlig kod
2. ✅ Tillämpa Single Responsibility Principle
3. ✅ Extrahera metoder ur långa funktioner
4. ✅ Skapa datamodeller (Product-klass)
5. ✅ Separera concerns (UI, business logic, data)
6. ✅ Byta namn på variabler till självdokumenterande
7. ✅ Ersätta magic numbers med konstanter
8. ✅ Implementera felhantering
9. ✅ Tillämpa DRY-principen
10. ✅ Förstå encapsulation

## Genomförande

### Fas 1: Introduktion (15 min)
1. Visa original-koden (`Program.cs`)
2. Låt studenter diskutera: "Vad är fel med denna kod?"
3. Lista problem på tavlan
4. Introducera REFACTORING_CHECKLIST.md

### Fas 2: Live-demo (30 min)
Demonstrera första steget live:
- Skapa Product-klass
- Konvertera från tre listor till `List<Product>`
- Visa att programmet fortfarande fungerar

**Viktigt**: Betona TDD-approach - testa efter varje steg!

### Fas 3: Självständigt arbete (2-3 timmar)
Studenter arbetar själva eller i par:
- Följ REFACTORING_CHECKLIST.md
- Commit efter varje fas (git-träning)
- Testa att programmet fungerar efter varje ändring

### Fas 4: Code Review (30 min)
- Par-programmering eller gruppgranskning
- Jämför lösningar
- Diskutera olika tillvägagångssätt

### Fas 5: Visa lösningen (30 min)
Visa `solution/`-mappen:
- Gå igenom varje klass
- Förklara design decisions
- Diskutera metrics (150+ rader → 4 rader i Main)

## Vanliga studentmisstag

### 1. För stora steg
**Problem**: Försöker refactorera allt på en gång, koden slutar fungera.
**Lösning**: Betona små steg. Kompilera och testa efter varje ändring.

### 2. Glömmer att testa
**Problem**: Gör många ändringar utan att testa, hittar inte var buggen uppstod.
**Lösning**: "Red-Green-Refactor" mindset.

### 3. Skapar för många klasser för tidigt
**Problem**: Överkomplicerar lösningen.
**Lösning**: Följ checklistans ordning. Börja enkelt.

### 4. Fastnar i namngivning
**Problem**: Spenderar för lång tid på perfekta namn.
**Lösning**: "Good enough now, perfect later". Namnge om vid behov.

### 5. Kopierar lösningen
**Problem**: Tittar på solution/ för tidigt.
**Lösning**: Gör solution/ osynlig initialt. Visa först vid Fas 5.

## Bedömningskriterier

### G (Godkänt)
- ✅ Product-klass skapad
- ✅ Minst 5 extraherade metoder ur Main
- ✅ Alla variabler har beskrivande namn
- ✅ Magic numbers ersatta med konstanter
- ✅ Program fungerar som förväntat

### VG (Väl Godkänt)
- ✅ Alla G-kriterier
- ✅ Separation of concerns (minst 4 klasser)
- ✅ Felhantering implementerad
- ✅ DRY-principen tillämpad konsekvent
- ✅ SOLID-principer synliga
- ✅ Kan förklara alla design decisions

## Diskussionsfrågor

Efter övningen, diskutera:
1. Vad var svårast att refactorera?
2. Hur vet man när man ska skapa en ny klass?
3. Hur påverkar refactoring testbarhet?
4. När är kod "clean enough"?
5. Vilka code smells upptäckte ni?

## Code Smells i original-koden

Använd för genomgång:
1. **Long Method** - Main() är 150+ rader
2. **Magic Numbers** - 0.25, 0.9, 5, 999999
3. **Primitive Obsession** - Tre parallella listor
4. **Feature Envy** - Alla metoder vill vara klasser
5. **Duplicated Code** - Samma validering upprepas
6. **Shotgun Surgery** - Ändra moms kräver ändringar på flera ställen
7. **Data Clumps** - n, p, q hör ihop
8. **Comments** (eller brist på) - Kod ska vara självförklarande

## Förlängning för snabba studenter

När studenten är klar:
1. Implementera Repository Pattern
2. Lägg till filhantering (JSON/CSV)
3. Skriv unit tests för InventoryManager
4. Implementera Strategy Pattern för rabatter
5. Lägg till logging
6. Skapa factory för Product-skapande

## Tiduppskattning

- **Totalt**: 4-6 timmar
- **Introduktion**: 15 min
- **Demo**: 30 min
- **Självständigt arbete**: 2-3 timmar
- **Code review**: 30 min
- **Genomgång lösning**: 30 min
- **Diskussion**: 30 min

## Tips för genomförande

1. **Använd git**: Låt studenter committa efter varje fas
2. **Pair programming**: Effektivt för refactoring
3. **Whiteboard**: Rita klassdiagram för solution innan kodning
4. **Pomodoro**: 25 min arbete, 5 min paus
5. **Showcase**: Låt studenter visa sin lösning för klassen

## Relaterade ämnen

Efter denna övning, följ upp med:
- Design Patterns (Strategy, Factory, Repository)
- Unit Testing och TDD
- SOLID-principerna (djupdykning)
- Clean Architecture
- Code Review best practices

## Resurser

Rekommendera:
- **Bok**: "Refactoring" av Martin Fowler
- **Bok**: "Clean Code" av Robert C. Martin
- **Video**: Refactoring.Guru (designpatterns)
- **Tool**: ReSharper eller Rider för automatisk refactoring
