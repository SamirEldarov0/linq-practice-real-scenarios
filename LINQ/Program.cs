using Practice;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

var people = new List<Person>
{
    new Person { Id = 1, FirstName = "Samir", LastName = "Eldarov", Age = 24, City = "Baku", Country = "Azerbaijan", Salary = 2200m, IsActive = true, CreatedAt = new DateTime(2024, 9, 12) },
    new Person { Id = 2, FirstName = "Aysel", LastName = "Aliyeva", Age = 22, City = "Baku", Country = "Azerbaijan", Salary = 1800m, IsActive = true, CreatedAt = new DateTime(2024, 11, 3) },
    new Person { Id = 3, FirstName = "Murad", LastName = "Huseynov", Age = 29, City = "Ganja", Country = "Azerbaijan", Salary = 1500m, IsActive = false, CreatedAt = new DateTime(2023, 6, 18) },
    new Person { Id = 4, FirstName = "Nigar", LastName = "Mammadova", Age = 31, City = "Sumqayit", Country = "Azerbaijan", Salary = 2600m, IsActive = true, CreatedAt = new DateTime(2025, 1, 20) },
    new Person { Id = 5, FirstName = "Elvin", LastName = "Rahimov", Age = 27, City = "Baku", Country = "Azerbaijan", Salary = 3100m, IsActive = true, CreatedAt = new DateTime(2024, 5, 9) },

    new Person { Id = 6, FirstName = "Leyla", LastName = "Karimova", Age = 19, City = "Baku", Country = "Azerbaijan", Salary = 900m, IsActive = true, CreatedAt = new DateTime(2024, 3, 15) },
    new Person { Id = 7, FirstName = "Farid", LastName = "Ismayilov", Age = 35, City = "Baku", Country = "Azerbaijan", Salary = 4200m, IsActive = false, CreatedAt = new DateTime(2022, 7, 2) },
    new Person { Id = 8, FirstName = "Gunel", LastName = "Tagiyeva", Age = 26, City = "Ganja", Country = "Azerbaijan", Salary = 1700m, IsActive = true, CreatedAt = new DateTime(2024, 8, 8) },
    new Person { Id = 9, FirstName = "Kamran", LastName = "Agayev", Age = 28, City = "Sumqayit", Country = "Azerbaijan", Salary = 2000m, IsActive = true, CreatedAt = new DateTime(2024, 12, 1) },
    new Person { Id = 10, FirstName = "Elnur", LastName = "Guliyev", Age = 23, City = "Baku", Country = "Azerbaijan", Salary = 2400m, IsActive = true, CreatedAt = new DateTime(2024, 10, 26) },

    new Person { Id = 11, FirstName = "Emil", LastName = "Hasanov", Age = 32, City = "Baku", Country = "Azerbaijan", Salary = 3600m, IsActive = true, CreatedAt = new DateTime(2023, 11, 7) },
    new Person { Id = 12, FirstName = "Rena", LastName = "Ibrahimova", Age = 25, City = "Sumqayit", Country = "Azerbaijan", Salary = 1300m, IsActive = false, CreatedAt = new DateTime(2024, 6, 25) },
    new Person { Id = 13, FirstName = "Orkhan", LastName = "Veliyev", Age = 21, City = "Baku", Country = "Azerbaijan", Salary = 1100m, IsActive = true, CreatedAt = new DateTime(2025, 2, 5) },
    new Person { Id = 14, FirstName = "Lala", LastName = "Shukurova", Age = 30, City = "Ganja", Country = "Azerbaijan", Salary = 2900m, IsActive = true, CreatedAt = new DateTime(2024, 7, 11) },
    new Person { Id = 15, FirstName = "Tural", LastName = "Aliyev", Age = 34, City = "Baku", Country = "Azerbaijan", Salary = 4100m, IsActive = false, CreatedAt = new DateTime(2023, 2, 14) },

    new Person { Id = 16, FirstName = "Amina", LastName = "Mustafayeva", Age = 20, City = "Baku", Country = "Azerbaijan", Salary = 1200m, IsActive = true, CreatedAt = new DateTime(2024, 4, 4) },
    new Person { Id = 17, FirstName = "Nurlan", LastName = "Sadiqov", Age = 27, City = "Ganja", Country = "Azerbaijan", Salary = 2100m, IsActive = true, CreatedAt = new DateTime(2024, 9, 30) },
    new Person { Id = 18, FirstName = "Sevda", LastName = "Babayewa", Age = 33, City = "Sumqayit", Country = "Azerbaijan", Salary = 3400m, IsActive = true, CreatedAt = new DateTime(2023, 12, 19) },
    new Person { Id = 19, FirstName = "Rashad", LastName = "Mammadov", Age = 24, City = "Baku", Country = "Azerbaijan", Salary = 1900m, IsActive = true, CreatedAt = new DateTime(2024, 5, 22) },
    new Person { Id = 20, FirstName = "Zahra", LastName = "Yusifova", Age = 28, City = "Baku", Country = "Azerbaijan", Salary = 2700m, IsActive = false, CreatedAt = new DateTime(2024, 1, 8) },

    new Person { Id = 21, FirstName = "Ali", LastName = "Hasanzade", Age = 26, City = "Istanbul", Country = "Turkey", Salary = 3200m, IsActive = true, CreatedAt = new DateTime(2024, 6, 1) },
    new Person { Id = 22, FirstName = "Elif", LastName = "Demir", Age = 23, City = "Ankara", Country = "Turkey", Salary = 2100m, IsActive = true, CreatedAt = new DateTime(2024, 8, 14) },
    new Person { Id = 23, FirstName = "Mehmet", LastName = "Yilmaz", Age = 29, City = "Istanbul", Country = "Turkey", Salary = 4000m, IsActive = false, CreatedAt = new DateTime(2023, 4, 27) },
    new Person { Id = 24, FirstName = "Zeynep", LastName = "Kaya", Age = 31, City = "Izmir", Country = "Turkey", Salary = 3500m, IsActive = true, CreatedAt = new DateTime(2025, 3, 10) },
    new Person { Id = 25, FirstName = "Can", LastName = "Arslan", Age = 27, City = "Bursa", Country = "Turkey", Salary = 2800m, IsActive = true, CreatedAt = new DateTime(2024, 2, 21) },

    new Person { Id = 26, FirstName = "Anna", LastName = "Ivanova", Age = 28, City = "Moscow", Country = "Russia", Salary = 4500m, IsActive = true, CreatedAt = new DateTime(2024, 9, 5) },
    new Person { Id = 27, FirstName = "Dmitry", LastName = "Petrov", Age = 34, City = "Saint Petersburg", Country = "Russia", Salary = 5200m, IsActive = false, CreatedAt = new DateTime(2023, 10, 16) },
    new Person { Id = 28, FirstName = "Olga", LastName = "Sidorova", Age = 24, City = "Kazan", Country = "Russia", Salary = 3300m, IsActive = true, CreatedAt = new DateTime(2024, 12, 22) },
    new Person { Id = 29, FirstName = "Sergey", LastName = "Volkov", Age = 30, City = "Moscow", Country = "Russia", Salary = 4800m, IsActive = true, CreatedAt = new DateTime(2024, 7, 7) },
    new Person { Id = 30, FirstName = "Irina", LastName = "Smirnova", Age = 22, City = "Novosibirsk", Country = "Russia", Salary = 2900m, IsActive = false, CreatedAt = new DateTime(2024, 3, 3) },

    new Person { Id = 31, FirstName = "John", LastName = "Smith", Age = 27, City = "London", Country = "UK", Salary = 5500m, IsActive = true, CreatedAt = new DateTime(2025, 1, 1) },
    new Person { Id = 32, FirstName = "Emily", LastName = "Brown", Age = 25, City = "Manchester", Country = "UK", Salary = 4800m, IsActive = true, CreatedAt = new DateTime(2024, 11, 19) },
    new Person { Id = 33, FirstName = "Daniel", LastName = "Wilson", Age = 33, City = "London", Country = "UK", Salary = 6200m, IsActive = false, CreatedAt = new DateTime(2023, 5, 6) },
    new Person { Id = 34, FirstName = "Sophia", LastName = "Taylor", Age = 29, City = "Liverpool", Country = "UK", Salary = 5100m, IsActive = true, CreatedAt = new DateTime(2024, 10, 9) },
    new Person { Id = 35, FirstName = "James", LastName = "Johnson", Age = 31, City = "Birmingham", Country = "UK", Salary = 4700m, IsActive = true, CreatedAt = new DateTime(2024, 6, 30) },

    new Person { Id = 36, FirstName = "Lucas", LastName = "Martin", Age = 26, City = "Berlin", Country = "Germany", Salary = 5300m, IsActive = true, CreatedAt = new DateTime(2024, 9, 18) },
    new Person { Id = 37, FirstName = "Mia", LastName = "Schmidt", Age = 24, City = "Munich", Country = "Germany", Salary = 4900m, IsActive = true, CreatedAt = new DateTime(2024, 8, 29) },
    new Person { Id = 38, FirstName = "Noah", LastName = "Fischer", Age = 30, City = "Hamburg", Country = "Germany", Salary = 5700m, IsActive = false, CreatedAt = new DateTime(2023, 9, 9) },
    new Person { Id = 39, FirstName = "Lina", LastName = "Weber", Age = 28, City = "Berlin", Country = "Germany", Salary = 5100m, IsActive = true, CreatedAt = new DateTime(2025, 2, 20) },
    new Person { Id = 40, FirstName = "Finn", LastName = "Keller", Age = 32, City = "Cologne", Country = "Germany", Salary = 4600m, IsActive = false, CreatedAt = new DateTime(2024, 4, 12) },

    new Person { Id = 41, FirstName = "Sara", LastName = "Garcia", Age = 23, City = "Madrid", Country = "Spain", Salary = 3200m, IsActive = true, CreatedAt = new DateTime(2024, 7, 23) },
    new Person { Id = 42, FirstName = "Miguel", LastName = "Lopez", Age = 27, City = "Barcelona", Country = "Spain", Salary = 4100m, IsActive = true, CreatedAt = new DateTime(2024, 9, 1) },
    new Person { Id = 43, FirstName = "Lucia", LastName = "Sanchez", Age = 31, City = "Valencia", Country = "Spain", Salary = 3900m, IsActive = false, CreatedAt = new DateTime(2023, 8, 17) },
    new Person { Id = 44, FirstName = "Carlos", LastName = "Ruiz", Age = 29, City = "Seville", Country = "Spain", Salary = 3600m, IsActive = true, CreatedAt = new DateTime(2025, 1, 15) },
    new Person { Id = 45, FirstName = "Elena", LastName = "Torres", Age = 25, City = "Madrid", Country = "Spain", Salary = 3000m, IsActive = true, CreatedAt = new DateTime(2024, 2, 9) },

    new Person { Id = 46, FirstName = "Omar", LastName = "Hassan", Age = 28, City = "Dubai", Country = "UAE", Salary = 8000m, IsActive = true, CreatedAt = new DateTime(2024, 12, 31) },
    new Person { Id = 47, FirstName = "Fatima", LastName = "Al Maktoum", Age = 24, City = "Abu Dhabi", Country = "UAE", Salary = 7500m, IsActive = false, CreatedAt = new DateTime(2024, 5, 5) },
    new Person { Id = 48, FirstName = "Ethan", LastName = "Walker", Age = 30, City = "New York", Country = "USA", Salary = 9000m, IsActive = true, CreatedAt = new DateTime(2025, 3, 25) },
    new Person { Id = 49, FirstName = "Olivia", LastName = "Davis", Age = 26, City = "Los Angeles", Country = "USA", Salary = 8500m, IsActive = true, CreatedAt = new DateTime(2024, 10, 2) },
    new Person { Id = 50, FirstName = "Liam", LastName = "Miller", Age = 33, City = "Chicago", Country = "USA", Salary = 7800m, IsActive = false, CreatedAt = new DateTime(2023, 3, 1) }
};

