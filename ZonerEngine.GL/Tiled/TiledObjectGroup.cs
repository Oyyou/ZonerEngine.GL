using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "objectgroup")]
  public class TiledObjectGroup
  {
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlElement("object")]
    public List<TiledObject> Objects { get; set; }
  }
}
