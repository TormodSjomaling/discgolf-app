using discgolf_app_dataaccess.Models;
using discgolf_app_dataaccess.Models.Dtos;
using Postgrest;
using System.Reflection;
using static Postgrest.QueryOptions;

namespace discgolf_app_dataaccess.DbContext
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly Supabase.Client _supabaseClient;

        public DatabaseConnection(Supabase.Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }
        
        public async Task<Round> PostRound(Round round)
        {
            
            var courseResponse = await _supabaseClient
              .From<CourseDto>()
              .Where(x => x.Layout == round.CourseInfo.LayoutName).Get();

            if (courseResponse.Models.Count == 0)
            {
                var x = new CourseDto
                {
                    Name = round.CourseInfo.CourseName,
                    Layout = round.CourseInfo.LayoutName
                };
                var result = await _supabaseClient.From<CourseDto>().Insert(x);

                var faen = new List<HoleDto>();
                var holeNumber = 1;

                foreach (var item in round.CourseInfo.HolePars)
                {
                    var dto = new HoleDto
                    {
                        CourseId = result.Model.CourseId,
                        HoleNumber = holeNumber,
                        Par = item
                    };
                    holeNumber += 1;

                    faen.Add(dto);
                }

                var holeResult = await _supabaseClient.From<HoleDto>().Insert(faen);

            };

            return null;
        }
    }
}
