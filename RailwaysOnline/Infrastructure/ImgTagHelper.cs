using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RailwaysOnline.Data;
using RailwaysOnline.Models;

namespace RailwaysOnline.Infrastructure
{
    [HtmlTargetElement("img", Attributes = "user-name")]
    public class ImgTagHelper : TagHelper
    {
        private const string IMAGE_NAME = "_advert.jpg";
        private const string PATH = "app/img/";
        public string UserName { get; set; }

        private UserManager<User> manager;
        public ImgTagHelper(UserManager<User> manager)
        {
            this.manager = manager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            User user = manager.Users.FirstOrDefault(u => u.UserName == UserName);
            string locale = "fr";
            if (null!=user)
            {
                locale = user.Language.ToString();
                
            }
            output.Attributes.SetAttribute("src", $"{PATH}{locale}{IMAGE_NAME}");

        }
    }
}
