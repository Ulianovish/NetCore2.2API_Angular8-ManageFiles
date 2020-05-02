using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
	public class BairesDev
	{
		//[Key]
		//public int PostId { get; set; }
		//[Required]
		//public string Creator { get; set; }
		//[Required]
		//public string Title { get; set; }
		//[Required]
		//public string Body { get; set; }
		//[Required]
		//public DateTime Dt { get; set; }
		[Key]
		public int Id { get; set; }
		public string PersonId { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string CurrentRole { get; set; }
		public string Country { get; set; }
		public string Industry { get; set; }
		public int? NumberOfRecommendations { get; set; }
		public int? NumberOfConnections { get; set; }
	}
}
