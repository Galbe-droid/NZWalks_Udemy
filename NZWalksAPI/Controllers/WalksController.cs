using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Model.Domain;
using NZWalksAPI.Model.DTO;
using NZWalksAPI.Repository;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModelAtribute]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            var walkModel = _mapper.Map<Walk>(addWalkRequestDto);

            await _walkRepository.CreateAsync(walkModel);

            return View(_mapper.Map<WalkDto>(walkModel));
          
        }

        //GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
                                                [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomain = await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            return Ok(_mapper.Map<List<WalkDto>>(walksDomain));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkModel = await _walkRepository.GetByIdAsync(id);

            if (walkModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModelAtribute]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id,[FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        { 
            var walkModel = _mapper.Map<Walk>(updateWalkRequestDto);

            walkModel = await _walkRepository.UpdateAsync(walkModel, id);

            if (walkModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkModel));

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walkModel = await _walkRepository.DeleteAsync(id);

            if(walkModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkModel));
        }
    }
}
