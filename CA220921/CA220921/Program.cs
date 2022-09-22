
using CA220921;

List <Kuldetes> kuldetesek = new List <Kuldetes> ();

using StreamReader sr = new(@"..\..\..\res\kuldetesek.csv");
while (!sr.EndOfStream) kuldetesek.Add(new Kuldetes(sr.ReadLine()));

//3. feladat 
Console.WriteLine($"3. feladat:\n\t" + 
    $"Összesen {kuldetesek.Count} alkalommal indítottak űrsiklót");

//4. feladat
//LINQ = Language-Integrated Query
int sum = kuldetesek.Sum(x => x.LegenysegSzama);
Console.WriteLine($"4. feladat:\n\t" +
    $"{sum} utas indult az űrbe összesen.");

//5. feladat
int km5u = kuldetesek.Count(x => x.LegenysegSzama < 5);
Console.WriteLine($"5. feladat:\n\t" +
    $"Összesen {km5u} alkalommal küldtek kevesebb mint 5 embert az űrbe");

//6. feladat
int cuul = kuldetesek
    .Where(x => x.SikloNeve == "Columbia")
    .OrderByDescending(x => x.KilovesDatuma)
    .First()
    .LegenysegSzama;


Console.WriteLine($"6. feladat:\n\t" + 
    $"{cuul} asztronauta volt volt a Columbia fedélzetén annak utolsó útján");

//7. feladat
Kuldetes lhk = kuldetesek
    .OrderBy(x => x.KuldetesHossza)
    .Last();
Console.WriteLine($"7. feladat\n\t" +
    $"A leghosszabb ideig a {lhk.SikloNeve} volt az űrben a " +
    $"{lhk.Kod} küldetés során " +
    $"Összesen {lhk.KuldetesHossza} órát volt távol a Földtől.");

//8. feladat
Console.Write("$8. feladat\n\t Évszám: ");
int evszam = int.Parse(Console.ReadLine());
int aeksz = kuldetesek.Count(x => x.KilovesDatuma.Year == evszam);
if (aeksz == 0)
    Console.WriteLine($"Ebben az évben nem volt küldetés.");
else Console.WriteLine($"Ebben az évben {aeksz} küldetés volt.");

//9. feladat
int kulsz = kuldetesek.Count(x => x.LandolasHelye == "Kennedy");
Console.WriteLine($"9. feladat:\n\t" +
    $"küldetések {kulsz/(float)kuldetesek.Count * 100:0.00}%-a fejeződött a Kennedy űrközpontban.");

//10. feladat
var spkh = kuldetesek.GroupBy(x => x.SikloNeve);

using StreamWriter sw = new(@"..\..\..\res\ursiklok.txt");

foreach (var e in spkh)
{
    sw.WriteLine($"{e.Key} \t {e.Sum(x => x.KuldetesHossza) / 24f}");
}




