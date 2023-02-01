#pragma once
#include "KeyboardState.h"

namespace Goja
{
	namespace Input
	{
		public ref class Keyboard
		{
		public:
			static KeyboardState^ GetState();
		};
	}
}