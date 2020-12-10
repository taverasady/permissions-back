using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permissions.BL.Dto;
using Permissions.BL.IRepositories;
using Permissions.BL.Repositories;
using Permissions.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PermitController : ControllerBase
    {
        private readonly IPermitRepository _permitRepository;
        private readonly IMapper _mapper;
        public PermitController(IPermitRepository permitRepository, IMapper mapper)
        {
            _permitRepository = permitRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get() => Ok(_mapper.Map<List<PermitDto>>(_permitRepository.GetAll(p => p.PermitType)));

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] PermitDto dto)
        {
            var model = _mapper.Map<Permit>(dto);

            await _permitRepository.AddAsync(model);
            await _permitRepository.SaveAsync();

            return Ok(_mapper.Map(model, dto));
        }
        [HttpPut("{key}")]
        public virtual async Task<IActionResult> Put([FromRoute] int key, [FromBody] PermitDto dto)
        {

            var model = await _permitRepository.FindAsync(key);

            model = _mapper.Map(dto, model);

            _permitRepository.Update(model);
            await _permitRepository.SaveAsync();

            return Ok(_mapper.Map(model, dto));
        }

        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int key, [FromBody] PermitDto dto)
        {
            var model = await _permitRepository.FindAsync(key);

            model = _mapper.Map(dto, model);
            _permitRepository.Remove(model);
            await _permitRepository.SaveAsync();

            return Ok();
        }
    }
}
