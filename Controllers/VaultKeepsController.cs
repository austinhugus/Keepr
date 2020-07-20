using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using keepr.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<DTOVaultKeep>> Get(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST
        [HttpPost]
        public ActionResult<DTOVaultKeep> Post([FromBody] DTOVaultKeep newDTOVaultKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Create(newDTOVaultKeep));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<DTOVaultKeep> Delete(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
