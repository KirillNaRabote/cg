using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace smesharik;

public class MainWindow : GameWindow
{
    private int _windowWidth;
    private int _windowHeight;

    private bool _isDragging = false;
    private Vector2 _startDragPosition;
    private Vector2 _offset;
    private Vector2 _startPosition;

    private readonly ParametersInPixels _paramsInPixels;
    private readonly Kopatich _kopatich;
    
    public MainWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
        : base(gameWindowSettings, nativeWindowSettings)
    {
        VSync = VSyncMode.On;
        _windowWidth = nativeWindowSettings.ClientSize.X;
        _windowHeight = nativeWindowSettings.ClientSize.Y;

        _paramsInPixels = new ParametersInPixels(
            (float)_windowWidth / 2,
            (float)_windowHeight / 2, 
            (float)400, 
            (float)400
        );
        
        _kopatich = new Kopatich(_paramsInPixels, _windowWidth, _windowHeight);
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
        _windowWidth = e.Width;
        _windowHeight = e.Height;
        
        double aspectRatio = (double)_windowWidth / _windowHeight;

        double viewWidth = 2.0;
        double viewHeight = viewWidth;

        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Viewport(0, 0, _windowWidth, _windowHeight);

        if (aspectRatio > 1)
        {
            viewWidth = viewHeight * aspectRatio;
        } else
        {
            viewHeight = viewWidth / aspectRatio;
        }
        
        GL.Ortho(-viewWidth * 0.5, viewWidth * 0.5, -viewHeight * 0.5, viewHeight * 0.5, -1, 1);
        Console.WriteLine($"{viewWidth}   {viewHeight}");
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
        
        GL.Color3(1.0f, 0.0f, 0.0f);
        _kopatich.DrawKopatich();
        
        SwapBuffers();
        base.OnRenderFrame(args);
    }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button == MouseButton.Left)
        {
            if (_kopatich.IsClick(MousePosition))
            {
                _isDragging = true;
                _startDragPosition = MousePosition;
                _startDragPosition.Y = _windowHeight - _startDragPosition.Y;
                _startPosition.X = _paramsInPixels.CenterXInPixels;
                _startPosition.Y = _paramsInPixels.CenterYInPixels;
            }
        }
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
        base.OnMouseMove(e);

        if (_isDragging)
        {
            _offset.X = MousePosition.X - _startDragPosition.X;
            _offset.Y = _windowHeight - MousePosition.Y - _startDragPosition.Y;

            _paramsInPixels.CenterXInPixels = _startPosition.X + _offset.X;
            _paramsInPixels.CenterYInPixels = _startPosition.Y + _offset.Y;
            
            Console.WriteLine($"offset {_offset.Y} start {_startDragPosition.Y}");
            
            _kopatich.UpdateParams(_paramsInPixels);
        }
    }

    protected override void OnMouseUp(MouseButtonEventArgs e)
    {
        base.OnMouseUp(e);

        _isDragging = false;
    }
}
