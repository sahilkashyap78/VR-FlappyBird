using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool dead = false;
    public float speed = 3.5f;
    public float jumpforce =10f;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
     if(dead==true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return; }
        //move forward
        GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y,speed);
        //Make Forward jump
        if(Input.GetMouseButtonDown(0))
        {

            Debug.Log("Mouse button pressessd");
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpforce,GetComponent<Rigidbody>().velocity.y);

        }
    }


    void OnTriggerEnter(Collider col)
    {


        if (col.tag == "Obstacles")
        {

            dead = true;
            
        }
            
                
                }

}
