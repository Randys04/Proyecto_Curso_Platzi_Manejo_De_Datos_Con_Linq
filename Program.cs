// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

printValues(queries.allCollection());

void printValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0,-70} {1,7} {2,11}\n", "Title", "Pages", "Published date" );
    foreach (var item in booksList)
    {
        Console.WriteLine("{0,-70} {1,7} {2,11}",item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}