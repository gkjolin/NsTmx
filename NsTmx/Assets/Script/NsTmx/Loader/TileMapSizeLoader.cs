﻿using System;
using System.IO;
using TmxCSharp.Models;
using XmlParser;
using Utils;

namespace TmxCSharp.Loader
{
    public static class TileMapSizeLoader
    {
		public static TileMapSize LoadTileMapSize(Stream stream)
		{
			if (stream == null || stream.Length <= 0)
				return null;
			
			int width = FilePathMgr.Instance.ReadInt(stream);
			int height = FilePathMgr.Instance.ReadInt(stream);
			int tileWidth = FilePathMgr.Instance.ReadInt(stream);
			int tileHeight = FilePathMgr.Instance.ReadInt(stream);

			return new TileMapSize(width, height, tileWidth, tileHeight);
		}

		public static void SaveToBinary(Stream stream, TileMapSize size)
		{
			if (stream == null || size == null)
				return;
			
			FilePathMgr.Instance.WriteInt(stream, size.Width);
			FilePathMgr.Instance.WriteInt(stream, size.Height);
			FilePathMgr.Instance.WriteInt(stream, size.TileWidth);
			FilePathMgr.Instance.WriteInt(stream, size.TileHeight);
		}

        public static TileMapSize LoadTileMapSize(XMLNode map)
        {
            if (map == null)
            {
                throw new ArgumentNullException("map");
            }

            string s = map.GetValue("@width");
            int width;
            if (!int.TryParse(s, out width))
                width = 0;

            s = map.GetValue("@height");
            int height;
            if (!int.TryParse(s, out height))
                height = 0;

            s = map.GetValue("@tilewidth");
            int tileWidth;
            if (!int.TryParse(s, out tileWidth))
                tileWidth = 0;

            s = map.GetValue("@tileheight");
            int tileHeight;
            if (!int.TryParse(s, out tileHeight))
                tileHeight = 0;

            return new TileMapSize(width, height, tileWidth, tileHeight);
        }
    }
}
