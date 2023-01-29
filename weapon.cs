using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

	public Transform Firepoint;
	public GameObject Bullet;


	void Update(){
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
	}
	void Shoot(){

		Instantiate(Bullet,Firepoint.position,Firepoint.rotation);
		}
	
}