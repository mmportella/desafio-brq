using DesafioBRQ.Data.DTO.SkillDTO;
using DesafioBRQ.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBRQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {

        private Data.BRQContext _context;
        private IMapper _mapper;

        public SkillController(Data.BRQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSkill([FromBody] CreateSkillDTO skillDTO)
        {
            Skill skill = _mapper.Map<Skill>(skillDTO);
            _context.Add(skill);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSkillById), new { id = skill.IdSkill }, skill);
        }

        [HttpGet]
        public IActionResult GetSkill()
        {
            List<Skill> skill = _context.Skills.ToList();
            if (skill != null)
            {
                List<ReadSkillDTO> readDTO = _mapper.Map<List<ReadSkillDTO>>(skill);
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("id/{id}")]
        public IActionResult GetSkillById(int id)
        {
            Skill skill = _context.Skills.FirstOrDefault(skill => skill.IdSkill == id);
            if (skill != null)
            {
                ReadSkillDTO candidatoDTO = _mapper.Map<ReadSkillDTO>(skill);
                return Ok(candidatoDTO);
            }
            return NotFound();
        }


        [HttpPut("id/{id}")]
        public IActionResult UpdateSkill(int id, [FromBody] CreateSkillDTO skillDTO)
        {
            Skill skill = _context.Skills.FirstOrDefault(skill => skill.IdSkill == id);
            if (skill != null)
            {
                _mapper.Map(skillDTO, skill);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteSkill(int id)
        {
            Skill skill = _context.Skills.FirstOrDefault(candidato => candidato.IdSkill == id);
            if (skill != null)
            {
                _context.Remove(skill);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}