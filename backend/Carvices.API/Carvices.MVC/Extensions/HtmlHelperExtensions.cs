using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Carvices.MVC.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string Validate<TModel>(this IHtmlHelper<TModel> htmlHelper, string propertyName)
        {
            return htmlHelper.ViewData.ModelState[propertyName]?.Errors.Count > 0 ? "is-invalid" : "";
        }
    }
}
