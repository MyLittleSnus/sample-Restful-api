using AutoMapper;
using GoodsApi.Infrustructure.DTO;
using GoodsApi.Models;

namespace GoodsApi.Infrustructure.Profiles
{
	public class GoodDTOProfile : Profile
	{
		public GoodDTOProfile()
		{
			CreateMap<GoodDTO, Good>()
				//.ForMember(
				//	dest => dest.Id,
				//	source => source.MapFrom(s => s.Id)
				//)
				.ForMember(
					dest => dest.Name,
					source => source.MapFrom(s => s.Name)
				)
				.ForMember(
					dest => dest.Category,
					source => source.MapFrom(s => s.Category)
				)
				.ForMember(
					dest => dest.Cost,
					source => source.MapFrom(s => s.Cost)
				);
		}
	}
}