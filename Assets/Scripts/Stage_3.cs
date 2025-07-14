using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class Stage_3 : MonoBehaviour
{
    public Transform target;
    public XROrigin XROrigin;
    public InputGetter InputGetter;
    public GameObject newXROrigin;
    public GameObject oldXROrigin;
    public GameObject stage4;
    public Animator oldAnimator;
    public Animator newAnimator;
    private float holdTime = 2f;
    private bool first = true;

    // Update is called once per frame
    void Update()
    {
        if (InputGetter.GetLeftTrigger() > 0.5f && InputGetter.GetRightTrigger() > 0.5f )
        {
            holdTime -= Time.deltaTime;
            if (holdTime <= 0f && first)
            {
                first = false;
                Debug.Log("Stage 3 completed!");
                StartCoroutine(transitionToMRI());
            }
        }
        else
        {
            holdTime = 2f;
        }
    }

    private IEnumerator transitionToMRI()
    {
        oldAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        XROrigin.MoveCameraToWorldLocation(target.position);
        XROrigin.MatchOriginUpCameraForward(target.up, target.forward);
        oldAnimator.SetTrigger("FadeIn");
        //oldXROrigin.SetActive(false);
        //newXROrigin.SetActive(true);
        stage4.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
