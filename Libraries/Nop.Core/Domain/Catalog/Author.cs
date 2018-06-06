using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;
using System;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Added for Task #1
    /// Represents an author 
    /// </summary>
    public partial class Author: BaseEntity, ISlugSupported
    {

        /// <summary>
        /// Gets or sets the firstname
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        /// Gets or sets the lastname
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets picture identifier
        /// </summary>
        public int PictureId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }


        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }




    }
}
