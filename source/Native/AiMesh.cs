using System.Numerics;

namespace OpenAssetImporter.Native;

public unsafe struct AiMesh
{
    public PrimitiveType primitiveTypes;
    public uint numVertices;
    public uint numFaces;
    public Vector3* vertices;
    public Vector3* normals;
    public Vector3* tangets;
    public Vector3* biTangents;
    public AiMeshColorArray colors;
    public AiMeshTextureCoordinateArray textureCoordinates;
    public AiMeshUVComponentArray uvComponentCounts;
    public AiFace* faces;
    public uint numBones;
    public nint bones;
    public uint materialIndex;
    public AiString name;
    public uint numAnimatedMeshes;
    public nint animatedMeshes;
    public MorphingMethod morphMethod;
    public AiAABB aabb;
    public AiString** textureCoordinateNames;
}
