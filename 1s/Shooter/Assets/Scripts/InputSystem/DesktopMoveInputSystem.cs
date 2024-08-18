using UnityEngine;

public class DesktopMoveInputSystem : IMoveInputSystem
{
    public Vector2 InputVector => 
        new Vector2
        (
            Input.GetAxisRaw(InputAxesHolder.HORIZONTAL), 
            Input.GetAxisRaw(InputAxesHolder.VERTICAL)
        );
}