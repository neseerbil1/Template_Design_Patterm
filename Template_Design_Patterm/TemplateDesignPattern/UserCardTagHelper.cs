using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Template_Design_Patterm.DAL.Entities;
using Template_Design_Patterm.TemplateDesignPattern;
using Template_Design_Patterm.DAL.Entities;

namespace Template_Design_Pattern.TemplateDesignPattern
{
    public class UserCardTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
       
        public AppUser AppUser { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result;
                if (user.EmailConfirmed)
                {
                    userCardTemplate = new PremiumUserCardTemplate();
                }
                else {
                    userCardTemplate = new GoldUserCardTemplate();
                }
            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
            }

            userCardTemplate.SetUser(AppUser);
            output.Content.SetHtmlContent(userCardTemplate.Build());
        }


    }
}