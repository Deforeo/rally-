using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using SkiaSharp;

namespace WPFRally.Infrastructure
{
    public class SpriteAtlas
    {
        private Dictionary<string, SKBitmap> _subTextures = new Dictionary<string, SKBitmap>();

        public SpriteAtlas(string atlasImagePath, string atlasXmlPath)
        {
            var fullImage = SKBitmap.Decode(atlasImagePath);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(atlasXmlPath);
            var root = xmlDoc.DocumentElement;
            foreach (XmlNode node in root.SelectNodes("SubTexture"))
            {
                string name = node.Attributes["name"].Value;
                int x = int.Parse(node.Attributes["x"].Value);
                int y = int.Parse(node.Attributes["y"].Value);
                int w = int.Parse(node.Attributes["width"].Value);
                int h = int.Parse(node.Attributes["height"].Value);
                var sub = new SKBitmap(w, h);
                using (var canvas = new SKCanvas(sub))
                {
                    canvas.DrawBitmap(fullImage, new SKRect(x, y, x + w, y + h), new SKRect(0, 0, w, h));
                }
                _subTextures[name] = sub;
            }
            fullImage.Dispose();
        }

        public SKBitmap GetTexture(string name) => _subTextures.TryGetValue(name, out var tex) ? tex : null;
    }
}
