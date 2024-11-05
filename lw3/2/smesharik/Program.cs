using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using smesharik;
//вспомнить примитивы
//сколько вершин нужно передать в триангл стрип чтобы нарисвоать 4 треугольника
//исправить проблему драг н дропа
//зачем нужна матрица проецирования
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