﻿using BLL.Interface;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaController : ControllerBase
    {
        private readonly IPasta _pastaService;

        public PastaController(PastaService pastaService)
        {
            _pastaService = pastaService ?? throw new ArgumentNullException(nameof(pastaService));
        }

        [HttpDelete("delete/{bindID}")]
        public IActionResult DeletePasta(int bindID)
        {
            if (_pastaService.DeletePasta(bindID))
                return Ok();

            return NotFound();
        }

        [HttpGet("history/{bindID}")]
        public IActionResult PastaHistoryByKey(int bindID)
        {
            try
            {
                var historyResponses = _pastaService.PastaHistoryByKey(bindID);
                return Ok(historyResponses);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
