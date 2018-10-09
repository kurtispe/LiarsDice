using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiarsDice.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DieController : ControllerBase
    {
    //    #region Constructor
    //    public DieController()
    //    {
    //        data = new EntityData(new MockDB());
    //    }
    //    #endregion

    //    #region Props
    //    private EntityData data;
    //    #endregion

    //    #region Functions

    //    #region HttpGet
    //    [HttpGet]
    //    public async Task<IActionResult> GetDiceAsync()
    //    {
    //        var response =  await data.FindAllAsync<DieDB>();

    //        List<Die> returnable = new List<Die>();

    //        foreach(DieDB die in response)
    //        {
    //            returnable.Add(die.ProduceReturnable());
    //        }

    //        return Ok(returnable);
    //    }
    //    [HttpGet("{playerID:int}")]
    //    public async Task<IActionResult> GetDiceAsync(int playerID)
    //    {
    //        var response = await data.FindAsync<PlayerDB>(playerID);
    //        var finalResponse = response.Dice;
    //        return Ok(finalResponse);
    //    }
    //    [HttpGet]
    //    [Route("save")]
    //    public async Task<IActionResult> GetSaveAsync()
    //    {
    //        DieDB d = new DieDB();

    //        await Task.Run(() =>
    //        {
    //            data.SaveAsync(d);
    //        });
    //        return Ok();
    //    }
    //    [HttpGet]
    //    [Route("baddie")]
    //    public async Task<IActionResult> GetJsonDie()
    //    {
    //        Die d = new Die(4, 8);
    //        await Task.Run(() =>
    //        {
    //            data.SaveAsync<DieDB>(new DieDB(d));
    //        });
    //        return Ok(d);
    //    }
    //    #endregion

    //    #region HttpPost
    //    [HttpPost]
    //    [Consumes("application/json")]
    //    public async Task<IActionResult> PostDiceAsync([FromBody] Die[] dice)
    //    {
    //        await Task.Run(() =>
    //        {
    //            foreach (Die d in dice)
    //            {
    //                DieDB die = new DieDB(d);
    //                data.SaveAsync<DieDB>(die);
    //            }
    //        });
    //        return Ok();
    //    }
    //    #endregion

    //    #region HttpDelete
    //    [HttpDelete]
    //    [Consumes("application/json")]
    //    public async Task<IActionResult> DeleteDieAsync([FromBody] Die die)
    //    {
    //        await Task.Run(() =>
    //        {
    //            data.DeleteOneAsync<DieDB>(new DieDB(die));
    //        });
    //        return Ok(); 
    //    }
    //    #endregion

    //    #endregion
    }
}