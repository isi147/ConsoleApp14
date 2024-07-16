//////////class President
//////////{
//////////    public string? Name { get; set; }
//////////    public string? Surname { get; set; }
//////////    public float Height { get; set; }

//////////    private static President? _instance = null;

//////////    private President()
//////////    {
//////////        Name = "XXX";
//////////        Surname = "XXXXX";
//////////        Height = 195;
//////////    }


//////////    public static President Instance
//////////    {
//////////        get
//////////        {
//////////            if (_instance == null)
//////////                _instance = new President();

//////////            return _instance;
//////////        }
//////////    }
//////////}



//////////class Program
//////////{
//////////    static void Main()
//////////    {
//////////        President president1 = President.Instance;
//////////        President president2 = President.Instance;

//////////        Console.WriteLine(president1 == president2);
//////////    }
//////////}



////////using System.Text;

////////namespace Builder;


////////// Product
////////// IBuilder
////////// ConcreteBuilder1, ConcreteBuilder2
////////// Director (Optional)



////////class House
////////{
////////    public string? Name { get; set; }
////////    public int Walls { get; set; }
////////    public int Doors { get; set; }
////////    public int Windows { get; set; }
////////    public bool HasRoof { get; set; }
////////    public bool HasGarage { get; set; }
////////    public bool HasGarden { get; set; }
////////    public bool HasPool { get; set; }

////////    public override string ToString()
////////    => @$"
////////        Name {Name}
////////        Walls {Walls}
////////        Doors {Doors}
////////        Windows {Windows}
////////        HasRoof {HasRoof}
////////        HasGarage {HasGarage}
////////        HasGarden {HasGarden}
////////        HasPool {HasPool}";
////////}


////////interface IHouseBuilder
////////{
////////    House House { get; set; }

////////    IHouseBuilder BuildWalls(int count);
////////    IHouseBuilder BuildDoors(int count);
////////    IHouseBuilder BuildWindows(int count);
////////    IHouseBuilder BuildRoof();
////////    IHouseBuilder BuildGarage();
////////    IHouseBuilder BuildGarden();
////////    IHouseBuilder BuildPool();

////////    void Reset();
////////    House Build();
////////}


////////class WoodHouseBuilder : IHouseBuilder
////////{
////////    public House House { get; set; } = new House { Name = "WoodHouse" };

////////    public IHouseBuilder BuildDoors(int count)
////////    {
////////        House.Doors = count;
////////        return this;
////////    }
////////    public IHouseBuilder BuildGarage()
////////    {
////////        House.HasGarage = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildGarden()
////////    {
////////        House.HasGarden = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildPool()
////////    {
////////        House.HasPool = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildRoof()
////////    {
////////        House.HasRoof = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildWalls(int count)
////////    {
////////        House.Walls = count;
////////        return this;
////////    }
////////    public IHouseBuilder BuildWindows(int count)
////////    {
////////        House.Windows = count;
////////        return this;
////////    }

////////    public House Build()
////////    {
////////        var result = House;

////////        Reset();
////////        House.Name = "WoodHouse";

////////        return result;
////////    }

////////    public void Reset() => House = new House();
////////}

////////class StoneHouseBuilder : IHouseBuilder
////////{
////////    public House House { get; set; } = new House { Name = "StoneHouse" };

////////    public IHouseBuilder BuildDoors(int count)
////////    {
////////        House.Doors = count;
////////        return this;
////////    }
////////    public IHouseBuilder BuildGarage()
////////    {
////////        House.HasGarage = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildGarden()
////////    {
////////        House.HasGarden = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildPool()
////////    {
////////        House.HasPool = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildRoof()
////////    {
////////        House.HasRoof = true;
////////        return this;
////////    }
////////    public IHouseBuilder BuildWalls(int count)
////////    {
////////        House.Walls = count;
////////        return this;
////////    }
////////    public IHouseBuilder BuildWindows(int count)
////////    {
////////        House.Windows = count;
////////        return this;
////////    }
////////    public House Build()
////////    {
////////        var result = House;

////////        Reset();
////////        House.Name = "StoneHouse";

////////        return result;
////////    }

////////    public void Reset() => House = new House();
////////}



////////class Director
////////{

////////    private IHouseBuilder _builder;

////////    public Director(IHouseBuilder builder)
////////    {
////////        _builder = builder;
////////    }


////////    public void ChangeBuilder(IHouseBuilder builder)
////////    {
////////        _builder = builder;
////////    }

////////    public IHouseBuilder BuildMinimalHouse()
////////        => _builder
////////               .BuildWalls(4)
////////               .BuildDoors(1)
////////               .BuildWindows(2)
////////               .BuildRoof();

