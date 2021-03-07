﻿using System;
using System.Runtime.InteropServices;

namespace FileToVox.Schematics
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Voxel : IEquatable<Voxel>
    {
        public readonly ushort X;
        public readonly ushort Y;
        public readonly ushort Z;
        public readonly int PalettePosition;
        public uint Color;

        public Voxel(ushort x, ushort y, ushort z, uint color, int palettePosition = -1)
        {
            X = x;
            Y = y;
            Z = z;
            Color = color;
            PalettePosition = palettePosition;
        }


        public bool IsDefaultValue()
        {
            return X == Y && Y == Z && Z == 0;
        }

        public override int GetHashCode()
        {
            //the index of the block at X,Y,Z is (Y×length + Z)×width + X
            return (Y * Schematic.MAX_WORLD_LENGTH + Z) * Schematic.MAX_WORLD_WIDTH + X;
        }

        public bool Equals(Voxel other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}, Color: {Color.ToString()}";
        }

        public static bool operator ==(Voxel c1, Voxel c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Voxel c1, Voxel c2)
        {
            return !c1.Equals(c2);
        }

    }
}
