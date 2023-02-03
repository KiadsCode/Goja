using System;
using System.ComponentModel;
using Goja.Content;
using Goja.Graphics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Goja
{
	/// <summary>
	/// Description of Window.
	/// </summary>
	public class Game
	{
		private SpriteBatch _spriteBatch;
		public const string GOJA_VERSION = "1.0.0";
		private ContentManager _contentManager;
		private float _frameTime = 0;
		private float _fpsRaw = 0;
		private float _fps;
		private GameComponentsCollection _components = new GameComponentsCollection();
		private const double UpdateRate = 60.0;
		private const double FrameRate = 60.0;
		private GameWindow _gameWindow;
		private Camera _camera = new Camera();
		
		public Camera Camera
		{
			get
			{
				return _camera;
			}
			protected set
			{
				_camera = value;
			}
		}

		public float FPS
		{
			get
			{
				return _fps;
			}
		}

		public ContentManager Content
		{
			get
			{
				return _contentManager;
			}
			protected set
			{
				_contentManager = value;
			}
		}

		private void UpdateFPS(double elapsed)
		{
			_frameTime += (float)elapsed;
			_fpsRaw++;
			if (_frameTime >= 1.0f)
			{
				_fps = _fpsRaw;
				_frameTime = 0.0f;
				_fpsRaw = 0;
			}
		}

		public int Width
		{
			get
			{
				return _gameWindow.Width;
			}
			protected set
			{
				_gameWindow.Width = value;
			}
		}
		public int Height
		{
			get
			{
				return _gameWindow.Height;
			}
			protected set
			{
				_gameWindow.Height = value;
			}
		}

		protected void SetVSync(bool value)
		{
			switch (value)
			{
				case true:
					_gameWindow.VSync = VSyncMode.On;
					IsVSync = true;
					break;
				case false:
					_gameWindow.VSync = VSyncMode.Off;
					IsVSync = false;
					break;
				default:
					IsVSync = true;
					_gameWindow.VSync = VSyncMode.Adaptive;
					break;
			}
		}

		protected void Exit()
		{
			_gameWindow.Exit();
		}

		public SpriteBatch SpriteBatch
		{
			get
			{
				return _spriteBatch;
			}
		}

		public bool IsVSync
		{
			get;
			protected set;
		}
		public string Title
		{
			get
			{
				return _gameWindow.Title;
			}
			protected set
			{
				_gameWindow.Title = value;
			}
		}
		
		protected void SetCameraPosition(Vector2 position)
		{
			Camera.Position = position;
			UpdateViewport();
		}

		public GameComponentsCollection Components { get { return _components; } }

		public Game()
		{
			_gameWindow = new GameWindow(800, 600, GraphicsMode.Default, "Goja project");
			_gameWindow.Load += new EventHandler<EventArgs>(InitializePrivate);
			_gameWindow.RenderFrame += new EventHandler<FrameEventArgs>(DrawPrivate);
			_gameWindow.UpdateFrame += new EventHandler<FrameEventArgs>(UpdatePrivate);
			_gameWindow.Resize += new EventHandler<EventArgs>(ResizePrivate);
			_gameWindow.Closing += new EventHandler<CancelEventArgs>(UnloadContentPrivate);
		}

		private void UnloadContentPrivate(object sender, CancelEventArgs e)
		{
			UnloadContent();
		}

		protected virtual void UnloadContent()
		{
			_contentManager.Unload();
		}

		protected virtual void BeginDraw()
		{
		}

		private void UpdateViewport()
		{
			GL.Viewport((int)_camera.Position.X, (int)_camera.Position.Y, _gameWindow.Width, _gameWindow.Height);
		}

		private void ResizePrivate(object sender, EventArgs e)
		{
			UpdateViewport(); 
			GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
			_spriteBatch = new SpriteBatch(this);
        }

		private void InitializePrivate(object sender, EventArgs e)
		{
			GL.ClearColor(Color4.Purple);
			Initialize();
		}

		private void DrawPrivate(object sender, FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);
            Draw(e.Time);
			_gameWindow.SwapBuffers();
		}

		private void UpdatePrivate(object sender, FrameEventArgs e)
		{
			Update(e.Time);
		}

		protected virtual void Draw(double elapsed)
		{
		}

		protected virtual void Update(double elapsed)
		{
			UpdateFPS(elapsed);
			foreach (GameComponent item in Components)
			{
				if (item.Enabled)
					item.Update(elapsed);
			}
		}

		protected virtual void Initialize()
		{
			UpdateViewport();
			Width = 800;
			Height = 480;
			GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
			LoadContent();
		}
		
		public System.Drawing.Icon Icon
		{
			get
			{
				return _gameWindow.Icon;
			}
		}
		
		protected virtual void LoadContent()
		{
			BeginDraw();
		}
		
		protected void UpdateIcon(string file)
		{			
			_gameWindow.Icon = new System.Drawing.Icon(TitleContainer.OpenStream(file));
		}

		public void Run()
		{
			Content = new ContentManager(@"");
			_spriteBatch = new SpriteBatch(this);
			
			Console.WriteLine("Goja version: " + GOJA_VERSION);
			
			_gameWindow.Run(UpdateRate, FrameRate);
		}
	}
}