using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBehavior : MonoBehaviour
{
    // Tower damage and projectile it fires. Both are used when attacking an enemy. Note some towers may use melee weapons like spears.
    public int damage;
    public GameObject projectile;
    Projectile projScript;
    float projSpeed;

    // Fire rate is decimal in terms of seconds per attack. For example, a fire rate of 0.5 would be 2 attacks per second.
    public float attackRate;
    public float attackTimer;

    // When a valid object comes within range, the tower will target that object.
    public float range;
    GameObject target;
    bool hasTarget;

    // Collider used to detect enemies
    CircleCollider2D rangeCol;

    // Start is called before the first frame update
    void Start()
    {
        rangeCol = GetComponent<CircleCollider2D>();
        rangeCol.radius = range;
        hasTarget = false;
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (hasTarget && attackTimer >= attackRate)
        {
            attack();
            attackTimer = 0;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            target = col.gameObject;
            hasTarget = true;
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            hasTarget = false;
        }
    }

    public void attack()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        projScript = projectile.GetComponent<Projectile>();
        projScript.setTarget(target);
    }
}
