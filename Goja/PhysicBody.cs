/*
 * Создано в SharpDevelop.
 * Пользователь: Acer
 * Дата: 05.02.2023
 * Время: 12:29
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace Goja
{
	/// <summary>
	/// Description of PhysicBody.
	/// </summary>
	public class PhysicBody
	{
		public Vector2 Transform = Vector2.Zero;
		internal Vector2 Gravity = Vector2.Zero;
		private const float GravityMaxAcceleration = 12f;
		private Vector2 _gravityAccelerating = Vector2.Zero;
		private float _mass;
		
		public void UpdateMass(float value)
		{
			_mass = value / 100f;
		}
		
		public bool Enabled
		{
			get;
			set;
		}
		
		private float GravityAccelerationUpdate(float value, float gravityValue)
		{
			return value + (_mass * (gravityValue / 20f));
		}
		
		public void Update(double elapsed)
		{
			if(Enabled)
			{
				if(_gravityAccelerating.X < GravityMaxAcceleration)
					_gravityAccelerating.X = GravityAccelerationUpdate(_gravityAccelerating.X, Gravity.X);
				if(_gravityAccelerating.Y < GravityMaxAcceleration)
					_gravityAccelerating.Y = GravityAccelerationUpdate(_gravityAccelerating.Y, Gravity.Y);
				Transform -= _gravityAccelerating;
			}
		}
		
		/// <exception cref="T:System.ArgumentNullException"></exception>
		public PhysicBody(Vector2 position)
		{
			if (position == null)
				throw new ArgumentNullException("position");
			this.Transform = position;
			
		}
		public void Impulse(Vector2 power)
		{
			_gravityAccelerating += power;
		}
		public void SetImpulse(Vector2 power)
		{
			_gravityAccelerating = power;
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			PhysicBody other = obj as PhysicBody;
				if (other == null)
					return false;
						return object.Equals(this.Transform, other.Transform) && object.Equals(this.Gravity, other.Gravity) && object.Equals(this._gravityAccelerating, other._gravityAccelerating) && object.Equals(this._mass, other._mass) && this.Enabled == other.Enabled;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (Transform != null)
					hashCode += 1000000007 * Transform.GetHashCode();
				if (Gravity != null)
					hashCode += 1000000009 * Gravity.GetHashCode();
				if (_gravityAccelerating != null)
					hashCode += 1000000021 * _gravityAccelerating.GetHashCode();
				hashCode += 1000000033 * _mass.GetHashCode();
				hashCode += 1000000087 * Enabled.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(PhysicBody lhs, PhysicBody rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(PhysicBody lhs, PhysicBody rhs) {
			return !(lhs == rhs);
		}

		#endregion
	}
}
