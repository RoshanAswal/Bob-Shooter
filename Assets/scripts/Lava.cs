using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lava : MonoBehaviour
{
    public List<GameObject> x;
    public Image h1,h2,h3;
    public GameObject res;
    private void Start() {
        x.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="BOB"){
            res.SetActive(true);
            Debug.Log(other.gameObject.tag);
            FindObjectOfType<AudioManager>().Stop("main");
            FindObjectOfType<AudioManager>().Play("ending");
            other.gameObject.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
            foreach (GameObject ob in x)
            {
                if(ob){
                    ob.transform.Find("armPivot").GetComponent<rotateHand>().enabled=false;
                }
            }        
            Destroy(h1);
            Destroy(h2);
            Destroy(h3);
            other.gameObject.GetComponent<Animator>().SetBool("death",true);
            other.gameObject.transform.rotation=Quaternion.Euler(0f,0f,90f);
            
        }   
    }
}
