using System.Numerics;

namespace OpenAssetImporter.Native;

public unsafe struct AiBone
{
    public AiString name;
    public uint numWeights;
    public nint armature;
    public nint node;
    public AiVertexWeight* weights;
    public Matrix4x4 offsetMatrix;
}
