using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {

	void GrantCatTheSweetReleaseOfDeath()
	{
		DestroyObject( gameObject );
	}

	void OnBecameInvisible() {
		Destroy( gameObject ); 
	}

	public void JoinConga() {
		collider2D.enabled = false;
		GetComponent<Animator>().SetBool( "InConga", true );
	}

}