////////    public IHouseBuilder BuildFullFeaturedHouse()
////////        => _builder
////////               .BuildWalls(12)
////////               .BuildDoors(3)
////////               .BuildWindows(7)
////////               .BuildRoof()
////////               .BuildGarage()
////////               .BuildGarden()
////////               .BuildPool();

////////}


////////class Program
////////{
////////    static void Main()
////////    {

////////        IHouseBuilder builder = new StoneHouseBuilder();
////////        House house;


////////        // Fluent
////////        house = builder
////////            .BuildWalls(4)
////////            .BuildDoors(1)
////////            .BuildWindows(2)
////////            .BuildRoof()
////////            .Build();


////////        Director director = new(builder);
////////        house = director.BuildFullFeaturedHouse().Build();

////////        // Console.WriteLine(house);










////////        // FluentValidation 

////////        /*
////////        StringBuilder sb = new StringBuilder();

////////        string fullname = sb
////////                .Append("Tural")
////////                .Append(" ")
////////                .Append("Novruzov")
////////                .ToString();

////////        Console.WriteLine(fullname);
////////        */
////////    }
////////}




//////using static System.Console;
//////#nullable disable


//////namespace DesignPatterns.Prototype;

//////public class Person
//////{
//////    public int Age;
//////    public DateTime BirthDate;
//////    public string Name;
//////    public IdInfo IdInfo;

//////    public Person ShallowCopy()
//////    {
//////        return (Person)MemberwiseClone();
//////    }

//////    public Person DeepCopy()
//////    {
//////        Person clone = (Person)MemberwiseClone();
//////        clone.IdInfo = new IdInfo(IdInfo.IdNumber);
//////        clone.Name = Name;
//////        return clone;
//////    }
//////}

//////public class IdInfo
//////{
//////    public int IdNumber;

//////    public IdInfo(int idNumber)
//////    {
//////        IdNumber = idNumber;
//////    }
//////}




//////class Program
//////{
//////    static void Main(string[] args)
//////    {
//////        Person p1 = new Person();
//////        p1.Age = 42;
//////        p1.BirthDate = Convert.ToDateTime("1977-01-01");
//////        p1.Name = "Jack Daniels";
//////        p1.IdInfo = new IdInfo(666);

//////        Person p2 = p1.ShallowCopy();
//////        Person p3 = p1.DeepCopy();


//////        WriteLine("Original values of p1, p2, p3:");
//////        WriteLine("   p1 instance values: ");
//////        DisplayValues(p1);
//////        WriteLine("   p2 instance values:");
//////        DisplayValues(p2);
//////        WriteLine("   p3 instance values:");
//////        DisplayValues(p3);



//////        p1.Age = 32;
//////        p1.BirthDate = Convert.ToDateTime("1900-01-01");
//////        p1.Name = "Frank";
//////        p1.IdInfo.IdNumber = 7878;

//////        WriteLine("\nValues of p1, p2 and p3 after changes to p1:");

//////        WriteLine("   p1 instance values: ");
//////        DisplayValues(p1);

//////        WriteLine("   p2 instance values (reference values have changed):");
//////        DisplayValues(p2);

//////        WriteLine("   p3 instance values (everything was kept the same):");
//////        DisplayValues(p3);
//////    }


//////    public static void DisplayValues(Person p)
//////    {
//////        Console.WriteLine($"\tName: {p.Name}, Age: {p.Age}, BirthDate: {p.BirthDate}");
//////        Console.WriteLine($"\tID#: {p.IdInfo.IdNumber}");
//////    }
//////}


////namespace Adapter;

////interface IAudioFile
////{
////    void Play();
////}

////class Mp3 : IAudioFile
////{
////    public void Play()
////    {
////        Console.WriteLine("Mp3 audio playing");
////    }
////}

////class Wav : IAudioFile
////{
////    public void Play()
////    {
////        Console.WriteLine("Wav audio playing");
////    }
////}

////class FLAC : IAudioFile
////{
////    public void Play()
////    {
////        Console.WriteLine("FLAC audio playing");
////    }
////}



////// Nuget
////class OGG
////{
////    public void PlayAudio()
////    {
////        Console.WriteLine("OGG audio playing");
////    }
////}





////// // Object Adapter
////// class OggAdapter : IAudioFile
////// {
//////     private readonly OGG? ogg = null;
////// 
//////     public OggAdapter()
//////     {
//////         ogg = new OGG();
//////     }
////// 
//////     public void Play()
//////     {
//////         ogg?.PlayAudio();
//////     }
////// }





////// Class Adapter
//////class OggAdapter : OGG, IAudioFile
//////{
//////    public void Play()
//////    {
//////        PlayAudio();
//////    }
//////}




