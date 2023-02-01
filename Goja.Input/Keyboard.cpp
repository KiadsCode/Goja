#include "Keyboard.h"

namespace Goja
{
	namespace Input
	{
		KeyboardState^ Keyboard::GetState()
		{
			return gcnew KeyboardState();
		}
	}
}