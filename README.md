# Pick a movie

This project was created as a simple college work for extra credits. It is intended to be a console app that does external API calls and fetch movie data according to the user's entry.

The application asks the user for a year and a title, and returns the movie's year, title, synopsis and reviews in the following json schema:
```
{
  "year": int,
  "title": string,
  "synopsis": string,
  "reviews": [
    {
      "author": string,
      "content": string,
      "publishedAt": datetime
    }
  ]
}
```

To run, simply copy and paste the command below in your terminal.
```dotnet run```