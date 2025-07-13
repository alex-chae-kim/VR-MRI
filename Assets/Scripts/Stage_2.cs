using Unity.VRTemplate;
using UnityEngine;

public class Stage_2 : StepManager
{
    public GameObject turnOffWindow;
    public GameObject turnOnWindow;
    public GameObject movement;
    public Door_Hinge_Manager doorHingeManager;

    public override void OnLastContinue()
    {
        Debug.Log("Stage 2: OnLastContinue called");
        if (turnOffWindow != null)
        {
            turnOffWindow.SetActive(false);
        }

        doorHingeManager.CloseDoor();
    }
}
