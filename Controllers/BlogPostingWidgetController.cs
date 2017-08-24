using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Nop.Services;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Core.Domain.Localization;
using Nop.Core.Data;
using Nop.Core;
using Nop.Web.Models.Common;
using Nop.Core.Caching;
using Nop.Web.Infrastructure.Cache;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.Widgets.Schema.BlogPosting.Controllers
{
	public class BlogPostingWidgetController : BasePluginController
	{
		private readonly Nop.Web.Factories.IBlogModelFactory blogFactory;
		private readonly Nop.Services.Blogs.IBlogService blogService;
		private readonly Nop.Core.IWorkContext workContext;
		private readonly Nop.Core.IStoreContext storeContext;
		private readonly Nop.Web.Factories.ICommonModelFactory commonFactory;
		private readonly Nop.Core.Caching.ICacheManager cacheManager;
		private readonly Nop.Services.Seo.IUrlRecordService urlService;

		public BlogPostingWidgetController(Nop.Web.Factories.IBlogModelFactory blogFactory,
			Nop.Services.Blogs.IBlogService blogService,
			Nop.Core.IWorkContext workContext,
			Nop.Core.IStoreContext storeContext,
			Nop.Core.Caching.ICacheManager cacheManager,
			Nop.Web.Factories.ICommonModelFactory commonFactory,
			Nop.Services.Seo.IUrlRecordService urlService
			)
		{
			this.blogFactory = blogFactory;
			this.blogService = blogService;
			this.workContext = workContext;
			this.storeContext = storeContext;
			this.cacheManager = cacheManager;
			this.commonFactory = commonFactory;
			this.urlService = urlService;
		}

		[AdminAuthorize]
		public ActionResult Configure()
		{
			return View("/Plugins/Widgets.Schema.BlogPosting/Views/Configure.cshtml");
		}
		public ActionResult PublicInfo(string widgetZone, object additionalData = null)
		{
			var blogPostId = (int)additionalData;
			var post = blogService.GetBlogPostById(blogPostId);
			Nop.Web.Models.Blogs.BlogPostModel BlogPostModel = new Web.Models.Blogs.BlogPostModel(); 
			blogFactory.PrepareBlogPostModel(BlogPostModel,post,false);
			var store = storeContext.CurrentStore;
			var logo = commonFactory.PrepareLogoModel();
			var blogPostSlug = urlService.GetActiveSlug(blogPostId, "BlogPost", 2);

			Models.BlogPostingViewModel model = new Models.BlogPostingViewModel();

			model.BlogPost = BlogPostModel;
			model.Store = store;
			model.Logo = logo;
			model.blogPostUrl = store.Url + "/" + blogPostSlug;
			model.logoUrl = logo.LogoPath;
			return View("/Plugins/Widgets.Schema.BlogPosting/Views/PublicInfo.cshtml",model);
		}
	}
}