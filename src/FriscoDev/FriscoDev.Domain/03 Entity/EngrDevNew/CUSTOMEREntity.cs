using System;

namespace FriscoDev.Domain.Entity.EngrDevNew
{
    public class CUSTOMEREntity : IEntity<CUSTOMEREntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string CS_ID { get; set; }
        public string CS_NAME { get; set; }
        public string CS_ADDRESS { get; set; }
        public decimal CS_COORDINATE_X { get; set; }
        public decimal CS_COORDINATE_Y { get; set; }
        public string CS_COUNTRY_ID { get; set; }
        public string CS_CITY_ID { get; set; }
        public int CS_POSTAL_CODE { get; set; }
        public string CS_PHONE1 { get; set; }
        public string CS_PHONE2 { get; set; }
        public string CS_CELL_PHONE1 { get; set; }
        public string CS_CELL_PHONE2 { get; set; }
        public int CS_COUNTRY_PHONE_CODE { get; set; }
        public string CS_EMAIL { get; set; }
        public string CS_TIME_ZONE { get; set; }
        public string CS_LANGUAUE_ID { get; set; }
        public bool CS_ACTIVED { get; set; }
        public DateTime? CS_ADD_TIME { get; set; }
        public DateTime? CS_UPDATE_TIME { get; set; }
    }
}
