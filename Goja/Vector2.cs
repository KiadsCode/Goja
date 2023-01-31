﻿/*
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
	}
}
