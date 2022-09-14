using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBKill : MonoBehaviour
{
    public GameObject bulletHit;
    GameObject par;
    float speed = 7f;
    float wait=11;
    Vector3 screenbounds;
    public Rigidbody2D bullet;
    public Rigidbody2D player;
    private void Awake()
    {  
        bullet.velocity=transform.right*speed;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void Update()
    {
      wait+=Time.deltaTime;
      if(wait>10){
        if (bullet.transform.position.x > screenbounds.x){
          par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
          Destroy(this.gameObject);
          Destroy(par,0.5f);
        }
        if(bullet.transform.position.x<screenbounds.x*-1){
          par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
          Destroy(this.gameObject);
          Destroy(par,0.5f);
        }
        if(bullet.transform.position.y>screenbounds.y){
          par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
          Destroy(par,0.5f);
          Destroy(this.gameObject);
        }
        if(bullet.transform.position.y<screenbounds.y*-1){
          par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
          Destroy(par,0.5f);
          Destroy(this.gameObject);
        }
        wait=0;
      }
    }
    private void OnCollisionEnter2D(Collision2D other) {
      par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
      if(other.gameObject.tag!="BOB" && other.gameObject.tag!="bullet"){
        if(other.gameObject.tag=="enemy")
          FindObjectOfType<AudioManager>().Play("metalHit");
        else
          FindObjectOfType<AudioManager>().Play("simpleHit");
      }
      Destroy(this.gameObject);
      Destroy(par,0.5f);
    }
    // void desParticle(){
    //   Destroy(par);
    // }
}
