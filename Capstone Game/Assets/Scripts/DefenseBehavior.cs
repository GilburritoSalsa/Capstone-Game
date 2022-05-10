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
    List<GameObject> targetQ;
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
        hasTarget = false;
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (hasTarget && attackTimer > attackRate /*&& !justFired*/)
        {
            attackTimer = 0;
            attack();
            
            //justFired = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Entered Range");
            targetQ.Add(col.gameObject);
            hasTarget = true;
        }
        if (col.gameObject.tag == "Damaging")
        {
            pScript = gameObject.GetComponent<Projectile>();
            col.gameObject.GetComponent<Projectile>().setTarget(targetQ[0]);
            Debug.Log("Firing");
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && targetQ.Count == 0)
        {
            hasTarget = false;
        }
    }

    public void attack()
    {
        pScript.setTarget(targetQ[0]);
        Instantiate(projectile, transform.position, Quaternion.identity);

    }
}
