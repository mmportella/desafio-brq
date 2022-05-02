using AutoMapper;
using DesafioBRQ.Data.DTO.SkillDTO;
using DesafioBRQ.Models;

namespace DesafioBRQ.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<CreateSkillDTO, Skill>();
            CreateMap<Skill, ReadSkillDTO>();
        }
    }
}
