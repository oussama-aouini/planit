using Microsoft.AspNetCore.Mvc;
using planit.Data;
using planit.Models;
using planit.Models.Dto;

namespace planit.Controllers
{
    [Route("api/v1/places")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PlaceDTO>> GetPlaces()
        {
            return Ok(PlaceStore.placeList);
        }

        [HttpGet("{id:int}", Name="GetPlace")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlaceDTO> GetPlace(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var place = PlaceStore.placeList.FirstOrDefault(u => u.Id == id);
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlaceDTO> CreatePlace([FromBody]PlaceDTO placeDTO)
        {
            if (PlaceStore.placeList.FirstOrDefault(u => u.Name.ToLower() == placeDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "The place already exists");
                return BadRequest(ModelState);
            }
            if (placeDTO == null)
            {
                return BadRequest(placeDTO);
            }
            if (placeDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            placeDTO.Id = PlaceStore.placeList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            PlaceStore.placeList.Add(placeDTO);

            return CreatedAtRoute("GetPlace", new {id = placeDTO.Id} ,placeDTO);
        }
    }
}
