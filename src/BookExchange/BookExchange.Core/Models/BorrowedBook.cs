using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookExchange.Core.Models
{
    public class BorrowedBook
    {
       [Key]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("User")]
        public Guid BorrowerId { get; set; }  
        public User Borrower { get; set; }  

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;

    }
}