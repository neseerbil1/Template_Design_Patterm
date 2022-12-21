using System.Text;

namespace Template_Design_Patterm.TemplateDesignPattern
{
    public class PremiumUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            var sb = new StringBuilder();
            sb.Append("<a href='#' class='btn btn-warning'>Profili Gör</a>");
            sb.Append("<a href='#' class='btn btn-danger'>Mesaj Gönder</a>");
            sb.Append("<a href='#' class='btn btn-success'>Bağış Yap</a>");
            return sb.ToString();
        }

        protected override string SetImage()
        {
            return $"<img class='car-img-top' src='{AppUser.Image}' style='width:50px; height:50px;'>";
        }
    }
}
