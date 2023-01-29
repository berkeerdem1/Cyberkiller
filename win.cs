using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class win : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.CompareTag("player")){
			SceneManager.LoadScene(4);
		}
		
	}

}
