using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.transform;
        baseHp = 1;
        curHp = baseHp;
        moveSpeed = 1;
        setTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Die();
        }
        float timeDif = Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * timeDif);
    }

    
}
