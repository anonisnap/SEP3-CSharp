using System;

namespace Entities.Models
{
    public class OrderEntry: ICloneable
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public Item Item { get; set; }


        public override string ToString()
        {
            return $"Order Entry\n " +
                   $"Id: {Id}\n" +
                   $"OrderId: {OrderId}\n" +
                   $"Amount: {Amount}\n" +
                   $"Item: {Item.ItemName}";        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}