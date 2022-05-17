using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public Vector3 targetPos;
    bool hasTarget;
    public float speed;
    public int damage;
    //ProjectileInfo thisInfo;

    // If the object's life exceeds its life timer, it will be destroyed.
    float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        //hasTarget = false;
        //thisInfo = GetComponent<ProjectileInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer > 4) 
        { 
            Destroy(gameObject);
            Debug.Log("Projectile Died of old age."); 
        }
        
        transform.position = Vector3.MoveTowards(transform.position, /*target.transform.position*/ targetPos, speed * Time.deltaTime);
    }

    public void setTarget(GameObject t)
    {
        //targetPos = t.transform.position;
        target = t;
        targetPos = target.transform.position;
        //hasTarget = true;
        //Debug.Log("Target Set");
    }

    public void setSpeed(float s)
    {
        speed = s;
    }

    public int getDamage()
    {
        return damage;
    }

    public void lostTarget() { hasTarget = false; }
    
    void CollisionEnter2D(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit an Enemy");
        }
    }
}
