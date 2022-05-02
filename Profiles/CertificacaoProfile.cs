using AutoMapper;
using DesafioBRQ.Data.DTO.CertificacaoDTO;
using DesafioBRQ.Models;

namespace DesafioBRQ.Profiles
{
    public class CertificacaoProfile : Profile
    {
        public CertificacaoProfile()
        {
            CreateMap<CreateCertificacaoDTO, Certificacao>();
            CreateMap<Certificacao, ReadCertificacaoDTO>();
        }
    }
}
