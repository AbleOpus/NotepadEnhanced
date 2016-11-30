using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using NotepadEnhanced.AppState;
using System.Drawing;
using System.IO;
using NotepadEnhanced.Localization;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced
{
    internal class Printing : IDisposable
    {
        private readonly PrintDocument printDocument = new PrintDocument();
        private readonly PrintDialog dlgPrint = new PrintDialog();
        private readonly PlainTextBox activeTextBox;
        private List<string> lines = new List<string>();
        private int linesPrinted;

        public Printing(PlainTextBox activeTextBox)
        {
            this.activeTextBox = activeTextBox;
            dlgPrint.Document = printDocument;
            dlgPrint.AllowSelection = !string.IsNullOrEmpty(this.activeTextBox.SelectedText);
            printDocument.PrintPage += printDoc_PrintPage;
            printDocument.BeginPrint += _printDoc_BeginPrint;
            printDocument.EndPrint += delegate { lines = null; };
        }

        public void PrintRichTextDocument(string documentName)
        {
            printDocument.DocumentName = documentName;

            try
            {
                if (dlgPrint.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (InvalidPrinterException ex)
            {
                ex.ShowError();
            }
        }

        private static float GetFontHeight(Graphics graphics)
        {
            SizeF fontSize = graphics.MeasureString("ABC", Settings.Instance.Font);
            return fontSize.Height;
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(Settings.Instance.FontColor);

            if (Settings.Instance.AddTitleToPrint)
            {
                // Align left
                if (Settings.Instance.PrintTitleAlign == 0)
                {
                    e.Graphics.DrawString(lines[0], Settings.Instance.Font, brush, x, y);
                    y += GetFontHeight(e.Graphics);
                }
                // Align center
                else if (Settings.Instance.PrintTitleAlign == 1)
                {
                    float width = GetStringWidth(lines[0]);
                    float xPos = x + (GetMaxLineWidth() / 2f) - (width / 2);
                    e.Graphics.DrawString(lines[0], Settings.Instance.Font, brush, xPos, y);
                    y += GetFontHeight(e.Graphics);
                }
                // Align right
                else if (Settings.Instance.PrintTitleAlign == 2)
                {
                    float width = GetStringWidth(lines[0]);
                    float xPos = x + GetMaxLineWidth() - width;
                    e.Graphics.DrawString(lines[0], Settings.Instance.Font, brush, xPos, y);
                    y += GetFontHeight(e.Graphics);
                }

                linesPrinted++;
            }

            while (linesPrinted < lines.Count)
            {
                string line = lines[linesPrinted++];
                e.Graphics.DrawString(line, Settings.Instance.Font, brush, x, y);
                y += GetFontHeight(e.Graphics);

                if (y >= e.MarginBounds.Bottom - GetFontHeight(e.Graphics))
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
            brush.Dispose();
        }

        private void _printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (dlgPrint.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                lines = new List<string>(activeTextBox.SelectedText.Split('\n'));
            }
            else
            {
                lines = GetPrintableLines();
            }

            // This is performed after lines are built, so easy insertions is done
            // First a new line is added then on top of that a title
            if (Settings.Instance.AddTitleToPrint && activeTextBox.SafeFileName.Length > 0)
            {
                lines.Insert(0, string.Empty);
                string title = Path.GetFileNameWithoutExtension(activeTextBox.SafeFileName);
                lines.Insert(0, title);
            }
        }

        /// <summary>
        /// Gets the maximum line with in pixels, accounting the margins of the
        /// page as well as the page with
        /// </summary>
        private float GetMaxLineWidth()
        {
            if (printDocument.DefaultPageSettings.Landscape)
            {
                return printDocument.DefaultPageSettings.PaperSize.Height -
                    printDocument.DefaultPageSettings.Margins.Left -
                     printDocument.DefaultPageSettings.Margins.Right;
            }

                return printDocument.DefaultPageSettings.PaperSize.Width -
                    printDocument.DefaultPageSettings.Margins.Left -
                    printDocument.DefaultPageSettings.Margins.Right;
        }

        /// <summary>
        /// Processes the lines so they fit within the page margins.
        /// </summary>
        private List<string> GetPrintableLines()
        {
            //Get rid of carriage returns so no ovelaps occur
            string text = activeTextBox.Text.Replace("\r", string.Empty);
            float maxLineWidth = GetMaxLineWidth();
            var lines = new List<string>();
            int indexStart = 0, indexEnd = 1;

            if (activeTextBox.LinesCount.Equals(1))
            {
                lines.Add(text);
                return lines;
            }

            while (++indexEnd < text.Length)
            {
                if (text[indexEnd] == '\n')
                {
                    lines.Add(text.Substring(indexStart, indexEnd - indexStart).Trim());
                    indexEnd = indexStart = indexEnd;
                    continue;
                }

                string line = text.Substring(indexStart, indexEnd - indexStart);
                if (!(GetStringWidth(line) >= maxLineWidth)) continue;
                int splitIndex = indexEnd - 1;

                while (indexEnd-- > 0)
                {
                    if (text[indexEnd].Equals(' '))
                    {
                        int length = indexEnd - indexStart;
                        lines.Add(text.Substring(indexStart, length).Trim());
                        indexStart = indexEnd;
                        break;
                    }

                    if (indexEnd.Equals(indexStart + 1))
                    {
                        int length = splitIndex - indexStart;
                        lines.Add(text.Substring(indexStart, length).Trim());
                    }
                }
            }

            return lines;
        }

        private float GetStringWidth(string text)
        {
            using (Graphics graphics = activeTextBox.CreateGraphics())
            {
                return graphics.MeasureString(text, Settings.Instance.Font).Width;
            }
        }

        public void ShowPrintPreview()
        {
            if (printDocument.PrinterSettings.IsValid)
            {
                using (var dlgPrintPreview = new PrintPreviewDialog())
                {
                    dlgPrintPreview.ClientSize = new Size(800, 600);
                    dlgPrintPreview.Document = printDocument;
                    dlgPrintPreview.ShowDialog();
                }
            }
            else
            {
                MessageDialog.Show(Strings.MsgNoPrinter, MessageBoxIcon.Information);
            }
        }

        public void ShowPageSetupDialog()
        {
            if (!printDocument.PrinterSettings.IsValid)
            {
                MessageDialog.Show(Strings.MsgNoPrinter, MessageBoxIcon.Information);
            }
            else
            {
                using (var dlgPageSetup = new PageSetupDialog())
                {
                    dlgPageSetup.Document = printDocument;
                    dlgPageSetup.ShowDialog();
                }
            }
        }

        public void Dispose()
        {
            dlgPrint.Dispose();
            printDocument.Dispose();
        }
    }
}