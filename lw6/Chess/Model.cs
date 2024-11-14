using Assimp;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Chess;

public class Model
{
    private Scene _scene = new();
    private int[] _displayLists = [];
    private readonly MaterialLoader _materialLoader = new();

    public Model(string filePath)
    {
        LoadModel(filePath);
    }
    
    private void LoadModel(string filePath)
    {
        AssimpContext importer = new AssimpContext();
        _scene = importer.ImportFile(
            filePath, 
            PostProcessSteps.FlipUVs
        );
        importer.Dispose();
        LoadTextures();
        CreateDisplayLists();
    }

    private void CreateDisplayLists()
    {
        int meshCount = _scene.MeshCount;
        _displayLists = new int[meshCount];

        for (int i = 0; i < meshCount; i++)
        {
            Mesh mesh = _scene.Meshes[i];

            _displayLists[i] = GL.GenLists(1);
            GL.NewList(_displayLists[i], ListMode.Compile);
            _materialLoader.ApplyMaterial(_scene.Materials[mesh.MaterialIndex], i);

            Vector3[] vertices = AssimpVectorToOpenTkVector([.. mesh.Vertices]);
            Vector3[] normals = AssimpVectorToOpenTkVector([.. mesh.Normals]);
            Vector3[] textureCoordinates = AssimpVectorToOpenTkVector([.. mesh.TextureCoordinateChannels[0]]);

            if (mesh.Faces[0].IndexCount % 3 == 0)
                GL.Begin(OpenTK.Graphics.OpenGL.PrimitiveType.Triangles);
            else
                GL.Begin(OpenTK.Graphics.OpenGL.PrimitiveType.Quads);
            
            for (int k = 0; k < vertices.Length; ++k)
            {
                GL.Normal3(normals[k]);
                if(_scene.Materials[mesh.MaterialIndex].HasTextureDiffuse) 
                    GL.TexCoord2(textureCoordinates[k].X, textureCoordinates[k].Y);
                GL.Vertex3(vertices[k]);
            }

            GL.End();

            GL.EndList();
        }
    }

    private void LoadTextures()
    {
        foreach (var mesh in _scene.Meshes)
        {
            if (mesh.MaterialIndex >= 0)
            {
                Material material = _scene.Materials[mesh.MaterialIndex];
                _materialLoader.LoadMaterialTextures(material);
            }
        }
    }

    public void RenderModel()
    {
        int meshCount = _scene.MeshCount;
        for (int i = 0; i < meshCount; i++)
        {
            GL.CallList(_displayLists[i]);
        }
    }

    private Vector3[] AssimpVectorToOpenTkVector(Vector3D[] vecArr)
    {
        Vector3[] vectorOpenTk = new Vector3[vecArr.Length];

        for(int i = 0; i < vecArr.Length; i++)
        {
            vectorOpenTk[i].X = vecArr[i].X;
            vectorOpenTk[i].Y = vecArr[i].Y;
            vectorOpenTk[i].Z = vecArr[i].Z;
        }

        return vectorOpenTk;
    }
}