namespace Team4CAProject.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Desc { set; get; }
        public int Stock { set; get; }
        public double UnitPrice { set; get; }
        public string Image { set; get; }


        public Product() { }

        public Product(string name, string desc, int stock, double unitPrice, string image)
        {
            Name = name;
            Desc = desc;
            Stock = stock;
            UnitPrice = unitPrice;
            Image = image;
        }
    }
}
