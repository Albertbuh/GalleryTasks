namespace Models
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double MaxSpeed { get; set; }
        public double WeightInKg { get; set; }

        protected Vehicle(string name, double maxSpeed, double weightInKg)
        {
            Id = Guid.NewGuid();
            Name = name;
            MaxSpeed = maxSpeed;
            WeightInKg = weightInKg;
        }
        public Vehicle(): this("some name", 0, 0)
        {}
    }
}
