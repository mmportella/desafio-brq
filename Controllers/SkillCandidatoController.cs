using DesafioBRQ.Data.DTO.SkillCandidatoDTO;
using DesafioBRQ.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBRQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillCandidatoController : ControllerBase
    {

        private Data.BRQContext _context;
        private IMapper _mapper;

        public SkillCandidatoController(Data.BRQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSkillCandidato([FromBody] CreateSkillCandidatoDTO skillcandidatoDTO)
        {
            SkillCandidato skillcandidato = _mapper.Map<SkillCandidato>(skillcandidatoDTO);
            _context.Add(skillcandidato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSkillCandidatoById), new { id = skillcandidato.IdSkillCandidato }, skillcandidato);
        }

        [HttpGet]
        public IActionResult GetSkillCandidato()
        {
            List<SkillCandidato> skillcandidatos = _context.SkillCandidatos.ToList();
            if (skillcandidatos != null)
            {
                List<ReadSkillCandidatoDTO> readDTO = _mapper.Map<List<ReadSkillCandidatoDTO>>(skillcandidatos);
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("id/{id}")]
        public IActionResult GetSkillCandidatoById(int id)
        {
            SkillCandidato skillcandidato = _context.SkillCandidatos.FirstOrDefault(skillcandidato => skillcandidato.IdSkillCandidato == id);
            if (skillcandidato != null)
            {
                ReadSkillCandidatoDTO candidatoDTO = _mapper.Map<ReadSkillCandidatoDTO>(skillcandidato);
                return Ok(candidatoDTO);
            }
            return NotFound();
        }

        [HttpGet("candidato/{idCandidato}")]
        public IActionResult GetSkillCandidatoByCandidato(int idCandidato)
        {
            List<SkillCandidato> skillcandidatos = _context.SkillCandidatos.ToList();
            List<SkillCandidato> retorno = new List<SkillCandidato>();
            if (skillcandidatos != null)
            {
                foreach (SkillCandidato s in skillcandidatos)
                {
                    if (s.CandidatoId == idCandidato)
                    {
                        retorno.Add(s);
                    }
                }
                List<ReadSkillCandidatoDTO> readDTO = _mapper.Map<List<ReadSkillCandidatoDTO>>(retorno);
                return Ok(readDTO);
            }
            return NotFound();
        }
        
        [HttpPut("id/{id}")]
        public IActionResult UpdateSkillCandidato(int id, [FromBody] CreateSkillCandidatoDTO skillcandidatoDTO)
        {
            SkillCandidato skillcandidato = _context.SkillCandidatos.FirstOrDefault(skillcandidato => skillcandidato.IdSkillCandidato == id);
            if (skillcandidato != null)
            {
                _mapper.Map(skillcandidatoDTO, skillcandidato);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteSkillCandidato(int id)
        {
            SkillCandidato skillcandidato = _context.SkillCandidatos.FirstOrDefault(skillcandidato => skillcandidato.IdSkillCandidato == id);
            if (skillcandidato != null)
            {
                _context.Remove(skillcandidato);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}