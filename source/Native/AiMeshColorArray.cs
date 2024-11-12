using System.Numerics;

namespace OpenAssetImporter.Native;

public unsafe struct AiMeshColorArray
{
    private Vector4* element0;
    private Vector4* element1;
    private Vector4* element2;
    private Vector4* element3;
    private Vector4* element4;
    private Vector4* element5;
    private Vector4* element6;
    private Vector4* element7;

    public Vector4* this[int index]
    {
        readonly get => index switch
        {
            0 => element0,
            1 => element1,
            2 => element2,
            3 => element3,
            4 => element4,
            5 => element5,
            6 => element6,
            7 => element7,
            _ => default,
        };
        set
        {
            switch (index)
            {
                case 0:
                    element0 = value;
                    break;
                case 1:
                    element1 = value;
                    break;
                case 2:
                    element2 = value;
                    break;
                case 3:
                    element3 = value;
                    break;
                case 4:
                    element4 = value;
                    break;
                case 5:
                    element5 = value;
                    break;
                case 6:
                    element6 = value;
                    break;
                case 7:
                    element7 = value;
                    break;
            }
        }
    }
}
