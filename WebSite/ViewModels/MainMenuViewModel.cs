using Nat.Web.Core.System.CMS;

namespace WebSite.ViewModels
{
    public class MainMenuViewModel
    {
        public IMenuService MenuService { get; set; }
        public long? ChildredForId { get; set; }
        public int MaxChildrenLevel { get; set; }
    }
}