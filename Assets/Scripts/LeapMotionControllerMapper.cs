using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;


public class LeapMotionControllerMapper : MonoBehaviour
{
	public HandController handController;
	Frame currentFrame;
	Frame lastFrame = null;
	Frame thisFrame = null;
	long difference = 0;

    public Transform controllerLeftThumb;
	public Transform controllerLeftIndex;
    public Transform controllerLeftMiddle;
	public Transform controllerLeftRing;
    public Transform controllerLeftPinkie;

	public Transform controllerRightThumb;
	public Transform controllerRightIndex;
	public Transform controllerRightMiddle;
	public Transform controllerRightRing;
	public Transform controllerRightPinkie;

	//public bool useRightIndex = false;
	//public bool useLeftIndex = false;
	//public bool useLeftThumb = false;
	//public bool useRightThumb = false;

    public bool requireExtendedFingers = true;
    public bool handsVisible = false;
    public KeyCode handVisToggle = KeyCode.A;
    //public KeyCode handVisOn = KeyCode.S;
    int visToggleCount = 0;
	private HandModel hml, hmr;
	
    void Start()
	{

		hml = handController.leftGraphicsModel;
		hmr = handController.rightGraphicsModel;

        if (handsVisible) {
			handController.leftGraphicsModel = hml;
			handController.rightGraphicsModel = hmr;

        } else {
			handController.leftGraphicsModel = null;
			handController.rightGraphicsModel = null;
            visToggleCount = 1;
        }

	}


	void Update()
	{


		this.currentFrame = handController.GetFrame();
		GestureList gestures = this.currentFrame.Gestures();

        // Toggle hand visibility
        if (Input.GetKeyDown(handVisToggle) && visToggleCount % 2 == 0)
		{
			handController.leftGraphicsModel = null;
			handController.rightGraphicsModel = null;
            visToggleCount++;
           
		}
        else if (Input.GetKeyDown(handVisToggle) && visToggleCount % 2 !=0)
		{
			handController.leftGraphicsModel = hml;
			handController.rightGraphicsModel = hmr;
            visToggleCount++;

		}

        // check for hands in frame
		foreach (var h in handController.GetFrame().Hands)
		{
			if (h.IsRight)
			{

				Finger thumbR = h.Fingers[(int)Finger.FingerType.TYPE_THUMB];
				Finger indexFingerR = h.Fingers[(int)Finger.FingerType.TYPE_INDEX];
				Finger middleFingerR = h.Fingers[(int)Finger.FingerType.TYPE_MIDDLE];
				Finger ringFingerR = h.Fingers[(int)Finger.FingerType.TYPE_RING];
				Finger pinkyFingerR = h.Fingers[(int)Finger.FingerType.TYPE_PINKY];

				if (controllerRightThumb != null)  
                {
                    if (requireExtendedFingers)
                    {
                        if (thumbR.IsExtended)
                        {
                            Leap.Vector positionRT = thumbR.TipPosition;
                            Vector3 unityPositionRT = positionRT.ToUnityScaled(false);
                            Vector3 worldPositionRT = handController.transform.TransformPoint(unityPositionRT);
                            controllerRightThumb.position = new Vector3(worldPositionRT.x, worldPositionRT.y, 0);
                        }
                    }
                    else 
                    {
						Leap.Vector positionRT = thumbR.TipPosition;
						Vector3 unityPositionRT = positionRT.ToUnityScaled(false);
						Vector3 worldPositionRT = handController.transform.TransformPoint(unityPositionRT);
						controllerRightThumb.position = new Vector3(worldPositionRT.x, worldPositionRT.y, 0);
                    }
				}

				if (controllerRightIndex != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (indexFingerR.IsExtended)
                        {
                            Leap.Vector positionRI = indexFingerR.TipPosition;
                            Vector3 unityPositionRI = positionRI.ToUnityScaled(false);
                            Vector3 worldPositionRI = handController.transform.TransformPoint(unityPositionRI);
                            controllerRightIndex.position = new Vector3(worldPositionRI.x, worldPositionRI.y, 0);
                        }
                    } 
                    else 
                    {
                        Leap.Vector positionRI = indexFingerR.TipPosition;
                        Vector3 unityPositionRI = positionRI.ToUnityScaled(false);
                        Vector3 worldPositionRI = handController.transform.TransformPoint(unityPositionRI);
                        controllerRightIndex.position = new Vector3(worldPositionRI.x, worldPositionRI.y, 0);
                    }
				}

				if (controllerRightMiddle != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (middleFingerR.IsExtended)
                        {
                            Leap.Vector positionRM = middleFingerR.TipPosition;
                            Vector3 unityPositionRM = positionRM.ToUnityScaled(false);
                            Vector3 worldPositionRM = handController.transform.TransformPoint(unityPositionRM);
                            controllerRightMiddle.position = new Vector3(worldPositionRM.x, worldPositionRM.y, 0);
                        }
                    }
                    else 
                    {
						Leap.Vector positionRM = middleFingerR.TipPosition;
						Vector3 unityPositionRM = positionRM.ToUnityScaled(false);
						Vector3 worldPositionRM = handController.transform.TransformPoint(unityPositionRM);
						controllerRightMiddle.position = new Vector3(worldPositionRM.x, worldPositionRM.y, 0);
                    }
				}

				if (controllerRightRing != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (ringFingerR.IsExtended)
                        {
                            Leap.Vector positionRR = ringFingerR.TipPosition;
                            Vector3 unityPositionRR = positionRR.ToUnityScaled(false);
                            Vector3 worldPositionRR = handController.transform.TransformPoint(unityPositionRR);
                            controllerRightRing.position = new Vector3(worldPositionRR.x, worldPositionRR.y, 0);
                        }
                    }
                    else
                    {
						Leap.Vector positionRR = ringFingerR.TipPosition;
						Vector3 unityPositionRR = positionRR.ToUnityScaled(false);
						Vector3 worldPositionRR = handController.transform.TransformPoint(unityPositionRR);
						controllerRightRing.position = new Vector3(worldPositionRR.x, worldPositionRR.y, 0);
                    }
				}


