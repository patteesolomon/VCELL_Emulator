using Microsoft.ML;
using System.Drawing;
using System.IO;

namespace VCELL_Emulator
{
    internal class InputData
    {
        #region vars
        private const string Filename = "image/Bias1/img.png";
        private const string Fn2 = "image/SpriteS.png";
        private static IDataView dataView;
        private static readonly Think thought;
        private static Think[] thoughts;
        private Stream stream;
        private Stream stream2;

        private int x1, y1, x2, y2;

        public Stream Stream { get => stream; set => stream = value; }
        public Stream Stream2 { get => stream2; set => stream2 = value; }
        
        internal static Think Thought => thought;

        private static IDataLoader<Image> datav1;
        private static IDataLoader<Image> datav2;
        private static IDataLoader<Stream> datar1;
        private static IDataLoader<Stream> datar2;
        internal static Think[] Thoughts { get => thoughts; set => thoughts = value; }
        public int X1 { get => x1; set => x1 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y2 { get => y2; set => y2 = value; }
        public IDataLoader<Image> Datav1 { get => datav1; set => datav1 = value; } // load
        public IDataLoader<Image> Datav2 { get => datav2; set => datav2 = value; } // these 

        public IDataLoader<Stream> Datar1 { get => datar1; set => datar1 = value; } // mfs for the 
        public IDataLoader<Stream> Datar2 { get => datar2; set => datar2 = value; } // ml model

        public static string Filename1 => Filename;

        public static string Fn21 => Fn2;

        public Image Image { get => image; set => image = value; }
        public Image Image1 { get => image1; set => image1 = value; }

        public string GetFnS1() => Filename1;

        public string GetFnS2() => Fn2;

        Image image = Image.FromFile(Filename1);
        
        Image image1 = Image.FromFile(Fn21);

        #endregion

        internal InputData()
        {
           
            byte [] data = new byte[image.Width * image.Height];
            byte [] data2 = new byte[image1.Width * image1.Height];

            if (stream.CanRead)
            {
                X1 = image.Width;
                Y1 = image.Height;
                X2 = image1.Width;
                Y2 = image1.Height;

                Stream.ReadAsync(data, 0, data.Length); 
                Stream2.ReadAsync(data2, 0, data2.Length);

                Datav1.Load(image);
                Datav2.Load(image1);
                Datar1.Load(Stream);
                Datar2.Load(Stream2);
            }
            // lastly use the dataView to access the Images needed
        }
    }
}