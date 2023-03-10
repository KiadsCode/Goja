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
	public class Game : IDisposable
	{
		#region IDisposable implementation

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				lock (this)
				{
					GameComponent[] array = new GameComponent[this._components.Count];
					this._components.CopyTo(array, 0);
					for (int i = 0; i < array.Length; i++)
					{
						IDisposable disposable = array[i] as IDisposable;
						if (disposable != null)
							disposable.Dispose();
					}
				}
			}
		}

	#endregion

		private SpriteBatch _spriteBatch;
		public const string GOJA_VERSION = "1.0.7";
		private ContentManager _contentManager;
		private float _frameTime = 0;
		private float _fpsRaw = 0;
		private float _fps;
		private GameComponentsCollection _components = new GameComponentsCollection();
		private const double UpdateRate = 60.0;
		private const double FrameRate = 60.0;
		private GameWindow _gameWindow;
		private Camera _camera = new Camera();
		
		#region Properties
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

		// disable once ConvertToAutoProperty
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
		public int Width
		{
			get
			{
				return _gameWindow.Size.Width;
			}
			protected set
			{
				_gameWindow.Size = new System.Drawing.Size(value, _gameWindow.Size.Height);
			}
		}
		public int Height
		{
			get
			{
				return _gameWindow.Size.Height;
			}
			protected set
			{
				_gameWindow.Size = new System.Drawing.Size(_gameWindow.Size.Width, value);
			}
		}
		public int GLWidth
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
		public int GLHeight
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
		/// <summary>
		/// Drawing sprites
		/// </summary>
		public SpriteBatch SpriteBatch
		{
			get
			{
				return _spriteBatch;
			}
		}

		/// <summary>
		/// returning Vertical Synchronize value
		/// </summary>
		public bool IsVSync
		{
			get;
			protected set;
		}
		
		/// <summary>
		/// Game Title value
		/// </summary>
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
		
		/// <summary>
		/// Components list
		/// </summary>
		public GameComponentsCollection Components { get { return _components; } }
		
		#endregion

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
		
		/// <summary>
		/// Closing game screen
		/// </summary>
		protected void Exit()
		{
			_gameWindow.Exit();
			EndRun();
		}
		
		protected void SetCameraPosition(Vector2 position)
		{
			Camera.Position = position;
			UpdateViewport();
		}


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

		/// <summary>
		/// Called when graphics resources need to be unloaded.
		/// Override this method to unload any game-specific graphics resources.
		/// </summary>
		protected virtual void UnloadContent()
		{
			_contentManager.Unload();
		}

		/// <summary>
		/// Starts the drawing of a frame. This method is followed by calls to Draw and EndDraw.
		/// </summary>
		protected virtual void BeginDraw()
		{
		}
		/// <summary>
		/// Ends the drawing of a frame. This method is preceeded by calls to Draw and BeginDraw.
		/// </summary>
		protected virtual void EndDraw()
		{
		}
		
		protected virtual void BeginRun()
		{
		}
		protected virtual void EndRun()
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
			BeginDraw();
			GL.Clear(ClearBufferMask.ColorBufferBit);
            Draw(e.Time);
			_gameWindow.SwapBuffers();
			EndDraw();
		}

		private void UpdatePrivate(object sender, FrameEventArgs e)
		{
			Update(e.Time);
		}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
		protected virtual void Draw(double elapsed)
		{
		}
	
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
		/// <param name="elapsed"></param>
		protected virtual void Update(double elapsed)
		{
			UpdateFPS(elapsed);
			foreach (GameComponent item in Components)
			{
				if (item.Enabled)
					item.Update(elapsed);
			}
		}
		
		public int X
		{
			get
			{
				return _gameWindow.X;
			}
		}
		public int Y
		{
			get
			{
				return _gameWindow.Y;
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
			Console.WriteLine("Goja API version: " + GOJA_VERSION);
			BeginRun();
			_gameWindow.Run(UpdateRate, FrameRate);
		}

	}
}