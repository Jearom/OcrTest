using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Tesseract;

namespace OcrTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            //return string.Format("You entered: {0}", value);
            return test1();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string test1()
        {
            string path = @"C:\Users\Jearom\Desktop\Baris_cv.pdf";
            var image = new Bitmap(@"C:\Users\Jearom\Desktop\sayisal.jpg");



            var ocr = new Tesseract.TesseractEngine(@"F:\TestProjects\OcrTest\OcrTest\tessdata", "eng", EngineMode.Default);

            ocr.SetVariable("tessedit_char_whitelist","01234567890");
            var data = ocr.Process(image);

            

            return data.GetText();
        }

    }
}
