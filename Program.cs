namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cafe Mokka = new Cafe(5);
            Mokka.AddClient(new Visitor("Vasiliy"));
            Mokka.AddClient(new Visitor("Ivan"));
            Mokka.AddClient(new Visitor("Dmitryi"));
            Mokka.AddClient(new Visitor("Nikolay Alexandrovich"), new DateTime(2024, 10, 12));
            Mokka.AddClient(new Visitor("Daniel"));
            Mokka.AddClient(new Visitor("Vitaliy"));
            Mokka.AddClient(new Visitor("Ignat"));
            var currentVisitors = Mokka.GetCurrentVisitors();
            Console.WriteLine("Текущие клиенты");
            foreach (var visitor in currentVisitors)
            {
                Console.WriteLine(visitor);
            }
            Console.WriteLine("Клиенты в ожидании");
            var waitingVisitors = Mokka.GetVisitorsInQueue();
            foreach (var visitor in waitingVisitors)
            {
                Console.WriteLine(visitor);
            }

            Mokka.RemoveClient(new Visitor("Ivan"));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            currentVisitors = Mokka.GetCurrentVisitors();
            Console.WriteLine("Текущие клиенты");
            foreach (var visitor in currentVisitors)
            {
                Console.WriteLine(visitor);
            }
            Console.WriteLine("Клиенты в ожидании");
            waitingVisitors = Mokka.GetVisitorsInQueue();
            foreach (var visitor in waitingVisitors)
            {
                Console.WriteLine(visitor);
            }
        }
    }
}
//Создайте приложение, эмулирующее очередь в популярное кафе. 
//Посетители кафе приходят и попадают в очередь, если нет свободного места. 
//При освобождении столика в кафе, первый посетитель очереди занимает его. 
//Если приходит клиент, который резервировал столик на определенное время, он получает зарезервированный столик вне очереди.
//При разработке приложения используйте класс Queue<T>.