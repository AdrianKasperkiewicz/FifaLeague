using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Tesseract;

namespace FL.Infrastructure.OCR
{
    public class OCRReader
    {
        public String Read(byte[] byes)
        {
            byte[] tiffByte;
            string result;
            using (var inStream = new MemoryStream(byes))
            using (var outStream = new MemoryStream())
            {
                System.Drawing.Image.FromStream(inStream).Save(outStream, System.Drawing.Imaging.ImageFormat.Tiff);
                tiffByte = outStream.ToArray();
            }

                        
            using (var engine = new TesseractEngine(@"C:\tessdata", "pol", EngineMode.Default))
            {
                using (Pix img = Pix.LoadTiffFromMemory(tiffByte))
                {
                    using (var page = engine.Process(img))
                    {
                        result = page.GetText();
                    }
                }
            }

            return result;
        }
    }
    
    
}
