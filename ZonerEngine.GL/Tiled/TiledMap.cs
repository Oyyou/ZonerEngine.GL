using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "map")]
  public class TiledMap
  {
    [XmlIgnore]
    public string Path { get; set; }

    [XmlAttribute("orientation")]
    public string Orientation { get; set; }

    [XmlAttribute("renderorder")]
    public string RenderOrder { get; set; }

    [XmlAttribute("width")]
    public int Width { get; set; }

    [XmlAttribute("height")]
    public int Height { get; set; }

    [XmlAttribute("tilewidth")]
    public int TileWidth { get; set; }

    [XmlAttribute("tileheight")]
    public int TileHeight { get; set; }

    [XmlElement("tileset")]
    public TiledTileset Tileset { get; set; }

    [XmlElement("layer")]
    public List<TiledLayer> Layers { get; set; }
  }
}
