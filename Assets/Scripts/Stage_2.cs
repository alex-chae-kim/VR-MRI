using Unity.VRTemplate;
using UnityEngine;

public class Stage_2 : StepManager
{
    public GameObject turnOffWindow;
    public GameObject stage3Manager;
    public Door_Hinge_Manager doorHingeManager;

    public override void OnLastContinue()
    {
        Debug.Log("Stage 2: OnLastContinue called");
        if (turnOffWindow != null)
        {
            turnOffWindow.SetActive(false);
        }
        if (stage3Manager != null)
        {
            stage3Manager.SetActive(true);
        }

        doorHingeManager.CloseDoor();
    }
}
