using System;
using AutoMapper;
using GoodsApi.Infrustructure.DTO;
using GoodsApi.Models;

namespace GoodsApi.Infrustructure.Profiles
{
	public class OrderDTOProfile : Profile
	{
		public OrderDTOProfile()
		{
			CreateMap<Order, OrderDTO>()
				.ForMember(
					dest => dest.Goods,
					source => source.MapFrom(s => s.Goods.Select(g => new GoodDTO
					{
						Name = g.Name,
						Category = g.Category,
						Cost = g.Cost
					}))
				)
				.ForMember(
					dest => dest.Status,
					source => source.MapFrom(s => s.Status)
				);
		}
	}
}

