/*
 * Создано в SharpDevelop.
 * Пользователь: Acer
 * Дата: 05.02.2023
 * Время: 12:38
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;

namespace Goja
{
	/// <summary>
	/// Description of World.
	/// </summary>
	public class World : GameComponent
	{
		private List<PhysicBody> _physicBodys = new List<PhysicBody>();
		public IEnumerable<PhysicBody> PhysicBodys
		{
			get
			{
				return _physicBodys;
			}
		}
		public Vector2 Gravity
		{
			get;
			private set;
		}
		
		public override void Update(double elapsed)
		{
			foreach (PhysicBody pb in _physicBodys)
				pb.Update(elapsed);
			base.Update(elapsed);
		}
		
		public void Add(PhysicBody pb)
		{
			_physicBodys.Add(pb);
		}
		
		public void UpdateGravityValue(Vector2 value)
		{
			Gravity = value;
			foreach (var pb in _physicBodys)
				pb.Gravity = value;
		}
		
		public World(Game game) : base(game)
		{
		}
	}
}
