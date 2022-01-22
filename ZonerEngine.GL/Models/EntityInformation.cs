using System;
using System.Collections.Generic;
using System.Text;

namespace ZonerEngine.GL.Models
{
  public class EntityInformation
  {
    public class Content
    {
      public string Header { get; set; }

      public string[] Values { get; set; }

      public bool IsValid => Values.Length > 0; // ?
    }

    public string Header { get; set; }

    public List<Content> Sections = new List<Content>();
  }
}
