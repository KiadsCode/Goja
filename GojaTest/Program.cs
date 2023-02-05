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
		HitBox boxC = new HitBox(32, -192, 86, 86);
        private Texture2D texture;
        private Texture2D ds;
        HitBox box;
        
		protected override void Initialize()
		{
			Content.RootDirectory = "Content/";
			Title = "Goja engine test";
			world = new World(this);
			go = new GameObject(this, world);
			go.PhysicBody.UpdateMass(100);
			world.UpdateGravityValue(new Vector2(0, 3));
			Components.Add(world);
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
			UpdateIcon("Game.ico");
			
			texture = Content.Load<Texture2D>(@"rs.png");
			ds = Content.Load<Texture2D>(@"BackGroundTile.png");
			base.LoadContent();
		}
		KeyboardState ks;
		KeyboardState ksOld;
		GameObject go;
		World world;
		
		protected override void Update(double elapsed)
		{
			ks = Keyboard.GetState();
            boxB = new HitBox((int)Vector2.Zero.X, (int)Vector2.Zero.X, ds.Bitmap.Width, ds.Bitmap.Height);
            box = new HitBox((int)go.PhysicBody.Transform.X, (int)go.PhysicBody.Transform.Y, texture.Bitmap.Width, texture.Bitmap.Height);
            
            if (ks.IsKeyDown(Keys.Escape))
				Exit();
			if(ks.IsKeyDown(Keys.A))
				go.PhysicBody.Transform.X -= 6;
			if(ks.IsKeyDown(Keys.D))
				go.PhysicBody.Transform.X += 6;
			if (ks.IsKeyDown(Keys.Space) && ksOld.IsKeyUp(Keys.Space) || box.Intersects(boxB))
				go.PhysicBody.SetImpulse(new Vector2(0, -5));
			if(ks.IsKeyDown(Keys.Q) && ksOld.IsKeyUp(Keys.Q))
				go.PhysicBody.Enabled = !go.PhysicBody.Enabled;
			

			ksOld = Keyboard.GetState();
			base.Update(elapsed);
		}

		float grav = 0.0f;
		
		Vector2 posXX = new Vector2(-210.0f, 0.0f);
		
		protected override void Draw(double elapsed)
		{
			SpriteBatch.Draw(ds, Vector2.Zero, new Vector3(1.0f, 1.0f, 1.0f));
			DrawTriangle();
			SpriteBatch.Draw(texture, go.PhysicBody.Transform, new Vector3(1.0f, 1.0f, 1.0f));
			
			if(box.Intersects(boxB))
            	SpriteBatch.DrawHitBox(boxB, new Vector3(1.0f, 0.0f, 0.0f), false);
            if (box.Intersects(boxC))
            	SpriteBatch.DrawHitBox(boxC, new Vector3(1.0f, 0.0f, 0.0f), true);
            base.Draw(elapsed);
		}
		
		public void DrawTriangle()
        {			
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Vertex2(0.0, 0.0);
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex2(0.325, 0.5);
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