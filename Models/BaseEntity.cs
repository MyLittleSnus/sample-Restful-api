using System.ComponentModel.DataAnnotations;

namespace GoodsApi.Models
{
	public abstract class BaseEntity
	{
		[Key]
		public string Id { get; set; }
	}
}