﻿using FileToVox.Converter.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FileToVox.Generator.Heightmap.Data
{
	public class HeightmapData : JsonBaseImportData
	{
		public HeightmapStep[] Steps { get; set; }
	}

	public enum PlacementMode
	{
		ADDITIVE,
		REPLACE,
		SUBSTRACT,
		TOP_ONLY
	}

	public enum RotationMode
	{
		X,
		Y,
		Z,
		XZ,
		XYZ
	}

	public class HeightmapStep
	{
		public string TexturePath { get; set; }
		public string ColorTexturePath { get; set; }
		public int Height { get; set; }
		public int Offset { get; set; }
		public bool EnableColor { get; set; }
		public int ColorLimit { get; set; } = 256;
		public bool Excavate { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public PlacementMode PlacementMode { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public RotationMode RotationMode { get; set; }

		public void ValidateSettings()
		{
			if (Height < 0)
			{
				Height = 1;
			}

			if (Offset < 0)
			{
				Offset = 0;
			}

			if (ColorLimit < 0)
			{
				ColorLimit = 256;
			}
		}
	}
}
