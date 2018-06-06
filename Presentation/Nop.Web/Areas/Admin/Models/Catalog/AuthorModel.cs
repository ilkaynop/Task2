using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Seo;
using Nop.Web.Areas.Admin.Validators.Catalog;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Added for Task #1
    /// Model
    /// </summary>
    [Validator(typeof(AuthorValidator))]
    public partial class AuthorModel : BaseNopEntityModel
    {

        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.FirstName")]
        public string FirstName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.LastName")]
        public string LastName { get; set; }


        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.SeName")]
        public string SeName { get; set; }


        [UIHint("Picture")]
        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.Picture")]
        public int PictureId { get; set; }


        [NopResourceDisplayName("Admin.Catalog.Authors.Fields.Deleted")]
        public bool Deleted { get; set; }


    }
}
