using System.Numerics;

namespace OpenAssetImporter.Native;

public unsafe struct AiNode
{
    public AiString name;
    public Matrix4x4 transformation;
    public AiNode* parent;
    public uint numChildren;
    public AiNode** children;
    public uint numMeshes;
    public uint* meshes;
    public AiMetadata* metadata;
}
