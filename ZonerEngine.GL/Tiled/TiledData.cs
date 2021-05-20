using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  [XmlRoot(ElementName = "data")]
  public class TiledData
  {
    [XmlAttribute("encoding")]
    public string Encoding { get; set; }

    [XmlText]
    public string Value { get; set; }
  }
}
