using AutoMapper;
using DesafioBRQ.Data.DTO.SkillCandidatoDTO;
using DesafioBRQ.Models;

namespace DesafioBRQ.Profiles
{
    public class SkillCandidatoProfile : Profile
    {
        public SkillCandidatoProfile()
        {
            CreateMap<CreateSkillCandidatoDTO, SkillCandidato>();
            CreateMap<SkillCandidato, ReadSkillCandidatoDTO>();
        }
    }
}
