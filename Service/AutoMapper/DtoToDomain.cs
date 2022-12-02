using AutoMapper;
using Domain.DTOs.Input;
using Domain.Entities;

namespace Service.AutoMapper;

public class DtoToDomain : Profile
{
    public DtoToDomain()
    {
        CreateMap<MessageViewInput, Message>();
    }
}
