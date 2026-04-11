using Unity.VRTemplate;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Stage_1_5 : StepManager
{
    public GameObject turnOffWindow;
    public GameObject turnOnWindow;
    public Door_Hinge_Manager doorHingeManager;

    public Transform target;
    public XROrigin XROrigin;
    public Animator oldAnimator;

    private IEnumerator transitionToStage2()
    {
        yield return new WaitForSeconds(2f);
        oldAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        XROrigin.MatchOriginUpCameraForward(target.up, target.forward);
        XROrigin.MoveCameraToWorldLocation(target.position);
        turnOnWindow.SetActive(true);
        oldAnimator.SetTrigger("FadeIn");
    }

    public override void OnLastContinue()
    {
        Debug.Log("Stage 1_5: OnLastContinue called");
        doorHingeManager.OpenDoor();
        turnOffWindow.SetActive(false);
        StartCoroutine(transitionToStage2());
    }


}
