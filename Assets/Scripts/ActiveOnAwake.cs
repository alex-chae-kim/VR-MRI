using UnityEngine;

[System.Serializable]
public class ActiveOnAwake : MonoBehaviour
{
    public GameObject[] gameObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in gameObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
