using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "group")]
  public class TiledGroup
  {
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlElement("layer")]
    public List<TiledLayer> Layers { get; set; }
  }
}
