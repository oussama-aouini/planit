using Microsoft.AspNetCore.Mvc;
using planit.Models;
using planit.Models.Dto;

namespace planit.Controllers
{
    [Route("api/v1/places")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PlaceDTO> GetPlaces()
        {
            return new List<PlaceDTO>
            {
                new PlaceDTO{Id=1, Name="Gormet", Category="food"},
                new PlaceDTO{Id=2, Name="Najib kharrat", Category="Health"}
            };
        }
    }
}