var activepeople = people.Where(x => x.IsActive).OrderBy(x=>x.Salary).ToList();

var fullnames = people.Where(x => x.Age >= 30).Select(x => $"{x.FirstName} {x.LastName}").ToList();

var p = people.Where(x => !x.IsActive).Count();

var p1 = people.Any(x => x.Salary > 8000);
var p2 = people.Where(x=>x.IsActive).All(x => x.Age > 18);

var p3 = people.Where(x => x.IsActive).OrderByDescending(x => x.Salary).Take(5).ToList();

var p4 = people.GroupBy(x => x.Country).Select(x => (Country: x.Key, AvgSalary: x.Average(s => s.Salary)))
    .OrderByDescending(x => x.AvgSalary).ToList();

var p5 = people.Where(x => x.CreatedAt.Year == 2024).ToList();

var p6 = people.Where(x => x.IsActive).OrderByDescending(x => x.Salary).Take(5).ToList();

var p7 = people.GroupBy(x => x.Country).Select(x =>
(
Country: x.Key,
AvgSalary: x.Average(s => s.Salary)
)).OrderByDescending(x => x.AvgSalary).ToList();

var p8 = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x => (City: x.Key, Count: x.Count())).ToList();
var p9 = people.Where(x => x.IsActive).GroupBy(x => x.City).ToDictionary(y => y.Key, y => y.Count());

