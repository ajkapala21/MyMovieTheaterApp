using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieTheater.Models;
using MovieTheater.Dtos;

namespace MovieTheater.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Viewing, ViewingDto>();
            Mapper.CreateMap<ViewingDto, Viewing>();
            Mapper.CreateMap<Seat, SeatDto>();
            Mapper.CreateMap<SeatDto, Seat>();
            Mapper.CreateMap<TicketDto, Ticket>();
            Mapper.CreateMap<Ticket, TicketDto>();
            Mapper.CreateMap<Theater, TheaterDto>();
            Mapper.CreateMap<TheaterDto, Theater>();
        }
    }
}