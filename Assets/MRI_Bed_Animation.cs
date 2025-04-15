using UnityEngine;

public class MRI_Bed : MonoBehaviour{
    public float speed = 7;
    public bool isMoving = true;  //Bed has to move in order for the script to work
    Vector3 targetPosition;  //bed has to stop at this location
    void Start(){
        transform.position = new Vector3(0, 0, 1); //place it 1 unit ahead of (0,0,0) on the z-axis
        targetPosition = transform.position + new Vector3(0,0,12);  //final position: (0,0,13)
    }
    void Update()
    {
        if (isMoving){ //isMoving is already assumed to be true 
            //translate the bed forward by 7 units/second and that it moves smoothly (Time.deltaTime)
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
            //if distance between the translated (current) position and endpoint is close, stop movement 
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f){
                isMoving = false;
            }
        }
    }
}

