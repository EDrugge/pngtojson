using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace PngToJson
{
    class Program
    {
        static void Main()
        {
            var img = new Bitmap("C:\\Dev\\test\\PngToJson\\AtlasCopco.png");


            //Console.Out.WriteLine($"Height: {img.Height}");
            //Console.Out.WriteLine($"Widht: {img.Width}");

            //var p = img.GetPixel(0, 0);
            //Console.Out.WriteLine($"{p.R}, {p.G}, {p.B}");

            var pixels = new List<List<int>>();

            for (var y = 0; y < img.Height; y++)
            {
                var row = new List<int>();
                pixels.Add(row);

                for (var x = 0; x < img.Width; x++)
                {
                    var pixel = img.GetPixel(x, y);
                    row.Add(pixel.R);
                    row.Add(pixel.G);
                    row.Add(pixel.B);
                }
            }

            var json = $"{{ \"Height\" : \"{img.Height}\", \"Width\" : \"{img.Width}\", \"Data\" : [ {CreateRows(pixels)} ] }}";

            var output = "C:\\Dev\\test\\PngToJson\\AtlasCopco.json";
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            File.WriteAllText(output, json, Encoding.UTF8);

            Console.Out.WriteLine(json);

            Console.ReadKey();
        }

        private static string CreateRows(List<List<int>> rows)
        {
            return string.Join(", ", rows.Select(r => $"[ {string.Join(", ", r)} ]"));
        }
    }
}