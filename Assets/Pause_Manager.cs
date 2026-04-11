using Unity.XR.CoreUtils;
using UnityEngine;

public class Pause_Manager : MonoBehaviour
{
    //public Transform target;
    //public XROrigin XROrigin;
    public InputGetter InputGetter;
    public AudioManager audioManager;
    public GameObject pauseMenu;
    public GameObject headcoil;
    public GameObject machine;
    private float holdTime = 3f;
    private float unpauseTime = 3f;
    private bool paused = false;
    public bool active = false;
    public string currentlyPlaying;

    void Start()
    {
        currentlyPlaying = "null";
    }

    void Update()
    {
            if (active & !paused & InputGetter.GetLeftTrigger() > 0.5f)
            {
                holdTime -= Time.deltaTime;
                if (holdTime <= 0f && !paused)
                {
                    paused = true;     
                    audioManager.Stop(currentlyPlaying);
                    pauseMenu.SetActive(true);
                    headcoil.SetActive(false);
                    machine.SetActive(false);
                    Debug.Log("Pause");
                    Time.timeScale = 0f;
                }
            }
            else
            {
                holdTime = 3f;
            }

            if (active & paused && InputGetter.GetLeftTrigger() > 0.5f)
            {
                unpauseTime -= Time.unscaledDeltaTime;
                if (unpauseTime <= 0f && paused)
                {
                    paused = false;
                    audioManager.Unpause(currentlyPlaying);
                    headcoil.SetActive(true);
                    machine.SetActive(true);
                    pauseMenu.SetActive(false);
                    Debug.Log("Un-pause");
                    Time.timeScale = 1f;
                }
            }
            else
            {
                unpauseTime = 3f;
            }
        }
}
