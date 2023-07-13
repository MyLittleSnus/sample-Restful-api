using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsApi.Models;

[Table("orders")]
public class Order : BaseEntity
{
	public List<Good> Goods { get; set; }
	public int Status { get; set; }
}