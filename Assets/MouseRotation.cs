using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour {
	public GameObject rotTopObj ;
	Vector2 lastPos ;
	bool lastPosSet = false ;
	float currentAngle = 0.0f ;
	float totalAngle = 0.0f ;
	float angleCount ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			// Debug.Log(Input.mousePosition);

			float x = Input.mousePosition.x / (float)Screen.width ;
			x = ( x - 0.5f ) * 2.0f ;

			float y = Input.mousePosition.y / (float)Screen.height ;
			y = ( y - 0.5f ) * 2.0f ;

			Vector2 pos = new Vector2( x, y );

			// Debug.Log(pos);

			if ( lastPosSet ){
				float angle = Vector2.Angle( lastPos, pos );
				Vector3 cross = Vector3.Cross(lastPos, pos);
				if (cross.z < 0.0f ){
					angle *= -1.0f ;
				}
				// Debug.Log( angle );
				rotTopObj.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentAngle);
				currentAngle += angle ;
				totalAngle += angle ;
				angleCount = totalAngle / 360.0f ;
				Debug.Log( angleCount );
			}

			lastPos = pos ;
			lastPosSet = true ;
		}
	}
}
