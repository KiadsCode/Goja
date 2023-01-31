using System;
using Goja;
using Goja.Audio;
using Goja.Graphics;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GojaTest
{
	public class GGame : Game
	{
		private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Texture2D ds;
        public GGame()
		{
			//SetVSync(true);
		}
		
		protected override void Initialize()
		{
            base.Initialize();
		}
		
		protected override void BeginDraw()
		{
			GL.ClearColor(Color4.CornflowerBlue);
            Width = 640;
            Height = 480;
			
			base.BeginDraw();
		}
		
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(this);
			
			texture = Content.Load<Texture2D>(@"trollFace.png");
			ds = Content.Load<Texture2D>(@"BackGroundTile.png");
			base.LoadContent();
		}
		
		protected override void Update(double elapsed)
		{
			if(Input.IsKeyDown(Keys.Escape))
				Exit();
			if(Input.IsKeyDown(Keys.A))
				posXX.X -= 6;
			if(Input.IsKeyDown(Keys.D))
				posXX.X += 6;
			if(Input.IsKeyDown(Keys.S))
				posXX.Y -= 6;
			if(Input.IsKeyDown(Keys.W))
				posXX.Y += 6;
			base.Update(elapsed);
		}
		
		Vector2 posXX = Vector2.Zero;
		
		protected override void Draw(double elapsed)
		{
			spriteBatch.Draw(ds, Vector2.Zero, new Vector3(1.0f, 0.0f, 0.0f));
			DrawTriangle();
			spriteBatch.Draw(texture, posXX, new Vector3(1.0f,1.0f,1.0f));
			
			base.Draw(elapsed);
		}
		public void DrawTriangle()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Vertex2(0.0, 0.0);
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex2(0.3, 0.5);
            GL.Color3(1.0f, 0.0f, 1.0f);
            GL.Vertex2(0.65, 0.0);
            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.End();
        }
	}
	class Program
	{
		public static void Main(string[] args)
		{
			
			// TODO: Implement Functionality Here
			GGame f = new GGame();
			f.Run();
		}
	}
}