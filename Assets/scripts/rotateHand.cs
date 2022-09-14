using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateHand : MonoBehaviour
{
    Vector3 screenbounds;
    public Transform player;
    public Transform Camera;
    public GameObject enemyBullet;
    public Transform startingPoint; 
    public float timebetween=4f;
    float starttime;
    void Update () {
        Vector3 current = transform.position;
        var direction = player.position - current;
        var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(timebetween<0){
            if(this.gameObject.transform.position.x-player.transform.position.x<15f || player.transform.position.x-this.gameObject.transform.position.x>15f){
                visible();
            }
            timebetween=2.5f;
        }else{
            timebetween-=Time.deltaTime;
        }
    }
    public void visible(){
        Instantiate(enemyBullet,startingPoint.position,startingPoint.rotation);
        FindObjectOfType<AudioManager>().Play("enemyGunshot");
    }   
}
