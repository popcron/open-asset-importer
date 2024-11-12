using OpenAssetImporter.Native;
using System;

namespace OpenAssetImporter;

public unsafe readonly struct MetadataEntry
{
    public readonly MetaDataType dataType;
    private readonly nint data;

    public readonly Type Type
    {
        get
        {
            return dataType switch
            {
                MetaDataType.Bool => typeof(bool),
                MetaDataType.Int32 => typeof(int),
                MetaDataType.UInt64 => typeof(ulong),
                MetaDataType.Float => typeof(float),
                MetaDataType.Double => typeof(double),
                MetaDataType.String => typeof(string),
                _ => throw new NotSupportedException($"Data type {dataType} is not supported")
            };
        }
    }

    internal MetadataEntry(MetaDataType dataType, nint data)
    {
        this.dataType = dataType;
        this.data = data;
    }

    public readonly override string ToString()
    {
        return Type.ToString();
    }

    public readonly bool Is<T>()
    {
        return Type == typeof(T);
    }

    public readonly T Read<T>() where T : unmanaged
    {
        ThrowIfTypeMismatch(typeof(T));
        return *(T*)data;
    }

    public readonly string ReadString()
    {
        ThrowIfTypeMismatch(typeof(string));
        return ((AiString*)data)->ToString();
    }

    public readonly void ThrowIfTypeMismatch(Type type)
    {
        Type thisType = Type;
        if (thisType != type)
        {
            throw new InvalidCastException($"Data type mismatch, expected {thisType} but got {type}");
        }
    }
}