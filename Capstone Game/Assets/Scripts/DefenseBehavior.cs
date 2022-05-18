using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBehavior : MonoBehaviour
{
    // Tower damage and projectile it fires. Both are used when attacking an enemy. Note some towers may use melee weapons like spears.
    public int damage;
    public GameObject projectile;
    Projectile pScript;
    float projSpeed;

    bool justFired;

    // Fire rate is decimal in terms of seconds per attack. For example, a fire rate of 0.5 would be 2 attacks per second.
    public float attackRate;
    public float attackTimer;

    // When a valid object comes within range, the tower will target that object.
    public float range;
    public List<GameObject> targetQ;
    public GameObject target;
    bool hasTarget;
    

    // Collider used to detect enemies
    CircleCollider2D rangeCol;

    // Start is called before the first frame update
    void Start()
    {
        pScript = projectile.GetComponent<Projectile>();
        targetQ = new List<GameObject>();
        rangeCol = GetComponent<CircleCollider2D>();
        rangeCol.radius = range;
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (targetQ.Count > 0 && attackTimer > attackRate)
        {
//            target = targetQ[0];
            attackTimer = 0;
            attack();
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy Entered Range");
            targetQ.Add(col.gameObject);
        }
        if (col.gameObject.tag == "Damaging")
        {
            if (targetQ[0] == null)
            {
                targetQ.RemoveAt(0);
            }
            else if(targetQ.Count != 0 || targetQ.Count < 0)
            {
                pScript = gameObject.GetComponent<Projectile>();
                col.gameObject.GetComponent<Projectile>().setTarget(targetQ[0]);
                //Debug.Log("Firing");
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            targetQ.RemoveAt(0);
        }

    }

    public void attack()
    {
        //if (!target.isMissing())
            Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
