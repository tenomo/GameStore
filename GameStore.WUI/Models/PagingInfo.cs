using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WUI.Models
{
    public class PagingInfo
    {
        // Кол-во товаров
        public int TotalItemsCount { get; set; }

        // Кол-во товаров на одной странице
        public int ItemsPerPageCount { get; set; }

        // Номер текущей страницы
        public int CurrentPageNumber { get; set; }

        // Общее кол-во страниц
        public int TotalPagesCount
        {
            get { return (int)Math.Ceiling((decimal)TotalItemsCount / ItemsPerPageCount); }
        }
    }
}