#pragma once
#include "MouseState.h"

namespace Goja
{
	namespace Input
	{
		public ref class Mouse
		{
		public:
			static MouseState^ GetState();
			static void SetPosition(int x, int y, int windowPosX, int windowPosY);
		};
	}
}