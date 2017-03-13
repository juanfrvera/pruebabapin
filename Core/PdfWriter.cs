using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace Contract
{

    /// <summary>
    /// Wrapper to access iTextSharp
    /// </summary>
    class _PdfWriter
    {
        #region ENUMs
        public enum PaperSize
        {
            LetterUS,
            LegalUS,
            A4,
                // a large number of other PDF sizes are not listed here.
                // If you add any, be sure to update DoCvtToPageSize(...)
            _COUNT  //must be last
        }

        public enum TypeFace
        {
            Times,
            Arial,
            Courier,

            _COUNT  //must be last
        }

        public enum ViewLayout
        {
            OnePage = iTextSharp.text.pdf.PdfWriter.PageLayoutSinglePage,
            TwoPage = iTextSharp.text.pdf.PdfWriter.PageLayoutTwoColumnLeft
            //PdfWriter.PageLayoutSinglePage - Display one page at a time. 
            //PdfWriter.PageLayoutOneColumn - Display the pages in one column. 
            //PdfWriter.PageLayoutTwoColumnLeft - Display the pages in two columns, with oddnumbered pages on the left. 
            //PdfWriter.PageLayoutTwoColumnRight - Display the pages in two columns, with oddnumbered pages on the right. 
        }

        public enum ViewMode
        {
            Default
            //PdfWriter.PageModeUseNone - Neither document outline nor thumbnail images visible. 
            //PdfWriter.PageModeUseOutlines - Document outline visible. 
            //PdfWriter.PageModeUseThumbs - Thumbnail images visible. 
            //PdfWriter.PageModeFullScreen - Full-screen mode, with no menu bar, window controls, or any other window visible. 
        }
        #endregion //ENUMs

        #region MEMBER VARIABLEs

        private string msFilePDF = "";
        
        private string msMsg = "";
        private bool mbRet = false;
        private string msEOL = Environment.NewLine;

        private float mfWidthScaleFactor = 1.0f;
        private bool mbApplyAlternatingColors = !true;

        //---------------------------------------------------------------
        // Document Summary
        //---------------------------------------------------------------
        private string msDocTitle = "";
        private string msDocAuthor = "";
        private string msDocSubject = "";
        private string msDocKeywords = "";

        //---------------------------------------------------------------
        // View Options
        //---------------------------------------------------------------
        private bool mbView2PageLayout = false;
        private bool mbViewToolbar = true;
        private bool mbViewMenubar = true;
        private bool mbViewWindowUI = true;
        private bool mbViewResizeToFit = true;
        private bool mbViewCenterOnScreen = true;
        private PaperSize menShowPaperSize = PaperSize.LetterUS;

        //---------------------------------------------------------------
        // Show Options
        //---------------------------------------------------------------
        private bool mbShowTitle = true;
        private bool mbShowPageNumber = true;
        private bool mbShowWatermark = true;
        private string msShowWatermarkText = "WATERMARK";
        private string msShowWatermarkFile = "watermark.png";
        private bool mbShowLandscape = true;

        //---------------------------------------------------------------
        // TypeFace Options
        //---------------------------------------------------------------
        private TypeFace menBodyTypeFace = TypeFace.Arial;
        private float mfBodyTypeSize = 10f;
        private bool mbBodyTypeStyleBold = false;
        private bool mbBodyTypeStyleItalics = false;

        private TypeFace menHeaderTypeFace = TypeFace.Arial;
        private float mfHeaderTypeSize = 10f;
        private bool mbHeaderTypeStyleBold = true;
        private bool mbHeaderTypeStyleItalics = false;

        //---------------------------------------------------------------
        // Permissions Options
        //---------------------------------------------------------------
        private bool mbEncryptionNeeded = false;
        private string msEncryptionPasswordOfCreator = "";
        private string msEncryptionPasswordOfReader = "";
        private bool mbEncryptionStrong = false;

        private bool mbAllowPrinting = true;
        private bool mbAllowModifyContents = true;
        private bool mbAllowCopy = true;
        private bool mbAllowModifyAnnotations = true;
        private bool mbAllowFillIn = true;
        private bool mbAllowScreenReaders = true;
        private bool mbAllowAssembly = true;
        private bool mbAllowDegradedPrinting = true;



        #endregion //MEMBER VARIABLEs

        #region PROPERTIES
        public PaperSize ShowPaperSize
        {
            get { return menShowPaperSize; }
            set { menShowPaperSize = value; }
        }

        public bool View2PageLayout
        {
            get { return mbView2PageLayout; }
            set { mbView2PageLayout = value; }
        }

        public bool ViewToolbar
        {
            get { return mbViewToolbar; }
            set { mbViewToolbar = value; }
        }

        public bool ViewMenubar
        {
            get { return mbViewMenubar; }
            set { mbViewMenubar = value; }
        }

        public bool ViewWindowUI
        {
            get { return mbViewWindowUI; }
            set { mbViewWindowUI = value; }
        }

        public bool ViewResizeToFit
        {
            get { return mbViewResizeToFit; }
            set { mbViewResizeToFit = value; }
        }

        public bool ViewCenterOnScreen
        {
            get { return mbViewCenterOnScreen; }
            set { mbViewCenterOnScreen = value; }
        }

        public bool ShowTitle
        {
            get { return mbShowTitle; }
            set { mbShowTitle = value; }
        }

        public bool ShowPageNumber
        {
            get { return mbShowPageNumber; }
            set { mbShowPageNumber = value; }
        }

        public bool ShowWatermark
        {
            get { return mbShowWatermark; }
            set { mbShowWatermark = value; }
        }

        public string ShowWatermarkText
        {
            get { return msShowWatermarkText; }
            set { msShowWatermarkText = value; }
        }

        public string ShowWatermarkFile
        {
            get { return msShowWatermarkFile; }
            set { msShowWatermarkFile = value; }
        }

        public bool ShowLandscape
        {
            get { return mbShowLandscape; }
            set { mbShowLandscape = value; }
        }


        //---------------------------------------------------------------
        // 
        //---------------------------------------------------------------
        public bool ApplyAlternatingColors
        {
            get { return mbApplyAlternatingColors; }
            set { mbApplyAlternatingColors = value; }
        }

        public string DocTitle
        {
            get { return msDocTitle; }
            set { msDocTitle = value; }
        }

        public string DocAuthor
        {
            get { return msDocAuthor; }
            set { msDocAuthor = value; }
        }

        public string DocSubject
        {
            get { return msDocSubject; }
            set { msDocSubject = value; }
        }

        public string DocKeywords
        {
            get { return msDocKeywords; }
            set { msDocKeywords = value; }
        }

        public float WidthScaleFactor
        {
            get { return mfWidthScaleFactor; }
            set { mfWidthScaleFactor = value; }
        }

        public string Message
        {
            get { return msMsg; }
            set { msMsg = value; }
        }

        public bool Success
        {
            get { return mbRet; }
            set { mbRet = value; }
        }

        public string Filename
        {
            get { return msFilePDF; }
            set { msFilePDF = value; }
        }

        public TypeFace FontBodyTypeFace
        {
            get { return menBodyTypeFace; }
            set { menBodyTypeFace = value; }
        }

        public float FontBodyTypeSize
        {
            get { return mfBodyTypeSize; }
            set { mfBodyTypeSize = value; }
        }

        public bool FontBodyTypeStyleBold
        {
            get { return mbBodyTypeStyleBold; }
            set { mbBodyTypeStyleBold = value; }
        }

        public bool FontBodyTypeStyleItalics
        {
            get { return mbBodyTypeStyleItalics; }
            set { mbBodyTypeStyleItalics = value; }
        }

        internal TypeFace FontHeaderTypeFace
        {
            get { return menHeaderTypeFace; }
            set { menHeaderTypeFace = value; }
        }

        public float FontHeaderTypeSize
        {
            get { return mfHeaderTypeSize; }
            set { mfHeaderTypeSize = value; }
        }

        public bool FontHeaderTypeStyleBold
        {
            get { return mbHeaderTypeStyleBold; }
            set { mbHeaderTypeStyleBold = value; }
        }

        public bool FontHeaderTypeStyleItalics
        {
            get { return mbHeaderTypeStyleItalics; }
            set { mbHeaderTypeStyleItalics = value; }
        }

        public bool EncryptionNeeded
        {
            get { return mbEncryptionNeeded; }
            set { mbEncryptionNeeded = value; }
        }

        public string EncryptionPasswordOfCreator
        {
            get { return msEncryptionPasswordOfCreator; }
            set { msEncryptionPasswordOfCreator = value; }
        }

        public string EncryptionPasswordOfReader
        {
            get { return msEncryptionPasswordOfReader; }
            set { msEncryptionPasswordOfReader = value; }
        }

        public bool EncryptionStrong
        {
            get { return mbEncryptionStrong; }
            set { mbEncryptionStrong = value; }
        }

        public bool AllowPrinting
        {
            get { return mbAllowPrinting; }
            set { mbAllowPrinting = value; }
        }

        public bool AllowModifyContents
        {
            get { return mbAllowModifyContents; }
            set { mbAllowModifyContents = value; }
        }

        public bool AllowCopy
        {
            get { return mbAllowCopy; }
            set { mbAllowCopy = value; }
        }

        public bool AllowModifyAnnotations
        {
            get { return mbAllowModifyAnnotations; }
            set { mbAllowModifyAnnotations = value; }
        }

        public bool AllowFillIn
        {
            get { return mbAllowFillIn; }
            set { mbAllowFillIn = value; }
        }

        public bool AllowScreenReaders
        {
            get { return mbAllowScreenReaders; }
            set { mbAllowScreenReaders = value; }
        }

        public bool AllowAssembly
        {
            get { return mbAllowAssembly; }
            set { mbAllowAssembly = value; }
        }

        public bool AllowDegradedPrinting
        {
            get { return mbAllowDegradedPrinting; }
            set { mbAllowDegradedPrinting = value; }
        }

        #endregion //PROPERTIES
             


        #region Helper methods
          
        public void CreateEmpty(Stream stream)
        {
            Document document = new Document(PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(document,stream);
            document.Open();
            document.Add(new Paragraph("Nothing to display"));           
            document.Close();
        }
        private string DoCvtToFontName(TypeFace enTypeFace)
        {
            string fontName;
            switch (enTypeFace)
            {
                default:
                case TypeFace.Arial:fontName = FontFactory.HELVETICA;break;
                case TypeFace.Times:fontName = FontFactory.TIMES_ROMAN;break;
                case TypeFace.Courier:fontName = FontFactory.COURIER;break;
            }
            return fontName;
        }
        private int DoCvtToStyle(bool bBold, bool bItalics)
        {
            int fontStyle = 0;
            if (bBold) fontStyle |= Font.BOLD;
            if (bItalics)fontStyle |= Font.ITALIC;
            return fontStyle;
        }
        private bool DoSetViewerPreferences(iTextSharp.text.pdf.PdfWriter writer)
        {
            bool bRet = true;

            int nViewerPreferences = 0;
            
            if (this.mbView2PageLayout)
                nViewerPreferences |= iTextSharp.text.pdf.PdfWriter.PageLayoutTwoColumnLeft;
            
            if (this.mbViewCenterOnScreen)
                nViewerPreferences |= iTextSharp.text.pdf.PdfWriter.CenterWindow;
            
            if (!this.mbViewMenubar)
                nViewerPreferences |= iTextSharp.text.pdf.PdfWriter.HideMenubar;
            
            if (this.mbViewResizeToFit)
                nViewerPreferences |= iTextSharp.text.pdf.PdfWriter.FitWindow;
            
            if (!this.mbViewToolbar)
                nViewerPreferences |= iTextSharp.text.pdf.PdfWriter.HideToolbar;
            
            if (!this.mbViewWindowUI)
                nViewerPreferences |= iTextSharp.text.pdf.PdfWriter.HideWindowUI;
            
            writer.ViewerPreferences = nViewerPreferences;

            return bRet;
        }
        private bool DoSetViewerPermissions(iTextSharp.text.pdf.PdfWriter writer)
        {
            bool bRet = true;

            //--- init the container for the various bit flags
            int permissions = 0;

            if (this.mbAllowPrinting)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowPrinting;
            else
                this.mbEncryptionNeeded = true;

            if (this.mbAllowModifyContents)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowModifyContents;
            else
                this.mbEncryptionNeeded = true;

            if (this.mbAllowCopy)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowCopy;
            else
                this.mbEncryptionNeeded = true;

            if (this.mbAllowModifyAnnotations)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowModifyAnnotations;
            else
                this.mbEncryptionNeeded = true;

            if (this.mbAllowFillIn)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowFillIn;
            else
                this.mbEncryptionNeeded = true;

            if (this.mbAllowScreenReaders)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowScreenReaders;
            else
                this.mbEncryptionNeeded = true;

            if (this.mbAllowAssembly)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowAssembly;
            else
                this.mbEncryptionNeeded = true;

            if (this.mbAllowDegradedPrinting)
                permissions |= iTextSharp.text.pdf.PdfWriter.AllowDegradedPrinting;
            else
                this.mbEncryptionNeeded = true;

            // NOTE: Even if the caller has not set passwords, for any of
            // the restrictions to take effect, the PDF has to be encrypted
            // See http://itextsharp.sourceforge.net/tutorial/ch01.html for details
            if (this.mbEncryptionNeeded)
            {
                writer.SetEncryption(this.mbEncryptionStrong
                                    , this.msEncryptionPasswordOfReader
                                    , this.msEncryptionPasswordOfCreator
                                    , permissions);
            }

            return bRet;
        }
        private bool DoAddMetaData(Document document)
        {
            bool bRet = true;
            if (document != null)
            {
                // step 3: we add some metadata and open the document
                //document.AddTitle(this.ReportInfo.Title);
                //document.AddSubject(this.ReportInfo.Subject);
                //document.AddKeywords(this.ReportInfo.Keywords);
                document.AddCreator("Ingematica");
                document.AddAuthor("Ingematica");
                document.AddHeader("Expires", "0");
            }
            else
            {
                bRet = false;
            }

            return bRet;
        }
        private iTextSharp.text.Rectangle DoCvtToPageSize(PaperSize enPaperSize)
        {
            iTextSharp.text.Rectangle pageSize;
            switch (enPaperSize)
            {
                default:
                    pageSize = iTextSharp.text.PageSize.LETTER;
                    break;
                case PaperSize.LegalUS:
                    pageSize = iTextSharp.text.PageSize.LEGAL;
                    break;
                case PaperSize.A4:
                    pageSize = iTextSharp.text.PageSize.A4;
                    break;
            }

            return pageSize;
        }

        #endregion //Helper methods
        #region XmlStore
        public void Write(Stream stream,DataTable dataSource)
        {
            // step 1: creation of a document-object
            // creation of the document with a certain size and certain margins
            // NOTE: We will use the default margins (36 pts on each edge)
            Rectangle mPageSize = this.DoCvtToPageSize(this.menShowPaperSize);
            if (this.mbShowLandscape) mPageSize = mPageSize.Rotate();
            Document document = new Document(mPageSize);
            // step 2:
            // we create a writer that listens to the document
            // and directs a PDF-stream to a file
            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            // step 2a: BEFORE we open the document, MUST set "view" preferences 
            this.DoSetViewerPreferences(writer);
            // step 2b: BEFORE we open the document, MUST set "view" permissions 
            this.DoSetViewerPermissions(writer);
            // step 2c: BEFORE we open the document, MUST add meta data
            this.DoAddMetaData(document);
            // step 3x: now open the document
            document.Open();
            // step 4: we add content to the document (this happens in a separate method)
            // NOTE: If you want to use another datasource, you will need to
            //       write an appropriate DoLoadDocument(...) 
            //       along the same lines as this one

            document.Add(this.CreateTable(dataSource));
            // step 5: we close the document
            document.Close();
        }


        private Font fontHeader;
        private Font FontHeader
        {
            get
            {

                if (fontHeader == null)
                {
                    fontHeader = FontFactory.GetFont
                        (this.DoCvtToFontName(this.menBodyTypeFace), this.mfBodyTypeSize,
                         this.DoCvtToStyle(this.mbBodyTypeStyleBold, this.mbBodyTypeStyleItalics));
                }
                return fontHeader;
            }
        }
        private Font fontBody;
        private Font FontBody
        {
            get
            {
                if (fontBody == null)
                {
                    fontBody = FontFactory.GetFont
                        (this.DoCvtToFontName(this.menHeaderTypeFace), this.mfHeaderTypeSize,
                         this.DoCvtToStyle(this.mbHeaderTypeStyleBold, this.mbHeaderTypeStyleItalics));
                }
                return fontBody;
            }
        }
        private Phrase Phrase(string text, Font font)
        {
            return new Phrase(new Chunk(text, font));
        }

        private PdfPTable CreateTable(DataTable dataSource)
        {
            if (dataSource.Rows.Count == 0)
                return null;

            // as we have data, we can create a PDFPTable
            PdfPTable pdfPTable = new PdfPTable(dataSource.Columns.Count);
            // define the column headers, sizes, etc.
            pdfPTable.DefaultCell.Padding = 3;  //in Points
            // Set Column Widths 
            List<float> columnsSize = new List<float>(dataSource.Columns.Count);
            foreach (DataColumn dataColumn in dataSource.Columns)
                columnsSize.Add(DataHelper.ColumnSize(dataColumn));
            pdfPTable.SetWidths(columnsSize.ToArray());
            // Set Column Header Cell Attributes                     
            pdfPTable.DefaultCell.BorderWidth = 1;
            pdfPTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // Set Column Header Text
            foreach (DataColumn dataColumn in dataSource.Columns)
                pdfPTable.AddCell(Phrase(dataColumn.ColumnName, this.FontHeader));
            pdfPTable.HeaderRows = 1;
            // Set the Data (i.e., rows)
            int colCount = dataSource.Columns.Count;


            int i = 1;
            foreach (DataRow datarow in dataSource.Rows)
            {
                if (mbApplyAlternatingColors && (i % 2 == 1))
                    pdfPTable.DefaultCell.GrayFill = 0.9f;  //very light gray 
                foreach (DataColumn dataColumn in dataSource.Columns)
                {
                    pdfPTable.AddCell(Phrase(datarow[dataColumn].ToString(), this.FontBody));                   
                }
                if (mbApplyAlternatingColors && (i % 2 == 1))
                    pdfPTable.DefaultCell.GrayFill = 1.0f;  //white  
                else
                    pdfPTable.DefaultCell.GrayFill = 9.0f;  //white    
                i++;
            }
            return pdfPTable;
        }  

        #endregion //XmlStore
    }
}
