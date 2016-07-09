using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WUI.Models
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }



        public GamesListViewModel(IEnumerable<Game> games, PagingInfo pagingInfo, string currentCategory)
        {
            this.Games = games;
            this.CurrentCategory = currentCategory;
            this.PagingInfo = pagingInfo;
        }

        public GamesListViewModel(IEnumerable<Game> games, PagingInfo pagingInfo)
        {
            this.Games = games;
            this.PagingInfo = pagingInfo;
        }
    }
}