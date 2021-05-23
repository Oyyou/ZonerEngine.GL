using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "property")]
  public class TiledProperty
  {
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("value")]
    public string Value { get; set; }
  }
}
