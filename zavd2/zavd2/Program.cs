using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Drawing;

namespace zavd2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Directory.GetFiles(@"D:\University\ООП\4 laba\zavd2\zavd2\files\");
            string[] names = Directory.GetFiles(@"D:\University\ООП\4 laba\zavd2\zavd2\files\").Select(Path.GetFileName).ToArray();
            Regex regexExtForImage = new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    if (regexExtForImage.IsMatch(Path.GetExtension(arr[i])))
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile(arr[i]);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        bitmap.Save(@"D:\University\ООП\4 laba\zavd2\zavd2\files\" + names[i].Split('.')[0] + "-mirrored.gif", ImageFormat.Gif);
                        Console.WriteLine("New photo has been created and saved.");
                    }
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Damaged file.");
                }
            }
            Console.ReadKey();
        }
    }
}