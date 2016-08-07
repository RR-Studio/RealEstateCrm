﻿using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.TagHelpers
{
    [HtmlTargetElement("city-list", Attributes = "city-id")]
    public class CitySelectListTagHelper : TagHelper
    {
        public int CityId { get; set; }
        public bool Disabled { get; set; }

        private ApplicationDbContext DbContext;

        public CitySelectListTagHelper([FromServices] ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "select";

            if (Disabled)
            {
                output.Attributes.SetAttribute("disabled", "disabled");
            }


            var items = new StringBuilder();
            var cityList = DbContext.Cities.OrderBy(x => x.Name).ToList();

            items.Append("<option value=\"\">Все города</option>");
            foreach (var city in cityList)
            {
                if (city.Id == CityId)
                {
                    items.Append($"<option value=\"{city.Id}\" selected=\"true\">{city.Name}</option>");
                }
                else
                {
                    items.Append($"<option value=\"{city.Id}\">{city.Name}</option>");
                }
            }
        
            output.Content.SetHtmlContent(items.ToString());
            output.Attributes.Add("class", "ui fluid dropdown");
        }
    }
}
