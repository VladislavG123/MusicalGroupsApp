using System;
using System.Linq;

namespace MusicalGroupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение Musical Group App!");

            using (AppContext context = new AppContext())
            {

                while (true)
                {
                    Console.WriteLine("1 - Для работы с музыкальными группами");
                    Console.WriteLine("2 - Для работы с песнями");
                    Console.WriteLine("3 - Выход");
                    int chouse;

                    if (int.TryParse(Console.ReadLine(), out chouse))
                    {
                        if (chouse == 3) break;

                        if (chouse == 1)
                        {
                            while (true)
                            {
                                Console.WriteLine("\n1 - Создать группу");
                                Console.WriteLine("2 - Добавить песню группе");
                                Console.WriteLine("3 - Назад.");
                                if (int.TryParse(Console.ReadLine(), out chouse))
                                {
                                    if (chouse == 1)
                                    {
                                        MusicalGroup newGroup = new MusicalGroup();

                                        while (true)
                                        {
                                            Console.WriteLine("Введите название группы");
                                            string name = Console.ReadLine();
                                            if (!(name is null) || name.Length > 0)
                                            {
                                                newGroup.Name = name;
                                                try
                                                {
                                                    var groups = context.MusicalGroups.Where(group => group.Name == newGroup.Name).ToList();
                                                    if (groups is null || groups.Count == 0)
                                                    {
                                                        context.MusicalGroups.Add(newGroup);
                                                        context.SaveChanges();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Такая группа уже существует!");
                                                    }

                                                    Console.WriteLine("Группа успешно добавлена!");
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Возникла непонятная ошибка!");
                                                }
                                                break;
                                            }
                                        }

                                    }
                                    else if (chouse == 2)
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("Введите название группы");
                                            string name = Console.ReadLine();
                                            try
                                            {
                                                var groups = context.MusicalGroups.Where(group => group.Name == name).ToList();

                                                if (!(groups is null))
                                                {
                                                    if (groups.Count == 1)
                                                    {
                                                        var currentGroup = groups[0];


                                                        Song song = new Song();
                                                        Console.WriteLine("Введите название песни");
                                                        song.Name = Console.ReadLine();

                                                        Console.WriteLine("Введите рейтинг песни");
                                                        int mark;
                                                        while (true)
                                                        {
                                                            if (int.TryParse(Console.ReadLine(), out mark))
                                                            {
                                                                if (mark > 0 && mark <= 5)
                                                                {
                                                                    song.Mark = mark;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Данные введены некорректно!");
                                                                    Console.WriteLine("Введите еще раз!");
                                                                }
                                                            }
                                                        }

                                                        Console.WriteLine("Введите длину песни в секундах");
                                                        int lenght;
                                                        while (true)
                                                        {
                                                            if (int.TryParse(Console.ReadLine(), out lenght))
                                                            {
                                                                if (lenght > 0)
                                                                {
                                                                    song.Lenght = lenght;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Данные введены некорректно!");
                                                                    Console.WriteLine("Введите еще раз!");
                                                                }
                                                            }
                                                        }

                                                        Console.WriteLine("Введите текст песни");
                                                        song.Content = Console.ReadLine();

                                                        song.MusicalGroup = currentGroup;

                                                        try
                                                        {
                                                            context.Songs.Add(song);
                                                            context.SaveChanges();
                                                        }
                                                        catch (Exception)
                                                        {
                                                            Console.WriteLine("Упс.. Что-то пошло не так!");
                                                        }
                                                        break;
                                                    }
                                                    throw new Exception();
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Что-то пошло не так!");
                                            }
                                        }
                                    }
                                    else if (chouse == 3) break;
                                }
                            }
                        }
                        else if (chouse == 2)
                        {
                            while (true)
                            {
                                Console.WriteLine("1 - Для поиска группы");
                                Console.WriteLine("2 - Для поиска песни");
                                Console.WriteLine("3 - Вывести топ песен с высоким рейтингом");
                                Console.WriteLine("4 - Вывести топ песен с низким рейтингом");
                                Console.WriteLine("5 - Выход");

                                if (int.TryParse(Console.ReadLine(), out chouse))
                                {
                                    if (chouse == 1)
                                    {
                                        Console.WriteLine("Введите название группы");
                                        string name = Console.ReadLine();

                                        var groups = context.MusicalGroups.Where(group => group.Name.Contains(name)).ToList();

                                        if (!(groups is null) && groups.Count > 0)
                                        {
                                            Console.WriteLine("Группы:");
                                            foreach (var group in groups)
                                            {
                                                Console.WriteLine($"{group.Name}");
                                                Console.WriteLine("\tПесни:");
                                                foreach (var song in group.Songs)
                                                {
                                                    Console.WriteLine($"{song.Name}");
                                                }
                                                Console.WriteLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Группа не найдена!");
                                        }
                                    }
                                    else if (chouse == 2)
                                    {
                                        Console.WriteLine("Введите название песни");
                                        string name = Console.ReadLine();

                                        var songs = context.Songs.Where(song => song.Name.Contains(name)).ToList();
                                        if (!(songs is null) && songs.Count > 0)
                                        {
                                            Console.WriteLine("Песни:\n");
                                            foreach (var song in songs)
                                            {
                                                Console.WriteLine($"Название - {song.Name}");
                                                Console.WriteLine($"Продолжительность - {song.Lenght} секунд");
                                                Console.WriteLine($"Рейтинг - {song.Mark}");
                                                Console.WriteLine($"Группа - {song.MusicalGroup}");
                                                Console.WriteLine("\tТекст:");
                                                Console.WriteLine($"{song.Content}");
                                                Console.WriteLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Песни не найдены!");
                                        }
                                    }
                                    else if (chouse == 3)
                                    {
                                        var songs = (from song
                                                    in context.Songs
                                                     orderby song.Mark descending
                                                     select song).ToList();
                                        Console.WriteLine();
                                        foreach (var song in songs)
                                        {
                                            Console.WriteLine($"{song.Name}, оценка - {song.Mark}");
                                        }
                                    }
                                    else if (chouse == 4)
                                    {
                                        var songs = (from song
                                                   in context.Songs
                                                     orderby song.Mark ascending
                                                     select song).ToList();
                                        Console.WriteLine();
                                        foreach (var song in songs)
                                        {
                                            Console.WriteLine($"{song.Name}, оценка - {song.Mark}");
                                        }
                                    }
                                    else if (chouse == 5) break;
                                    else
                                    {
                                        Console.WriteLine("Такого варианта нет!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Неверный ввод!");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
