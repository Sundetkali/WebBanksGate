namespace WebSite.ViewModels
{
    public class TreeViewModel
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string LayoutTitle { get; set; }
        public string IconCss { get; set; }
        public string OpenId { get; set; }
        public string OpenDataJson { get; set; }
        public string GetDataParamsJson { get; set; }
        public string TabCss { get; set; }
        public bool HideTreeLeftMenu { get; set; }
    }
}