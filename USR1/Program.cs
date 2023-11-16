using System.Collections.Generic;

List<int> mnogoChisel = new List<int>();
Random random = new Random();
for (int i = 0; i < 100000; i++)
{
	mnogoChisel.Add(random.Next(1, 100));
}
int chislo = mnogoChisel[0];
mnogoChisel.RemoveAll(x => x % chislo == 0);
for (int i = mnogoChisel.Count - 1; i > 0; i--)
{
	if (mnogoChisel[i] % 2 == 0 && mnogoChisel[i - 1] % 2 == 0)
	{
		mnogoChisel.Insert(i, 0);
	}
}

foreach (var item in mnogoChisel)
{
    Console.WriteLine(item);
}