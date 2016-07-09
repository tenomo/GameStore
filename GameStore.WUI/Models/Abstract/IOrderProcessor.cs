using GameStore.WUI.Models.Concrete;

namespace GameStore.WUI.Models.Abstract
{
    public  interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}