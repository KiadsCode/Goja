#include "Input.h"

using namespace System;

namespace Goja
{
	bool Input::IsKeyDown(Keys key)
	{
		return GetAsyncKeyState((int)key);
	}
	bool Input::IsKeyUp(Keys key)
	{
		return !IsKeyDown(key);
	}
	VECTOR2F^ Input::GetGlobalMousePosition()
	{
		VECTOR2F ^data = gcnew VECTOR2F(0);
		POINT p;
		if(GetCursorPos(&p))
		{
			data->X = p.x;
			data->Y = p.y;
		}
		return data;
	}
}
