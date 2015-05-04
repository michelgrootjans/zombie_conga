using UnityEngine;
using System.Collections;

public class ScreenRelativePosition : MonoBehaviour {

	public enum ScreenEdge {LEFT, RIGHT, TOP, BOTTOM};
	public ScreenEdge screenEdge;
	public float yOffset;
	public float xOffset;

	// Use this for initialization
	void Start () {
		// 1
		Vector3 newPosition = transform.position;
		Camera camera = Camera.main;
		
		// 2
		switch(screenEdge)
		{
			// 3
		case ScreenEdge.RIGHT:
			newPosition.x = xOffset + camera.aspect * camera.orthographicSize;
			newPosition.y = yOffset;
			break;
			
			// 3
		case ScreenEdge.LEFT:
			newPosition.x = xOffset - camera.aspect * camera.orthographicSize;
			newPosition.y = yOffset;
			break;
			
			// 4
		case ScreenEdge.TOP:
			newPosition.y = yOffset + camera.orthographicSize;
			newPosition.x = xOffset;
			break;
			
			// 4
		case ScreenEdge.BOTTOM:
			newPosition.y = yOffset - camera.orthographicSize;
			newPosition.x = xOffset;
			break;
		}
		// 5
		transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
