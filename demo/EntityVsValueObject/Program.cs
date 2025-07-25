using EntityVsValueObject.Model;

// Not my real birthday
var me = new Person("Ivan", "Temelkov", new Age(new DateTime(1986, 02, 13)));

var anotherMe = new Person("Ivan", "Temelkov", new Age(new DateTime(1986, 02, 13)));

Console.WriteLine(me.Equals(anotherMe)); // Should be false

var johnFoeGuid = Guid.NewGuid();

var johnDoe = new Person("John", "Doe", new Age(new DateTime(1966, 08, 26)), johnFoeGuid);

var johnDoeFromDb = new Person("John", "Doe", new Age(new DateTime(1966, 08, 26)), johnFoeGuid);

Console.WriteLine(johnDoe.Equals(johnDoeFromDb)); // Should be true


var currentAge = me.Age.GetValue(DefaultDateProvider.Instance).TotalDays;
Console.WriteLine($"{me.Name} is {currentAge} days old."); // Age when the application is run

var fixedDateProvider = new FixedDateProvider(new DateTimeOffset(new DateTime(2025, 07, 25)));

var ageAsCoded = me.Age.GetValue(fixedDateProvider).TotalDays;
Console.WriteLine($"{me.Name} is {ageAsCoded} days old."); // Age when the application is run

Console.WriteLine(me.Age.Equals(johnDoe.Age)); // Should be false
