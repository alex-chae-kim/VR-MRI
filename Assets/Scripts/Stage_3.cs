using UnityEngine;

public class Stage_3 : MonoBehaviour
{
    public InputGetter InputGetter;
    private float holdTime = 2f;

    // Update is called once per frame
    void Update()
    {
        if (InputGetter.GetLeftTrigger() > 0.5f && InputGetter.GetRightTrigger() > 0.5f )
        {
            holdTime -= Time.deltaTime;
            if (holdTime <= 0f)
            {
                Debug.Log("Stage 3 completed!");
            }
        }
        else
        {
            holdTime = 2f;
        }
    }
}
