#pragma once

namespace GojaCPP
{
	/// <summary>
	/// Description of Vector2.
	/// </summary>
	public ref class VECTOR2F
	{
	public:
		float X, Y;

		static VECTOR2F^ Up()
		{
			return gcnew VECTOR2F(0, -1);
		}
		static VECTOR2F^ Down()
		{
			return gcnew VECTOR2F(0, 1);
		}
		static VECTOR2F^ Left()
		{
			return gcnew VECTOR2F(-1, 0);
		}
		static VECTOR2F^ Right()
		{
			return gcnew VECTOR2F(1, 0);
		}

		void Subtract(VECTOR2F^ b);
		void Add(VECTOR2F^ b);
		static VECTOR2F^ Zero();
		VECTOR2F(float x, float y);
	};
}