using DBAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DBAccess
{
    public class Repository<TTable> where TTable : Table
    {
        public string TableName { get; private set; }

        private readonly Type currentTableType;

        public Repository()
        {
            currentTableType = typeof(TTable);

            TableNameAttribute tableNameAttrib = currentTableType.GetCustomAttribute(typeof(TableNameAttribute), true) as TableNameAttribute;

            TableName = tableNameAttrib.Name;
        }

        public string Select()
        {
            PropertyInfo[] properties = currentTableType.GetProperties();

            Dictionary<string, bool> tableMembers = new Dictionary<string, bool>();

            foreach (var prop in properties)
            {
                var isPrimary = prop.GetCustomAttribute(typeof(PrimaryKeyAttribute)) != null;
                var keyNameAttribute = (prop.GetCustomAttribute(typeof(KeyAttribute)) as KeyAttribute);

                var name = keyNameAttribute?.Name ?? prop.Name;

                tableMembers.Add(name, isPrimary);
            }

            var selectQuery = $"SELCT {string.Join(",", tableMembers.Keys)} FROM {TableName}";

            return selectQuery;

            //Dictionary<string, bool> tableMembers = properties.ToDictionary(
            //    prop => prop.Name, 
            //    prop => prop.GetCustomAttribute(typeof(PrimaryKeyAttribute), true) != null
            //);
        }

        public string Insert(TTable entity)
        {
            // INSERT INTO <TABLENAME>(<FIELDS_SEPARATE_BY_COMMA>) VALUES(<VALUES_SEPARATED_BY_COMMA_FROM_ENTITY>)
            // CoolTable: INSERT INTO myCoolTable(myId, myName) VALUES(entity.Id, entity.Name)
            throw new NotImplementedException();
        }

        public string Update(TTable entity)
        {
            // UPDATE <TABLENAME> SET <FIELD> = "<ENTITY.FIELD_VALUE>" WHERE <PRIMARY_KEY_FIELD> = <ENTITY.PRIMARY_FIELD_VALUE_FROM_ENTITY>
            // CoolTable: UPDATE myCoolTable SET myName = 'entity.Name' WHERE myId = 'entity.Id'
            throw new NotImplementedException();
        }

        public string Delete(TTable entity)
        {
            // primaryKeyValue is the value from entity which has the PrimaryKey attribute
            //return Delete(primaryKeyValue);
            throw new NotImplementedException();
        }

        public string Delete(int primaryId)
        {
            // DELETE FROM <TABLENAME> WHERE <PRIMARY_KEY_FIELD> = <ENTITY.PRIMARY_FIELD_VALUE_FROM_ENTITY>
            throw new NotImplementedException();
        }
    }
}
