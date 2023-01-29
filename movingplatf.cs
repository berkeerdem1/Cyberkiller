
using UnityEngine;

public class movingplatf : MonoBehaviour
{
	public Transform firstPos,secondPos;
	public float speed;
	
	Vector3 nextPos;
	
	private void Start(){
		nextPos=firstPos.position;
	}
	private void Update(){
		if(transform.position==firstPos.position)
			nextPos=secondPos.position;
		if(transform.position==secondPos.position)
			nextPos=firstPos.position;
		
		transform.position=Vector3.MoveTowards(transform.position,nextPos,speed*Time.deltaTime);
		
	}
	
	private void OnDrawGizmos(){
		Gizmos.DrawLine(firstPos.position,secondPos.position);
	}
	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.transform.tag=="player")
			collision.collider.transform.SetParent(transform);
	}
	private void OnCollisionExit2D(Collision2D collision){
		if(collision.transform.tag=="player")
			collision.collider.transform.SetParent(null);
	}
}
