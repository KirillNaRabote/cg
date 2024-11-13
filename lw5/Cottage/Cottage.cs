using OpenTK.Graphics.OpenGL;

namespace Cottage;

public class Cottage
{
    House house = new();
    Garage garage = new();
    Yard yard = new ();
    Sky sky = new();

    public bool ShowFog = false;
    
    public Cottage() 
    {
        house.WallTexture = brickWallTexture;
        house.DoorTexture = doorTexture;
        house.RootTexture = rootTilesTexture;
        house.GrafityTexture = grafityTexture;
        house.WindowTexture = windowTexture;
        house.AtticBoardsTexture = atticBoardsTexture;

        garage.WallTexture = brickWallTexture;
        garage.GarageDoorTexture = garageDoorTexture;
        garage.RootTexture = rootTilesTexture;
        garage.WindowTexture = windowTexture;
        garage.AtticBoardsTexture = atticBoardsTexture;

        yard.GrassTexture = grassTexture;
        yard.FenceTexture = fenceTexture;

        sky.SkyTexture = skyTexture;
    }

    private int brickWallTexture = Texture.LoadTexture(
        "images/brick-wall.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private int doorTexture = Texture.LoadTexture(
        "images/door.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private int garageDoorTexture = Texture.LoadTexture(
        "images/garage-door.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private int grassTexture = Texture.LoadTexture(
        "images/grass.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private int windowTexture = Texture.LoadTexture(
        "images/window.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private int rootTilesTexture = Texture.LoadTexture(
        "images/root-tiles.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private int grafityTexture = Texture.LoadTexture(
        "images/grafity.gif", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.ClampToBorder,
        TextureWrapMode.ClampToBorder);
    private int atticBoardsTexture = Texture.LoadTexture(
        "images/attic-boards.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    private int fenceTexture = Texture.LoadTexture(
        "images/fence.jpg", 
        TextureMagFilter.Linear,
        TextureMinFilter.LinearMipmapLinear,
        TextureWrapMode.Repeat,
        TextureWrapMode.Repeat);
    //разобраться с текстуркой, можно продублировать пиксели на границах
    //при рисовании неба отключить освещение
    private int skyTexture = Texture.LoadTexture(
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

        house.Draw();
        garage.Draw();
        yard.Draw();
        
        GL.Enable(EnableCap.Light0);
        GL.Enable(EnableCap.Light1);
        
        sky.Draw();

        GL.Disable(EnableCap.Light0);
        GL.Disable(EnableCap.Light1);
        
        GL.Disable(EnableCap.Fog);
    }
}