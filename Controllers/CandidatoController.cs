using DesafioBRQ.Data.DTO.CandidatoDTO;
using DesafioBRQ.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBRQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {

        private Data.BRQContext _context;
        private IMapper _mapper;

        public CandidatoController(Data.BRQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCandidato([FromBody] CreateCandidatoDTO candidatoDTO)
        {
            Candidato candidato = _mapper.Map<Candidato>(candidatoDTO);
            _context.Add(candidato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCandidatoById), new { id = candidato.IdCandidato }, candidato);
        }

        [HttpGet]
        public IActionResult GetCandidato()
        {
            List<Candidato> candidatos = _context.Candidatos.ToList();
            if (candidatos != null)
            {
                List<ReadCandidatoDTO> readDTO = _mapper.Map<List<ReadCandidatoDTO>>(candidatos);
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("id/{id}")]
        public IActionResult GetCandidatoById(int id)
        {
            Candidato candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.IdCandidato == id);
            if (candidato != null)
            {
                ReadCandidatoDTO candidatoDTO = _mapper.Map<ReadCandidatoDTO>(candidato);
                return Ok(candidatoDTO);
            }
            return NotFound();
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult GetCandidatoByCpf(long cpf)
        {
            Candidato candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Cpf == cpf);
            if (candidato != null)
            {
                ReadCandidatoDTO candidatoDTO = _mapper.Map<ReadCandidatoDTO>(candidato);
                return Ok(candidatoDTO);
            }
            return NotFound();
        }

        [HttpPut("id/{id}")]
        public IActionResult UpdateCandidato(int id, [FromBody] CreateCandidatoDTO candidatoDTO)
        {
            Candidato candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.IdCandidato == id);
            if (candidato != null)
            {
                _mapper.Map(candidatoDTO, candidato);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteCandidato(int id)
        {
            Candidato candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.IdCandidato == id);
            if (candidato != null)
            {
                _context.Remove(candidato);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
