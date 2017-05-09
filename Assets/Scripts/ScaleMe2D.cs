using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class ScaleMe2D : MonoBehaviour {

	public GameObject target;
	public void ScaleWithDelta(Gesture gesture) {

		if (gesture.pickedObject) {
		
			if (gesture.pickedObject.name == "Controller 1" ) { // select intended target - requires naming consistency
				
				target.transform.localScale += new Vector3( gesture.deltaPinch* .4f * Time.deltaTime,  gesture.deltaPinch* .4f * Time.deltaTime,  0);
				//target.transform.localScale += new Vector3( gesture.deltaPinch* .4f * Time.deltaTime,  gesture.deltaPinch* .4f * Time.deltaTime,  1);
				//Debug.Log("You're scaling Controller 1");

			} else {
				
				// pinching in space
				//Debug.Log("Picked Object:"+gesture.pickedObject.name+" on layer "+gesture.pickedObject.layer);
		
			}

		}
	}

}
