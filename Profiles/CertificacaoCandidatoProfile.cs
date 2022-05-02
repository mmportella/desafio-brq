using AutoMapper;
using DesafioBRQ.Data.DTO.CertificacaoCandidatoDTO;
using DesafioBRQ.Models;

namespace DesafioBRQ.Profiles
{
    public class CertificacaoCandidatoProfile : Profile
    {
        public CertificacaoCandidatoProfile()
        {
            CreateMap<CreateCertificacaoCandidatoDTO, CertificacaoCandidato>();
            CreateMap<CertificacaoCandidato, ReadCertificacaoCandidatoDTO>();
        }
    }
}
