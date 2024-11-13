using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Cottage;

public class Sky
{
    public int SkyTexture { get; set; }
    
    private Box3 cubeBox = new Box3(-120f, -120f, -120f, 120f, 120f, 120f);
    private Box2 skyTextureCoord = new Box2(0f, 0f, 1f, 1f);

    private readonly float _offset = 0.01f;

    public Sky()
    {
    }

    public void Draw()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, SkyTexture);
        
        
        GL.Begin(PrimitiveType.Quads);
        
        //Передняя грань
        GL.Normal3(0f, 0f, -1f);
        GL.TexCoord2(skyTextureCoord.Max.X * 3 / 4, skyTextureCoord.Max.Y *  2 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Min.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Min.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X, skyTextureCoord.Max.Y / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Max.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 3 / 4, skyTextureCoord.Max.Y / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Max.Y, cubeBox.Max.Z);
        
        //Левая грань
        GL.Normal3(1f, 0f, 0f);
        GL.TexCoord2(skyTextureCoord.Min.X, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Min.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X / 4, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Min.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X / 4, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Max.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Min.X, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Max.Y, cubeBox.Max.Z);
        
        //Задняя грань
        GL.Normal3(0f, 0f, 1f);
        GL.TexCoord2(skyTextureCoord.Max.X * 1 / 4, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Min.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 2 / 4, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Min.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 2 / 4, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Max.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 1 / 4, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Max.Y, cubeBox.Min.Z);
        
        //правая грань
        GL.Normal3(-1f, 0f, 0f);
        GL.TexCoord2(skyTextureCoord.Max.X * 2 / 4, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Min.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 3 / 4, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Min.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 3 / 4, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Max.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X  * 2 / 4, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Max.Y, cubeBox.Min.Z);
        
        //нижняя грань
        GL.Normal3(0f, 1f, 0f);
        GL.TexCoord2(skyTextureCoord.Max.X * 1 / 4, skyTextureCoord.Max.Y);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Min.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 2 / 4, skyTextureCoord.Max.Y);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Min.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 2 / 4, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Min.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 1 / 4, skyTextureCoord.Max.Y * 2 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Min.Y, cubeBox.Min.Z);
        
        //верхняя грань
        GL.Normal3(0f, -1f, 0f);
        GL.TexCoord2(skyTextureCoord.Max.X * 1 / 4, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Max.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 2 / 4, skyTextureCoord.Max.Y * 1 / 3);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Max.Y, cubeBox.Min.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 2 / 4, skyTextureCoord.Min.Y);
        GL.Vertex3(cubeBox.Max.X, cubeBox.Max.Y, cubeBox.Max.Z);
        
        GL.TexCoord2(skyTextureCoord.Max.X * 1 / 4, skyTextureCoord.Min.Y);
        GL.Vertex3(cubeBox.Min.X, cubeBox.Max.Y, cubeBox.Max.Z);
        
        GL.End();
    }
}