var p10 = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x => (
    City: x.Key,
    ActiveCount: x.Count()
)).OrderByDescending(x => x.ActiveCount).FirstOrDefault();//Take  or single

var p11 = people.GroupBy(x => x.Country).OrderBy(x => x.Max(y => y.Salary)).ToList();

var p12 = people.GroupBy(x => x.Country).Select(x => x.MaxBy(y => y.Salary)).ToList();
var p13 = people.GroupBy(x => x.Country).Select(x => x.OrderBy(y => y.Salary).First()).ToList();

var p144 = people.Where(x => x.CreatedAt.AddDays(90) >= DateTime.Now).OrderByDescending(x => x.CreatedAt).ToList();
var p14 = people
    .Where(x => x.CreatedAt >= DateTime.UtcNow.AddDays(-90))
    .OrderByDescending(x => x.CreatedAt)
    .ToList();
//var p15=people.GroupBy(x=>x.)
var p15 = people.GroupBy(x => x.Country).Select(x => (
    Country: x.Key,
    Count: x.Count()
)).Where(y => y.Count >= 5).OrderByDescending(y => y.Count).ToList();

var p16 = people.GroupBy(x => x.Country).Select(x => (
    Country: x.Key,
    TotalCount: x.Count(),
    ActiveCount: x.Where(y => y.IsActive).Count()
)).ToList();

