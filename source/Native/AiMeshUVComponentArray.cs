namespace OpenAssetImporter.Native;

public unsafe struct AiMeshUVComponentArray
{
    private fixed uint uvs[Assimp.MaxNumberOfTextureCoordinates];

    public uint this[int index]
    {
        get => uvs[index];
        set => uvs[index] = value;
    }
}