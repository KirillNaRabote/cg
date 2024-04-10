using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace func;

public class MainWindow: GameWindow
{
    private const float WindowMinX = -10;
    private const float WindowMaxX = 10;
    private const float WindowMinY = -10;
    private const float WindowMaxY = 10;
 
    private readonly FunctionGraph _funcGraph = new FunctionGraph(0.01f, -2.0f, 3.0f, WindowMinX, WindowMaxX, WindowMinY, WindowMaxY);
    
    public MainWindow(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws)
    {
        Console.WriteLine(GL.GetString(StringName.Version));
        Console.WriteLine(GL.GetString(StringName.Vendor));
        Console.WriteLine(GL.GetString(StringName.Renderer));
        Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

        VSync = VSyncMode.On;
    }

    //инициализация ресурсов
    protected override void OnLoad()
    {
        base.OnLoad();
        GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
        GL.Enable(EnableCap.CullFace);
        GL.CullFace(CullFaceMode.Back);
    }

    //игровой цикл
    protected override void OnResize(ResizeEventArgs e)
    {
        int w = e.Width;
        int h = e.Height;
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Viewport(0, 0, w, h);

        GL.Ortho(WindowMinX, WindowMaxX, WindowMinY, WindowMaxY, 1, -1);
        
        
        base.OnResize(e);
    }

    //логика
    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        var key = KeyboardState;

        if (key.IsKeyDown(Keys.Escape)) Close();
        
        base.OnUpdateFrame(args);
    }

    //отрисовка
    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        _funcGraph.DrawCoordinateAxes();
        _funcGraph.DrawFunction();
        
        SwapBuffers();
        base.OnRenderFrame(args);
    }
}