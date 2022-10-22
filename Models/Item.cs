namespace FPTBook.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Book book { get; set; }
        public int Item_Quantity { get; set; }
        public double Total { get; set; }
    }
}
