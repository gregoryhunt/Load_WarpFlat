using System;
using System.Collections.Generic;
using System.Text;

namespace Load_WarpFlat.Model
{
    public enum FieldType { F_BOOL, F_DATE, F_DBIIISTRING, F_FLOAT, F_INT, F_LDECIMAL, F_LONG, F_MENU, F_RDECIMAL, F_STRING, F_TIME, N_STRING, PE_PHONE, PE_PHONE7, PE_STRINGB, PE_ZIP, PE_ZIP5, SP_2000DATE, SP_2000SDATE, SP_COMP3, SP_RCOMP, W7_RICHEDIT }

    public class SpdataMapItem
    {
        public string Name { get; set; }
        public int StartingPosition { get; set; }
        public int Length { get; set; }
        public FieldType Type { get; set; }
    }
}