var p17 = people.GroupBy(x => x.Country).Select(x =>
{
    int total = x.Count();
    int activeCount = x.Where(y => y.IsActive).Count();
    decimal activePercentage = total == 0 ? 0 : (decimal)(activeCount * 100) / total;

    return (
        Country: x.Key,
        TotalCount: total,
        ActiveCount: activeCount,
        ActivePecentage: activePercentage
    );
}).ToList();

var p18 = people.GroupBy(x => x.Country).Select(x => (
    Country:x.Key,
    TotalCount:x.Count(),
    ActiveCount:x.Where(x=>x.IsActive).Count(),
    ActivePecentage:(decimal)(x.Where(x => x.IsActive).Count())//yarimciq
)).ToList();

var p19 = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x => (
    City: x.Key,
    TotalSalary: x.Sum(y => y.Salary)
)).OrderByDescending(x => x.TotalSalary).ToList();

var p20 = people.GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var AvgSalary= x.Average(y => y.Salary);

    return (City, AvgSalary);
}).MaxBy(x=>x.AvgSalary);

var p21 = people.GroupBy(x => x.City).Select(x => x.MaxBy(y => y.CreatedAt)).ToList();

var p22 = people.GroupBy(x => x.City).Select(x => x.OrderByDescending(x => x.CreatedAt).FirstOrDefault()).ToList();
var p23 = people.OrderBy(x => x.Country).OrderBy(x => x.City).OrderBy(x => x.LastName).Skip(7).Take(7).ToList();
int pageNumber = 2, pageSize = 7;
var p24 = people.OrderBy(x => x.Country).ThenBy(x => x.City).ThenBy(x => x.LastName).Skip((pageNumber - 1) * 7).Take(pageSize).ToList();

//var p25=people.Where(x=>x.FirstName.ToLower().Contains("ba"))

var p26 = people.GroupBy(x => x.Country).Select(x => (
    Country: x.Key,
    Top3:x.OrderByDescending(y=>y.Salary).Take(3).ToList()
)).ToList();

var p27 = people.GroupBy(x => x.CreatedAt.Year).Select(x =>
{
    var year = x.Key;
    var count = x.Count();
    return (year, count);
}).OrderBy(x=>x.year).ToList();

var p28 = people.Where(x => x.IsActive&&x.Age>=18).Select(x =>
{
    var Score=(x.Salary*7)/10+ x.Age*30;
    var Person = x;
    return (Person, Score);
}).OrderByDescending(x=>x.Score).ToList();

var p29 = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var Person = x.Where(x=>x.IsActive).OrderByDescending(x=>x.Age).FirstOrDefault();
    return (City, Person);
}).ToList();

var p30 = people.Where(x => x.IsActive).GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var TotalSalary = x.Sum(y => y.Salary);
    return (Country, TotalSalary);
}).OrderByDescending(x => x.TotalSalary).Take(2).ToList();

var thread = new Thread(() =>
{
    while (true)
    {
        Thread.Sleep(1000);
    }
});

thread.IsBackground = true;
thread.Start();

//26) Oldest active person per city For each City, return the oldest active person.
var p31 = people.Where(x => x.IsActive).GroupBy(x=>x.City).Select(x =>
{
    var City = x.Key;
    var OldestPerson=x.OrderByDescending(y=>y.Age).FirstOrDefault();

    return (City, OldestPerson);
}).ToList();

//27) Top 2 countries by total salary (active only) Find the top 2 countries with the highest sum of Salary among active people.
//List<(string Country, decimal TotalSalary)>

var p32 = people.Where(x => x.IsActive).GroupBy(x => x.Country).Select(x => (
    Country: x.Key,
    TotalSalary: x.Sum(x=>x.Salary)
)).OrderByDescending(x=>x.TotalSalary).Take(2).ToList();

//28) Median salary per country   Compute median salary per country.  (If even count → average of two middle salaries.) List<(string Country, decimal MedianSalary)>
var p33 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country= x.Key;
    var Salaries = x.Select(y => y.Salary).OrderBy(y => y).ToList();
    decimal MedianSalary;
    int count = Salaries.Count;
    if (count % 2 == 0)
    {
        MedianSalary=(Salaries[count / 2 - 1] + Salaries[count / 2]) / 2;
    }
    else
    {
        MedianSalary = Salaries[count / 2];
    }
    return (Country, MedianSalary);

}).ToList();

