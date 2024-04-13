using Linqd;
// By default the query doesn't execute until the foeach loop is called or methods in the query

// The Three Parts of a LINQ Query:
// 1. Data source.
int[] numbers = [0, 1, 2, 3, 4, 5, 6];

// 2. Query creation.
// numQuery is an IEnumerable<int>
var numQuery =
    from num in numbers
    where (num % 2) == 0
    select num;

// 3. Query execution.
foreach (int num in numQuery)
{
  Console.Write("{0,1} ", num);
}

// deferred execution ^^^^

// Force executions

var evenNumQuery =
    from num in numbers
    where (num % 2) == 0
    select num;

int evenNumCount = evenNumQuery.Count();

List<int> numQuery2 =
    (from num in numbers
     where (num % 2) == 0
     select num).ToList();

// or like this:
// numQuery3 is still an int[]

var numQuery3 =
    (from num in numbers
     where (num % 2) == 0
     select num).ToArray();


// Data source.
int[] scores = [90, 71, 82, 93, 75, 82];

// Query Expression.
IEnumerable<int> scoreQuery = //query variable
    from score in scores //required
    where score > 80 // optional
    orderby score descending // optional
    select score; //must end with select or group

// Execute the query to produce the results
foreach (var testScore in scoreQuery)
{
  Console.WriteLine(testScore);
}

City[] cities = [new City(20000), new City(120000), new City(112000), new City(150340), new City(23000)];

//Query syntax
IEnumerable<City> queryMajorCities =
    from city in cities
    where city.Population > 100000
    select city;

// Execute the query to produce the results
foreach (City city in queryMajorCities)
{
  Console.WriteLine(city);
}

// Method-based syntax
IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);

// IMPLICIT TYPE
var queryCities =
    from city in cities
    where city.Population > 100000
    select city;

// many "from"

Country[] countries = [new Country("Spain", [.. cities], 300000, 900000)];

IEnumerable<City> cityQuery =
    from country in countries
    from city in country.Cities
    where city.Population > 10000
    select city;

var queryNameAndPop =
    from country in countries
    select new
    {
      country.Name,
      Pop = country.Population
    };

// percentileQuery is an IEnumerable<IGrouping<int, Country>>
var percentileQuery =
    from country in countries
    let percentile = (int)country.Population / 10_000_000
    group country by percentile into countryGroup
    where countryGroup.Key >= 20
    orderby countryGroup.Key
    select countryGroup;

// grouping is an IGrouping<int, Country>
foreach (var grouping in percentileQuery)
{
  Console.WriteLine(grouping.Key);
  foreach (var country in grouping)
  {
    Console.WriteLine(country.Name + ":" + country.Population);
  }
}

IEnumerable<City> queryCityPop =
    from city in cities
    where city.Population is < 200000 and > 100000
    select city;

// joins
//var categoryQuery =
//    from cat in categories
//    join prod in products on cat equals prod.Category
//    select new
//    {
//      Category = cat,
//      Name = prod.Name
//    };

// method syntax
List<int> numbers1 = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
List<int> numbers2 = [15, 14, 11, 13, 19, 18, 16, 17, 12, 10];

// Query #4.
double average = numbers1.Average();

// Query #5.
IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);
// Query #6.
IEnumerable<int> largeNumbersQuery = numbers2.Where(c => c > 15);
// var is used for convenience in these queries
double average2 = numbers1.Average();
var concatenationQuery2 = numbers1.Concat(numbers2);
var largeNumbersQuery2 = numbers2.Where(c => c > 15);

List<string> words = ["an", "apple", "a", "day"];

var query = words.Select(word => word.Substring(0, 1));

foreach (string s in query)
{
  Console.WriteLine(s);
}

List<string> phrases = ["an apple a day", "the quick brown fox"];

query = phrases.SelectMany(phrases => phrases.Split(' '));

foreach (string s in query)
{
  Console.WriteLine(s);
}


List<Student> students =
  [
      new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= [97, 92, 81, 60]},
    new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
    new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
    new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
    new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
    new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
    new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
    new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
    new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
    new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
    new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
    new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
  ];

IEnumerable<Student> studentQuery =
    from student in students
    where student.Scores[0] > 90 && student.Scores[3] < 80
    select student;

// Execute the query.
// var could be used here also.
foreach (Student student in studentQuery)
{
  Console.WriteLine("{0}, {1}", student.Last, student.First);
}

IEnumerable<IGrouping<char, Student>> studentQuery2 =
    from student in students
    group student by student.Last[0];

foreach (IGrouping<char, Student> studentGroup in studentQuery2)
{
  Console.WriteLine(studentGroup.Key);
  foreach (Student student in studentGroup)
  {
    Console.WriteLine("   {0}, {1}",
                student.Last, student.First);
  }
}

var studentQuery3 =
    from student in students
    group student by student.Last[0];

foreach (var groupOfStudents in studentQuery3)
{
  Console.WriteLine(groupOfStudents.Key);
  foreach (var student in groupOfStudents)
  {
    Console.WriteLine("   {0}, {1}",
        student.Last, student.First);
  }
}

var studentQuery4 =
    from student in students
    group student by student.Last[0] into studentGroup
    orderby studentGroup.Key
    select studentGroup;

foreach (var groupOfStudents in studentQuery4)
{
  Console.WriteLine(groupOfStudents.Key);
  foreach (var student in groupOfStudents)
  {
    Console.WriteLine("   {0}, {1}",
        student.Last, student.First);
  }
}


// studentQuery5 is an IEnumerable<string>
// This query returns those students whose
// first test score was higher than their
// average score.
var studentQuery5 =
    from student in students
    let totalScore = student.Scores[0] + student.Scores[1] +
        student.Scores[2] + student.Scores[3]
    where totalScore / 4 < student.Scores[0]
    select student.Last + " " + student.First;

foreach (string s in studentQuery5)
{
  Console.WriteLine(s);
}


var studentQuery6 =
    from student in students
    let totalScore = student.Scores[0] + student.Scores[1] +
        student.Scores[2] + student.Scores[3]
    select totalScore;

double averageScore = studentQuery6.Average();
Console.WriteLine("Class average score = {0}", averageScore);


IEnumerable<string> studentQuery7 =
    from student in students
    where student.Last == "Garcia"
    select student.First;

Console.WriteLine("The Garcias in the class are:");
foreach (string s in studentQuery7)
{
  Console.WriteLine(s);
}

// Files
string startFolder = @"c:\ydl\";

// Take a snapshot of the file system.  
DirectoryInfo dir = new DirectoryInfo(startFolder);

// This method assumes that the application has discovery permissions  
// for all folders under the specified path.  
IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

//Create the query  
IEnumerable<FileInfo> fileQuery =
    from file in fileList
    where file.Extension == ".txt"
    orderby file.Name
    select file;

//Execute the query. This might write out a lot of files!  
foreach (FileInfo fi in fileQuery)
{
  Console.WriteLine(fi.FullName);
}

// Create and execute a new query by using the previous
// query as a starting point. fileQuery is not
// executed again until the call to Last()  
var newestFile =
    (from file in fileQuery
     orderby file.CreationTime
     select new { file.FullName, file.CreationTime })
    .Last();

Console.WriteLine("\r\nThe newest .txt file is {0}. Creation time: {1}",
    newestFile.FullName, newestFile.CreationTime);