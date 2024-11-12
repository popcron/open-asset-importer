# Open Asset Importer
WIP C# bindings for Open Asset Importer, compatible with NativeAOT.

### Usage
Below is loading a file from disk into a scene:
```cs
using Scene scene = new("path/to/file.fbx");
ReadOnlySpan<Mesh> meshes = scene.Meshes;
Console.WriteLine($"Loaded {scene.Name} with {meshes.Length} meshes");
```