namespace PaletteLeuzoise.Site.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    using Microsoft.Extensions.Logging;

    using PaletteLeuzoise.Site.ViewModels;
    
    using Umbraco.Cms.Core.Web;
    using Umbraco.Cms.Web.Common;
    using Umbraco.Cms.Web.Common.Controllers;

    public class HomepageController : RenderController
    {
        public HomepageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) 
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        { }

        public override IActionResult Index()
        {
            // TODO : Override Render controller to get content property directly
            // TODO : Constants instead of magic strings 
            var content = UmbracoContext.PublishedRequest.PublishedContent;

            return CurrentTemplate(new HomepageViewModel()
            {
                Title = content.GetProperty("mainTitle").GetValue().ToString(),
                DescriptionTitle = content.GetProperty("descriptionTitle").GetValue().ToString(),
                DescriptionContent = content.GetProperty("descriptionContent").GetValue().ToString(),
            });
        }
    }
}
