﻿using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {

	private Transform followTarget;
	private float moveSpeed; 
	private float turnSpeed; 
	private bool isZombie;
	private Vector3 targetPosition;

	void GrantCatTheSweetReleaseOfDeath()
	{
		DestroyObject( gameObject );
	}

	public void OnBecameInvisible() {
		if ( !isZombie ) Destroy( gameObject ); 
	}

	void Update () {
		//1
		if(isZombie)
		{
			//2
			Vector3 currentPosition = transform.position;            
			Vector3 moveDirection = targetPosition - currentPosition;
			
			//3
			float targetAngle = 
				Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp( transform.rotation, 
			                                      Quaternion.Euler(0, 0, targetAngle), 
			                                      turnSpeed * Time.deltaTime );
			
			//4
			float distanceToTarget = moveDirection.magnitude;
			if (distanceToTarget > 0)
			{
				//5
				if ( distanceToTarget > moveSpeed )
					distanceToTarget = moveSpeed;
				
				//6
				moveDirection.Normalize();
				Vector3 target = moveDirection * distanceToTarget + currentPosition;
				transform.position = 
					Vector3.Lerp(currentPosition, target, moveSpeed * Time.deltaTime);
			}
		}
	}


	public void JoinConga( Transform followTarget, float moveSpeed, float turnSpeed ) {
		//2
		this.followTarget = followTarget;
		this.moveSpeed = moveSpeed * 2f;
		this.turnSpeed = turnSpeed;
		
		//3
		isZombie = true;
		
		//4
		Transform cat = transform.GetChild(0);
		cat.GetComponent<Collider2D>().enabled = false;
		cat.GetComponent<Animator>().SetBool( "InConga", true );	

		UpdateTargetPosition();
	}

	public void UpdateTargetPosition()
	{
		targetPosition = followTarget.position;
	}

}
