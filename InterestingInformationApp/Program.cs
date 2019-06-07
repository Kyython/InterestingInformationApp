using InterestingInformationApp.MusicInformationApp;
using InterestingInformationApp.YearFactApi;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using unirest_net.http;

namespace InterestingInformationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter any year - ");
            string year = CheckString(Console.ReadLine());
            string jsonYearFactInformation = GetYearFact(year).Result;

            var yearFactInformation = JsonConvert.DeserializeObject<YearFact>(jsonYearFactInformation);

            Console.WriteLine($"\nThe fact of the {year} year - " + yearFactInformation.Text);

            Console.WriteLine("__________________________________________________");

            Console.Write("\nEnter the name of the artist(group) or music and album name - ");
            string jsonMusicInformation = GetArtistInformationByName(Console.ReadLine()).Result;

            var musicInformation = JsonConvert.DeserializeObject<MusicInformation>(jsonMusicInformation);

            foreach (var information in musicInformation.Data)
            {
                Console.WriteLine("Artist(Group) - " + information.Artist.Name);
                Console.WriteLine("Album name -  " + information.Album.Title);
                Console.WriteLine("Music name - " + information.Title);
                Console.WriteLine("Duration - " + SecondConverter(information.Duration));
                Console.WriteLine("Deezer music rank - " + information.Rank);
                Console.WriteLine("_________________________________________\n");
            }

            if (musicInformation.Data.Count == 0)
            {
                Console.WriteLine("\nAt your request, nothing found!!!");
                Console.WriteLine("Please press enter");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Please press enter");
            Console.ReadLine();
        }

        static Task<string> GetArtistInformationByName(string authorName)
        {
            HttpResponse<string> response = Unirest.get($"https://deezerdevs-deezer.p.rapidapi.com/search?q={authorName}")
            .header("X-RapidAPI-Key", "37bc8b8080msh458791eb3ab32c9p1775cbjsn11c7e725e180").asString();

            return Task.FromResult(response.Body);
        }

        static Task<string> GetYearFact(string year)
        {
            HttpResponse<string> response = Unirest.get($"https://numbersapi.p.rapidapi.com/{year}/year?fragment=true&json=true")
            .header("X-RapidAPI-Key", "37bc8b8080msh458791eb3ab32c9p1775cbjsn11c7e725e180").asString();

            return Task.FromResult(response.Body);
        }

        static string SecondConverter(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string convertTime = time.ToString(@"mm\:ss");

            return convertTime;
        }

        static string CheckString(string userString)
        {
            bool isNum = int.TryParse(userString, out int number);

            if (isNum)
            {
                return userString;
            }
            else
            {
                return "0";
            }
        }
    }
}
