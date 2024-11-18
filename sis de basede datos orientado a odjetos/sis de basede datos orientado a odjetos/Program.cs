using System;
using System.Collections.Generic;

class Program
{
    // Clase que representa un libro
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public override string ToString()
        {
            return $"Título: {Title}, Autor: {Author}, Género: {Genre}, Año: {Year}";
        }
    }

    // Clase que simula una base de datos orientada a objetos
    public class BookDatabase
    {
        private List<Book> books = new List<Book>();

        // Método para agregar un libro
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Libro agregado exitosamente.");
        }

        // Método para mostrar todos los libros
        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("Lista de libros:");
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        // Método para buscar libros por género
        public void SearchByGenre(string genre)
        {
            var foundBooks = books.FindAll(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));

            if (foundBooks.Count == 0)
            {
                Console.WriteLine($"No se encontraron libros en el género: {genre}");
                return;
            }

            Console.WriteLine($"Libros en el género '{genre}':");
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }

        // Método para buscar libros por autor
        public void SearchByAuthor(string author)
        {
            var foundBooks = books.FindAll(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));

            if (foundBooks.Count == 0)
            {
                Console.WriteLine($"No se encontraron libros del autor: {author}");
                return;
            }

            Console.WriteLine($"Libros del autor '{author}':");
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }

        // Método para eliminar un libro por título
        public void RemoveBook(string title)
        {
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
            {
                Console.WriteLine($"No se encontró un libro con el título: {title}");
                return;
            }

            books.Remove(book);
            Console.WriteLine("Libro eliminado exitosamente.");
        }
    }

    static void Main(string[] args)
    {
        BookDatabase database = new BookDatabase();

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Mostrar todos los libros");
            Console.WriteLine("3. Buscar libros por género");
            Console.WriteLine("4. Buscar libros por autor");
            Console.WriteLine("5. Eliminar libro por título");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ingrese el título del libro: ");
                    string title = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string author = Console.ReadLine();
                    Console.Write("Ingrese el género del libro: ");
                    string genre = Console.ReadLine();
                    Console.Write("Ingrese el año del libro: ");
                    int year = int.Parse(Console.ReadLine());

                    Book newBook = new Book(title, author, genre, year);
                    database.AddBook(newBook);
                    break;

                case "2":
                    database.DisplayBooks();
                    break;

                case "3":
                    Console.Write("Ingrese el género para buscar: ");
                    string searchGenre = Console.ReadLine();
                    database.SearchByGenre(searchGenre);
                    break;

                case "4":
                    Console.Write("Ingrese el autor para buscar: ");
                    string searchAuthor = Console.ReadLine();
                    database.SearchByAuthor(searchAuthor);
                    break;

                case "5":
                    Console.Write("Ingrese el título del libro a eliminar: ");
                    string removeTitle = Console.ReadLine();
                    database.RemoveBook(removeTitle);
                    break;

                case "6":
                    Console.WriteLine("Saliendo del sistema...");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }
}

