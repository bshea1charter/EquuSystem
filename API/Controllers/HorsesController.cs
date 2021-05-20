using System.Collections.Generic;
using System.Data;
using AutoMapper;
using EquuSystem.Data;
using EquuSystem.Dtos;
using EquuSystem.Repository.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EquuSystem.Controllers
{
    [Route("api/horses")]
    [ApiController]
    public class HorsesController : ControllerBase
    {
        private readonly IHorseRepo _repository;
        private readonly IMapper _mapper;

        public HorsesController(IHorseRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/horses
        [HttpGet]
        public ActionResult<IEnumerable<HorseReadDto>> GetAllHorses()
        {
            var HorseItems = _repository.GetHorses();

            return Ok(_mapper.Map<IEnumerable<HorseReadDto>>(HorseItems));
        }

        //GET api/horses/5
        [HttpGet("{id}", Name = "GetHorseById")]
        public ActionResult<HorseReadDto> GetHorseById(int id)
        {
            var HorseItem = _repository.GetHorseById(id);
            if (HorseItem != null)
            {
                return Ok(_mapper.Map<HorseReadDto>(HorseItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<HorseCreateDto> CreateHorse(HorseCreateDto createHorse)
        {
            var HorseModel = _mapper.Map<Horse>(createHorse);
            _repository.CreateHorse(HorseModel);
            _repository.SaveChanges();

            var HorseReadDto = _mapper.Map<HorseReadDto>(HorseModel);

            return CreatedAtRoute(nameof(GetHorseById), new { Id = HorseReadDto.horse_id }, HorseReadDto);

            //return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHorse(int id, HorseUpdateDto horseUpdateDto)
        {
            var HorseFromRepo = _repository.GetHorseById(id);
            if (HorseFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(horseUpdateDto, HorseFromRepo);

            _repository.UpdateHorse(HorseFromRepo); //dont have to do this, entity framework handles this

            _repository.SaveChanges();

            return NoContent();
        }

        //PATH api/horses/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialHorseUpdate(int id, JsonPatchDocument<HorseUpdateDto> patchDoc)
        {
            var HorseFromRepo = _repository.GetHorseById(id);
            if (HorseFromRepo == null)
            {
                return NotFound();
            }

            var HorseToPatch = _mapper.Map<HorseUpdateDto>(HorseFromRepo);
            patchDoc.ApplyTo(HorseToPatch, ModelState);

            if (!TryValidateModel(HorseToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(HorseToPatch, HorseFromRepo);

            _repository.UpdateHorse(HorseFromRepo); //dont have to do this, entity framework handles this

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/breeds/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteHorse(int id)
        {
            var HorseFromRepo = _repository.GetHorseById(id);
            if (HorseFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteHorse(HorseFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }

    [Route("api/horsejoinbreed")]
    [ApiController]
    public class HorseBreedController : ControllerBase
    {
        private readonly IHorseRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public IConfiguration Configuration { get; }

        public HorseBreedController(IHorseRepo repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(table);
            return JSONString;
        }

        //GET api/horsejoinbreed
        [HttpGet]
        public object GetHorseBreed()
        {
            string query = @"SELECT [horse_id]
                              ,[horse_name]
                              ,[horse_breed_id]
                        	  ,[breed_name]
                              ,[horse_dob]
                              FROM [EquuSoft].[dbo].[horses]
                              LEFT OUTER JOIN [EquuSoft].[dbo].[breeds] ON breeds.breed_id = horses.horse_breed_id";

            string myDb1ConnectionString = _configuration.GetConnectionString("EquuSystemConnection");

            var con = new SqlConnection(myDb1ConnectionString);
            var cmd = new SqlCommand(query, con);
            var da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            cmd.CommandType = CommandType.Text;
            con.Open();
            da.Fill(table);
            con.Close();

            return DataTableToJSONWithJSONNet(table);
        }
    }

}