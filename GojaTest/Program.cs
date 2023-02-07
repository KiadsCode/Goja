using System;
using Goja;
using Goja.Audio;
using Goja.Graphics;
using Goja.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GojaTest
{
	public class GGame : Game
	{
		private ulong t;
		private KeyboardState ks;
		private KeyboardState ksOld;
		private GameObject go;
		private World world;
		private HitBox boxB;
		private HitBox boxC = new HitBox(32, 32, 86, 86);
        private Texture2D texture;
        private Texture2D ds;
        private HitBox box;
        private WavSound sfx;
        
		protected override void Initialize()
		{
			Content.RootDirectory = "Content";
			Title = "Goja engine test";
			world = new World(this);
			go = new GameObject(this, world);
			go.PhysicBody.UpdateMass(150);
			world.UpdateGravityValue(new Vector2(0, 3));
			Components.Add(world);
			base.Initialize();
		}
		
		protected override void LoadContent()
		{
			UpdateIcon("Game.ico");
			
			texture = Content.Load<Texture2D>(@"rs");
			ds = Content.Load<Texture2D>(@"playerTest");
			sfx = Content.Load<WavSound>(@"expl");
			
			GL.ClearColor(Color4.CornflowerBlue);
            Width = 640;
            Height = 480;
            
			base.LoadContent();
		}
		
		protected override void Update(double elapsed)
		{
			t++;
			ks = Keyboard.GetState();
			Vector2 sinPos = new Vector2((float)Math.Sin(t / 12) * 6, (float)Math.Sin(t / 6) * 6);
			boxC = new HitBox((int)sinPos.X, (int)sinPos.Y, 86, 86);
            boxB = new HitBox(0, 0, ds.Bitmap.Width, ds.Bitmap.Height);
            box = new HitBox((int)go.PhysicBody.Transform.X, (int)go.PhysicBody.Transform.Y, texture.Bitmap.Width, texture.Bitmap.Height);
            
            if (ks.IsKeyDown(Keys.Escape))
				Exit();
			if(ks.IsKeyDown(Keys.A))
				go.PhysicBody.Transform.X -= 6;
			if(ks.IsKeyDown(Keys.D))
				go.PhysicBody.Transform.X += 6;
			if(go.PhysicBody.Enabled == false)
			{
				if(ks.IsKeyDown(Keys.W))
					go.PhysicBody.Transform.Y += 6;
				if(ks.IsKeyDown(Keys.S))
					go.PhysicBody.Transform.Y -= 6;
			}
			if (ks.IsKeyDown(Keys.Space) && ksOld.IsKeyUp(Keys.Space) || box.Intersects(boxB) || box.Intersects(boxC))
				go.PhysicBody.SetImpulse(new Vector2(0, -7));
			if(ks.IsKeyDown(Keys.E) && ksOld.IsKeyUp(Keys.E))
				sfx.Play();
			if(ks.IsKeyDown(Keys.Q) && ksOld.IsKeyUp(Keys.Q))
				go.PhysicBody.Enabled = !go.PhysicBody.Enabled;
			

			ksOld = Keyboard.GetState();
			base.Update(elapsed);
		}
		
		protected override void Draw(double elapsed)
		{
			SpriteBatch.Draw(ds, Vector2.Zero);
			DrawTriangle();
			SpriteBatch.Draw(texture, go.PhysicBody.Transform);
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