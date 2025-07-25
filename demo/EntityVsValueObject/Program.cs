using EntityVsValueObject.Model;

// Not my real birthday
var me = new Person("Ivan", "Temelkov", "Temelkov", new Age(new DateTime(1986, 02, 13)));

var anotherMe = new Person("Ivan", "Temelkov", "Temelkov", new Age(new DateTime(1986, 02, 13)));

Console.WriteLine(me.Equals(anotherMe)); // Should be false

var johnFoeGuid = Guid.NewGuid();

var johnDoe = new Person("John", "Doe", new Age(new DateTime(1966, 08, 26)), johnFoeGuid);

var johnDoeFromDb = new Person("John", "Doe", new Age(new DateTime(1966, 08, 26)), johnFoeGuid);

Console.WriteLine(johnDoe.Equals(johnDoeFromDb)); // Should be true

var currentAge = johnDoe.Age.GetValue(DefaultDateProvider.Instance).TotalDays;
Console.WriteLine($"Today {johnDoe.FullName.Value} is {currentAge:0} days old."); // Age when the application is run

var dateReference = new DateTime(2025, 07, 25);
var fixedDateProvider = new FixedDateProvider(new DateTimeOffset(dateReference));

var ageAsCoded = johnDoe.Age.GetValue(fixedDateProvider).TotalDays;
Console.WriteLine($"{johnDoe.FullName.Value} was {ageAsCoded:0} days old on {dateReference:dd MMMM yyyy}."); // Age when the application is run

Console.WriteLine(me.Age.Equals(johnDoe.Age)); // Should be false
