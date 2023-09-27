namespace OnlineShop.Lib.Options;
    public class ServiceAdressOptions
    {
        public const string SectionName = nameof(ServiceAdressOptions);
        public string IdentityServer { get; set; }
        public string UserManagementServer { get; set; }
        public string OrdersService { get; set; }
        public string ArticleService { get; set; }
        public string ApiService { get; set; }
        public string CategoryService { get; set; }
}
