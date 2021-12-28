using System.ComponentModel.DataAnnotations.Schema;

namespace rest_api.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
