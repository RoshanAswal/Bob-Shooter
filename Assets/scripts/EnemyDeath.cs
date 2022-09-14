using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    int enemyCount=0;
    public GameObject rot;
    public GameObject rotpivot;
    public HealthBar health;
    int c=0;
    public float hitPoints,maxHitPoints;
    private void Start() {
        hitPoints=maxHitPoints;
        health.SetHealth(hitPoints,maxHitPoints);
    }
    void Update()
    {
        health.SetHealth(hitPoints,maxHitPoints);
        if(enemyCount==3){
            Time.timeScale=0.5f;
            this.gameObject.transform.rotation=Quaternion.Euler(0f,0f,-90f);
            rot.transform.rotation=Quaternion.Euler(0f,0f,0f);
            rotpivot.transform.rotation=Quaternion.Euler(0f,0f,0f);
            Invoke("Des",1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="bullet"){
            enemyCount++;
            hitPoints--;
        }
    }
    void Des(){
        c++;
        Time.timeScale=1;
        Destroy(this.gameObject);
    }
}
