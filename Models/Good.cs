using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsApi.Models;

[Table("goods")]
public class Good : BaseEntity
{
	[Required]
	public int Category { get; set; }

	[Required]
	[MinLength(4)]
	[MaxLength(100)]
	public required string Name { get; set; }

	[Required]
	[Range(0, 100000)]
	public double Cost { get; set; }

	public List<Order> Orders { get; set; } // same problem here
}