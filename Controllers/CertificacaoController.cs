using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DesafioBRQ.Data.DTO.CertificacaoDTO;
using DesafioBRQ.Models;

namespace DesafioBRQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificacaoController : ControllerBase
    {

        private Data.BRQContext _context;
        private IMapper _mapper;

        public CertificacaoController(Data.BRQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCertificacao([FromBody] CreateCertificacaoDTO certificacaoDTO)
        {
            Certificacao certificacao = _mapper.Map<Certificacao>(certificacaoDTO);
            _context.Add(certificacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCertificacaoById), new { id = certificacao.IdCertificacao }, certificacao);
        }

        [HttpGet]
        public IActionResult GetCandidato()
        {
            List<Certificacao> certificacao = _context.Certificacoes.ToList();
            if (certificacao != null)
            {
                List<ReadCertificacaoDTO> readDTO = _mapper.Map<List<ReadCertificacaoDTO>>(certificacao);
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("id/{id}")]
        public IActionResult GetCertificacaoById(int id)
        {
            Certificacao certificacao = _context.Certificacoes.FirstOrDefault(certificacao => certificacao.IdCertificacao == id);
            if (certificacao != null)
            {
                ReadCertificacaoDTO certificacaoDTO = _mapper.Map<ReadCertificacaoDTO>(certificacao);
                return Ok(certificacaoDTO);
            }
            return NotFound();
        }

        [HttpPut("id/{id}")]
        public IActionResult UpdateCertificacao([FromBody] CreateCertificacaoDTO certificacaoDTO, int id)
        {
            Certificacao certificacao = _context.Certificacoes.FirstOrDefault(certificacao => certificacao.IdCertificacao == id);
            if (certificacao != null)
            {
                _mapper.Map(certificacaoDTO, certificacao);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteCertificacao(int id)
        {
            Certificacao certificacao = _context.Certificacoes.FirstOrDefault(certificacao => certificacao.IdCertificacao == id);
            if (certificacao != null)
            {
                _context.Remove(certificacao);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
