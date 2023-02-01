using System;
using Goja;
using Goja.Input;
using Goja.Graphics;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GojaTest
{
	public class GGame : Game
	{
		HitBox boxB;
		private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Texture2D ds;
        HitBox box;
        public GGame()
		{
		}
        
		protected override void Initialize()
		{
			Content.RootDirectory = "Content/";
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
			
			texture = Content.Load<Texture2D>(@"rs.png");
			ds = Content.Load<Texture2D>(@"BackGroundTile.png");
			base.LoadContent();
		}
		
		protected override void Update(double elapsed)
		{
			if(Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			if(Keyboard.GetState().IsKeyDown(Keys.A))
				posXX.X -= 6;
			if(Keyboard.GetState().IsKeyDown(Keys.D))
				posXX.X += 6;
			if(Keyboard.GetState().IsKeyDown(Keys.S))
				posXX.Y -= 6;
			if(Keyboard.GetState().IsKeyDown(Keys.W))
				posXX.Y += 6;
			
			boxB = new HitBox((int)Vector2.Zero.X, (int)Vector2.Zero.X, ds.Bitmap.Width, ds.Bitmap.Height);
			box = new HitBox((int)posXX.X, (int)posXX.Y, texture.Bitmap.Width, texture.Bitmap.Height);
			
			
			if(Keyboard.GetState().IsKeyDown(Keys.Down))
				SetCameraPosition(new Vector2(Camera.Position.X, Camera.Position.Y + 2));
			if(Keyboard.GetState().IsKeyDown(Keys.Left))
				SetCameraPosition(new Vector2(Camera.Position.X + 2, Camera.Position.Y));
			if(Keyboard.GetState().IsKeyDown(Keys.Right))
				SetCameraPosition(new Vector2(Camera.Position.X - 2, Camera.Position.Y));
			if(Keyboard.GetState().IsKeyDown(Keys.Up))
				SetCameraPosition(new Vector2(Camera.Position.X, Camera.Position.Y - 2));
				
			base.Update(elapsed);
		}
		
		Vector2 posXX = new Vector2(-210.0f, 0.0f);
		
		protected override void Draw(double elapsed)
		{
			spriteBatch.Draw(ds, Vector2.Zero, new Vector3(1.0f, 1.0f, 1.0f));
			DrawTriangle();
			spriteBatch.Draw(texture, posXX, new Vector3(1.0f,1.0f,1.0f));
			
			if(box.Intersects(boxB))
				boxB.Draw(new Vector3(1.0f, 0.0f, 0.0f), this, false);
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