//////class Program
//////{
//////    static void Main()
//////    {
//////        List<IAudioFile> winamp = new()
//////        {
//////            new Mp3(),
//////            new Wav(),
//////            new OggAdapter(),
//////            new FLAC(),
//////            new Mp3(),
//////            new FLAC(),
//////            new OggAdapter()
//////        };


//////        foreach (var audio in winamp)
//////            audio.Play();
//////    }
//////}






////interface INotifier
////{
////    void Send(string message);
////}


////class Notifier : INotifier
////{
////    public void Send(string message)
////    {
////        Console.WriteLine("Message sent with Email"); ;
////    }
////}



////class Application
////{
////    private readonly INotifier _notifier;
////    public Application(INotifier notifier)
////    {
////        _notifier = notifier;
////    }

////    public void SendMessage(string message)
////    {
////        _notifier.Send(message);
////    }
////}










////// Decorators
////abstract class BaseDecorator : INotifier
////{
////    protected INotifier _notifier { get; set; }

////    public BaseDecorator(INotifier notifier)
////    {
////        _notifier = notifier;
////    }

////    public virtual void Send(string message)
////    {
////        _notifier.Send(message);
////    }
////}


////class TelegramDecorator : BaseDecorator
////{
////    public TelegramDecorator(INotifier notifier) : base(notifier) { }

////    public override void Send(string message)
////    {
////        // hard code
////        base.Send(message);
////        Console.WriteLine("Message sent with Telegram");
////    }
////}


////class FacebookDecorator : BaseDecorator
////{
////    public FacebookDecorator(INotifier notifier) : base(notifier) { }

////    public override void Send(string message)
////    {
////        // hard code
////        base.Send(message);
////        Console.WriteLine("Message sent with Facebook");
////    }
////}


////class SlackDecorator : BaseDecorator
////{
////    public SlackDecorator(INotifier notifier) : base(notifier) { }

////    public override void Send(string message)
////    {
////        // hard code
////        base.Send(message);
////        Console.WriteLine("Message sent with Slack");
////    }
////}



////class Program
////{
////    static void Main()
////    {

////        INotifier notifier = new Notifier();

////        notifier = new TelegramDecorator(notifier);
////        notifier = new FacebookDecorator(notifier);
////        notifier = new SlackDecorator(notifier);



////        Application client = new(notifier);
////        client.SendMessage("Discount 50%");
////    }
////}


//#nullable disable

//namespace Facade;


//interface IDevice
//{
//    string Vendor { get; set; }
//    string Model { get; set; }
//    void Start();
//}


//class CPU : IDevice
//{
//    public string Vendor { get; set; }
//    public string Model { get; set; }

//    public void Start()
//    {
//        Console.WriteLine("CPU started");
//    }
//}


//class RAM : IDevice
//{
//    public string Vendor { get; set; }
//    public string Model { get; set; }

//    public void Start()
//    {
//        Console.WriteLine("RAM started");
//    }
//}

//class GPU : IDevice
//{
//    public string Vendor { get; set; }
//    public string Model { get; set; }

//    public void Start()
//    {
//        Console.WriteLine("GPU started");
//    }
//}

//class MotherBoard : IDevice
//{
//    public string Vendor { get; set; }
//    public string Model { get; set; }

//    public void Start()
//    {
//        Console.WriteLine("Motherboard started");
//    }

//}

//class PowerSupply : IDevice
//{
//    public string Vendor { get; set; }
//    public string Model { get; set; }

//    public void Start()
//    {
//        Console.WriteLine("PowerSupply started");
//    }
//}

//class Case : IDevice
//{
//    public List<IDevice> Devices { get; set; } = new();

//    public string Vendor { get; set; }
//    public string Model { get; set; }

//    public void AddDevice(IDevice _otherdevice)
//    {
//        Devices.Add(_otherdevice);
//    }

//    public void Start()
//    {
//        Devices.ForEach(e => e.Start());
//        Console.WriteLine("Computer started");
//    }
//}




//class ComputerFacade
//{
//    MotherBoard mb = new MotherBoard();
//    RAM ram = new RAM();
//    GPU gpu = new GPU();
//    CPU cpu = new CPU();
//    PowerSupply ps = new PowerSupply();
//    Case c = new Case();

//    public ComputerFacade()
//    {
//        c.AddDevice(mb);
//        c.AddDevice(ram);
//        c.AddDevice(gpu);
//        c.AddDevice(cpu);
//        c.AddDevice(ps);
//    }

//    public void Start()
//    {
//        // some hard code 

//        c.Start();
//    }
//}



//class Program
//{
//    static void Main()
//    {
//        ComputerFacade facade = new ComputerFacade();
//        facade.Start();
//    }
//}