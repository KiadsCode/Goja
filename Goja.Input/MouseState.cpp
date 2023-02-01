#include "MouseState.h"

namespace Goja
{
	namespace Input
	{
		bool MouseState::IsButtonPressed(MouseButton button)
		{
			switch (button)
			{
			case MouseButton::LeftButton:
				return LeftMouseButton;
				break;
			case MouseButton::RightButton:
				return RightMouseButton;
				break;
			case MouseButton::MiddleButton:
				return MiddleMouseButton;
				break;
			default:
				return false;
				break;
			}
			return false;
		}
		bool MouseState::IsButtonReleased(MouseButton button)
		{
			return !IsButtonPressed(button);
		}

		int MouseState::GetPositionX(int windowPosX)
		{
			int pos = 0;
			POINT p;
			if (GetCursorPos(&p))
				pos = p.x;
			pos -= windowPosX;
			return pos;
		}
		int MouseState::GetPositionY(int windowPosY)
		{
			int pos = 0;
			POINT p;
			if (GetCursorPos(&p))
				pos = p.y;
			pos -= windowPosY;
			return pos;
		}

		VECTOR2F^ MouseState::GetPosition(int windowPosX, int windowPosY)
		{
			int posX = GetPositionX(windowPosX);
			int posY = GetPositionY(windowPosY);
			VECTOR2F^ pos = gcnew VECTOR2F(posX, posY);
			return pos;
		}

		MouseState::MouseState()
		{
			LeftMouseButton = GetAsyncKeyState((int)MouseButton::LeftButton);
			RightMouseButton = GetAsyncKeyState((int)MouseButton::RightButton);
			MiddleMouseButton = GetAsyncKeyState((int)MouseButton::MiddleButton);
		}
	}
}