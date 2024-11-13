using OpenTK.Graphics.OpenGL;

namespace Cottage;

public class Cottage
{
    private readonly House _house;
    private readonly Garage _garage;
    private readonly Yard _yard;
    private readonly Sky _sky;

    public bool ShowFog = false;
    
    public Cottage()
    {
        _house = new House(_wallTexture, _doorTexture, _roofTexture, _graffitiTexture, _windowTexture, _atticBoardsTexture);

        _garage = new Garage(_wallTexture, _garageDoorTexture, _roofTexture, _windowTexture, _atticBoardsTexture);
        
        _yard = new Yard(_grassTexture, _fenceTexture);
        
        _sky = new Sky(_skyTexture);
    }

    private readonly int _wallTexture = Texture.LoadTexture(
        "images/brick-wall.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private readonly int _doorTexture = Texture.LoadTexture(
        "images/door.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private readonly int _garageDoorTexture = Texture.LoadTexture(
        "images/garage-door.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private readonly int _grassTexture = Texture.LoadTexture(
        "images/grass.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private readonly int _windowTexture = Texture.LoadTexture(
        "images/window.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private readonly int _roofTexture = Texture.LoadTexture(
        "images/root-tiles.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private readonly int _graffitiTexture = Texture.LoadTexture(
        "images/grafity.gif", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.ClampToBorder,
        TextureWrapMode.ClampToBorder);
    private readonly int _atticBoardsTexture = Texture.LoadTexture(
        "images/attic-boards.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private readonly int _fenceTexture = Texture.LoadTexture(
        "images/fence.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    //разобраться с текстуркой, можно продублировать пиксели на границах
    //при рисовании неба отключить освещение
    private readonly int _skyTexture = Texture.LoadTexture(
        "images/sky.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.ClampToEdge,
        TextureWrapMode.ClampToEdge);

    public void Draw()
    {
        if (ShowFog)
        {
            GL.Enable(EnableCap.Fog);
        }
        else
        {
            GL.Disable(EnableCap.Fog);
        }

        GL.Fog(FogParameter.FogMode, (int)FogMode.Exp);
        GL.Fog(FogParameter.FogColor, new float[] { 0.5f, 0.5f, 0.5f, 0f });
        GL.Fog(FogParameter.FogDensity, 0.015f);

        _house.Draw();
        _garage.Draw();
        _yard.Draw();
        
        GL.Disable(EnableCap.Lighting);
        
        _sky.Draw();
        
        GL.Enable(EnableCap.Lighting);
    }
}