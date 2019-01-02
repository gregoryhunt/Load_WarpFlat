using Load_WarpFlat.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Load_WarpFlat
{
    public static class Extensions
    {
        public static T[] Slice<T>(this T[] source, int index, int length)
        {
            T[] slice = new T[length];
            Array.Copy(source, index, slice, 0, length);
            return slice;
        }
        public static short BytesToShort(this byte[] source)
        {
            return BitConverter.ToInt16(source, 0);
        }
        public static int BytesToLong(this byte[] source)
        {
            return BitConverter.ToInt32(source, 0);
        }
        public static string BytesToString(this byte[] source)
        {
            var value = new string(source.Select(b => (char)b).ToArray());
            // \u000D \u000A
            return Regex.Replace(value, @"[^\u0020-\u007E|\u000D|\u000A]", string.Empty).TrimEnd();
        }
        public static BsonDocument UnflattedObject(byte[] row, List<SpdataMapItem> spdataMap)
        {
            BsonDocument bson = new BsonDocument();
            foreach (var item in spdataMap)
            {
                switch (item.Type)
                {
                    case FieldType.F_BOOL:
                        break;
                    case FieldType.F_DATE:
                        break;
                    case FieldType.F_DBIIISTRING:
                        break;
                    case FieldType.F_FLOAT:
                        break;
                    case FieldType.F_INT:
                        break;
                    case FieldType.F_LDECIMAL:
                        break;
                    case FieldType.F_LONG:
                        break;
                    case FieldType.F_MENU:
                        break;
                    case FieldType.F_RDECIMAL:
                        break;
                    case FieldType.F_STRING:
                        break;
                    case FieldType.F_TIME:
                        break;
                    case FieldType.N_STRING:
                        break;
                    case FieldType.PE_PHONE:
                        break;
                    case FieldType.PE_PHONE7:
                        break;
                    case FieldType.PE_STRINGB:
                        break;
                    case FieldType.PE_ZIP:
                        break;
                    case FieldType.PE_ZIP5:
                        break;
                    case FieldType.SP_2000DATE:
                        break;
                    case FieldType.SP_2000SDATE:
                        break;
                    case FieldType.SP_COMP3:
                        break;
                    case FieldType.SP_RCOMP:
                        break;
                    case FieldType.W7_RICHEDIT:
                        break;
                    default:
                        break;
                }
            }
            return null;
        }

    }
}
