namespace AccManagement.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }

        public override string ToString()
        {
            return $"Purchase of : {Qty} {Name}(s) at ZAR. {(Qty * Price):#.00} ";
        }
    }
}