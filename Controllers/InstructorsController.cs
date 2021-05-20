using System.Collections.Generic;
using AutoMapper;
using EquuSystem.Data;
using EquuSystem.Dtos;
using EquuSystem.Repository.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EquuSystem.Controllers
{
    [Route("api/instructors")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorRepo _repository;
        private readonly IMapper _mapper;

        public InstructorsController(IInstructorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/breeds
        [HttpGet]
        public ActionResult<IEnumerable<InstructorReadDto>> GetAllInstructors()
        {
            var InstructorItems = _repository.GetInstructors();

            return Ok(_mapper.Map<IEnumerable<InstructorReadDto>>(InstructorItems));
        }

        //GET api/breeds/5
        [HttpGet("{id}", Name = "GetInstructorById")]
        public ActionResult<EquuSystemReadDto> GetInstructorById(int id)
        {
            var InstructorItem = _repository.GetInstructorById(id);
            if (InstructorItem != null)
            {
                return Ok(_mapper.Map<InstructorReadDto>(InstructorItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<InstructorCreateDto> CreateInstructor(InstructorCreateDto createInstructor)
        {
            var InstructorModel = _mapper.Map<Instructor>(createInstructor);
            _repository.CreateInstructor(InstructorModel);
            _repository.SaveChanges();

            var InstructorReadDto = _mapper.Map<InstructorReadDto>(InstructorModel);

            return CreatedAtRoute(nameof(GetInstructorById), new { Id = InstructorReadDto.instructor_id }, InstructorReadDto);

            //return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInstructor(int id, InstructorUpdateDto instructorUpdateDto)
        {
            var InstructorFromRepo = _repository.GetInstructorById(id);
            if (InstructorFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(instructorUpdateDto, InstructorFromRepo);

            _repository.UpdateInstructor(InstructorFromRepo); //dont have to do this, entity framework handles this

            _repository.SaveChanges();

            return NoContent();
        }

        //PATH api/breeds/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialInstructorUpdate(int id, JsonPatchDocument<EquuSystemUpdateDto> patchDoc)
        {
            var InstructorFromRepo = _repository.GetInstructorById(id);
            if (InstructorFromRepo == null)
            {
                return NotFound();
            }

            var InstructorToPatch = _mapper.Map<EquuSystemUpdateDto>(InstructorFromRepo);
            patchDoc.ApplyTo(InstructorToPatch, ModelState);

            if (!TryValidateModel(InstructorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(InstructorToPatch, InstructorFromRepo);

            _repository.UpdateInstructor(InstructorFromRepo); //dont have to do this, entity framework handles this

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/breeds/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteInstructor(int id)
        {
            var InstructorFromRepo = _repository.GetInstructorById(id);
            if (InstructorFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteInstructor(InstructorFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}