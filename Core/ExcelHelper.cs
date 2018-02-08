using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Resources;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using OfficeOpenXml;
using System.Linq;
using iTextSharp.text;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace Core
{
    public sealed class ExcelHelper
    {
        public static void ClearData(ExcelWorksheet worksheetBD, string startCell, int startColumn)
        {
            if (worksheetBD.Cells.Last(c => c.Start.Column == startColumn).Start.Row > worksheetBD.Cells[startCell].Start.Row)
            {
                worksheetBD.Cells[startCell + ":" + worksheetBD.Cells.Last(c => c.Start.Column == startColumn).Address].Clear();
            }  
        }
    }
}
