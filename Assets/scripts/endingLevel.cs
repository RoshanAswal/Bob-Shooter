using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingLevel : MonoBehaviour
{
    public List<GameObject> x;
    private void Start() {
        x.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
    }
    private void Update() {
        foreach(GameObject ob in x.ToArray()){
            if(ob==null){
                x.Remove(ob);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="BOB" && x.Count==0){
            gameObject.GetComponent<Collider2D>().isTrigger=true;
            gameObject.GetComponent<SpriteRenderer>().enabled=false;               
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag=="BOB")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
