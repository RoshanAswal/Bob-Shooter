using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public GameObject bulletHit;
    GameObject par;
    float speed = 7f;
    Vector3 screenbounds;
    public Rigidbody2D bullet;
    public Rigidbody2D player;
    // public GameObject parent;
    private void Start()
    {
      bullet.velocity=transform.right*-speed;
      screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void Update()
    {
      if (bullet.transform.position.x > screenbounds.x){
        par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
        Destroy(par,0.5f);
        Destroy(this.gameObject);
      }
      if(bullet.transform.position.x<screenbounds.x*-1){
        par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
        Destroy(this.gameObject);
        Destroy(par,0.5f);
      }
      if(bullet.transform.position.y>screenbounds.y){
        par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
        Destroy(this.gameObject);
        Destroy(par,0.5f);
      }
      if(bullet.transform.position.y<screenbounds.y*-1){
        par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
        Destroy(this.gameObject);
        Destroy(par,0.5f);
      }
    }
    private void OnCollisionEnter2D(Collision2D other) {
      par=Instantiate(bulletHit,bullet.transform.position,bullet.transform.rotation)as GameObject;
      if(other.gameObject.tag!="enemy" && other.gameObject.tag!="enemyBullet"){
      FindObjectOfType<AudioManager>().Play("simpleHit");
      }
      if(other.gameObject.tag!="enemy"){
        Destroy(this.gameObject);
      }
      Destroy(par,0.5f);
    }
    // void desParticle(){
    //   Destroy(par);
    // }
}
