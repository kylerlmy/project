namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class SiteConfigEntity : IEntity<SiteConfigEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string ProfileImgUrl { get; set; }
        public string Login_UR_ID { get; set; }
        public string Default_Location { get; set; }
        public string Address { get; set; }
    }
}
