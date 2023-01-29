using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    [SerializeField] Transform spawnpoint;

    public GameObject PauseMenu;
    public static bool isPaused = false;



    public float faster;
    public int speed;
    public float jumpspeed;
    public float smalljump;
    public int damage;
    public int health;
    public int duck;



    Animator animator;
    Rigidbody2D rb;

    bool canJump = true;
    bool faceRight = true;
    bool canAttack = true;

    Vector2 forward;
    public Vector3 offset;
    RaycastHit2D hit;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        PauseMenu.SetActive(false);



    }
    public void TakeDamage(int damage)
    {

        Debug.Log("takedamage");
        health -= damage;
        animator.SetTrigger("hurt");

        if (health <= 0)
        {
            for (int i = 3; i <= 3; i++)
            {

                transform.position = spawnpoint.position;

            }
            Die();
        }

    }


    private void Die()
    {
        //anim.SetTrigger("death");

        Debug.Log("player die ");
        //Destroy(gameObject);

        SceneManager.LoadScene("GameOverscene");


    }


    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(moveInput * faster, rb.velocity.y);
                animator.SetBool("isFaster", true);
            }
            else
            {
                animator.SetBool("isFaster", false);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("isDucking", true);

        }
        else
        {
            animator.SetBool("isDucking", false);
        }


        if (faceRight == true && moveInput < 0)
        { //ÖNEMLi
            Flip();
        }
        else if (faceRight == false && moveInput > 0)
        {
            Flip();
        }

        animator.SetBool("isJumping", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            animator.SetBool("isJumping", true);
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause menu");
            if (isPaused)
            {
                resumegame();
            }
            else
            {
                pausegame();
            }
        }



        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            Attack();
        }

    }


    public void pausegame()
    {
        PauseMenu.SetActive(true);
        //Time.timeScale=0f;

    }
    public void resumegame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MaınMenu");
    }
    public void quitgame()
    {
        Application.Quit();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.transform.tag == "platform") || (collision.transform.tag == "enemy"))
        {
            canJump = true;
        }

    }


    private void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector2.up * jumpspeed);
            canJump = false;
            //animator.SetTrigger("ziplama");
        }
    }





    private void Flip()
    {  //KARAKTERi X EKSENiNDE TERS YÖNE DÖNDÜRME
        faceRight = !faceRight;
        //Vector3 scaler=transform.localScale;
        //scaler.x*=-1;
        //transform.localScale=scaler;
        transform.Rotate(new Vector3(0, 180, 0));
    }
    private void Attack()
    {
        canAttack = false;

        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2);
        }
        else
        {
            forward = transform.TransformDirection(Vector2.right * 2);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, forward, 1.0f);

        //	if(hit){
        //		if(hit.transform.tag=="enemy"){
        //			hit.transform.GetComponent<enemycontroller>().GetDamage(damage);
        //		}
        //		else{
        //			Debug.Log("nothing to hit");
        //	}
        //	}

        animator.SetTrigger("Attack");

        StartCoroutine(AttackDelay());

    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
