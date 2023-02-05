/*
 * Создано в SharpDevelop.
 * Пользователь: Acer
 * Дата: 05.02.2023
 * Время: 12:52
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using Goja;

namespace GojaTest
{
	/// <summary>
	/// Description of Player.
	/// </summary>
	public class GameObject : GameComponent
	{
		public PhysicBody PhysicBody = new PhysicBody(Vector2.Zero);
		public GameObject(Game game, World world) : base(game)
		{
			PhysicBody.Enabled = true;
			world.Add(PhysicBody);
		}
	}
}
