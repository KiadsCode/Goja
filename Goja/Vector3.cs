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
	public class Vector3
	{
		public float X, Y, Z;
		
		public static Vector3 Lerp(Vector3 a, Vector3 b, float c)
		{
			Vector3 result = Vector3.Zero;
			result.X = MathHelper.Lerp(a.X, b.X, c);
			result.Y = MathHelper.Lerp(a.Y, b.Y, c);
			result.Z = MathHelper.Lerp(a.Z, b.Z, c);
			return result;
		}
		
		public static Vector3 Zero
		{
			get
			{
				return new Vector3(0, 0, 0);
			}
		}
		
		public Vector3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}
	}
}
