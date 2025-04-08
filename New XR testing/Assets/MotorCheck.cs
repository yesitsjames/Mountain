using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCheck : MonoBehaviour
{
    public int intensity;
    
    void OnTriggerEnter(Collider collider)
    {
        
            Debug.Log("Collided:"+ collider.tag);
            GetComponent<Renderer>().enabled = true;

        switch (collider.tag) {
            case "Rain":
            intensity = 10;
            break;
            case "Wind":
            intensity = 5;
            break;
            case "Bullet":
            intensity = 100;
            break;
            case "Blood":
            intensity = 15;
            break;
            default:
            intensity = 50; 
            break;
        
        }
            
        
        
    }

    private void OnTriggerStay(Collider collider)
    {
        //Debug.Log("Collided:" + collider.tag);
        GetComponent<Renderer>().enabled = true;

        switch (collider.tag)
        {


            
            case "Heat":
                Vector3 heatDistance = transform.position - collider.transform.position;
                if (heatDistance.magnitude > 0)
                {
                    intensity = (int)(20 / heatDistance.magnitude);
                    Debug.Log(intensity);
                }
                else {
                    intensity = 500;
                    Debug.Log("MAX heat");
                }
                
                break;
            case "Cold":
                Vector3 coldDistance = transform.position - collider.transform.position;
                if (coldDistance.magnitude > 0)
                {
                    intensity = (int)(50 / coldDistance.magnitude);
                    Debug.Log(intensity);
                }
                else
                {
                    intensity = 500;
                    Debug.Log("MAX cold");
                }
                break;




            default:
                break;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Collided");
        GetComponent<Renderer>().enabled = false;
        intensity = 0;
    }
}