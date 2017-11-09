namespace Midterm_StorePOS
{
    class Product
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public override string ToString()
        {
            return $"\t{name, -16} \t{category, -8} \t{description, -35} \t${price, -5} \t{quantity, -6}";
        }

        public Product(string name, string category, string description, double price, int quantity)
        {
            this.name = name;
            this.category = category;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
