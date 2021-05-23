using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "properties")]
  public class TiledProperties
  {
    [XmlElement("property")]
    public List<TiledProperty> Properties { get; set; }
  }
}
