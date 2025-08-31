
interface IPrintable
{
    void PrintDetails();
}

class Book : IPrintable
 
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearOfPublication { get; set; }
    public bool IsBorrowed { get; set; }

    public Book(string bookTitle = "Aknown", string bookAuthor = "Aknown", int yearOfPub = 0, bool bookIsBorrroed = false)
    {
        Title = bookTitle;
        Author = bookAuthor;
        YearOfPublication = yearOfPub;
        IsBorrowed = bookIsBorrroed;
    }
    
    public void PrintDetails()
    {
    string isAvailable = IsBorrowed ? "NO" : "YES";
    Console.WriteLine($"Tittle: {Title}\t Author: {Author}\t Year: {YearOfPublication}\t Available: {isAvailable}");
    }
}

class Library
{
    private static List<Book> All_the_books = null;

    public static void Initial_collection()
    {
        List<Book> collection_of_books = new List<Book>();
        collection_of_books.Add(new Book("1984", "George Orwell", 1949));
        collection_of_books.Add(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
        collection_of_books.Add(new Book("Pride and Prejudice", "Jane Austen", 1813));
        collection_of_books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
        collection_of_books.Add(new Book("Beloved", "Toni Morrison", 1987));
        collection_of_books.Add(new Book("The Catcher in the Rye", "J.D. Salinger", 1951));
        collection_of_books.Add(new Book("One Hundred Years of Solitude", "Gabriel García Márquez", 1967));
        collection_of_books.Add(new Book("The Road", "Cormac McCarthy", 2006));
        collection_of_books.Add(new Book("The Name of the Wind", "Patrick Rothfuss", 2007));
        collection_of_books.Add(new Book("Sapiens: A Brief History of Humankind", "Yuval Noah Harari", 2011));
        Library.All_the_books = collection_of_books;
    }

    // Add a book
    public static void Add_book(Book the_book_to_add)
    {

        All_the_books.Add(the_book_to_add);
        Console.WriteLine("The book is added!");
    }

    // List the books
    public static void Display_list_of_book()
    {
        if (All_the_books != null)
        {
            foreach (Book book in All_the_books)
            {
                book.PrintDetails();
            }
        }
        else
        {
            Console.WriteLine("The Library is currently empty!");
        }
    }

    // Search a book
    public static void Search_book(string bookTitle)
    {
        if (All_the_books != null)
        {
            if (All_the_books.Any(Book => Book.Title == bookTitle))
            {
                string message = !All_the_books.Find(Book => Book.Title == bookTitle).IsBorrowed ? "is" : "is not";
                Console.WriteLine($"The book: {bookTitle} exist and {message} currently available!");
            }
            else
            {
                Console.WriteLine($"Sorry, there isn't any book with the title: \'{bookTitle}\' in the Library!");
            }
        }
    }

    //Borrow a book
    public static void Borrow_book(string bookTitle)
    {
        if (All_the_books != null)
        {
            if (All_the_books.Any(Book => Book.Title == bookTitle))
            {
                if (All_the_books.Find(Book => Book.Title == bookTitle).IsBorrowed)
                {
                    Console.WriteLine($"Sorry, the book: {bookTitle} is currently rented!");
                }
                else
                {
                    All_the_books.Find(Book => Book.Title == bookTitle).IsBorrowed = true;
                    Console.WriteLine($"Successful borrowing of book: {bookTitle}. Happy reading!");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, there isn't any book with the title: \'{bookTitle}\' in the Library!");
            }
        }
    }

    //Return a book
    public static void Return_book(string bookTitle)
    {
        if (All_the_books != null)
        {
            if (All_the_books.Any(Book => Book.Title == bookTitle))
            {
                if (All_the_books.Find(Book => Book.Title == bookTitle).IsBorrowed == true)
                {
                    All_the_books.Find(Book => Book.Title == bookTitle).IsBorrowed = false;
                    Console.WriteLine($"Successful return of the book: {bookTitle}!");
                }
                else Console.WriteLine("Something went wrong. The book is already available for borrowing");
            }
            else Console.WriteLine("Something went wrong doesn't exists");
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        Library.Initial_collection();
        int[] mychoices = { 1, 2, 3, 4, 5 };
        int user_choice;

        do
        {
            user_choice = 0;
            bool valid_int_choice = false;
            //Console.Clear();
            Console.WriteLine("===== Library's Menu =====");
            Console.WriteLine("1. View all books");
            Console.WriteLine("2. Search a book");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Exit the programm");
            Console.WriteLine("Select an option (1-5)");
            Console.Write("Option: ");

            while (!valid_int_choice)
            {
                try
                {
                    Console.Write("Option (1-5): ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out user_choice))
                    {
                        throw new FormatException("The option has to be an integer.");
                    }
                    if (!mychoices.Contains(user_choice))
                    {
                        throw new ArgumentOutOfRangeException("The option has to be between 1 and 5.");
                    }
                    valid_int_choice = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            switch (user_choice)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("List of books:");
                        Library.Display_list_of_book();
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("");
                        Console.Write("Type the book's title that you want to search: ");
                        Library.Search_book(Console.ReadLine());
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("");
                        Console.Write("Type the book's title that you want to search: ");
                        Library.Borrow_book(Console.ReadLine());
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("");
                        Console.Write("Type the book's title that you want to search: ");
                        Library.Return_book(Console.ReadLine());
                    }
                    break;
                case 5:
                    Console.WriteLine("");
                    Console.WriteLine("Exiting Programm!");
                    break;
            }

        }
        while (user_choice != 5);

    }
}
