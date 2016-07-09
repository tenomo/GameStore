using GameStore.WUI.Models.Concrete;
using System;
using System.Web.Mvc;

namespace GameStore.WUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {

        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса
            Cart cart = null;

            if (controllerContext.HttpContext.Session != null)
            {
                cart = controllerContext.HttpContext.Session[sessionKey] as Cart;
            }

            // Создать объект Cart если он не обнаружен в сеансе
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            // Возвратить объект Cart
            return cart;
        }
    }
}