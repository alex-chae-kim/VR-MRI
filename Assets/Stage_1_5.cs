using Unity.VRTemplate;
using UnityEngine;

public class Stage_1_5 : StepManager
{
    public GameObject turnOffWindow;
    public GameObject turnOnWindow;
    public Door_Hinge_Manager doorHingeManager;

    public override void OnLastContinue()
    {
        Debug.Log("Stage 1_5: OnLastContinue called");
        if (turnOffWindow != null)
        {
            turnOffWindow.SetActive(false);
        }

        if (turnOnWindow != null)
        {
            turnOnWindow.SetActive(true);
        }

        doorHingeManager.OpenDoor();
    }
}
