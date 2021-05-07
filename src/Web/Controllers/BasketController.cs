using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Controllers
{
    // todo: web > basketviewmodelservice > getcreatebasket 
    // todo : appcore > basketservice > additemtobasket
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IBasketService _basketService;

        public BasketController(IBasketViewModelService basketViewModelService, IBasketService basketService)
        {
            _basketViewModelService = basketViewModelService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketViewModelService.GetBasketViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToBasket(int productId, int quantity)
        {
            // application core projesinde BasketService : IBasketService
            // AddItemToBasket(int basketId, int catalogItemId, int quantity)
            var basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
            await _basketService.AddItemToBasket(basketId, productId, quantity);

            // sepetteki yeni öğe sayısını döndür.
            return Json(await _basketViewModelService.GetBasketItemsCountViewModel(basketId));
        }
    }
}
