using OpenAssetImporter.Native;
using System;

namespace OpenAssetImporter;

public unsafe readonly struct Face
{
    private readonly AiFace face;

    public readonly ReadOnlySpan<int> Indices
    {
        get
        {
            return new ReadOnlySpan<int>(face.indices, (int)face.numIndices);
        }
    }

    internal Face(AiFace face)
    {
        this.face = face;
    }
}