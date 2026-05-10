using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace WPFRally.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float WorldWidth { get; set; }
        public float WorldHeight { get; set; }
        public SKPoint StartPosition { get; set; }
        public SKPoint FinishPosition { get; set; }
        public List<ObstacleData> Obstacles { get; set; }
        public List<CheckpointData> Checkpoints { get; set; } = new List<CheckpointData>();
        public string BackgroundSpritePath { get; set; } // фон трассы
        public TiledMapData MapData { get; set; }
    }

    public class ObstacleData
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string SpritePath { get; set; }
    }
    public class CheckpointData
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Index { get; set; }
    }

    public class TiledMapData
    {
        public int TileWidth { get; set; } = 128;
        public int TileHeight { get; set; } = 128;
        public int WidthInTiles { get; set; }
        public int HeightInTiles { get; set; }
        public List<List<string>> Tiles { get; set; }  // [row][col]
    }
}
