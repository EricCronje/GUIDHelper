// See https://aka.ms/new-console-template for more information

TestGUIDWithRegex();

static void TestGUIDWithRegex()
{
    Console.WriteLine("GUID Test:");
    var guidString = Guid.NewGuid().ToString();
    string nonGuidString = "<Invalid>-<0000000>-<NotOK>-12345566756767erert";
    string messageFormat = $"{0} | guid is {1}, non Guid is {2}";
    var GUIDString = GUIDHelper.GUIDHelper.ValidateWithRegex(guidString).ToString();
    var NonGUIDString = GUIDHelper.GUIDHelper.ValidateWithRegex(nonGuidString).ToString();
    Console.WriteLine($"Is GUID: {GUIDString} -- {guidString}");
    Console.WriteLine($"Is GUID: {NonGUIDString} -- {nonGuidString}");
    Console.ReadLine();
}