//29) People who earn above their country average Return all people whose salary is above the average salary of their country. List<Person>

var p34 = people.GroupBy(x => x.Country).SelectMany(x =>
{
    var AvgSalary = x.Average(y => y.Salary);
    return x.Where(y => y.Salary > AvgSalary);
}).ToList();

//30) City diversity per country

//For each country return the number of distinct cities it has people in. List<(string Country, int CityCount)>

var p35 = people.GroupBy(x => x.Country).Select(x =>
{
    //kkk
    var Country = x.Key;
    var CityCount = x.Select(x => x.City).Distinct().Count();
    return (Country, CityCount);
}).ToList();

var p36 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Person = x.MinBy(y=>y.Age);
    var Persen2=x.OrderByDescending(y=>y.Age).FirstOrDefault();
    return (Country, Person);
}).ToList();


//31) First created active person per country

//For each country find the first CreatedAt among active persons (earliest signup).

//✅ Output:

//List<(string Country, Person? Person)>

var p37 = people.Where(x => x.IsActive).GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Person = x.OrderBy(x => x.CreatedAt).FirstOrDefault();
    var persen2 = x.MinBy(y => y.CreatedAt);

    return (Country, Person);
}).ToList();
//88

//32) Active streak check -- Return people whose CreatedAt is within last 365 days AND IsActive == true. List<Person>  Sort by CreatedAt desc.

var p38 = people.Where(x=>x.IsActive && x.CreatedAt >= DateTime.UtcNow.AddDays(-365)).OrderByDescending(x=>x.CreatedAt).ToList();

//34) Salary rank inside country

//For each country, return people with their rank by salary (1 = highest).
//(No need to handle ties specially, just rank by order)

var p399 = people.GroupBy(x => x.Country).SelectMany(x =>
{
    var Country = x.Key;
    var RankedPeople = x.OrderByDescending(y => y.Salary).Select((y, index) =>
    {
        var Person = y;
        var Rank = index + 1;
        return (Country, Person, Rank);
    });
    return RankedPeople;
}).ToList();
//33) Average age per city -- Compute average age of people per city. List<(string City, double AvgAge)>

var p39 = people.GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var AvgAge = x.Average(y => y.Age);
    return (City, AvgAge);
}).ToList();


var p40 = people.Select(x =>
{
    var FullName=$"{x.FirstName}.{x.LastName}";
    return (FullName, x.Id);
}).ToDictionary();

//11) “Second highest salary” per country

//For each country, find the second highest salary person (ignore ties? no → include correct second distinct salary).
//List<(string Country, Person? Person)>
//If a country has fewer than 2 people → Person = null.

//33) Average age per city -- Compute average age of people per city. List<(string City, double AvgAge)>

var p4g0 = people.Select(x =>
{
    var FullName = $"{x.FirstName}.{x.LastName}";
    return (FullName, x.Id);
}).ToDictionary();

var p41 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var SecondHighstSalaryPerson=x.Select(y=>y.Salary).Distinct().OrderByDescending(y => y).Skip(1).FirstOrDefault();
    var Person = x.FirstOrDefault(y => y.Salary == SecondHighstSalaryPerson);
}).ToList();

//12) Normalize + search

//Return people whose FirstName + " " + LastName contains "an" (case-insensitive). List<Person>

//Example: "Daniel Wilson", "Anna Ivanova" etc.
var p42 = people.Where(x => (x.FirstName.ToLower() + " " + x.LastName.ToLower()).Contains("an")).ToList();
//13) Salary buckets

//Group people into buckets:

//"Low" if Salary < 2000

//"Mid" if Salary between 2000 and 5000 (inclusive)

//"High" if Salary > 5000

//Return counts in each bucket.

//Dictionary<string, int>

var p4112 = people.Where(x => (x.FirstName.ToLower() + " " + x.LastName.ToLower()).Contains("an")).ToList();
//sss

//var p43 = people.GroupBy(x=>x.CreatedAt.Year).Select(x =>
//{
//    var Year = x.Key;
//    int Total = x.Count();
//    int Active = x.Where(x => x.IsActive).Count();
//    int Growth = Total-x.Where(x=>x.CreatedAt.Year).Count();
//}).ToList();

//36) Yearly growth

//For each year (CreatedAt.Year), return: total people active people growth compared to previous year
//List<(int Year, int Total, int Active, int? Growth)>
//Growth = Total - previousYearTotal

var p44 = people.GroupBy(x => x.CreatedAt.Year).Select(x =>
{
    var Year = x.Key;
    int Total = x.Count();
    int Active = x.Where(x => x.IsActive).Count();
    return (Year, Total, Active);
}).OrderBy(x=>x.Year).ToList();


