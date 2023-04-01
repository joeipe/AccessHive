using AccessHive.Application;
using AccessHive.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AccessHive.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IAppService _appService;

        public DataController(ILogger<DataController> logger, IAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet]
        public async Task<ActionResult> GetRole()
        {
            using (_logger.BeginScope("GetRole"))
            _logger.LogInformation("GetRole() Started");

            return Ok(await _appService.GetRoleAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoleById(int id)
        {
            using (_logger.BeginScope("GetRoleById"))
            _logger.LogInformation($"GetRoleById({id} Started)");

            var vm = await _appService.GetRoleByIdAsync(id);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole([FromBody] RoleVM value)
        {
            var result = await _appService.AddRoleAsync(value);
            return result.IsSuccess ? Created("", value) : StatusCode(StatusCodes.Status500InternalServerError, result.Error);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRole([FromBody] RoleVM value)
        {
            var result = await _appService.UpdateRoleAsync(value);
            return result.IsSuccess ? Ok() : StatusCode(StatusCodes.Status500InternalServerError, result.Error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletRole(int id)
        {
            var result = await _appService.DeletRoleAsync(id);
            return result.IsSuccess ? Ok() : StatusCode(StatusCodes.Status500InternalServerError, result.Error);
        }

        [HttpGet]
        public async Task<ActionResult> GetEnvironment()
        {
            var obj = new List<string>()
            {
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "none",
                Environment.GetEnvironmentVariable("ASPNETCORE_ENV_VERSION") ?? "none"
            };

            return Ok(await Task.FromResult(obj));
        }
    }
}