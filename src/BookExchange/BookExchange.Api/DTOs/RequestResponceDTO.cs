namespace BookExchange.Api.DTOs
{
    public class RequestResponceDTO
    {
        public Guid RequestId { get; set; }
        public string BookName { get; set; }
        public Guid BookId { get; set; } 
          public string RequesterString{ get; set; }
        public Guid RequesterId{ get; set; }
        public string ApproverName { get; set; }
         public Guid ApproverId { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool ResponseStatus { get; set; }


    }
}