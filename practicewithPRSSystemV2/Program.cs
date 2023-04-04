using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicewithPRSSystemV2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PRSV2DbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("PRSDbContext"));
});
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();


//find the longest streak in a pattern
//input: 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20, 20, 20, 20
//output: 4
List<string> excersize = new List<string>();
excersize = Console.ReadLine();
int count = 0;
int max = 0;
for (int i = 0; i < excersize.Count; i++)
{
    if (excersize[i] == excersize[i + 1])
    {
        count++;
    }
    else
    {
        if (count > max)
        {
            max = count;
        }
        count = 0;
    }
}
class Solution
{
    static void Main(string[] args)
    {
        List<string> excersizes = new List<string>;
        excersizes = Console.ReadLine();
        string Y;
        string N;
        foreach (excersize in excersizes)
        {
            if (excersize.Equals(excersize++))
            {
                Y++;
            }
            else N++;
        }

    }
}




class Solution
{
    static void Main(string[] args)
    {

        List<int> list = new List<int>();
        List<int> list2 = new List<int>();
        list = Console.ReadLine();
        list2 = Console.ReadLine();
        Console.WriteLine(list);
        Console.WriteLine(list2);

    }

    private static async Task<IActionResult> FindMatches(int list, int list2)
    {
        var matches = await Solution.Equals(object list, object list2)
                matches = (from list, list2
                           
                       });
    }
}
