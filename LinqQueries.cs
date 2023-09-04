

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
}

