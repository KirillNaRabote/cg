using System.Drawing.Imaging;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Cottage;

public class Texture
{
    public static int LoadTexture(
        string filepath, 
        TextureMagFilter magFilter,
        TextureMinFilter minFilter,
        TextureWrapMode wrapS,
        TextureWrapMode wrapT)
    {
        Bitmap bmp = new(filepath);

        GL.GenTextures(1, out int textureId);
        GL.BindTexture(TextureTarget.Texture2D, textureId);

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)magFilter);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)minFilter);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)wrapS);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)wrapT);

        BitmapData bmpData = bmp.LockBits(
            new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadOnly,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height, 0,
            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

        bmp.UnlockBits(bmpData);
        
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        
        return textureId;
    }
}