#include "Vector2.h"

namespace GojaCPP
{

	void VECTOR2F::Add(VECTOR2F^ b)
	{
		X += b->X;
		Y += b->Y;
	}
	void VECTOR2F::Subtract(VECTOR2F^ b)
	{
		X -= b->X;
		Y -= b->Y;
	}

	VECTOR2F ^VECTOR2F::Zero()
	{
		return gcnew VECTOR2F(0, 0);
	}

	VECTOR2F::VECTOR2F(float x, float y)
	{
		X = x;
		Y = y;
	}
}
