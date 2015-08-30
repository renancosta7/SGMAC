using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlnArCond
{
    public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
    {
       
        protected Font footer
        {
            get
            {
                BaseColor grey = new BaseColor(128, 128, 128);
                Font font = FontFactory.GetFont("Arial", 9, Font.NORMAL, grey);
                return font;
            }
        }
        
        public override void OnStartPage(PdfWriter writer, Document doc)
        {
            PdfPTable headerTbl = new PdfPTable(1);
            headerTbl.TotalWidth = doc.PageSize.Width;
            Image logo = Image.GetInstance(HttpContext.Current.Server.MapPath("/IMG/Logopdf.jpg"));
            logo.ScalePercent(50);
            PdfPCell cell = new PdfPCell(logo);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.PaddingRight = 20;
            cell.Border = 0;
            headerTbl.AddCell(cell);
            headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height - 10), writer.DirectContent);
        }

        
    }
}
