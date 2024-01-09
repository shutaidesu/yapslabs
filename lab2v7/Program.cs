namespace lab2v7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в музыкальный каталог!");
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("1. Поиск композиции");
            Console.WriteLine("2. Вывод информации о всех композициях");
            Console.WriteLine("3. Добавление композиции");
            Console.WriteLine("4. Удаление композиции");
            Console.WriteLine("5. Выход");

            Catalog catalog = new Catalog();

            while (true)
            {
                Console.Write("Введите номер команды: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Введите критерий поиска: ");
                        string searchCriteria = Console.ReadLine();
                        List<Composition> searchResults = catalog.Search(searchCriteria);
                        Console.WriteLine("Результаты поиска:");
                        foreach (var result in searchResults)
                        {
                            Console.WriteLine(result);
                        }
                        break;

                    case "2":
                        catalog.DisplayAllCompositions();
                        break;

                    case "3":
                        Console.Write("Введите имя исполнителя: ");
                        string artist = Console.ReadLine();
                        Console.Write("Введите название композиции: ");
                        string title = Console.ReadLine();

                        Composition newComposition = new Composition { Artist = artist, Title = title };
                        catalog.AddComposition(newComposition);
                        Console.WriteLine("Композиция добавлена в каталог.");
                        break;

                    case "4":
                        Console.Write("Введите имя исполнителя композиции для удаления: ");
                        string artistToDelete = Console.ReadLine();
                        Console.Write("Введите название композиции для удаления: ");
                        string titleToDelete = Console.ReadLine();

                        Composition compositionToDelete = catalog.Search(artistToDelete, titleToDelete).FirstOrDefault();

                        if (compositionToDelete != null)
                        {
                            catalog.RemoveComposition(compositionToDelete);
                            Console.WriteLine("Композиция удалена из каталога.");
                        }
                        else
                        {
                            Console.WriteLine("Композиция не найдена в каталоге.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Выход из программы.");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Некорректная команда. Пожалуйста, введите корректный номер команды.");
                        break;
                }
            }
        }
    }
}