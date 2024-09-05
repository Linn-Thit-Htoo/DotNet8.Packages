using Bogus;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

int no = 0;
Random random = new Random();
var template = new Faker<Staff>()
    .StrictMode(true)
    .RuleFor(o => o.Id, f => Guid.NewGuid().ToString())
    .RuleFor(
        o => o.No,
        f =>
        {
            no++;
            return $"S{no.ToString().PadLeft(6, '0')}";
        }
    )
    .RuleFor(o => o.Name, f => f.Name.FirstName() + " " + f.Name.LastName())
    .RuleFor(o => o.MobileNo, f => f.Phone.PhoneNumber())
    .RuleFor(
        o => o.DateOfBirth,
        f => f.Date.Between(DateTime.Now.AddYears(-30), DateTime.Now.AddYears(-20))
    )
    .RuleFor(
        o => o.Salary,
        f =>
        {
            int randomNumber = random.Next(1000000, 1000000000);
            var result =
                randomNumber.ToString().Substring(0, 1)
                + "0".PadLeft(randomNumber.ToString().Length - 1, '0');
            return Convert.ToDecimal(result);
        }
    )
    .RuleFor(o => o.Address, f => f.Address.FullAddress());

var staff = template.Generate(100);
Console.WriteLine(JsonConvert.SerializeObject(staff, Formatting.Indented));

Console.ReadLine();

public class Staff
{
    public string Id { get; set; }
    public string No { get; set; }
    public string Name { get; set; }
    public string MobileNo { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public string Address { get; set; }
}
