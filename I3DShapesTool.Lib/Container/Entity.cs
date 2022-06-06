﻿
using System.IO;

namespace I3DShapesTool.Lib.Container
{
    /// <summary>
    /// Entity.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Entity type as an integer
        /// </summary>
        public int Type { get; }

        /// <summary>
        /// Entity type as en enum
        /// </summary>
        public EntityType EntityType => Type switch
        {
            1 => EntityType.Shape,
            2 => EntityType.Spline,
            _ => EntityType.Unknown,
        };

        /// <summary>
        /// Entity byte size
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Entity byte data
        /// </summary>
        public byte[] Data { get; }

        public Entity(int type, int size, byte[] data)
        {
            Type = type;
            Size = size;
            Data = data;
        }

        public static Entity Read(BinaryReader stream)
        {
            int type = stream.ReadInt32();
            int size = stream.ReadInt32();
            byte[]? data = stream.ReadBytes(size);

            return new Entity(type, size, data);
        }

        public void Write(BinaryWriter stream)
        {
            stream.Write(Type);
            stream.Write(Data.Length);
            stream.Write(Data);
        }
    }
}