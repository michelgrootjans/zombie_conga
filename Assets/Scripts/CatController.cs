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
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Animator>().SetBool( "InConga", true );
	}

}
