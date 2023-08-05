using System.Drawing;
using System.Drawing.Imaging;
using System.Text;


// Text to be displayed on the image
string inputString =
    @"In the heart of Augusta, Georgia's embrace,
     Where minds converge, and dreams take chase,
     TheClubhou.se stands, a beacon of light,
     Uniting innovators, from morning to night.

     A hackathon blooms, an event of grand scale,
     Where brilliance and code, they shall unveil,
     In the coworking space, ideas interlace,
     A symphony of talent, each one finds their place.

     With laptops aglow and keyboards at play,
     Tech wizards embark on this coding ballet,
     From sunrise to dusk, their passion won't fade,
     As lines of code dance, and new worlds are made.

     In theClubhou.se's halls, creativity soars,
     A melting pot of visionaries, ambition roars,
     Entrepreneurs, designers, and programmers unite,
     To shape a tomorrow that's shining so bright.

     Through coffee-fueled days and laughter-filled nights,
     They weave magic and code, merging their sights,
     Collaboration ignites, sparks light up the air,
     As ideas take flight, in this hackathon affair.

     In the midst of the challenge, friendships bloom,
     As they code side by side, in a shared tech room,
     Encouragement abounds, and knowledge is shared,
     Together they strive, their skills finely pared.

     Amidst the midnight oil, and the clock's racing hand,
     Breakthroughs arise, like stars in the night's command,
     With a common purpose, they push and explore,
     To create solutions, never seen before.

     When dawn breaks the horizon, a sense of elation,
     TheClubhou.se's hackathon, a testament to creation,
     For in this gathering, ideas intertwine,
     Fueling a future that will surely shine.

     So raise your glasses, in a toast to the feat,
     TheClubhou.se's hackathon, where magic's complete,
     In Augusta, Georgia, a haven for tech,
     Where collaboration thrives, and innovation's a spec.";

var sb = new StringBuilder();

byte[] binaryData = Encoding.ASCII.GetBytes(inputString);

foreach (byte data in binaryData)
{
    sb.Append(Convert.ToString(data, 2).PadLeft(8, '0'));
    sb.Append(" ");
}

var binaryString = sb.ToString();

// Console.WriteLine(binaryString);

// Create a Bitmap object to hold the image
int maxWidth = 1920; // Image width in pixels
int lineHeight = 20; // Image height in pixels

using (var image = new Bitmap(maxWidth, 1000))
{
    using (var graphics = Graphics.FromImage(image))
    {
        // Set the background color (optional)
        graphics.Clear(Color.Black);

        // Define styles for individual characters
        Font regularFont = new Font("Monospace", 16, FontStyle.Regular);
        Font boldFont = new Font("Monospace", 18, FontStyle.Bold);
        Font italicFont = new Font("Monospace", 22, FontStyle.Italic);

        int x = 0;
        int y = 0;

        // Split the text into separate lines
        string[] lines = WrapText(binaryString, regularFont, maxWidth, graphics);

        int rgb = 0;

        foreach (string line in lines)
        {
            x = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (rgb == 0)
                    graphics.DrawString(line[i].ToString(), italicFont, Brushes.DarkMagenta, x, y);
                else if (rgb == 1)
                    graphics.DrawString(line[i].ToString(), regularFont, Brushes.DarkOrange, x, y);
                else if (rgb == 2)
                    graphics.DrawString(line[i].ToString(), regularFont, Brushes.Gold, x, y);
                else if (rgb == 3)
                    graphics.DrawString(line[i].ToString(), regularFont, Brushes.Green, x, y);
                else if (rgb == 4)
                    graphics.DrawString(line[i].ToString(), boldFont, Brushes.RoyalBlue, x, y);
                else if (rgb == 5)
                    graphics.DrawString(line[i].ToString(), boldFont, Brushes.Blue, x, y);
                else if (rgb == 6)
                    graphics.DrawString(line[i].ToString(), regularFont, Brushes.Indigo, x, y);
                
                rgb++;
                
                if (rgb == 7) rgb = 0;

                // Update the x-coordinate for the next character
                x += (int)graphics.MeasureString(line[i].ToString(), regularFont).Width;
            }

            y += lineHeight;
        }
    }

    string outputPath = "C:/Users/sarah.matta/RiderProjects/HackathonAug2023/output.png";
    image.Save(outputPath, ImageFormat.Png);

    // Dispose of the image and graphics objects to release resources
    image.Dispose();
}

static string[] WrapText(string text, Font font, int maxWidth, Graphics graphics)
{
    string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    string currentLine = string.Empty;
    System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();

    foreach (string word in words)
    {
        if (currentLine.Length == 0)
        {
            currentLine = word;
        }
        else
        {
            string testLine = currentLine + " " + word;
            SizeF textSize = graphics.MeasureString(testLine, font);

            if (textSize.Width <= maxWidth)
            {
                currentLine = testLine;
            }
            else
            {
                lines.Add(currentLine);
                currentLine = word;
            }
        }
    }

    if (!string.IsNullOrEmpty(currentLine))
    {
        lines.Add(currentLine);
    }

    return lines.ToArray();
}