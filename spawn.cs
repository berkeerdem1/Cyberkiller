using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
	[SerializeField]Transform spawnpoint;

    void OnCollisionEnter2D(Collision2D col)
    {
		if(col.transform.CompareTag("player")){
			col.transform.position=spawnpoint.position;
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
