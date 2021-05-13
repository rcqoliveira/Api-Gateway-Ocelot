namespace RC.OrdersApi
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Product(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}