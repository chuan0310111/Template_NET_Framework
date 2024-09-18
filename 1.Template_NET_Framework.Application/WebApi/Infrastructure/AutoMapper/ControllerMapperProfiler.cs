using _1.Template_NET_Framework.Application.WebApi.ViewModels;
using _2.Template_NET_Framework.Services.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.Template_NET_Framework.Application.WebApi.Infrastructure.AutoMapper
{
    public class ControllerMapperProfiler : Profile
    {
        public ControllerMapperProfiler() {

            CreateMap<BaseDto, BaseViewModel>();
            CreateMap<HsinChuAreaDto, HsinChuAreaViewModel>();
            CreateMap<HsinChuAreaResultDto, HsinChuAreaResultViewModel>();


        }
    }
}