//52) Stable countries

//Countries where salary variance is below a threshold.
//List<string>

var p45 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Salaries = x.Select(y => y.Salary).ToList();
    var AvgSalary = Salaries.Average();
    var Variance = Salaries.Average(y => (y - AvgSalary) * (y - AvgSalary));
    return (Country, Variance);
}).Where(x => x.Variance < 1000000).Select(x => x.Country).ToList();

//43) Young high earners

//Find people:

//Age<country average age

//Salary> country average salary

//✅ Output: List<Person>

var p46 = people.GroupBy(x => x.Country).SelectMany(x =>
{
    var AvgAge = x.Average(y => y.Age);
    var AvgSalary = x.Average(y => y.Salary);
    return x.Where(y => y.Age < AvgAge && y.Salary > AvgSalary);
}).ToList();

//41) People with same last name across countries

//Find last names that appear in more than one country.

//List<(string LastName, List<string> Countries)>

var p47 = people.GroupBy(x => x.LastName).Select(x =>
{
    var LastName = x.Key;
    var Countries = x.Select(x => x.Country).Distinct().ToList();
    return (LastName, Countries);
}).Where(x => x.Countries.Count() > 1).ToList();

//44) Monthly signup heatmap

//Return count of people grouped by:
//Year

//Month
//List<(int Year, int Month, int Count)>
var p48 = people.GroupBy(x => new { x.CreatedAt.Year, x.CreatedAt.Month }).Select(x =>
{
    var Year = x.Key.Year;
    var Month = x.Key.Month;
    var Count = x.Count();
    return (Year, Month, Count);
}).ToList();

//45) Salary gap per city

//For each city calculate:

//max salary – min salary

//List<(string City, decimal Gap)>

var p49 = people.GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var Gap = x.Max(y => y.Salary) - x.Min(y => y.Salary);

    return (City, Gap);
}).ToList();

//46) Active consistency

//Find countries where active rate >= 70%.

//✅ Output:

//List<string>

var p50 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var ActiveCountryCount = x.Where(x => x.IsActive).Count();
    var TotalCountryCount = x.Count();
    var ActiveRate = ActiveCountryCount * 100 / TotalCountryCount;
    return (Country, ActiveRate);
}).Where(x => x.ActiveRate >= 70).Select(x => x.Country).ToList();

//48) Name similarity

//Find people whose FirstName starts with same 3 letters and are in the same country.
//List<List<Person>>

var p51 = people
    .Where(p => p.FirstName.Length >= 3)
    .GroupBy(p => new
    {
        Prefix = p.FirstName.Substring(0, 3),
        p.Country
    })
    .Where(g => g.Count() > 1)
    .Select(g => g.ToList())
    .ToList();

//49) Salary ladder

//For each country, return people ordered by salary and mark:

//IsPromotionCandidate if next person earns ≥ 20% more.

//List<(Person Person, bool IsPromotionCandidate)>

var p49 = people
    .GroupBy(p => p.Country)
    .SelectMany(g =>
    {
        var ordered = g.OrderBy(p => p.Salary).ToList();

        return ordered.Select((person, index) =>
        {
            bool isPromotionCandidate =
                index < ordered.Count - 1 &&
                ordered[index + 1].Salary >= person.Salary * 1.2m;

            return (person, isPromotionCandidate);
        });
    })
    .ToList();


//26) Oldest active person per city

//For each City, return the oldest active person.
//List<(string City, Person? Person)>
//00

//If a city has no active people → Person = null.

var p52 = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var Person = x.MaxBy(x => x.Age);
    var Person2 = x.OrderByDescending(x => x.Age).FirstOrDefault();
    return (City, Person);
}).ToList();
//28) Median salary per country

//Compute median salary per country.
//(If even count → average of two middle salaries.)
//List<(string Country, decimal MedianSalary)>

//27) Top 2 countries by total salary (active only)

//Find the top 2 countries with the highest sum of Salary among active people.

//✅ Output:

//List<(string Country, decimal TotalSalary)>
var p53 = people.Where(x => x.IsActive).GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var TotalSalary = x.Sum(y => y.Salary);
    return (Country, TotalSalary);
}).OrderByDescending(x => x.TotalSalary).Take(2).ToList();

var p54 = people.GroupBy(x => x.Country).SelectMany(x =>
{
    var AvgSalary = x.Average(x => x.Salary);
    var people = x.Where(x => x.Salary > AvgSalary);
    return people;
}).ToList();

//30) City diversity per country

//For each country return the number of distinct cities it has people in.

//List<(string Country, int CityCount)>

