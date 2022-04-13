using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookExchange.Core.Models
{
    public class Request
    {

        [Key]
        public Guid RequestId { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; } 
        public Book? Book { get; set; } 
       
        [ForeignKey("User")]
        public Guid RequesterId{ get; set; }
        public User? Requester { get; set; }

        [ForeignKey("User")]
        public Guid ApproverId { get; set; }
        public User? Approver { get; set; }

        public DateTime CurrentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ResponseStatus { get; set; }  = "Pending";


    }
}