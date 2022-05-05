using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string name;
    public GameObject target;
    public int baseHp;
    int curHp;
    public float moveSpeed;
    public Vector3 targetPos;
    public Transform targetTransform;
    //public Transform transform;
    public GameObject manager;
    public int goldDrop;
    ShopScript shop;

    // Start is called before the first frame update
    void Start()
    {

        curHp = baseHp;
        manager = GameObject.FindWithTag("Controller");
        shop = manager.GetComponent<ShopScript>();
        setTarget();
    }


    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Die();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

    }



    public void Die()
    {
        Debug.Log("Enemy died.");
        shop.somethingDied(goldDrop);
        Destroy(gameObject);
    }

    public void setTarget() 
    { 
        target = GameObject.FindWithTag("Keep");
        targetTransform = target.transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damaging")
        {
            Projectile proj = collision.gameObject.GetComponent<Projectile>();
            curHp -= proj.getDamage();
            Debug.Log("Ouch, that hurt!");
        }
        else
        {
            moveSpeed = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        setTarget();
    }
}
