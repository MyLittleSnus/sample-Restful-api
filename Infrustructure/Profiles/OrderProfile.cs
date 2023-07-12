using System;
using AutoMapper;
using GoodsApi.Infrustructure.DTO;
using GoodsApi.Models;

namespace GoodsApi.Infrustructure.Profiles
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{
			CreateMap<OrderDTO, Order>()
				.ForMember(
					dest => dest.Id,
					dto => dto.MapFrom(dto => Guid.NewGuid().ToString())
				)
				.ForMember(
					dest => dest.Status,
					dto => dto.MapFrom(dto => dto.Status)
				)
				.ForMember(
					dest => dest.Goods,
					dto => dto.MapFrom(dto => dto.Goods)
				);
		}
	}
}