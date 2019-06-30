﻿using AutoMapper;
using FriscoDev.Application.Models;
using FriscoDev.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriscoDev.UI.Models
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Account, AccountViewModel>()
           .ForMember(dest => dest.ID, mo => mo.MapFrom(src => src.UR_ID))
           .ForMember(dest => dest.UserName, mo => mo.MapFrom(src => src.UR_NAME))
           .ForMember(dest => dest.AddTime, mo => mo.MapFrom(src => src.UR_ADDTIME.ToString("yyyy/MM/dd")))
           .ForMember(dest => dest.UR_PASSWD, mo => mo.Ignore());

            CreateMap<AccountViewModel, Account>();

            CreateMap<PMD, PMGModel>();

            CreateMap<PMGModel, PMD>();

        }



    }
}