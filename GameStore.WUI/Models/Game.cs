//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameStore.WUI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Game
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "��������")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "��������")]
        public string Category { get; set; }

        [Display(Name = "���������")]
        public string Description { get; set; }

        [Display(Name = "Price ($)")]
        public double Price { get; set; }
    }
}
