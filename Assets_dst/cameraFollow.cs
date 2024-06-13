using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
   private Transform target;
    public float smoothing;

  //  public Vector4 maxPos;
  //  public Vector4 minPos;

    void Start()
    {
        
       
    }

void Uptade()
{
    
  
}
    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if(transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x,target.position.y, transform.position.z);

          /*  targetPos.x = Mathf.Clamp(targetPos.x , minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y , minPos.y, maxPos.y);*/

            transform.position = Vector3.Lerp(transform.position,targetPos, smoothing);
        }
    }
}
