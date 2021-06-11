namespace RC.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FantasyName { get; set; }

        public Customer(int id, string name, string fantasyName)
        {
            this.Id = id;
            this.Name = name;
            this.FantasyName = fantasyName;
        }
    }
}
