using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemycontroller : MonoBehaviour
{
	public int health;
	//public int inithealth;
	//public Image healthbar;




	Animator animator;



	void Start(){
		//inithealth=health;
	}
	void Update(){
		//healthbar.fillAmount=Mathf.Lerp(healthbar.fillAmount,(float)health/(float)inithealth,Time.deltaTime*2);
	}


	public void TakeDamage(int damage){
		health-=damage;
		//animator.SetTrigger("hurt");
		//HealthBar.value=health;
		if(health<=0){
			enemyDie();

		}

	}
	private void enemyDie(){
		//animator.SetTrigger("isdead");
		Debug.Log("die");
		//this.enabled=false;
		//GetComponent<Collider2D>().enabled=false;
		
		Destroy(gameObject);
	}

	
}
