﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorIntroduction.TagHelpers.Web.Models;
using RazorIntroduction.TagHelpers.Web.UserCards;

namespace RazorIntroduction.TagHelpers.Web.TagHelpers.Custom
{
    public class UserCardTagHelper : TagHelper
    {

        public User User { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userCardTemplate = new PrimeUserCardTemplate();
            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
            }

            userCardTemplate.SetUser(User);

            output.Content.SetHtmlContent(userCardTemplate.Build());
        }
    }
}
