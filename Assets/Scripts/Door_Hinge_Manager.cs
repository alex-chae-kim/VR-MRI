using UnityEngine;

public class Door_Hinge_Manager : MonoBehaviour
{
    public float openAngle = 90f;  // Target angle
    public float openSpeed = 30f;  // Degrees per second

    private bool isOpening = false;

    public void OpenDoor()
    {
        if (!isOpening)
            StartCoroutine(OpenDoorSmoothly());
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
}
