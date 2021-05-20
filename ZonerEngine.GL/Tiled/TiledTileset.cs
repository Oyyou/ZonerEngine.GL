using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "tileset")]
  public class TiledTileset
  {
    [XmlAttribute("firstgid")]
    public int FirstGId { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("tilewidth")]
    public int TileWidth { get; set; }

    [XmlAttribute("tileheight")]
    public int TileHeight { get; set; }

    [XmlAttribute("tilecount")]
    public int TileCount { get; set; }

    [XmlAttribute("columns")]
    public int Columns { get; set; }

    [XmlElement("image")]
    public TiledImage Image { get; set; }
  }
}
