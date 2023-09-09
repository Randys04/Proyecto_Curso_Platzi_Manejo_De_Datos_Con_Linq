

using System.Reflection.Metadata.Ecma335;

public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();
    public LinqQueries() 
    {
        using (StreamReader reader = new StreamReader("books.json")) 
        {
            string json = reader.ReadToEnd();
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
        } 
    }

    public IEnumerable<Book> allCollection()
    {
        return booksCollection;
    }

    public IEnumerable<Book> booksAfter2000()
    {
        // extension method
        // return booksCollection.Where(book => book.PublishedDate.Year > 2000);

        // query expresion
        return from book in booksCollection where book.PublishedDate.Year > 2000 select book;
    }

    public IEnumerable<Book> booksWithMoreThan250PagesAndInActionInTheirTitle()
    {
        // extension method
        // return booksCollection.Where(book => book.PageCount > 249 && book.Title.Contains("in Action"));

        // query expresion
        return from book in booksCollection where book.PageCount > 250 && book.Title.Contains("in Action") select book;
    }

    public bool AllBooksHasStatus()
    {
        return booksCollection.All(book => book.Status != string.Empty);
    }

    public bool AnyBookWasPublishedIn2005()
    {
        return booksCollection.Any(book => book.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> BooksThatContainsPythonInTheirCategories()
    {
        // extension method
        // return booksCollection.Where(book => book.Categories.Contains("Python"));
        
        // query expresion
        return from book in booksCollection where book.Categories.Contains("Python") select book;
    }

    public IEnumerable<Book> JavaBooksByNameAscendant()
    {
        return booksCollection.Where(book => book.Categories.Contains("Java")).OrderBy(book => book.Title);
    }

    public IEnumerable<Book> BooksWithMoreThan450PagesSortedinDescendingOrder()
    {
        return booksCollection.Where(book => book.PageCount > 450).OrderByDescending(book => book.PageCount);
    }

    public IEnumerable<Book> ThreeMostRecentJavaBooks()
    {
        return booksCollection.Where(book => book.Categories.Contains("Java")).OrderByDescending(book => book.PublishedDate).Take(3);
    }

    public IEnumerable<Book> thirdAndFourthBookWithMoreThan400Pages()
    {
        return booksCollection.Where(book => book.PageCount > 400).Take(4).Skip(2);
    }


}

