using System;

namespace OpenAssetImporter;

[Flags]
public enum PostProcessSteps : uint
{
    CalcTangentSpace = 1,
    JoinIdenticalVertices = 2,
    MakeLeftHanded = 4,
    Triangulate = 8,
    RemoveComponent = 16,
    GenNormals = 32,
    GenSmoothNormals = 64,
    SplitLargeMeshes = 128,
    PreTransformVertices = 256,
    LimitBoneWeights = 512,
    ValidateDataStructure = 1024,
    ImproveCacheLocality = 2048,
    RemoveRedundantMaterials = 0x1000,
    FixInfacingNormals = 0x2000,
    PopulateArmatureData = 0x4000,
    SortByPType = 0x8000,
    FindDegenerates = 0x10000,
    FindInvalidData = 0x20000,
    GenUVCoords = 0x40000,
    TransformUVCoords = 0x80000,
    FindInstances = 0x100000,
    OptimizeMeshes = 0x200000,
    OptimizeGraph = 0x400000,
    FlipUVs = 0x800000,
    FlipWindingOrder = 0x1000000,
    SplitByBoneCount = 0x2000000,
    Debone = 0x4000000,
    GlobalScale = 0x8000000,
    EmbedTextures = 0x10000000,
    ForceGenNormals = 0x20000000,
    DropNormals = 0x40000000,
    GenBoundingBoxes = 0x80000000,
}