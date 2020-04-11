using DBAccess.Attributes;
using System;

namespace DBAccess
{
    [TableName("myCoolTable")]
    public class CoolTable : Table
    {
        [PrimaryKey]
        [Key("myId")]
        public int Id { get; set; }

        [Key("myName")]
        public string Name { get; set; }

        public Nullable<int> Age { get; set; }
    }
}
