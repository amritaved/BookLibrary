using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models
{
	public class Book
	{
		/// <summary>
		/// The unique identifier for the Book.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The Title of the Book. 
		/// </summary>
		[Required]
		public string? Title { get; set; }

		/// <summary>
		/// The Author of the Book. 
		/// </summary>
		[Required]
		public string? Author { get; set; }

		/// <summary>
		/// The genre of the Book
		/// </summary>
		public string? Genre { get; set; }

		/// <summary>
		/// The year the Book was published.
		/// </summary>
		public int Year { get; set; }

	}
}

