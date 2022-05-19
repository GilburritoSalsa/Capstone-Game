using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    //Color and delay variables
    private SpriteRenderer rend;
    private Color startColor;
    private float timer = 0.0f;
    private float waitTime = 3.0f;


    // Collider used to detect enemies
    CircleCollider2D rangeCol;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
        pScript = projectile.GetComponent<Projectile>();
        targetQ = new List<GameObject>();
        rangeCol = GetComponent<CircleCollider2D>();
        rangeCol.radius = range;
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < waitTime)
        {
            rend.color = Color.gray;
            timer += Time.deltaTime;
        }
        else {
            rend.color = startColor;
            attackTimer += Time.deltaTime;
            if (targetQ.Count > 0 && attackTimer > attackRate)
            {
                //            target = targetQ[0];
                attackTimer = 0;
                attack();
            }
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
            else
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
