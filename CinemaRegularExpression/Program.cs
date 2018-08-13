using System;

namespace CinemaRegularExpression
{
    class Program
    {
        static void Main()
        {
            CollectionFilms collectionFilms = new CollectionFilms("films.html");
            collectionFilms.Scan();
            collectionFilms.Print();
            Console.ReadLine();
        }
    }
}
