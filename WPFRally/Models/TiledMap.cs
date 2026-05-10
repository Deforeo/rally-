using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using WPFRally.Infrastructure;

namespace WPFRally.Models
{
    public class TiledMap
    {
        private SpriteAtlas _atlas;
        private TiledMapData _data;

        public TiledMap(SpriteAtlas atlas, TiledMapData data)
        {
            _atlas = atlas;
            _data = data;
        }

        public void Draw(SKCanvas canvas, Camera camera, float viewportWidth, float viewportHeight)
        {
            SKRect visible = camera.GetVisibleWorldRect(viewportWidth, viewportHeight);
            int startCol = Math.Max(0, (int)(visible.Left / _data.TileWidth));
            int endCol = Math.Min(_data.WidthInTiles, (int)(visible.Right / _data.TileWidth) + 1);
            int startRow = Math.Max(0, (int)(visible.Top / _data.TileHeight));
            int endRow = Math.Min(_data.HeightInTiles, (int)(visible.Bottom / _data.TileHeight) + 1);

            for (int row = startRow; row < endRow; row++)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    string tileName = _data.Tiles[row][col];
                    var texture = _atlas.GetTexture(tileName);
                    if (texture == null) continue;

                    float worldX = col * _data.TileWidth;
                    float worldY = row * _data.TileHeight;
                    SKPoint screen = camera.WorldToScreen(new SKPoint(worldX, worldY), viewportWidth, viewportHeight);
                    canvas.DrawBitmap(texture, screen.X, screen.Y);
                }
            }
        }
    }
}
