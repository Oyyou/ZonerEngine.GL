using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "object")]
  public class TiledObject
  {
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("type")]
    public string Type { get; set; }

    [XmlAttribute("x")]
    public float X { get; set; }

    [XmlAttribute("y")]
    public float Y { get; set; }

    [XmlAttribute("width")]
    public float Width { get; set; }

    [XmlAttribute("height")]
    public float Height { get; set; }
  }
}
