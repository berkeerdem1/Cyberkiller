using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
	public Transform FirePoint2;
	public Transform FirePoint3;
	public GameObject Bullet;
	private Transform target;



	public float distance;
	private Animator animator;
	public float followspeed;

	bool faceRight=false;
	
	void start(){
		target=GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
	}
	
	void FixedUpdate(){
		Physics2D.queriesStartInColliders=false;
		
		//if(target=GameObject.FindGameObjectWithTag("player").GetComponent<Transform>()){
		
		if(true){
			animator=GetComponent<Animator>();
			enemyAi();
		}
		
	}
	void enemyAi(){
		RaycastHit2D hitEnemy=Physics2D.Raycast(transform.position,-transform.right,distance);
		
		if(hitEnemy.collider!=null){
			Debug.DrawLine(transform.position,hitEnemy.point,Color.red);
			//animator.SetBool("isattack",true);
			if(target){
				//enemyfollow();
				Shoot();
				animator.SetBool("isshoot",true);
			}

		}

		else{
			Debug.DrawLine(transform.position,transform.position-transform.right*distance,Color.green);
			animator.SetBool("isshoot",false);
		}
	}
	void enemyfollow(){
		Vector3 targetposition=new Vector3(target.position.x,gameObject.transform.position.y,target.position.x);
		transform.position=Vector2.MoveTowards(transform.position,targetposition,followspeed * Time.deltaTime);
	}

	private void Switch(){
		faceRight=!faceRight;
		Vector3 scaler=transform.localScale;
		scaler.x*=-1;
		transform.localScale=scaler;
		


	}

	void Shoot(){
		if(!faceRight){
			Instantiate(Bullet,FirePoint2.position,FirePoint2.rotation);
		}
		if(faceRight){
			Instantiate(Bullet,FirePoint3.position,FirePoint3.rotation);
		}
	}
}
