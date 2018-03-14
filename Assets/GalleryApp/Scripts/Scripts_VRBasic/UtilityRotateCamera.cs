using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityRotateCamera : MonoBehaviour {

    public float sensivility = 0.5f;

    Vector2 mousePositionRef = Vector2.zero;

	
	void Update () {

        if (Input.GetMouseButtonDown(1)) {

            mousePositionRef = Input.mousePosition;

        }

        if (Input.GetMouseButton(1)) {

            transform.localEulerAngles += new Vector3(mousePositionRef.y - Input.mousePosition.y, Input.mousePosition.x - mousePositionRef.x, 0) * sensivility;
            mousePositionRef = Input.mousePosition;

        }

	}
}
