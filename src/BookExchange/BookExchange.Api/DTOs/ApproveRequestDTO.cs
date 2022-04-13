namespace BookExchange.Api.DTOs
{
    public class ApproveRequestDTO
    {
    public Guid BookId { get; set; }
    public Guid BorrowerId { get; set; }
    public Guid LenderId { get; set; }
    public DateTime ApprovalDate { get; set; }
    public string ResponseStatus { get; set; } 

    }
}