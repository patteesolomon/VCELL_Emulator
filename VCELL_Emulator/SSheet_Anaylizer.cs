using System;
using System.Drawing;

namespace VCELL_Emulator
{
         //new Image().Jpeg;
    /// <summary>
    /// this class is for spriting 
    /// </summary>
    internal class SSheet_Anaylizer
    {
        int width, height; // this shit goes in a fileoutput
        // and this calculates bounds

        int x, y, xoff, yoff;
        InputData data = new();
        
        int a, r, g, b;

        // borders for each pane
        int xB, yB;

        public int XB { get { return xB; } set { xB = value; } }

        public int YB { get { return yB; } set { yB = value; } }

        public SSheet_Anaylizer(int x, int y, int xoff,
            int yoff, int a, int r, int g, int b)
        {
            ImgIntComparison(x, y,  xoff,
             yoff,  a,  r,  g,  b);
            // dont use a background
            // analyze the integers from the file.
            // color // restrict palette
            // then draw all pixels
            
            Draw( x,  y,  xoff,  yoff,
             a,  r,  g,  b);
        }

        /// <summary>
        /// this is for comparing img 1 and img 2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xoff"></param>
        /// <param name="yoff"></param>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        private static void ImgIntComparison(int x,
            int y, int xoff, int yoff, int a, 
            int r, int g, int b)
        {
            // maybe use some new properties to save 
            // some of theses values

            //1 compare both images width and length
            //2 find a pane border within both
            //3 count how many panes are needed to draw
        }

        /// <summary>
        /// This does the magic for image2 as a print
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="xoff"></param>
        /// <param name="yoff"></param>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public System.Drawing.Image Draw
            (int x, int y, int xoff, int yoff,
            int a, int r, int g, int b)
        {
            var width = data.Image1.Width;
            var height = data.Image1.Height;

            Bitmap bitmap1 = new(data.Image1);

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
#pragma warning disable CA1416 // Validate platform compatibility
                    bitmap1.SetPixel(x + xoff,
                    y + yoff, Color.FromArgb(a, r, g, b));
#pragma warning restore CA1416 // Validate platform compatibility
                }
#pragma warning disable CA1416 // Validate platform compatibility
                bitmap1.Save(data.GetFnS1());
#pragma warning restore CA1416 // Validate platform compatibility
                
            }
            return data.Image1;
        }

        public System.Drawing.Image 
            PaneDiv(System.Drawing.Image diV)
        {
            // each pane that exists is about 960 x 960
            // bc this is too fucking annoying when it comes
            // to spacing this shit out.
            // change these if you feel like You need this shit
            // to be smaller or larger
            XB = 160; // <--
            YB = 160; // <--
            int Rxb = XB / 2; // offset for the centering
            int Ryb = YB / 2; // offset for the centering

            //diV.
            // put shit here
            return diV;
        }
    }
}
