namespace OpenAssetImporter.Native;

public unsafe struct AiMaterial
{
    public AiMaterialProperty** properties;
    public uint numProperties;
    public uint numAllocated;
}