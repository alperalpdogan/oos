using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.OOS.Models;
using Nop.Services.Catalog;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.OOS.Components
{
    public class OosViewComponent : NopViewComponent
    {
        private readonly IProductService _productService;

        public OosViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var productId = 0;
            if (additionalData.GetType() == typeof(ProductDetailsModel))
                productId = (additionalData as ProductDetailsModel).Id;

            else if (additionalData.GetType() == typeof(ProductOverviewModel))
                productId = (additionalData as ProductOverviewModel).Id;

            //get product for warehouse
            //maybe create a new service for the query since the search does not cache results
            //var product = await _productService.SearchProductsAsync(warehouseId: 1);
            var product = await _productService.GetProductByIdAsync(productId);

            var model = new OosModel()
            {
                OutOfStock = product.StockQuantity <= 0
            };

            return View("~/Plugins/Widgets.Oos/Views/OosProduct.cshtml", model);
        }
    }
}
