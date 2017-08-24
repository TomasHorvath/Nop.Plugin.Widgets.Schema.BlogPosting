using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.Schema.BlogPosting.Models
{
	public class BlogPostingViewModel
	{
		public Nop.Web.Models.Blogs.BlogPostModel BlogPost { get; set; }
		public Nop.Core.Domain.Stores.Store Store {get;set;}
		public Nop.Web.Models.Common.LogoModel Logo { get; set; }
		public string blogPostUrl { get; set; }
		public string logoUrl { get; set; }
	}
}
