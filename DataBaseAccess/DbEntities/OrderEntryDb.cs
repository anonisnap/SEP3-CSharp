namespace Entities.Models
{
    public class OrderEntryDb
    {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public int Amount { get; set; }
            public int ItemId {get;set;}
    }
}