using Last_task_CSh;



Console.WriteLine("Введите ключи дерева в формате: 7 2 3 1 8 9 23\n");

var keys = Console.ReadLine().Split(" ").Select(s=> Convert.ToInt32(s));

NodeAVL? top = null;

foreach(var key in keys)
{
    top = top == null ? new NodeAVL(key) : top.Instert(top, key);
}

top.Display();

top.Search(top, 8)?.Display();

top.Remove(top, 8)?.Display();