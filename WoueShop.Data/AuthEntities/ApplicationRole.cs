using Microsoft.AspNetCore.Identity;

namespace WoueShop.Data.AuthEntities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name)
        {
            this.Name = name;
            NormalizedName = name.ToUpper();
        }


    }
}
