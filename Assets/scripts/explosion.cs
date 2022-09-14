using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class explosion : MonoBehaviour
{
    public GameObject res;
    public movement movement;
    public float fieldOfImpact;
    public GameObject explosionEffect;
    public float force,upforce;
    public LayerMask layer;
    public Rigidbody2D player;
    public List<GameObject> x;
    private void Start() {
        x.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag!="ground"){
            FindObjectOfType<AudioManager>().Play("explosion");
            Collider2D[] objects=Physics2D.OverlapCircleAll(transform.position,fieldOfImpact,layer);
            foreach (Collider2D obj in objects)
            {
                Vector3 direction=obj.transform.position-transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction*force);
                obj.GetComponent<Rigidbody2D>().AddForce(player.transform.up*force);
                if(obj.gameObject.tag=="enemy"){
                    obj.transform.rotation=Quaternion.Euler(0f,0f,-90f);
                    Destroy(obj.gameObject);
                }
                if(obj.gameObject.tag=="BOB"){
                    FindObjectOfType<AudioManager>().Stop("main");
                    FindObjectOfType<AudioManager>().Play("ending");
                    movement.enabled=false;
                    foreach (GameObject ob in x)
                    {
                        if(ob){
                            ob.transform.Find("armPivot").GetComponent<rotateHand>().enabled=false;
                        }
                    }
                    player.AddForce(-transform.right*force);
                    player.GetComponent<Rigidbody2D>().AddForce(player.transform.up*force);
                    movement.animator.SetBool("death",true);
                    player.transform.rotation=Quaternion.Euler(0f,0f,90f);
                    Destroy(movement.h1);
                    Destroy(movement.h2);
                    Destroy(movement.h3);
                    res.SetActive(true);
                }
            }
            GameObject par=Instantiate(explosionEffect,transform.position,Quaternion.identity);
            Destroy(par,1f);
            Destroy(gameObject);
        }   
    }
 
    void OnDrawGizmosSelected() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,fieldOfImpact);    
    }
}
