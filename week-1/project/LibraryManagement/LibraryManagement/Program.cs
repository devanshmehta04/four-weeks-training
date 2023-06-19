namespace LibraryManagement
{
    public class Program
    {
        private static List<Book> books = new List<Book>();
        private static List<Author> authors = new List<Author>();
        private static List<Borrower> borrowers = new List<Borrower>();
        static void Main(string[] args)
        {
            // Initialize collections for books, authors, and borrowers
            // Main program loop
            while (true)
            {
                DisplayMenu();
                int choice;
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    // Add cases for each menu option
                    case 1:
                        // Add a book
                        AddBook();
                        break;
                    case 2:
                        UpdateBooks();
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        DisplayBooks();
                        break;
                    case 5:
                        DidplayAuthors();
                        break;
                    case 6:
                        AddBorrower();
                        break;
                    // ...
                    case 16:
                        // Filter books by status
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        private static void AddBorrower()
        {
            Console.WriteLine("===== Add a Borrower =====");
            Console.WriteLine("Enter the borrower's first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the borrower's last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the borrower's email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the borrower's phone number:");
            string phoneNumber = Console.ReadLine();
            Borrower borrower = new Borrower(firstName, lastName, email, phoneNumber);
            borrowers.Add(borrower);
            Console.WriteLine("\nBorrower added successfully!");
        }
        private static void DidplayAuthors()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.Author);
            }
        }
        private static void ListAllBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
        private static void DeleteBook()
        {
            Console.WriteLine("Deletin .........");
            Console.WriteLine("Enter the book title that you want to delete");
            string delbook = Console.ReadLine();
            Book book = books.FirstOrDefault(b => b.Title == delbook);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book Deleted");
            }
            else
            {
                Console.WriteLine("Book doesnot exist");
            }
        }
        private static void UpdateBooks()
        {
            Console.WriteLine("Updating Book");
            Console.WriteLine("Enter the title of the book");
            string title = Console.ReadLine();
            Book book = books.FirstOrDefault(b => b.Title == title);
            if (book == null)
            {
                Console.WriteLine("BOOK UNAVIALABLE");
            }
            else
            {
                Console.WriteLine("Enter new title");
                string newtitle = Console.ReadLine();
                Console.WriteLine("Enter new author");
                string newAuthor = Console.ReadLine();
                Console.WriteLine("Enter the publication year");
                int newPublicationyear = Console.Read();
                book.Title = newtitle;
                book.Author = newAuthor;
                book.PublicationYear = newPublicationyear;
                Console.WriteLine("Book Updated Successfully");
            }
        }
        private static void DisplayBooks()
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Title},{book.PublicationYear}");
            }
        }
        private static void AddBook()
        {
            Console.WriteLine("Enter book title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Author Name");
            string auth = Console.ReadLine();
            Console.WriteLine("Enter publication year");
            int year = Console.Read();
            Book book = new Book(title, auth, year);
            books.Add(book);
            Console.WriteLine("Book added successfully");
        }
        static void DisplayMenu()
        {
            // Display the menu options
            Console.WriteLine("Welcome to the Library Management System!\n");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            // ...Add Other options here
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }
    }
    // Class definitions
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public Book(string title, string auth, int year)
        {
            Title = title;
            Author = auth;
            PublicationYear = year;
        }
    }
    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Borrower(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}