// using System.Drawing;
// using System.Drawing.Drawing2D;
// using System.Drawing.Imaging;
// using System.Text;
//
//
// // Text to be displayed on the image
// string inputString =
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas." +
//     "Hello, C#! Rainbows are awesome. Rainbow Pirates. Galaxies far far away. theClubhou.se. Lorem Lorem Lorem. Foo bar bas.";
//
// var sb = new StringBuilder();
//
// byte[] binaryData = Encoding.ASCII.GetBytes(inputString);
//
// foreach (byte data in binaryData)
// {
//     sb.Append(Convert.ToString(data, 2).PadLeft(8, '0'));
//     sb.Append(" ");
// }
//
// var binaryString = sb.ToString();
//
// Console.WriteLine(binaryString);
//
// // Create a Bitmap object to hold the image
// int maxWidth = 1920; // Image width in pixels
// int lineHeight = 30; // Image height in pixels
//
// using (var image = new Bitmap(maxWidth, 1000))
// {
//     using (var graphics = Graphics.FromImage(image))
//     {
//         // Set the background color (optional)
//         graphics.Clear(Color.Black);
//
//         // Define styles for individual characters
//         Font regularFont = new Font("Arial", 20, FontStyle.Regular);
//         // Font boldFont = new Font("Arial", 20, FontStyle.Bold);
//         // Font italicFont = new Font("Arial", 20, FontStyle.Italic);
//
//         int x = 0;
//         int y = 0;
//         // float x = 10;
//         // float y = height / 2;
//
//         // Split the text into separate lines
//         string[] lines = WrapText(binaryString, regularFont, maxWidth, graphics);
//
//         int rgb = 0;
//
//         foreach (string line in lines)
//         {
//             x = 0;
//
//             for (int i = 0; i < line.Length; i++)
//             {
//                 // Apply individual styles for specific characters
//                 if (rgb == 0)
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.Red, x, y);
//                 else if (rgb == 1)
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.DarkOrange, x, y);
//                 else if (rgb == 2)
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.Yellow, x, y);
//                 else if (rgb == 3)
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.Green, x, y);
//                 else if (rgb == 4)
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.RoyalBlue, x, y);
//                 else if (rgb == 5)
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.Blue, x, y);
//                 else if (rgb == 6)
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.Indigo, x, y);
//                 else
//                     graphics.DrawString(line[i].ToString(), regularFont, Brushes.Magenta, x, y);
//
//                 rgb++;
//
//                 if (rgb == 7) rgb = 0;
//
//                 // Update the x-coordinate for the next character
//                 x += (int)graphics.MeasureString(line[i].ToString(), regularFont).Width;
//             }
//
//             // graphics.DrawString(line, regularFont, Brushes.RoyalBlue, 0, y);
//             y += lineHeight;
//         }
//     }
//
//     // Save the image to a file (you can choose another format if needed)
//     string outputPath = "C:/Users/sarah.matta/RiderProjects/HackathonAug2023/output.png";
//     image.Save(outputPath, ImageFormat.Png);
//
//     // Dispose of the image and graphics objects to release resources
//     image.Dispose();
// }
//
// static string[] WrapText(string text, Font font, int maxWidth, Graphics graphics)
// {
//     string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//     string currentLine = string.Empty;
//     System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();
//
//     foreach (string word in words)
//     {
//         if (currentLine.Length == 0)
//         {
//             currentLine = word;
//         }
//         else
//         {
//             string testLine = currentLine + " " + word;
//             SizeF textSize = graphics.MeasureString(testLine, font);
//
//             if (textSize.Width <= maxWidth)
//             {
//                 currentLine = testLine;
//             }
//             else
//             {
//                 lines.Add(currentLine);
//                 currentLine = word;
//             }
//         }
//     }
//
//     if (!string.IsNullOrEmpty(currentLine))
//     {
//         lines.Add(currentLine);
//     }
//
//     return lines.ToArray();
// }