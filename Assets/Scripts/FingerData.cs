using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;


public class FingerData : MonoBehaviour {
    public HandController hc;
	Frame currentFrame;
	Frame lastFrame = null;
	Frame thisFrame = null;
	long difference = 0;

    public Transform controllerToMoveLeft;
    public Transform controllerToMoveLeftThumb;
    public Transform controllerToMoveRight;
    public Transform controllerToMoveRightThumb;
    public bool useRightHandOnly = false;
    public bool useLeftHandOnly = false;
    public bool useLeftThumb = false;
    public bool useRightThumb = false;
    private HandModel hml, hmr;
	void Start () {
		
		hml = hc.leftGraphicsModel;
		hmr = hc.rightGraphicsModel;


	}
	
	
	void Update () {


        this.currentFrame = hc.GetFrame();
		GestureList gestures = this.currentFrame.Gestures();

        if (Input.GetKeyDown(KeyCode.A))
        {
            HandModel hml, hmr;
            hml = hc.leftGraphicsModel;
            hmr = hc.rightGraphicsModel;
            hc.leftGraphicsModel = null;
            hc.rightGraphicsModel = null;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            hc.leftGraphicsModel = hml;
            hc.rightGraphicsModel = hmr;
        }  

				foreach (var h in hc.GetFrame().Hands)
		{
			if (h.IsRight)
			{
				
				Finger thumb = h.Fingers[(int)Finger.FingerType.TYPE_THUMB];
				Finger indexFinger = h.Fingers[(int)Finger.FingerType.TYPE_INDEX];
				Finger middleFinger = h.Fingers[(int)Finger.FingerType.TYPE_MIDDLE];
				Finger ringFinger = h.Fingers[(int)Finger.FingerType.TYPE_RING];
				Finger pinkyFinger = h.Fingers[(int)Finger.FingerType.TYPE_PINKY];

                if (useRightHandOnly == false && useLeftHandOnly == false)
                {
                    Leap.Vector position = indexFinger.TipPosition;
                    Vector3 unityPosition = position.ToUnityScaled(false);
                    Vector3 worldPosition = hc.transform.TransformPoint(unityPosition);
                    controllerToMoveRight.position = new Vector3(worldPosition.x, worldPosition.y, 0);
                }

                if (useRightHandOnly == true && useLeftHandOnly == false)
                {
                    Leap.Vector position2 = thumb.TipPosition;
                    Vector3 unityPosition2 = position2.ToUnityScaled(false);
                    Vector3 worldPosition2 = hc.transform.TransformPoint(unityPosition2);
                    controllerToMoveLeft.position = new Vector3(worldPosition2.x, worldPosition2.y, 0);

					Leap.Vector position = indexFinger.TipPosition;
					Vector3 unityPosition = position.ToUnityScaled(false);
					Vector3 worldPosition = hc.transform.TransformPoint(unityPosition);
                    controllerToMoveRight.position = new Vector3(worldPosition.x, worldPosition.y, 0);
                }

                if (useRightThumb == true && useRightHandOnly == false)
				{
					Leap.Vector position6 = thumb.TipPosition;
					Vector3 unityPosition6 = position6.ToUnityScaled(false);
					Vector3 worldPosition6 = hc.transform.TransformPoint(unityPosition6);
					controllerToMoveRightThumb.position = new Vector3(worldPosition6.x, worldPosition6.y, 0);
				}


			}
			if (h.IsLeft)
			{

				Finger thumb = h.Fingers[(int)Finger.FingerType.TYPE_THUMB];
				Finger indexFinger = h.Fingers[(int)Finger.FingerType.TYPE_INDEX];
				Finger middleFinger = h.Fingers[(int)Finger.FingerType.TYPE_MIDDLE];
				Finger ringFinger = h.Fingers[(int)Finger.FingerType.TYPE_RING];
				Finger pinkyFinger = h.Fingers[(int)Finger.FingerType.TYPE_PINKY];

				


                if (useLeftHandOnly == false && useRightHandOnly == false)
                {
					Leap.Vector position = indexFinger.TipPosition;
					Vector3 unityPosition = position.ToUnityScaled(false);
					Vector3 worldPosition = hc.transform.TransformPoint(unityPosition);
					controllerToMoveLeft.position = new Vector3(worldPosition.x, worldPosition.y, 0);
                }

				if (useLeftHandOnly == true && useRightHandOnly == false)
				{

					Leap.Vector position4 = indexFinger.TipPosition;
					Vector3 unityPosition4 = position4.ToUnityScaled(false);
					Vector3 worldPosition4 = hc.transform.TransformPoint(unityPosition4);
					controllerToMoveLeft.position = new Vector3(worldPosition4.x, worldPosition4.y, 0);

					Leap.Vector position3 = thumb.TipPosition;
					Vector3 unityPosition3 = position3.ToUnityScaled(false);
					Vector3 worldPosition3 = hc.transform.TransformPoint(unityPosition3);
					controllerToMoveLeft.position = new Vector3(worldPosition3.x, worldPosition3.y, 0);

				}
                if (useLeftThumb == true && useLeftHandOnly == false)
				{
					Leap.Vector position5 = thumb.TipPosition;
					Vector3 unityPosition5 = position5.ToUnityScaled(false);
					Vector3 worldPosition5 = hc.transform.TransformPoint(unityPosition5);
					controllerToMoveLeftThumb.position = new Vector3(worldPosition5.x, worldPosition5.y, 0);
				}

				// Bounds of control movement
				// -x -10.58  +x 10..54
				// -y -6.67   +y 8.81

				
			}

		}


	}
}