var p55 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var CityCount = x.Select(x => x.City).Distinct().Count();
    return (Country, CityCount);
}).ToList();
//31) First created active person per country

//For each country find the first CreatedAt among active persons (earliest signup).
//List<(string Country, Person? Person)>

var p56 = people.Where(x => x.IsActive).GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Person = x.OrderBy(x => x.CreatedAt).FirstOrDefault();
    return (Country, Person);
}).ToList();

//32) Active streak check

//Return people whose CreatedAt is within last 365 days AND IsActive == true.
//Sort by CreatedAt desc.

var p57 = people.Where(x => x.IsActive && x.CreatedAt >= DateTime.UtcNow.AddDays(-365)).OrderByDescending(x => x.CreatedAt).ToList();


var fullNames = people.Where(x => x.IsActive && (x.Age > 18 && x.Age < 30) && x.City == "Baku").OrderBy(x => x.Age).ThenByDescending(x => x.Salary).Select(x =>
{
    var FullName = $"{x.FirstName} {x.LastName}";
    return FullName;
}).ToList();

var averageSalary = people.Any(x => !x.IsActive) ? 0 : people.Where(x => x.IsActive && x.Country == "Azerbaijan").Average(x => x.Salary);

var ppp = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x =>
{
    var City=x.Key;
    var ActiveCount = x.Count();
    return (City, ActiveCount);
}).OrderByDescending(x=>x.ActiveCount).Take(3).ToList();

var dict = people.Where(x => x.IsActive && x.Salary > 2000).Select(x =>
{
    var Key = x.Id;
    var Value = $"{x.FirstName} {x.LastName}";
    return (Key, Value);
}).ToDictionary();

var mrpg = people.GroupBy(x => x.Country).Select(x =>
{
    var Person = x.MaxBy(y => y.CreatedAt);
    return Person;
}).ToList();

var mrpg2=people.GroupBy(x => x.Country).Select(x =>
{
    var Person = x.OrderByDescending(y => y.CreatedAt).FirstOrDefault();
    return Person;
}).ToList();

var b1=people.Any(x=>x.Salary>=8000);
var b2=people.Where(x=>x.IsActive).All(x=>x.Age>18);

var p111 = people.Where(x => x.IsActive).GroupBy(x=>x.City).Select(x =>
{
    var City = x.Key;
    var Count = x.Count();
    return (City, Count);
}).MaxBy(x=>x.Count);


var p112 = people.GroupBy(x => x.Country).Select(x =>
{
    var Person1 = x.OrderByDescending(y => y.Salary).FirstOrDefault();
    var Person = x.MaxBy(y => y.Salary);
    return Person;
}).ToList();
var thp5=people.Where(x=>x.IsActive).OrderByDescending(x=>x.Salary).Take(5).ToList();
var averageSalaryPercountry = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var AvgSalary = x.Average(y => y.Salary);
    return (Country, AvgSalary);
}).OrderBy(x => x.AvgSalary).ToList();

var p58 = people.Where(x => x.CreatedAt >= DateTime.UtcNow.AddDays(-90)).OrderByDescending(x => x.CreatedAt).ToList();

var p113 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Person = x.Select(x => x.Salary).Distinct().Count() < 2 ? null : x.OrderByDescending(y => y.Salary).Skip(1).FirstOrDefault();
    return (Country, Person);
}).ToList();

//15) Complex filter

//Return full names of people who:

//Active

//Age between 20–30

//Country is Azerbaijan / Turkey / Germany

//Salary > 2000
//Sort by:

//Country ascending

//City ascending

//Salary descending

//✅ Output: List<string>

var p113w = people
    .GroupBy(x => x.Country)
    .Select(g =>
    {
        var country = g.Key;

        var person = g
            .GroupBy(p => p.Salary)
            .OrderByDescending(sg => sg.Key)
            .Skip(1)
            .SelectMany(sg => sg)
            .FirstOrDefault();

        return (country, person);
    })
    .ToList();

var p114 = people.Where(x => (x.FirstName + " " + x.LastName).ToLower().Contains("an")).ToList();
var p115 = people.GroupBy(x => x.Salary < 2000 ? "Low" : x.Salary <= 5000 ? "Mid" : "High").Select(x =>
{
    var Bucket = x.Key;
    var Count = x.Count();
    return (Bucket, Count);
}).ToDictionary(x => x.Bucket, x => x.Count);


var p117 = people.GroupBy(x => new { x.FirstName, x.LastName }).Select(x =>
{
    var FullName = x.Key;
    var Count = x.Count();
    return (FullName, Count);
}).Where(x => x.Count > 1).ToList();

var p118 = people.GroupBy(x => x.Salary < 2000 ? "Low" : x.Salary <= 5000 ? "Mid" : "High").Select(x =>
{
    var Bucket = x.Key;
    var pep = x.ToList();
    return (Bucket, pep);
}).ToDictionary();

