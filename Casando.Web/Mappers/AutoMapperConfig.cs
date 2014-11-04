using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Casando.Web.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m => m.AddProfile<ConvidadoProfile>());
            Mapper.Initialize(m => m.AddProfile<PresenteProfile>());
        }
    }
}