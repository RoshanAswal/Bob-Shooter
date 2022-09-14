using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
   public Transform player;

    void FixedUpdate()
    {
        Vector3 pos=new Vector3(player.position.x,0f,-10f);
        Vector3 smooth=Vector3.Lerp(transform.position,pos,0.125f);
        transform.position=smooth;
    }
}
