// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

// all collection
// printValues(queries.allCollection());

// books after 2000
//printValues(queries.booksAfter2000());

// books with more than 250 pages and contains the word "in Action" in their title
//printValues(queries.booksWithMoreThan250PagesAndInActionInTheirTitle());

// verify if all books have a status
// Console.WriteLine($"All books have a status? - {queries.AllBooksHasStatus()}");

// verify if any book was published in 2005
// Console.WriteLine($"Any book was published in 2005? - {queries.AnyBookWasPublishedIn2005()}");

// books with "Python" in their categories
printValues(queries.BooksThatContainsPythonInTheirCategories());

void printValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0,-70} {1,7} {2,11}\n", "Title", "Pages", "Published date" );
    foreach (var item in booksList)
    {
        Console.WriteLine("{0,-70} {1,7} {2,11}",item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}