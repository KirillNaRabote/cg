using func;
using OpenTK.Graphics.OpenGLES2;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

var nws = new NativeWindowSettings()
{
    //настройки окна
    Size = new Vector2i(500, 500),
    Title = "nigga nigga nigga nigga nigga nigga nigga",
    WindowBorder = WindowBorder.Resizable,
    Location = new Vector2i(710, 290),
    
    //настрйки OpenTK
    API = ContextAPI.OpenGL,
    Profile = ContextProfile.Core,
    Flags = ContextFlags.ForwardCompatible
};

var window = new MainWindow(GameWindowSettings.Default, nws);
window.Run();

/*var gms = GameWindowSettings.Default;
var nws = new NativeWindowSettings()
{
    Size = new Vector2i(800, 600),
    Location = new Vector2i(370, 300),
    WindowBorder = WindowBorder.Resizable,
    WindowState = WindowState.Normal,
    Title = "Learn OpenTK",
    
    Flags = ContextFlags.Default,
    APIVersion = new Version(3, 3),
    Profile = ContextProfile.Compatability,
    API = ContextAPI.OpenGL
};
var gameWindow = new GameWindow(gms, nws);

gameWindow.Run();*/