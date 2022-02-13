﻿using Expediente_RASE.DTO;
using Expediente_RASE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Expediente_RASE.Utils
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<TDoctore, TDoctore_POST>().ReverseMap();//mapea desde Autor hacia AutorDTO y viceversa
            CreateMap<TDoctore_POST, TDoctore>();//mapea desde AutorCreacionDTO hacia Autor

            CreateMap<TDoctore, TDoctore_GET_DELETE>().ReverseMap();//mapea desde Autor hacia AutorDTO y viceversa
            CreateMap<TDoctore_GET_DELETE, TDoctore>();


        }
    }
}