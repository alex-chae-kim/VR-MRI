using System.Collections;
using Unity.VRTemplate;
using UnityEngine;

public class Stage_6 : StepManager
{
    public Animator screenAnimator;

    public override void OnLastContinue()
    {
        StartCoroutine(endSimulation());
    }
    public IEnumerator endSimulation()
    {
        screenAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);
        Application.Quit();
    }
}