var p119 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Count = x.Count();
    return (Country, Count);
}).Where(x => x.Count >= 5).OrderByDescending(x => x.Count).ToList();

var p1192 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Total = x.Count();
    var Active = x.Where(x => x.IsActive).Count();
    var ActivePercentage = Active * 100 / Total;

    return (Country, Total, Active, ActivePercentage);
}).ToList();

var p120 = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var TotalSalary = x.Sum(x => x.Salary);
    return (City, TotalSalary);
}).OrderByDescending(x => x.TotalSalary).ToList();

var p121 = people.GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var AvgSalary = x.Average(y => y.Salary);
    return (City, AvgSalary);
}).OrderByDescending(x => x.AvgSalary).Take(1).FirstOrDefault();//or MaxBy

var p122 = people.GroupBy(x => x.City).Select(x =>
{
    //var City = x.Key;
    var Person = x.MaxBy(x => x.CreatedAt);
    var Person2 = x.OrderBy(x => x.CreatedAt).FirstOrDefault();
    return Person;
}).ToList();

//var p123 = people.GroupBy(x => x.City).OrderByDescending(x=>).ToList();

int pageSize1 = 7, pageNumber1 = 2;

var p123 = people.OrderBy(x => x.Country).ThenBy(x => x.City).ThenBy(x => x.LastName).Skip((pageNumber1 - 1) * pageNumber1).Take(pageNumber1).ToList();

var p124 = people.Where(x => x.FirstName.ToLower().Contains("ba") || x.LastName.ToLower().Contains("ba") || x.City.ToLower().Contains("ba")).ToList();

var p125 = people.GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var Top3 = x.OrderByDescending(x => x.Salary).Take(3).ToList();
    return (Country, Top3);
}).ToList();

var p126 = people.GroupBy(x => x.CreatedAt.Year).Select(x =>
{
    var Year = x.Key;
    var Count = x.Count();
    return (Year, Count);
}).OrderBy(x => x.Year).ToList();

var p127 = people.Where(x => x.IsActive && x.Age >= 18).Select(x =>
{
    var Person = x;
    var Score = (x.Salary * 7) / 10 + x.Age * 10;
    return (Person, Score);
}).OrderBy(x => x.Score).ToList();

var p129 = people.Where(x => x.IsActive).GroupBy(x => x.City).Select(x =>
{
    var City = x.Key;
    var Person = x.OrderByDescending(x => x.Age).FirstOrDefault();
    return (City, Person);
}).ToList();

var p128 = people.Where(x => x.IsActive).GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var TotalSalary = x.Sum(y => y.Salary);
    return (Country, TotalSalary);
}).OrderByDescending(x=>x.TotalSalary).Take(2).ToList();

var p130 = people.GroupBy(x => x.Country).Select(x =>   //2,4,6,8
{
    var Country = x.Key;
    var Salaries = x.Select(y => y.Salary).OrderBy(y => y).ToList();
    var Count = x.Count();
    var MedianSalary = (Count % 2 == 0) ? (Salaries[(Count / 2) - 1] + Salaries[Count / 2]) / 2 : Salaries[Count / 2];

    return (Country, MedianSalary);
}).ToList();

var p131 = people.GroupBy(x => x.Country).SelectMany(x =>
{
    var AvgSalary = x.Average(y => y.Salary);
    var pep = x.Where(y => y.Salary > AvgSalary);
    return pep;
}).ToList();

var p132 = people.GroupBy(x => x.Country).Select(x =>
{
    //Azerbaijan - Baku, Oghuz, Gabala, Gabala
    var CityCount = x.Select(y => y.City).Distinct().Count();
    return (Country: x.Key, CityCount);
}).ToList();

var p133 = people.Where(x => x.IsActive).GroupBy(x => x.Country).Select(x =>
{
    var Country = x.Key;
    var FirstCreatedPerson = x.MinBy(y => y.CreatedAt);
    var F = x.OrderBy(x => x.CreatedAt).FirstOrDefault();
    return (Country, FirstCreatedPerson);
}).ToList();

var p134 = people.Where(x => x.IsActive && x.CreatedAt >= DateTime.UtcNow.AddDays(-90)).OrderByDescending(x => x.CreatedAt).ToList();

var p135 = people.GroupBy(x => x.Country).SelectMany(x =>
{
    var pep = x.OrderByDescending(y => y.Salary);
    return pep;
}).Select((t, index) =>
{
    return (t.Country, t, index + 1);
}).ToList();

var rrr = people.DistinctBy(x=>x.Salary).Select(x =>
{
    var Key = $"{x.FirstName}.{x.LastName}".ToLower();
    var Value = x.Id;
    return (Key, Value);
}).ToList();