using System.Collections.Generic;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Web.Models.Catalog
{
    public partial class AuthorNavigationModel : BaseNopModel
    {
        public AuthorNavigationModel()
        {
            this.Authors = new List<AuthorBriefInfoModel>();
        }

        public IList<AuthorBriefInfoModel> Authors { get; set; }

        public int TotalAuthors { get; set; }
    }

    public partial class AuthorBriefInfoModel : BaseNopEntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string SeName { get; set; }

        public bool IsActive { get; set; }
    }
}