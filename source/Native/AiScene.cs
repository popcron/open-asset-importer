namespace OpenAssetImporter.Native;

public unsafe struct AiScene
{
    public SceneFlags flags;
    public AiNode* rootNode;
    public uint numMeshes;
    public AiMesh** meshes;
    public uint numMaterials;
    public nint materials;
    public uint numAnimations;
    public nint animations;
    public uint numTextures;
    public nint textures;
    public uint numLights;
    public nint lights;
    public uint numCameras;
    public nint cameras;
    public AiMetadata* metadata;
    public AiString name;
    public uint numSkeletons;
    public nint skeletons;

    private readonly nint somethingIdk;
}