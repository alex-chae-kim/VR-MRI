using UnityEngine;

public class Door_Hinge_Manager : MonoBehaviour
{
    private float openAngle = 90f;
    private float closeAngle = 0f;

    public void OpenDoor()
    {
        while (transform.rotation.y < openAngle)
        {
            transform.Rotate(0, 0.5f, 0);
            if (transform.rotation.y >= openAngle)
            {
                transform.rotation = Quaternion.Euler(0, openAngle, 0);
                break;
            }
        }
    }

    public void CloseDoor()
    {
        while (transform.rotation.y > closeAngle)
        {
            transform.Rotate(0, -0.5f, 0);
            if (transform.rotation.y <= closeAngle)
            {
                transform.rotation = Quaternion.Euler(0, closeAngle, 0);
                break;
            }
        }
    }


}
