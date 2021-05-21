using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZonerEngine.GL.Tiled
{
  public class TiledReader
  {
    private XmlSerializer _serializer = new XmlSerializer(typeof(TiledMap));

    private ContentManager _content;

    public TiledReader(ContentManager content)
    {
      _content = content;
    }

    public TiledMap Read(string tmxFile)
    {
      var newPath = Path.Combine("content", tmxFile);

      if (!File.Exists(newPath))
        throw new ApplicationException($"File: '{tmxFile}' doesn't exist");

      using (var fileStream = new FileStream(newPath, FileMode.Open))
      {
        var tiledMap = (TiledMap)_serializer.Deserialize(fileStream);
        tiledMap.Path = tmxFile;
        return tiledMap;
      }
    }

    public List<List<int>> GetLayerArray(TiledLayer layer)
    {
      var lists = layer.Data.Value.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

      return lists.Select(c => c.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(v => int.Parse(v)).ToList()).ToList();
    }

    public Texture2D GetTilemapTexture(TiledMap map)
    {
      var path = Path.GetDirectoryName(map.Path);
      var file = Path.Combine(path, Path.GetFileNameWithoutExtension(map.Tileset.Image.Source));

      var texture = _content.Load<Texture2D>(file);

      return texture;
    }

    public Dictionary<int, Vector2> GetTilesetPosition(TiledTileset tileset)
    {
      var result = new Dictionary<int, Vector2>();

      var height = tileset.Image.Height / tileset.TileHeight;
      var width = tileset.Image.Width / tileset.TileWidth;

      int i = 0;
      for (int y = 0; y < height; y++)
      {
        for(int x = 0; x < width; x++)
        {
          i++;

          result.Add(i, new Vector2(x * tileset.TileWidth, y * tileset.TileHeight));
        }
      }

      return result;
    }
  }
}
