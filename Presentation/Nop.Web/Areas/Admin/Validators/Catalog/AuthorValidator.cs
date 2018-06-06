using FluentValidation;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;


namespace Nop.Web.Areas.Admin.Validators.Catalog
{

    /// <summary>
    /// Added for Task #1
    /// Validator
    /// </summary>
    public partial class AuthorValidator : BaseNopValidator<AuthorModel>
    {

        public AuthorValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Authors.Fields.FirstName.Required"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Authors.Fields.LastName.Required"));
            RuleFor(x => x.Description).MaximumLength(500).WithMessage(localizationService.GetResource("Admin.Authors.Fields.Description.MaximumLengthExceed"));
            RuleFor(x => x.PictureId).NotEmpty().WithMessage(localizationService.GetResource("Admin.Authors.Fields.PictureId.Required"));
        }

    }
}
