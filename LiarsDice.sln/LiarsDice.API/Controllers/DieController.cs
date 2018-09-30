using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiarsDice.Data;
using LiarsDice.Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiarsDice.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DieController : ControllerBase
    {
        #region Constructor
        public DieController()
        {
            data = new EntityData();
        }
        #endregion

        #region Props
        private EntityData data;
        #endregion

        #region Functions
        [HttpGet]
        public async Task<IActionResult> GetDiceAsync()
        {
            var response = await data.FindAllAsync<Die>();
            return Ok(response);
        }
        [HttpGet("{playerID:int}")]
        public async Task<IActionResult> GetDiceAsync(int playerID)
        {
            var response = await data.FindAsync<Player>(playerID);
            var finalResponse = response.Dice;
            return Ok(finalResponse);
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> PostDiceAsync([FromBody] List<Die> dice)
        {
            await Task.Run(() =>
            {
                foreach (Die d in dice)
                {
                    data.SaveAsync<Die>(d);
                }
            });
            return Ok();
        }
        [HttpDelete]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteDieAsync([FromBody] Die die)
        {
            await Task.Run(() =>
            {
                data.DeleteOneAsync<Die>(die);
            });
            return Ok(); 
        }

        [HttpGet]
        [Route("save")]
        public async Task<IActionResult> GetSaveAsync()
        {
            Die d = new Die();

            await Task.Run(() =>
            {
                data.SaveAsync<Die>(d);
            });
            return Ok();
        }
  
        #endregion
    }
}