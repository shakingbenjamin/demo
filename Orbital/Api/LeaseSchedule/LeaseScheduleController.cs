using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.LeaseSchedule
{
    /// <summary>
    /// The lease schedule controller, would have authorization
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="configuration"></param>
    /// [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LeaseScheduleController : ControllerBase
    {
        private readonly ILeaseScheduleRepository repository;
        private readonly IConfiguration configuration;

        public LeaseScheduleController(ILeaseScheduleRepository repository, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.repository = repository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var leaseSchedules = await repository.GetAllLeaseSchedules();
                return Ok(leaseSchedules);
            }
            catch(Exception ex)
            {
                return BadRequest($"Getting all of the lease schedules with the following exception: {ex.Message}");
            }
        }
    }
}