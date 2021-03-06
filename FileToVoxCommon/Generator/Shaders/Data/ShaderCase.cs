﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileToVoxCommon.Generator.Shaders.Data
{
	public class ShaderCase : ShaderStep
	{
		[Description("Iterations: Set the number of times the shader will be applied for this step")]
		[Range(1, 10)]
		public int Iterations { get; set; } = 1;

		[Description("TargetColorIndex: The index of the color target. If value is set to -1, then the shader is applied to all colors")]
		[Range(-1, 256)]
		public int TargetColorIndex { get; set; } = -1;

		public override ShaderType ShaderType { get; set; } = ShaderType.CASE;
		public override void DisplayInfo()
		{
			base.DisplayInfo();
			Console.WriteLine("[INFO] Iterations: " + Iterations);
			Console.WriteLine("[INFO] TargetColorIndex: " + TargetColorIndex);
		}

		public override void ValidateSettings()
		{
			if (Iterations < 0)
			{
				Console.WriteLine("[WARNING] Negative value found for Iterations, replace to 1...");
				Iterations = 1;
			}
		}
	}
}
