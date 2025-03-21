﻿
/// <summary>
/// This class represents a collection of Book objects,
/// for instance the books in a library
/// </summary>
public class BookRepository
{
    #region Instance fields
    private Dictionary<string, Book> _books;
    #endregion

    #region Constructor
    public BookRepository()
    {
        _books = new Dictionary<string, Book>();
    }
    #endregion

    #region Properties
    public int Count
    {
        get { return _books.Count; }
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method adds a single Book object 
    /// to the List of books 
    /// </summary>
    public void AddBook(Book aBook)
    {
        // TODO
        if (!_books.ContainsKey(aBook.ISBN))
        {
            _books.Add(aBook.ISBN, aBook);
        }
        
    }

    /// <summary>
    /// This method returns a Book object (if any) from
    /// the List of books, which has a matching ISBN number.
    /// If no such object exists, the method returns null.
    /// </summary>
    public Book? LookupBook(string isbn)
    {
        // TODO
        if (_books.ContainsKey(isbn))
        {
            return _books[isbn];
        }
        else
        {
            return null;
        } 
    }

    /// <summary>
    /// This method deletes a Book object from the List
    /// of books, specifically the object which has a
    /// matching ISBN number. If no such object exists,
    /// no object is deleted.
    /// </summary>
    public void DeleteBook(string isbn)
    {
        // TODO
        _books.Remove(isbn);
    }
    #endregion
}
