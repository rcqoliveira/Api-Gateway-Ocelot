namespace RC.OrdersApi
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }

        public OrderItem(int id, Product product)
        {
            this.Id = id;
            this.Product = product;
        }
    }
}
