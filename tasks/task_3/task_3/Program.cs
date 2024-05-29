using Services;
using Models;
using Extensions;

var service = new InstanceService();

var vehicleTypes = service.GetInstances<Vehicle>();
service.WriteAllInstancesToDisk<Vehicle>(@".\instances");

Console.WriteLine("All vehicle types:");
foreach (var vehicleType in vehicleTypes)
    Console.WriteLine(vehicleType);

//IEnumerable<Type> SearchTypesByName<T>(string searchName)
//{
//    var service = new InstanceService();
//    searchName = searchName.ToLower();

//    return service.GetInstances<T>()
//            .Select(instance => instance!.GetType())
//            .Where(t => t.Name.ToLower().Contains(searchName))
//            .OrderBy(t => t.Name);
//}

//void WriteAllInstancesToDisk<T>(string directoryPath)
//{
//    if(!Directory.Exists(directoryPath))
//        Directory.CreateDirectory(directoryPath);
//    var service = new InstanceService();
//    var instances = service.GetInstances<T>();

//    foreach(var instance in instances)
//    {
//        var filepath = Path.Combine(directoryPath, $"{instance!.GetType()}.json");

//        var json = JsonSerializer.Serialize(instance);
//        File.WriteAllText(filepath, json);
//        Console.WriteLine($"Save {instance.GetType()} to hard drive {filepath}");
//    }
//}
