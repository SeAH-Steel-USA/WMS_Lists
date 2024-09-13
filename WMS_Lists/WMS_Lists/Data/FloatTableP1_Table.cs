using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
namespace WMS_Lists.Data
{
    public class FloatTableP1_Table
    {
        public DateTime? DateAndTime { get; set; }
        public short? Millitm { get; set; }
        public short? TagIndex { get; set; }
        public double? Val { get; set; }
        public char? Status { get; set; }
        public char? Marker { get; set; }
    }
}
