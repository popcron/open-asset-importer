namespace OpenAssetImporter;

public enum MorphingMethod
{
    Unknown = 0,
    VertexBlend = 1,
    MorphNormalize = 2,
    MorphRelative = 3,
    Force32Bit = int.MaxValue,
}