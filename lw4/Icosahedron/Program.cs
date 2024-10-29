using Icosahedron;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

var nws = new NativeWindowSettings()
{
    //настройки окна
    ClientSize = new Vector2i(1920, 1080),
    Title = "Icosahedron",
    WindowBorder = WindowBorder.Resizable,

    //настрйки OpenTK
    API = ContextAPI.OpenGL,
    Profile = ContextProfile.Compatability,
    Flags = ContextFlags.Default
};

var window = new MainWindow(GameWindowSettings.Default, nws);
window.Run();