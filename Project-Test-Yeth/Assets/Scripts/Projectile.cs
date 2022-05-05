using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject target;
    bool hasTarget;
    public float speed;
    public int damage;

    // If the object's life exceeds its life timer, it will be destroyed.
    float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        hasTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer > 4) { Destroy(gameObject); }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void setTarget(GameObject t)
    {
        target = t;
        hasTarget = true;
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
            Destroy(gameObject);
        }
    }
}
