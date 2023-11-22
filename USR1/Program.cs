using System.Collections.Generic;

Random random = new Random();
List<int> mnogoChisel = new List<int>();
for (int i = 0; i < 100000; i++)
{
	mnogoChisel.Add(random.Next(1, 100));
}
LinkedList<int> nemnogoChisel = new LinkedList<int>(mnogoChisel);


DateTime startList = DateTime.Now;
int chislo = mnogoChisel[0];
mnogoChisel.RemoveAll(x => x % chislo == 0);
DateTime endRemoving = DateTime.Now;
Console.WriteLine((endRemoving - startList).TotalSeconds + " секунд на удаление в List всех елементов кратных первому");
for (int i = mnogoChisel.Count - 1; i > 0; i--)
{
	if (mnogoChisel[i] % 2 == 0 && mnogoChisel[i - 1] % 2 == 0)
	{
		mnogoChisel.Insert(i, 0);
	}
}
DateTime endList = DateTime.Now;
Console.WriteLine((endRemoving - startList).TotalSeconds + " секунд на вставку в List нулей");

startList = DateTime.Now;
int firstElement = nemnogoChisel.First.Value;
LinkedListNode<int> current = nemnogoChisel.First;
while (current != null)
{
	if (current.Value % firstElement == 0)
	{
		LinkedListNode<int> next = current.Next;
		nemnogoChisel.Remove(current);
		current = next;
	}
	else
	{
		current = current.Next;
	}
}
endRemoving = DateTime.Now;
Console.WriteLine((endRemoving - startList).TotalSeconds + " секунд на удаление в LinkedList всех елементов кратных первому");
InsertZeroBetweenParityElements(nemnogoChisel);
endList = DateTime.Now;
Console.WriteLine((endRemoving - startList).TotalSeconds + " секунд на вставку в LinkedList нулей");



static void InsertZeroBetweenParityElements(LinkedList<int> linkedList)
{
	var current = linkedList.First;
	while (current != null && current.Next != null)
	{
		if (current.Value % 2 == 0 && current.Next.Value % 2 == 0)
		{
			linkedList.AddAfter(current, 0);
		}
		current = current.Next;
	}
}