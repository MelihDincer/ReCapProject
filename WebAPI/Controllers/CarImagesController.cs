using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var vehicleDeleteImage = _carImageService.GetImagesByCarId(carImage.Id).Data;
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}