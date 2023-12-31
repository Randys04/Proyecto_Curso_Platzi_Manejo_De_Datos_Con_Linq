﻿

using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public IEnumerable<Book> firstThreeBooksFromCollection()
    {
        return booksCollection.Take(3).Select(book => new Book() {Title = book.Title, PageCount = book.PageCount });
    }

    public int totalBooksBetween200And500Pages()
    {
        // this line can be a bad practice 
        // return booksCollection.Where(book => book.PageCount >= 200 && book.PageCount <= 500).Count();

        return booksCollection.Count(book => book.PageCount >= 200 && book.PageCount <= 500);
    }

    public DateTime minPublishedDateBook()
    {
        return booksCollection.Min(book => book.PublishedDate);
    }

    public int biggestNumberOfPagesOfABook()
    {
        return booksCollection.Max(book => book.PageCount);
    }

    public Book bookWithTheLeastNumberOfPages()
    {
        return booksCollection.Where(book => book.PageCount > 0).MinBy(book => book.PageCount);
    }
    public Book mostRecentBook()
    {
        return booksCollection.MaxBy(book => book.PublishedDate);
    }

    public int totalNumberOfPagesOfBooksWithBetween0And500Pages ()
    {
        return booksCollection.Where(book => book.PageCount >= 0 && book.PageCount <= 500)
            .Sum(book => book.PageCount);
    }

    public string booksTitlesAfter2015()
    {
        return booksCollection.Where(book => book.PublishedDate.Year > 2015)
            .Aggregate("", (Titles, next) =>
            {
                if (Titles != string.Empty)
                {
                    Titles += " - " + next.Title;
                }
                else
                {
                    Titles = next.Title;
                }

                return Titles;
            }
            );
    }

    public double averageNumberOfCharactersInTitles ()
    {
        return booksCollection.Average(book => book.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> booksAfter2000GroupByYear()
    {
        return booksCollection.Where(book => book.PublishedDate.Year >= 2000).GroupBy(book => book.PublishedDate.Year);
    }

    public ILookup<char, Book> booksDictionaryByLetter()
    {
        return booksCollection.ToLookup(book => book.Title[0], book => book);
    }

    public IEnumerable<Book> booksAfter2005WithMoreThan500Pages()
    {
        var booksAfter2005 = booksCollection.Where(book => book.PublishedDate.Year > 2005);
        var booksMore500pages = booksCollection.Where(book => book.PageCount > 500);

        return booksAfter2005
            .Join(booksMore500pages, bookX => bookX.Title, bookY => bookY.Title, (bookX, bookY) => bookX);
    }

}

