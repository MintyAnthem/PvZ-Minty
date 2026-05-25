using UnityEngine;
using UnityEngine.InputSystem;

public class Tester_Script : MonoBehaviour
{

    public SunCounter_Script sunCounter;

    public void OnSpaceButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            sunCounter.ChangeSun(25);
        }
    }
}
