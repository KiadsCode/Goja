/*
 * Создано в SharpDevelop.
 * Пользователь: Acer
 * Дата: 31.01.2023
 * Время: 20:46
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;

namespace Goja.Graphics
{
    /// <summary>
    /// Drawing sprites
    /// </summary>
    public class SpriteBatch
    {
        private Game _game;

        public SpriteBatch(Game game)
        {
            _game = game;
        }
        
        #region Textures Drawing
        public void Draw(Texture2D texture, Vector2 pos, Vector3 color, Vector2 origin)
        {
            Game game = _game;
            Vector2 position = new Vector2(pos.X + origin.X, pos.Y - origin.Y);

            float x = position.X / game.Width;
            float y = position.Y / game.Width;
            float renerYA = (position.Y + texture.Bitmap.Height * 2) / game.Height;
            float renerYB = (position.Y) / game.Height;

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, texture.TextureID);
            GL.Begin(PrimitiveType.Quads);

            GL.Rotate(1, 0.0f, 0.0f, 0.0f);
            GL.Color3(color.X, color.Y, color.Z);
            GL.TexCoord2(0.0f, -1.0f); GL.Vertex2((position.X - texture.Bitmap.Width * 2) / game.Width, renerYA);
            GL.TexCoord2(1.0f, -1.0f); GL.Vertex2(x, renerYA);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x, renerYB);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2((position.X - texture.Bitmap.Width * 2) / game.Width, renerYB);
            GL.Color3(1.0f, 1.0f, 1.0f);

            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Blend);
        }
        public void Draw(Texture2D texture, Vector2 pos)
        {
            Game game = _game;

            float x = pos.X / game.Width;
            float y = pos.Y / game.Width;
            float renerYA = (pos.Y + texture.Bitmap.Height * 2) / game.Height;
            float renerYB = (pos.Y) / game.Height;

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, texture.TextureID);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.TexCoord2(0.0f, -1.0f); GL.Vertex2((pos.X - texture.Bitmap.Width * 2) / game.Width, renerYA);
            GL.TexCoord2(1.0f, -1.0f); GL.Vertex2(x, renerYA);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x, renerYB);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2((pos.X - texture.Bitmap.Width * 2) / game.Width, renerYB);
            GL.Color3(1.0f, 1.0f, 1.0f);

            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Blend);
        }
        public void Draw(Texture2D texture, Vector2 pos, Vector3 color)
        {
            Game game = _game;

            float x = pos.X / game.Width;
            float y = pos.Y / game.Width;
            float renerYA = (pos.Y + texture.Bitmap.Height * 2) / game.Height;
            float renerYB = (pos.Y) / game.Height;

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, texture.TextureID);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color.X, color.Y, color.Z);
            GL.TexCoord2(0.0f, -1.0f); GL.Vertex2((pos.X - texture.Bitmap.Width * 2) / game.Width, renerYA);
            GL.TexCoord2(1.0f, -1.0f); GL.Vertex2(x, renerYA);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x, renerYB);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2((pos.X - texture.Bitmap.Width * 2) / game.Width, renerYB);
            GL.Color3(1.0f, 1.0f, 1.0f);

            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Blend);
        }
        #endregion
        #region HitBox Drawing        
        private void DrawHitBoxBase(Vector3 color, float left, float right, float top, float bottom)
		{
			GL.Color3(color.X, color.Y, color.Z);
			GL.Vertex2(left, top);
			GL.Vertex2(left, bottom);
			GL.Vertex2(right, bottom);
			GL.Vertex2(right, top);
			GL.Color3(1.0f, 1.0f, 1.0f);
		}
		public void DrawHitBox(HitBox hitBox, Vector3 color, bool linesType)
		{
			Size gameSize = new Size(_game.Width, _game.Height);
			float Left = hitBox.Left;
			float Right = hitBox.Right;
			float Top = hitBox.Top;
			float Bottom = hitBox.Bottom;
			float left = Left / gameSize.Width;
			float top = Top / gameSize.Height;
			float bottom = Bottom / gameSize.Height;
			float right = Right / gameSize.Width;
			if(linesType)
			{
				GL.LineWidth(3);
				GL.Begin(PrimitiveType.LineLoop);
				DrawHitBoxBase(color, left, right, top, bottom);
				GL.End();
				GL.LineWidth(1);
			}
			else
			{
				GL.Begin(PrimitiveType.Quads);
                DrawHitBoxBase(color, left, right, top, bottom);
				GL.End();
			}
		}
        #endregion
        
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			SpriteBatch other = obj as SpriteBatch;
				if (other == null)
					return false;
						return object.Equals(this._game, other._game);
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (_game != null)
					hashCode += 1000000007 * _game.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(SpriteBatch lhs, SpriteBatch rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(SpriteBatch lhs, SpriteBatch rhs) {
			return !(lhs == rhs);
		}

		#endregion
    }
}