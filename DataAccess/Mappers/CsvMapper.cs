using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace DataAccess.Mappers
{
    public class CsvMapper : ICsvMapper
    {
        public async Task<Round> CsvToModelMapper(IFormFile file)
        {
            using (TextFieldParser parser = new TextFieldParser(file.OpenReadStream()))
            {
                var scoreDataList = new List<ScoreData>();
                var scoreDataLists = new List<string[]>();
                var courseInfo = new Course();

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Skip the header line
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    scoreDataLists.Add(fields);
                }

                foreach (var item in scoreDataLists)
                {
                    if (item == scoreDataLists[0])
                    {
                        string format = "yyyy-MM-dd HHmm";

                        courseInfo.CourseName = item[1];
                        courseInfo.LayoutName = item[2];
                        courseInfo.Date = DateTime.ParseExact(item[3], format, CultureInfo.InvariantCulture);
                        courseInfo.CoursePar = int.Parse(item[4]);
                        courseInfo.HolePars = item.Skip(6).Select(int.Parse).ToList();

                        continue;
                    }

                    ScoreData scoreData = new ScoreData
                    {
                        PlayerName = item[0],
                        Total = int.Parse(item[4]),
                        HoleScores = item.Skip(6).Select(int.Parse).ToList()
                    };


                    scoreData.PlusMinus = scoreData.Total - courseInfo.CoursePar;

                    scoreDataList.Add(scoreData);
                }

                var roundResults = new Round
                {
                    CourseInfo = courseInfo,
                    ScoreData = scoreDataList
                };

                //Next step er å legge dette inn i DB
                Console.WriteLine(roundResults);
                return roundResults;
            }
        }
    }
}