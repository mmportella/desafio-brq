using AutoMapper;
using DesafioBRQ.Data.DTO.CandidatoDTO;
using DesafioBRQ.Models;

namespace DesafioBRQ.Profiles
{
    public class CandidatoProfile : Profile
    {
        public CandidatoProfile()
        {
            CreateMap<CreateCandidatoDTO, Candidato>();
            CreateMap<Candidato, ReadCandidatoDTO>();
        }
    }
}
