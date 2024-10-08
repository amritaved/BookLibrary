using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LibraryManagementTest;
[TestClass]
public class BookRepositoryTests
{
    public BookRepositoryTests()
    {
    }

    private DbContextOptions<BookContext> CreateNewContextOptions()
    {
        return new DbContextOptionsBuilder<BookContext>().UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString()).Options;
    }

    [TestMethod]
    public async Task GetAllBooksAsync_ReturnsAllBooks()
    {
        // Arrange
        var options = CreateNewContextOptions();
        using var context = new BookContext(options);
        context.Database.EnsureCreated();
        var repository = new BookRepository(context);

        // Act
        var books = await repository.GetAllBooks();

        // Assert
        Assert.AreEqual(4, books.Count());
    }

    [TestMethod]
    public async Task GetBookByIdAsync_ReturnsCorrectBook()
    {
        // Arrange
        var options = CreateNewContextOptions();
        using var context = new BookContext(options);
        context.Database.EnsureCreated();
        var repository = new BookRepository(context);

        // Act
        var book = await repository.GetBookById(1);

        // Assert
        Assert.IsNotNull(book);
        Assert.AreEqual("Ikigai", book?.Title);
    }

    [TestMethod]
    public async Task AddBookAsync_AddsBookToDatabase()
    {
        // Arrange
        var options = CreateNewContextOptions();
        using var context = new BookContext(options);
        var repository = new BookRepository(context);
        var newBook = new Book { Id = 5, Title = "Brave New World", Author = "Aldous Huxley", Genre = "Dystopian", Year = 1932 };

        // Act
        await repository.AddBook(newBook);
        var book = await repository.GetBookById(5);

        // Assert
        Assert.IsNotNull(book);
        Assert.AreEqual("Brave New World", book?.Title);
    }

    [TestMethod]
    public async Task UpdateBookAsync_UpdatesBookDetails()
    {
        // Arrange
        var options = CreateNewContextOptions();
        using var context = new BookContext(options);
        context.Database.EnsureCreated();
        var repository = new BookRepository(context);
        var bookToUpdate = await repository.GetBookById(1);
        Assert.IsNotNull(bookToUpdate);
        bookToUpdate.Title = "Ikigai - Updated";

        // Act
        await repository.UpdateBook(bookToUpdate);
        var updatedBook = await repository.GetBookById(1);

        // Assert
        Assert.AreEqual("Ikigai - Updated", updatedBook?.Title);
    }

    [TestMethod]
    public async Task DeleteBookAsync_RemovesBookFromDatabase()
    {
        // Arrange
        var options = CreateNewContextOptions();
        using var context = new BookContext(options);
        context.Database.EnsureCreated();
        var repository = new BookRepository(context);

        // Act
        await repository.DeleteBook(1);
        var book = await repository.GetBookById(1);

        // Assert
        Assert.IsNull(book);
    }
}