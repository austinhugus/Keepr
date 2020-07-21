using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using keepr.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Keepr.Models;

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
        [HttpGet]
        public ActionResult<IEnumerable<VaultKeep>> Get()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetByUserId(userId));
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
                string user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Create(newDTOVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DELETEBYID
        [HttpDelete("{id}")]
        public ActionResult<DTOVaultKeep> Delete(int Id)
        {
            try
            {
                string user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Delete(user, Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
