using UnityEngine;

[System.Serializable]
public class ActiveOnAwake : MonoBehaviour
{
    public GameObject[] wakeUpObjects;
    public GameObject[] sleepObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in wakeUpObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        foreach (GameObject obj in sleepObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
