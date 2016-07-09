using GameStore.WUI.Models.Concrete;

namespace GameStore.WUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartIndexViewModel(Cart cart, string returnUrl)
        {
            this.ReturnUrl = returnUrl;
            this.Cart = cart;
        }
    }
}