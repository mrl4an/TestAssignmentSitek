using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbfDataReader;
using DocumentFormat.OpenXml.Office2013.Word;
using TestAssignmentSitek.DataModel;

namespace TestAssignmentSitek.View
{
    internal class DataBaseProcessing
    {
        public static List<ObjectInfo> SortArray(List<ObjectInfo> objectInfos)
        {
            objectInfos.Sort((x, y) =>
            {
                int lastComparison = x.name.CompareTo(y.name);
                if (lastComparison == 0)
                {
                    return x.name_type.CompareTo(y.name_type);
                }
                return lastComparison;
            });
            return objectInfos; 
        }
        public static List<ObjectInfo> ObjectInfos()
        {
            var result = new List<ObjectInfo>();
            using (var dbfReader = new DbfDataReader.DbfDataReader(config.CurrentDirecory + @"\NAMEMAP.DBF"))
            {
                while (dbfReader.Read())
                {
                    result.Add(new ObjectInfo(dbfReader.GetValue(3).ToString(), dbfReader.GetValue(2).ToString()));
                }
            }
            result = SortArray(result);
            return result; 
        }
    }
}
