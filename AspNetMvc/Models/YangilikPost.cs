using Microsoft.AspNetCore.Http;

namespace AspNetMvc.Models
{
	public class YangilikPost:Yangilik
	{
		public IFormFile Image { get; set; }
	}
}
