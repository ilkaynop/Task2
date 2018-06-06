using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Areas.Admin.Validators.Catalog;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public partial class AuthorListModel : BaseNopModel
    {

        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.FirstName")]
        public string SearchFirstName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.LastName")]
        public string SearchLastName { get; set; }

    }
}
