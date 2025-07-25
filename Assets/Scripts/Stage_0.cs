using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using Unity.VRTemplate;

public class Stage_0 : StepManager
{
    public Scan_Manager scanManager;
    public Dropdown_Manager dropdownManager;
    public Transform target;
    public XROrigin XROrigin;
    public InputGetter InputGetter;
    public GameObject stage1;
    public Animator oldAnimator;

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator transitionToStage1()
    {
        oldAnimator.SetTrigger("FadeOut");
        foreach (string option in dropdownManager.options)
        {
            Scan scan = new Scan(option, option, default, false);
            scanManager.addScan(scan);
        }
        yield return new WaitForSeconds(3f);
        XROrigin.MoveCameraToWorldLocation(target.position);
        XROrigin.MatchOriginUpCameraForward(target.up, target.forward);
        oldAnimator.SetTrigger("FadeIn");
        stage1.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public override void OnLastContinue()
    {
        StartCoroutine(transitionToStage1());
    }
}
