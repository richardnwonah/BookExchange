namespace BookExchange.Core.Models
{
    public class BorrowedBook
    {
       // [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public User Borrower { get; set; }   
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}