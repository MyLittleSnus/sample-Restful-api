using GoodsApi.Models;

namespace GoodsApi.Infrustructure.DTO;

public class OrderDTO
{
	public List<GoodDTO> Goods { get; set; }
	public int Status { get; set; }
}