#include "VECTOR2F.h"

using namespace System;

namespace GojaCPP
{
	VECTOR2F::VECTOR2F(float x, float y) {
		X = x;
		Y = y;
	}	
	VECTOR2F::VECTOR2F(float value) {
		X = value;
		Y = value;
	}

	VECTOR2F::~VECTOR2F() {
		X = 0;
		Y = 0;
	}
}