using UnityEngine;

public class Door_Hinge_Manager : MonoBehaviour
{
    public float openAngle = 90f;  
    public float closeAngle = 0f;  
    public float openSpeed = 30f;  // Degrees per second

    private bool isOpening = false;
    private bool isClosing = false;

    public void OpenDoor()
    {
        if (!isOpening)
            StartCoroutine(OpenDoorSmoothly());
    }

    public void CloseDoor()
    {
        if (!isOpening)
            StartCoroutine(CloseDoorSmoothly());
    }

    private System.Collections.IEnumerator OpenDoorSmoothly()
    {
        isOpening = true;
        float currentAngle = transform.localEulerAngles.y;
        float targetAngle = currentAngle + openAngle;
        float angleRemaining = openAngle;

        while (angleRemaining > 0.01f)
        {
            float angleThisFrame = openSpeed * Time.deltaTime;
            angleThisFrame = Mathf.Min(angleThisFrame, angleRemaining);

            transform.Rotate(0, angleThisFrame, 0);

            angleRemaining -= angleThisFrame;

            yield return null;
        }

        Vector3 finalRotation = transform.localEulerAngles;
        finalRotation.y = targetAngle;
        transform.localEulerAngles = finalRotation;

        Debug.Log("Door opened to angle: " + transform.localEulerAngles.y);
        isOpening = false;
    }

    private System.Collections.IEnumerator CloseDoorSmoothly()
    {
        isClosing = true;
        float currentAngle = transform.localEulerAngles.y;
        float targetAngle = closeAngle;
        float angleRemaining = openAngle;

        while (angleRemaining > 0.01f)
        {
            float angleThisFrame = openSpeed * Time.deltaTime;
            angleThisFrame = Mathf.Min(angleThisFrame, angleRemaining);

            transform.Rotate(0, -angleThisFrame, 0);

            angleRemaining -= angleThisFrame;

            yield return null;
        }

        Vector3 finalRotation = transform.localEulerAngles;
        finalRotation.y = targetAngle;
        transform.localEulerAngles = finalRotation;

        Debug.Log("Door closed to angle: " + transform.localEulerAngles.y);
        isClosing = false;
    }
}
