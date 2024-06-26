﻿using AutoMapper;

namespace BLL.Mappings
{
    public interface IMapTo<T>
    {
        void MapTo(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}