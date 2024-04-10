using func;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

var nws = new NativeWindowSettings()
{
    //настройки окна
    ClientSize = new Vector2i(500, 500),
    Title = "Parabola",
    WindowBorder = WindowBorder.Resizable,
    
    
    //настрйки OpenTK
    API = ContextAPI.OpenGL,
    Profile = ContextProfile.Compatability,
    Flags = ContextFlags.Default
};

var window = new MainWindow(GameWindowSettings.Default, nws);
window.Run();