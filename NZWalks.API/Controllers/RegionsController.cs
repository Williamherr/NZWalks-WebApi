using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.RegionRepository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dBContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dBContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from the database
            var regions = await regionRepository.GetAllAsync();

            return Ok(mapper.Map<List<RegionDTO>>(regions));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var region = await regionRepository.GetByIdAsync(id);

            if (region == null) return NotFound();

            return Ok(mapper.Map<List<RegionDTO>>(region));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionDto)
        {
            

            var region = mapper.Map<Region>(addRegionDto);

            region = await regionRepository.CreateAsync(region);

            var regionDto = mapper.Map<RegionDTO>(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);


        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionDto)
        {
            

            var regionDomainModel = mapper.Map<Region>(updateRegionDto);

            var region = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (region == null) return NotFound();

            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            if (region == null) return NotFound();

            return Ok(mapper.Map<RegionDTO>(region));
        }
    }

}
