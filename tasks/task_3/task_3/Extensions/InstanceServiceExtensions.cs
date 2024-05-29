using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Extensions
{
    internal static class InstanceServiceExtensions
    {
        public static IEnumerable<Type> SearchTypesByName<T>(this InstanceService instanceService, string searchName)
        {
            return instanceService.GetInstances<T>()
                    .Select(instance => instance!.GetType())
                    .Where(t => t.Name.Contains(searchName, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(t => t.Name);
        }

        public static void WriteAllInstancesToDisk<T>(this InstanceService instanceService, string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            var instances = instanceService.GetInstances<T>();

            foreach (var instance in instances)
            {
                var filepath = Path.Combine(directoryPath, $"{instance!.GetType()}.json");

                var json = JsonSerializer.Serialize(instance);
                File.WriteAllText(filepath, json);
                Console.WriteLine($"Save {instance.GetType()} to hard drive {filepath}");
            }
        }

        public static void WriteAllInstancesToDisk<T>(this InstanceService instanceService, string directoryPath, string searchName)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            var instances = instanceService.GetInstances<T>()
                                .Where(t => t!.GetType().Name.Contains(searchName, StringComparison.CurrentCultureIgnoreCase));

            foreach (var instance in instances)
            {
                try
                {
                    var filepath = Path.Combine(directoryPath, $"{instance!.GetType()}.json");

                    var json = JsonSerializer.Serialize(instance);
                    File.WriteAllText(filepath, json);
                    Console.WriteLine($"Save {instance.GetType()} to hard drive {filepath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception thrown while save instance of {instance?.GetType()}: {ex.ToString()}");
                }
            }
        }

    }
}
