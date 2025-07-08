using Unity.VRTemplate;
using UnityEngine;

public class Stage_0 : StepManager
{
    public GameObject turnOffWindow;
    public GameObject turnOnWindow;
    public Door_Hinge_Manager doorHingeManager;

    public override void OnLastContinue()
    {
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
