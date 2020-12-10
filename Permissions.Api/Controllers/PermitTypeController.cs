using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permissions.BL.Dto;
using Permissions.BL.IRepositories;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitTypeController : ControllerBase
    {
        private readonly IPermitTypeRepository _permitTypeRepository;
        private readonly IMapper _mapper;
        public PermitTypeController(IPermitTypeRepository permitTypeRepository, IMapper mapper)
        {
            _permitTypeRepository = permitTypeRepository;
            _mapper = mapper;
        }

        public virtual IQueryable Get()
        {
            return _permitTypeRepository.GetAll();
        }
        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int key, [FromBody] PermitTypeDto dto)
        {
            var model = await _permitTypeRepository.FindAsync(key);

            model = _mapper.Map(dto, model);
            _permitTypeRepository.Remove(model);
            await _permitTypeRepository.SaveAsync();

            return Ok();
        }
    }
}
