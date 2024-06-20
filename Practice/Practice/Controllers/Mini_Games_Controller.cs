using Microsoft.AspNetCore.Mvc;
using Practice.Repository;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mini_Games_Controller : ControllerBase
    {
        private readonly IMini_Games_Repository _mini_Games_Repository;

        public Mini_Games_Controller(IMini_Games_Repository mini_Games_Repository)
        {
            _mini_Games_Repository = mini_Games_Repository;
        }
        [HttpGet("Dice Roll")]
        //[Authorize]
        public int Dice_Roll()
        {
            try
            {
                return _mini_Games_Repository.Dice_Roll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Toss")]
        //[Authorize]
        public string Toss()
        {
            try
            {
                return _mini_Games_Repository.Toss();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
