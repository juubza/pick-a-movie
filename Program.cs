using RestSharp;
using Newtonsoft.Json.Linq;

Console.WriteLine("Provide a year: ");
var year = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Provide a title: ");
var title = Console.ReadLine();

var movie = new Movie(title!, year);
title = title!.Replace(" ", "+");

Console.WriteLine("\nFound the following results:");

var omdbApiUrl = $"http://www.omdbapi.com/?apikey={Constants.OMDB_API_KEY}&t={title}&y={year}&plot=full";
var options = new RestClientOptions(omdbApiUrl);
var client = new RestClient(options);
var request = new RestRequest(string.Empty);
request.AddHeader("accept", "application/json");
var response = await client.GetAsync(request);
dynamic json = JObject.Parse(response.Content!);
movie.AddSynopsis((string)json.Plot);

var tmdbIdApiUrl = $"https://api.themoviedb.org/3/search/movie?query={title}&include_adult=true&year={year}";
options = new RestClientOptions(tmdbIdApiUrl);
client = new RestClient(options);
request = new RestRequest(string.Empty);
request.AddHeader("accept", "application/json");
request.AddHeader("Authorization", "Bearer " + Constants.TMDB_ACCESS_TOKEN);
response = await client.GetAsync(request);
json = JObject.Parse(response.Content!);
var id = json.results[0].id;

var tmdbReviewsApiUrl = $"https://api.themoviedb.org/3/movie/{id}/reviews";
options = new RestClientOptions(tmdbReviewsApiUrl);
client = new RestClient(options);
request = new RestRequest(string.Empty);
request.AddHeader("accept", "application/json");
request.AddHeader("Authorization", "Bearer " + Constants.TMDB_ACCESS_TOKEN);
response = await client.GetAsync(request);
json = JObject.Parse(response.Content!);

foreach (dynamic data in json.results) {
    var review = new Review((string)data.author, (string)data.content, (DateTime)data.created_at);
    movie.AddReview(review);
}

movie.PrintJson();