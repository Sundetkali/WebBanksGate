using System.ComponentModel.DataAnnotations;
using Nat.Web.Core.Resources;
using WebSite.Properties;

namespace WebSite.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        [Display(Name = nameof(AccountResources.UserName), ResourceType = typeof(AccountResources))]
        [UIHint("String")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        [Display(Name = nameof(AccountResources.Password), ResourceType = typeof(AccountResources))]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}