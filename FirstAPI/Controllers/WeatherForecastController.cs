using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static List<Student> students = new List<Student>();
      
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("GetStudents")]
        public IEnumerable<Student> GetStudents()
        {
            return students;
        }
        [HttpPost("SaveStudents")]
        public IEnumerable<Student> SaveStudents(Student student)
        {
            students.Add(student);
            return students;
        }
        [HttpDelete("DeleteStudents")]
        public IEnumerable<Student> DeleteStudents(int id)
        {
            students.RemoveAll(a => a.Id == id);
            return students;
        }
    }
}
