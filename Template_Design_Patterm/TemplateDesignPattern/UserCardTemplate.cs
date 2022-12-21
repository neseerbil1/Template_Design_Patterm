using System.Text;
using Template_Design_Patterm.DAL.Entities;

namespace Template_Design_Patterm.TemplateDesignPattern
{
    public abstract class UserCardTemplate
    {

            protected AppUser AppUser { get; set; }
        public void SetUser(AppUser appUser)
        { 
            AppUser = appUser; 
        }
        protected abstract string SetImage();
        protected abstract string SetFooter();
        public string Build()
        {
            var sb = new StringBuilder();
            sb.Append("<div classs='card'>");
            sb.Append(SetImage());
            sb.Append($@"<div class='card-body'>
<h4>{AppUser.UserName}</h4>
<p>{AppUser.Description}</p>");
            sb.Append(SetFooter());
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }
     

  }
}
