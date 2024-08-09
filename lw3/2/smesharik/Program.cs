using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using smesharik;

var nws = new NativeWindowSettings()
{
    //настройки окна
    ClientSize = new Vector2i(800, 800),
    Title = "Smesharik",
    WindowBorder = WindowBorder.Resizable,

    //настрйки OpenTK
    API = ContextAPI.OpenGL,
    Profile = ContextProfile.Compatability,
    Flags = ContextFlags.Default
};

var window = new MainWindow(GameWindowSettings.Default, nws);
window.Run();