
interface IPrintable
{
    void PrintDetails();
}

public class Book : IPrintable
 
{
    public string Title { get; set; } 
    public string Author { get; set; } 
    //
    public DateTime YearOfPublication { get;  }
    public bool IsBorrowed { get; set; }
    /* Constructor */
    // Note: In order to provide DateTime-Timestamp like here in the example where you want only the Year
    // use DateTime data type see for further details Documentation: https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-9.0
    public Book(string bookTitle = "Aknown", string bookAuthor = "Aknown", int yearOfPublication = default, bool bookIsBorrroed = false)
    {
        Title = bookTitle;
        Author = bookAuthor;
        YearOfPublication = new DateTime(yearOfPublication);
        IsBorrowed = bookIsBorrroed;
    }
    
    public void PrintDetails()
    {
        string isAvailable = IsBorrowed ? "NO" : "YES";
        Console.WriteLine($"Tittle: {Title}\t Author: {Author}\t Year: {YearOfPublication}\t Available: {isAvailable}");
    }
}

public class Library
{
    //Note: In c# or in Java see the documentation for naming conventions
    private List<Book> AllTheBooks = new List<Book>(); 

    /* Constructor */
    public Library()
    {
        AllTheBooks = Initialization();
    }
    

    public List<Book> Initialization()
    {
        List<Book> BookCollection = new List<Book>();
        BookCollection.Add(new Book("1984", "George Orwell", 1949));
        BookCollection.Add(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
        BookCollection.Add(new Book("Pride and Prejudice", "Jane Austen", 1813));
        BookCollection.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
        BookCollection.Add(new Book("Beloved", "Toni Morrison", 1987));
        BookCollection.Add(new Book("The Catcher in the Rye", "J.D. Salinger", 1951));
        BookCollection.Add(new Book("One Hundred Years of Solitude", "Gabriel García Márquez", 1967));
        BookCollection.Add(new Book("The Road", "Cormac McCarthy", 2006));
        BookCollection.Add(new Book("The Name of the Wind", "Patrick Rothfuss", 2007));
        BookCollection.Add(new Book("Sapiens: A Brief History of Humankind", "Yuval Noah Harari", 2011));

        return BookCollection;
    }

    //Note: Redundant comment because you use a nice and undestandable method name
    //Note: The static is not needed here
    public void AddBook(Book book)
    {

        AllTheBooks.Add(book);
        Console.WriteLine("The book is added!");
    }

    //Note: Redundant comment because you use a nice and undestandable method name
    //Note: The static is not needed here
    public void DisplayListOfBooks()
    {
        if (AllTheBooks != null)
        {
            foreach (Book book in AllTheBooks)
            {
                book.PrintDetails();
            }
        }
        else
        {
            Console.WriteLine("The Library is currently empty!");
        }
    }
    //Note: Redundant comment because you use a nice and undestandable method name
    //Note: The static is not needed here
    public void SearchBook(string bookTitle)
    {
        if (AllTheBooks != null)
        {
            if (AllTheBooks.Any(Book => Book.Title == bookTitle))
            {
                string message = !AllTheBooks.Find(Book => Book.Title == bookTitle).IsBorrowed ? "is" : "is not";
                Console.WriteLine($"The book: {bookTitle} exist and {message} currently available!");
            }
            else
            {
                Console.WriteLine($"Sorry, there isn't any book with the title: \'{bookTitle}\' in the Library!");
            }
        }
    }
    //Note: Redundant comment because you use a nice and undestandable method name
    //Note: The static is not needed here
    public void BorrowBook(string bookTitle)
    {
        if (AllTheBooks != null)
        {
            if (AllTheBooks.Any(Book => Book.Title == bookTitle))
            {
                if (AllTheBooks.Find(Book => Book.Title == bookTitle).IsBorrowed)
                {
                    Console.WriteLine($"Sorry, the book: {bookTitle} is currently rented!");
                }
                else
                {
                    AllTheBooks.Find(Book => Book.Title == bookTitle).IsBorrowed = true;
                    Console.WriteLine($"Successful borrowing of book: {bookTitle}. Happy reading!");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, there isn't any book with the title: \'{bookTitle}\' in the Library!");
            }
        }
    }
    //Note: Redundant comment because you use a nice and undestandable method name
    //Note: The static is not needed here

    public void ReturnBook(string bookTitle)
    {
        if (AllTheBooks != null)
        {
            if (AllTheBooks.Any(Book => Book.Title == bookTitle))
            {
                if (AllTheBooks.Find(Book => Book.Title == bookTitle).IsBorrowed == true)
                {
                    AllTheBooks.Find(Book => Book.Title == bookTitle).IsBorrowed = false;
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
        //Note: First create an instance of the Library class always make use of the Constructor
        //Note: The AlltheBooks variable has already been Initialized in the Constructor
        Library library = new Library();
        //Note: PascalCase for naming conventions
        int[] myChoices = { 1, 2, 3, 4, 5 };
        int userChoice;

        do
        {
            userChoice = 0;
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
                    if (!int.TryParse(input, out userChoice))
                    {
                        throw new FormatException("The option has to be an integer.");
                    }
                    if (!myChoices.Contains(userChoice))
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

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("List of books:");
                    library.DisplayListOfBooks();
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.Write("Type the book's title that you want to search: ");
                    library.SearchBook(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("");
                    Console.Write("Type the book's title that you want to search: ");
                    library.BorrowBook(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("");
                    Console.Write("Type the book's title that you want to search: ");
                    library.ReturnBook(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("");
                    Console.WriteLine("Exiting Programm!");
                    break;
            }

        }
        while (userChoice != 5);

    }
}
