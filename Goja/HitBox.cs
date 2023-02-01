/*
 * Создано в SharpDevelop.
 * Пользователь: Acer
 * Дата: 01.02.2023
 * Время: 8:04
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using OpenTK.Graphics.OpenGL;

namespace Goja
{
	/// <summary>
	/// Description of 2D HitBox
	/// </summary>
	public class HitBox
	{
		public int Width;
		public int Height;
		public int X, Y;
		public float Left
		{
			get
			{
				return X - Width * 2;
			}
		}
		public float Right
		{
			get
			{
				return X;
			}
		}
		public float Top
		{
			get
			{
				return Y + Height * 2;
			}
		}
		public float Bottom
		{
			get
			{
				return Y;
			}
		}
		
		public HitBox(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
		
		public bool Intersects(HitBox value)
		{
			return Left < value.Right &&
				Right > value.Left &&
				Top > value.Bottom &&
				Bottom < value.Top;
		}

		private void DrawHitBox(Vector3 color, float left, float right, float top, float bottom)
		{
			GL.Color3(color.X, color.Y, color.Z);
			GL.Vertex2(left, top);
			GL.Vertex2(left, bottom);
			GL.Vertex2(right, bottom);
			GL.Vertex2(right, top);
			GL.Color3(1.0f, 1.0f, 1.0f);
		}
		public void Draw(Vector3 color, Game game, bool linesType)
		{
			float left = Left / game.Width;
			float top = Top / game.Height;
			float bottom = Bottom / game.Height;
			float right = Right / game.Width;
			if(linesType)
			{
				GL.LineWidth(3);
				GL.Begin(PrimitiveType.LineLoop);
				DrawHitBox(color, left, right, top, bottom);
				GL.End();
				GL.LineWidth(1);
			}
			else
			{
				GL.Begin(PrimitiveType.Quads);
				DrawHitBox(color, left, right, top, bottom);
				GL.End();
			}
		}
	}
}
