using DesafioBRQ.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DesafioBRQ.Data.DTO.CertificacaoCandidatoDTO;

namespace DesafioBRQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificacaoCandidatoController : ControllerBase
    {
        private Data.BRQContext _context;
        private IMapper _mapper;

        public CertificacaoCandidatoController(Data.BRQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCertificacaoCandidato([FromBody] CreateCertificacaoCandidatoDTO certificacaoCandidatoDTO)
        {
            CertificacaoCandidato certificacaoCandidato = _mapper.Map<CertificacaoCandidato>(certificacaoCandidatoDTO);
            _context.Add(certificacaoCandidato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCertificacaoCandidatoById), new { id = certificacaoCandidato.IdCertificacaoCandidato }, certificacaoCandidato);
        }


        [HttpGet]
        public IActionResult GetCertificacaoCandidatos()
        {
            List<CertificacaoCandidato> certificacaoCandidato = _context.CertificacoesCandidatos.ToList();
            if (certificacaoCandidato != null)
            {
                List<ReadCertificacaoCandidatoDTO> readDTO = _mapper.Map<List<ReadCertificacaoCandidatoDTO>>(certificacaoCandidato);
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("id/{id}")]
        public IActionResult GetCertificacaoCandidatoById(int id)
        {
            CertificacaoCandidato certificacaoCandidato = _context.CertificacoesCandidatos.FirstOrDefault(certificacaoCandidato => certificacaoCandidato.IdCertificacaoCandidato == id);
            if (certificacaoCandidato != null)
            {
                ReadCertificacaoCandidatoDTO certificacaoCandidatoDTO = _mapper.Map<ReadCertificacaoCandidatoDTO>(certificacaoCandidato);
                return Ok(certificacaoCandidatoDTO);
            }
            return NotFound();
        }

        [HttpGet("candidato/{idCandidato}")]
        public IActionResult GetCertificacaoCandidatoByCandidato(int idCandidato)
        {
            List<CertificacaoCandidato> certcandidatos = _context.CertificacoesCandidatos.ToList();
            List<CertificacaoCandidato> retorno = new List<CertificacaoCandidato>();
            if (certcandidatos != null)
            {
                foreach (CertificacaoCandidato s in certcandidatos)
                {
                    if (s.CandidatoId == idCandidato)
                    {
                        retorno.Add(s);
                    }
                }
                List<ReadCertificacaoCandidatoDTO> readDTO = _mapper.Map<List<ReadCertificacaoCandidatoDTO>>(retorno);
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpPut("id/{id}")]
        public IActionResult UpdateCertificacaoCandidato(int id, [FromBody] CreateCertificacaoCandidatoDTO certificacaoCandidatoDTO)
        {
            CertificacaoCandidato certificacaoCandidato = _context.CertificacoesCandidatos.FirstOrDefault(certificacaoCandidato => certificacaoCandidato.IdCertificacaoCandidato == id);
            if (certificacaoCandidato != null)
            {
                _mapper.Map(certificacaoCandidatoDTO, certificacaoCandidato);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteCertificacaoCandidato(int id)
        {
            CertificacaoCandidato certificacaoCandidato = _context.CertificacoesCandidatos.FirstOrDefault(certificacao => certificacao.IdCertificacaoCandidato == id);
            if (certificacaoCandidato != null)
            {
                _context.Remove(certificacaoCandidato);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}