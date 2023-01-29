using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{


    public float distance;

    private Transform target;
    private Animator animator;
    public float followspeed;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        enemyAi();
    }





    void enemyAi()
    {
        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, -transform.right, distance);

        if (hitEnemy.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            //animator.SetBool("isattack",true);
            if (target)
                enemyfollow();
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            //animator.SetBool("isattack",true);
        }
    }
    void enemyfollow()
    {
        Vector3 targetposition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetposition, followspeed * Time.deltaTime);
    }
}
