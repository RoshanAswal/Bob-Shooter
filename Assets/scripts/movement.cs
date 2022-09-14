using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public GameObject res;
    private Sounds[] music;
    public Rigidbody2D player;
    public GameObject starting;
    public GameObject bulletPrefab;
    public ParticleSystem dust;
    public float speed=20f;
    float jumpspeed=5f,coolspeed=10f;
    public static bool cooljump=false;
    public Animator animator;
    int jumpCount=0,BOBCount=0;
    float degreePerSec=180f,rotAmount,curRot;
    public Image h1,h2,h3;
    public List<GameObject> x;
    private void Start() {
        x.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
        FindObjectOfType<AudioManager>().Play("main");
        music=FindObjectOfType<AudioManager>().sounds;
    }
    void rotate(){
        transform.rotation=Quaternion.Euler(0f,0f,90f);
    }
    void Update()
    {
       if(BOBCount==1)
            Destroy(h3);
       if(BOBCount==2)
            Destroy(h2);

        if(BOBCount==3){
            Death();
        }
        rotAmount=degreePerSec*Time.deltaTime;
        curRot=transform.localRotation.eulerAngles.z;
        Vector3 horizontal=new Vector3(SimpleInput.GetAxis("Horizontal"),0f,0f);
        if(horizontal.x<0){
            moveRight();
        }else if(horizontal.x>0){
            moveLeft();
        }else{
            animator.SetBool("RunLeft",false);
            animator.SetBool("RunRight",false);
        }
        transform.position+=horizontal*speed*Time.deltaTime;    

        if(cooljump==true){
            dust.Play();
            foreach (Sounds i in music)
            {
                if(i.clip.name=="main")
                    i.pitch=0.1f;
            }
            animator.SetBool("jumping",true);
            Time.timeScale=0.3f;
            player.freezeRotation=false;
            transform.localRotation=Quaternion.Euler(new Vector3(0,0,curRot+rotAmount));
            Invoke("stopDust",1f);
        }
        else{
            foreach (Sounds i in music)
            {
                if(i.clip.name=="main")
                    i.pitch=0.66f;
            }
            player.rotation=0;
            Time.timeScale=1;
        }
    }
    void Death(){
        FindObjectOfType<AudioManager>().Stop("main");
        FindObjectOfType<AudioManager>().Play("ending");

        gameObject.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
        foreach (GameObject ob in x)
        {
            if(ob){
                ob.transform.Find("armPivot").GetComponent<rotateHand>().enabled=false;
            }
        }        
        Destroy(h1);
        animator.SetBool("death",true);
        rotate();
        res.SetActive(true);
        Invoke("musicStop",1f);
    }
    void musicStop(){
        FindObjectOfType<AudioManager>().Stop("ending");
    }
    void moveRight(){
        dust.Play();
        animator.SetBool("RunLeft",true);
        Invoke("stopDust",1f);
    }
    void moveLeft(){
        dust.Play();
        animator.SetBool("RunRight",true);
        Invoke("stopDust",1f);
    }
    public void Jump(){
        if(jumpCount<2){
            dust.Play();
            animator.SetBool("jumping",true);
            player.AddForce(new Vector2(0f,jumpspeed),ForceMode2D.Impulse);
            jumpCount++;
            Invoke("stopDust",1f);
        }
    }
    public void CoolJump(){
        if(jumpCount==0){
            FindObjectOfType<AudioManager>().Play("slow");
            cooljump=true;
            player.AddForce(new Vector2(0f,coolspeed),ForceMode2D.Impulse);
        }
        jumpCount=2;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="ground"){
            jumpCount=0;
            cooljump=false;
            animator.SetBool("jumping",false);
        }
        if(other.gameObject.tag=="enemyBullet")
            BOBCount++;
    }
    public void shotBullet(){
        GameObject b=Instantiate(bulletPrefab,starting.transform.position,transform.rotation)as GameObject;
        FindObjectOfType<AudioManager>().Play("BOBgunshot");
        starting.GetComponent<SpriteRenderer>().enabled=true;
        StartCoroutine(muzzle());
    }
    IEnumerator muzzle(){
        yield return new WaitForSeconds(0.25f);
        starting.GetComponent<SpriteRenderer>().enabled=false;
    }
    void stopDust(){
        dust.Stop();
    }
}
