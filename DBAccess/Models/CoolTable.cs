using DBAccess.Attributes;
using System;

namespace DBAccess.Models
{
    [TableName("myCoolTable")]
    public class CoolTable : Table
    {
        [PrimaryKey]
        [Key("myId")]
        public Nullable<int> Id { get; set; }

        [Key("myName")]
        public string Name { get; set; }

        public Nullable<int> Age { get; set; }

        public Nullable<StatusEnum> Status { get; set; }
    }
}
