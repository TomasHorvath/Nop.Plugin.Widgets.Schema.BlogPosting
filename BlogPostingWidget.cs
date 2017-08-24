using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Common;
namespace Nop.Plugin.Widgets.Schema.BlogPosting
{
	/// <summary>
	/// PLugin
	/// </summary>
	public class BlogPostingWidget : BasePlugin, IWidgetPlugin
	{
		/// <summary>
		/// Gets widget zones where this widget should be rendered
		/// </summary>
		/// <returns>Widget zones</returns>
		public IList<string> GetWidgetZones()
		{
			return new List<string> { "blogpost_page_bottom" };
		}
		/// <summary>
		/// Gets a route for provider configuration
		/// </summary>
		/// <param name="actionName">Action name</param>
		/// <param name="controllerName">Controller name</param>
		/// <param name="routeValues">Route values</param>
		public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "Configure";
			controllerName = "BlogPostingWidget";
			routeValues = new RouteValueDictionary { { "Namespaces", "Nop.Plugin.Widgets.Schema.BlogPosting.Controllers" }, { "area", null } };
		}
		/// <summary>
		/// Gets a route for displaying widget
		/// </summary>
		/// <param name="widgetZone">Widget zone where it's displayed</param>
		/// <param name="actionName">Action name</param>
		/// <param name="controllerName">Controller name</param>
		/// <param name="routeValues">Route values</param>
		public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "PublicInfo";
			controllerName = "BlogPostingWidget";
			routeValues = new RouteValueDictionary
			{
				{"Namespaces", "Nop.Plugin.Widgets.Schema.BlogPosting.Controllers"},
				{"area", null},
				{"widgetZone", widgetZone}
			};
		}
		/// <summary>
		/// Install plugin
		/// </summary>
		public override void Install()
		{
			PluginManager.MarkPluginAsInstalled(this.PluginDescriptor.SystemName);
		}
		/// <summary>
		/// Uninstall plugin
		/// </summary>
		public override void Uninstall()
		{
			PluginManager.MarkPluginAsUninstalled(this.PluginDescriptor.SystemName);
		}
	}
}
