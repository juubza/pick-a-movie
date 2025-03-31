using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;

public class Movie {
    public int Year { get; private set; }
    public string Title { get; private set; }
    public string? Synopsis { get; private set; } = null;
    public List<Review> Reviews {get; private set; } = new();

    public Movie(string title, int year) {
        var cultInfo = new CultureInfo("en-US", false).TextInfo;
        Title = cultInfo.ToTitleCase(title);
        Year = year;
    }

    public void AddSynopsis(string synopsis) => Synopsis = synopsis;

    public void AddReview(Review review) => Reviews.Add(review);

    public void PrintJson() {
        var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var json = JsonConvert.SerializeObject(this, Formatting.Indented, settings);
        Console.WriteLine(json);
    }
}