                if (controllerRightPinkie != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (pinkyFingerR.IsExtended)
                        {
                            Leap.Vector positionRP = pinkyFingerR.TipPosition;
                            Vector3 unityPositionRP = positionRP.ToUnityScaled(false);
                            Vector3 worldPositionRP = handController.transform.TransformPoint(unityPositionRP);
                            controllerRightPinkie.position = new Vector3(worldPositionRP.x, worldPositionRP.y, 0);
                        }
                    }
                    else
                    {
						Leap.Vector positionRP = pinkyFingerR.TipPosition;
						Vector3 unityPositionRP = positionRP.ToUnityScaled(false);
						Vector3 worldPositionRP = handController.transform.TransformPoint(unityPositionRP);
						controllerRightPinkie.position = new Vector3(worldPositionRP.x, worldPositionRP.y, 0);
                    }
				}

			}
			if (h.IsLeft)
			{

				Finger thumbL = h.Fingers[(int)Finger.FingerType.TYPE_THUMB];
				Finger indexFingerL = h.Fingers[(int)Finger.FingerType.TYPE_INDEX];
				Finger middleFingerL = h.Fingers[(int)Finger.FingerType.TYPE_MIDDLE];
				Finger ringFingerL = h.Fingers[(int)Finger.FingerType.TYPE_RING];
				Finger pinkyFingerL = h.Fingers[(int)Finger.FingerType.TYPE_PINKY];




				if (controllerLeftThumb != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (thumbL.IsExtended)
                        {
                            Leap.Vector positionLT = thumbL.TipPosition;
                            Vector3 unityPositionLT = positionLT.ToUnityScaled(false);
                            Vector3 worldPositionLT = handController.transform.TransformPoint(unityPositionLT);
                            controllerLeftThumb.position = new Vector3(worldPositionLT.x, worldPositionLT.y, 0);
                        }
                    }
                    else
                    {
						Leap.Vector positionLT = thumbL.TipPosition;
						Vector3 unityPositionLT = positionLT.ToUnityScaled(false);
						Vector3 worldPositionLT = handController.transform.TransformPoint(unityPositionLT);
						controllerLeftThumb.position = new Vector3(worldPositionLT.x, worldPositionLT.y, 0);
                    }
				}

				if (controllerLeftIndex != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (indexFingerL.IsExtended)
                        {
                            Leap.Vector positionLI = indexFingerL.TipPosition;
                            Vector3 unityPositionLI = positionLI.ToUnityScaled(false);
                            Vector3 worldPositionLI = handController.transform.TransformPoint(unityPositionLI);
                            controllerLeftIndex.position = new Vector3(worldPositionLI.x, worldPositionLI.y, 0);
                        }
                    }
                    else
                    {
						Leap.Vector positionLI = indexFingerL.TipPosition;
						Vector3 unityPositionLI = positionLI.ToUnityScaled(false);
						Vector3 worldPositionLI = handController.transform.TransformPoint(unityPositionLI);
						controllerLeftIndex.position = new Vector3(worldPositionLI.x, worldPositionLI.y, 0);
                    }
				}
				if (controllerLeftMiddle != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (middleFingerL.IsExtended)
                        {
                            Leap.Vector positionLM = middleFingerL.TipPosition;
                            Vector3 unityPositionLM = positionLM.ToUnityScaled(false);
                            Vector3 worldPositionLM = handController.transform.TransformPoint(unityPositionLM);
                            controllerLeftMiddle.position = new Vector3(worldPositionLM.x, worldPositionLM.y, 0);
                        }
                    }
                    else
                    {
						Leap.Vector positionLM = middleFingerL.TipPosition;
						Vector3 unityPositionLM = positionLM.ToUnityScaled(false);
						Vector3 worldPositionLM = handController.transform.TransformPoint(unityPositionLM);
						controllerLeftMiddle.position = new Vector3(worldPositionLM.x, worldPositionLM.y, 0);
                    }
				}

				if (controllerLeftRing != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (ringFingerL.IsExtended)
                        {
                            Leap.Vector positionLR = ringFingerL.TipPosition;
                            Vector3 unityPositionLR = positionLR.ToUnityScaled(false);
                            Vector3 worldPositionLR = handController.transform.TransformPoint(unityPositionLR);
                            controllerLeftRing.position = new Vector3(worldPositionLR.x, worldPositionLR.y, 0);
                        }
                    }
                    else
                    {
						Leap.Vector positionLR = ringFingerL.TipPosition;
						Vector3 unityPositionLR = positionLR.ToUnityScaled(false);
						Vector3 worldPositionLR = handController.transform.TransformPoint(unityPositionLR);
						controllerLeftRing.position = new Vector3(worldPositionLR.x, worldPositionLR.y, 0);
                    }
				}
				if (controllerLeftPinkie != null)
				{
                    if (requireExtendedFingers)
                    {
                        if (pinkyFingerL.IsExtended)
                        {
                            Leap.Vector positionLP = pinkyFingerL.TipPosition;
                            Vector3 unityPositionLP = positionLP.ToUnityScaled(false);
                            Vector3 worldPositionLP = handController.transform.TransformPoint(unityPositionLP);
                            controllerLeftPinkie.position = new Vector3(worldPositionLP.x, worldPositionLP.y, 0);
                        }
                    }
                    else
                    {
						Leap.Vector positionLP = pinkyFingerL.TipPosition;
						Vector3 unityPositionLP = positionLP.ToUnityScaled(false);
						Vector3 worldPositionLP = handController.transform.TransformPoint(unityPositionLP);
						controllerLeftPinkie.position = new Vector3(worldPositionLP.x, worldPositionLP.y, 0);
                    }
				}
				
			}

		}


	}
}
