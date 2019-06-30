namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class DeviceNamesEntity : IEntity<DeviceNamesEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int DeviceType { get; set; }
        public string Name { get; set; }
    }
}
