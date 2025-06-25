using UnityEngine;

public class bedTranslator : MonoBehaviour
{
    public float distance;
    public float moveSpeed;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool inMRI;
    private bool buttonPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = gameObject.transform.position;
        endPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - distance);
        inMRI = false;
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            if (!inMRI)
            {
                if(transform.position.z > endPos.z) 
                {
                    gameObject.transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
                }
                else
                {
                    buttonPressed = false;
                    inMRI = true;
                }
                
            }
            else if (inMRI)
            {
                if (transform.position.z < startPos.z)
                {
                    gameObject.transform.Translate(0, 0, moveSpeed * Time.deltaTime);
                }
                else
                {
                    buttonPressed = false;
                    inMRI = false;
                }
            }

        }
    }

    public void moveBed()
    {
        buttonPressed = true;
    }
}
