/*
 * Сделано в SharpDevelop.
 * Пользователь: Acer
 * Дата: 25.01.2023
 * Время: 18:01
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;

namespace Goja
{
	/// <summary>
	/// Description of Vector2.
	/// </summary>
	public class Vector2
	{
		public float X, Y;
		
		public static Vector2 Lerp(Vector2 a, Vector2 b, float c)
		{
			Vector2 result = Vector2.Zero;
			result.X = MathHelper.Lerp(a.X, b.X, c);
			result.Y = MathHelper.Lerp(a.Y, b.Y, c);
			return result;
		}
		
		public static Vector2 Zero
		{
			get
			{
				return new Vector2(0, 0);
			}
		}
		
		public Vector2(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			Vector2 other = obj as Vector2;
				if (other == null)
					return false;
						return object.Equals(this.X, other.X) && object.Equals(this.Y, other.Y);
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * X.GetHashCode();
				hashCode += 1000000009 * Y.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(Vector2 lhs, Vector2 rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Vector2 lhs, Vector2 rhs) {
			return !(lhs == rhs);
		}
		public static Vector2 operator +(Vector2 lhs, Vector2 rhs) {
			return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
		}
		public static Vector2 operator -(Vector2 lhs, Vector2 rhs) {
			return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
		}		
		public static Vector2 operator -(Vector2 lhs) {
			return new Vector2(-lhs.X, -lhs.Y);
		}

		#endregion
	}
}
