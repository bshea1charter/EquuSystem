using System.Collections.Generic;
using AutoMapper;
using EquuSystem.Data;
using EquuSystem.Dtos;
using EquuSystem.Repository.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EquuSystem.Controllers
{
    [Route("api/breeds")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly IEquuSystemRepo _repository;
        private readonly IMapper _mapper;

        public BreedsController(IEquuSystemRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/breeds
        [HttpGet]    
        public ActionResult <IEnumerable<EquuSystemReadDto>> GetAllBreeds()
        {
            var BreedItems = _repository.GetBreeds();    

            return Ok(_mapper.Map<IEnumerable<EquuSystemReadDto>>(BreedItems));
        }

        //GET api/breeds/5
        [HttpGet("{id}", Name ="GetBreedById")]
        public ActionResult <EquuSystemReadDto> GetBreedById(int id)
        {
            var BreedItem = _repository.GetBreedById(id);
            if(BreedItem != null)
            { 
                return Ok(_mapper.Map<EquuSystemReadDto>(BreedItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<EquuSystemCreateDto> CreateBreed(EquuSystemCreateDto createBreed)
        {
            var BreedModel = _mapper.Map<Breed>(createBreed);
            _repository.CreateBreed(BreedModel);
            _repository.SaveChanges();

            var BreedReadDto = _mapper.Map<EquuSystemReadDto>(BreedModel);

            return CreatedAtRoute(nameof(GetBreedById), new { Id = BreedReadDto.breed_id }, BreedReadDto);

            //return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBreed(int id, EquuSystemUpdateDto breedUpdateDto)
        {
            var BreedFromRepo = _repository.GetBreedById(id);
            if(BreedFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(breedUpdateDto, BreedFromRepo);

            _repository.UpdateBreed(BreedFromRepo); //dont have to do this, entity framework handles this

            _repository.SaveChanges();

            return NoContent();
        }

        //PATH api/breeds/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialBreedUpdate(int id, JsonPatchDocument<EquuSystemUpdateDto> patchDoc)
        {
            var BreedFromRepo = _repository.GetBreedById(id);
            if (BreedFromRepo == null)
            {
                return NotFound();
            }

            var BreedToPatch = _mapper.Map<EquuSystemUpdateDto>(BreedFromRepo);
            patchDoc.ApplyTo(BreedToPatch, ModelState);

            if(!TryValidateModel(BreedToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(BreedToPatch, BreedFromRepo);

            _repository.UpdateBreed(BreedFromRepo); //dont have to do this, entity framework handles this

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/breeds/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBreed(int id)
        {
            var BreedFromRepo = _repository.GetBreedById(id);
            if (BreedFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteBreed(BreedFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}