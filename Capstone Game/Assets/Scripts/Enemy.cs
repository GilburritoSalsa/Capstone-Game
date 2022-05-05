using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public int baseHp;
    public int curHp;
    public float moveSpeed;
    public Vector3 targetPos;
    public Transform targetTransform;
    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Die();
        }


    }



    public void Die()
    {
        Destroy(gameObject);
    }

    public void setTarget() 
    { 
        target = GameObject.FindWithTag("Keep");
        targetTransform = target.transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision occured.");
        moveSpeed = 0;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        setTarget();
    }
}
