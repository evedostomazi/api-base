using AutoMapper;
using Domain.DTOs.Input;
using Domain.Entities;

namespace Service.AutoMapper;

public class DomainToDto : Profile
{
    public DomainToDto()
    {
        CreateMap<Message, MessageViewInput>();
    }
}
