using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestServer
{
    public class ImageMGR
    {
        List<ImageData>  lsData = new List<ImageData>();

        private ImageMGR()
        {
            
        }

        private static ImageMGR sInst = new ImageMGR();

        public static ImageMGR Inst
        {
            get { return sInst; }
        }

        public ImageData GetImage(int index)
        {
            if (lsData.Count == 0 || index >= lsData.Count)
                return null;
            return lsData[index];
        }


        public void Init()
        {
            string path = Application.StartupPath + "\\Image";
            string [] files = Directory.GetFiles(path);
            foreach (var f in files)
            {
                if(f.EndsWith(".jpg")==false)
                    continue;
                ImageData data = new ImageData(f);
                data.Load();
                lsData.Add(data);
            }
            
        }

    }

    public class ImageData
    {
        public string fileName;
        public string hexData;
        public byte[] bsData;

        public ImageData(string file)
        {
            this.fileName = file;
        }

        public void Load()
        {
            try
            {
                FileStream fs = new FileStream(this.fileName, FileMode.Open);
                bsData = new byte[fs.Length];
                fs.Read(bsData, 0, (int)fs.Length);
                fs.Close();

                hexData = StringTools.ByteArrayToHexString(bsData).Replace(" ","");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"\r\n"+ex.StackTrace);
            }
        }


    }
}
