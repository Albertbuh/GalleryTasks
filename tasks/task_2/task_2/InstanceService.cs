namespace Services
{
    public class InstanceService
    {
        private static readonly InstanceService _instanceService = new();
        public IEnumerable<T> GetInstances<T>()
        {
            var type = typeof(T);
            var result = new List<T>();

            try
            {
                var derivedTypes = AppDomain.CurrentDomain.GetAssemblies()
                                        .SelectMany(x => x.GetTypes())
                                        .Where(t => type.IsAssignableFrom(t) && !t.IsAbstract);

                foreach (var derivedType in derivedTypes)
                {
                    var instance = Activator.CreateInstance(derivedType);
                    if (instance != null)
                        result.Add((T)instance);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception thrown in InstanceService: " + e.ToString());
            }

            return result;
        }

        public static InstanceService GetService() => _instanceService;
    }
}
