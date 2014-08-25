using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	/*
	public GameController gameController;
	TutorialSteps currStep;
	
	enum TutorialSteps{
		STEP_1,
		STEP_2
	};
	
	// Use this for initialization
	void Start () {
		SetTutorialStep(TutorialSteps.STEP_1);
	}
	
	void Update(){
		if(currStep == TutorialSteps.STEP_1){
			if(Input.anyKeyDown){
				SetTutorialStep(TutorialSteps.STEP_2);
			}
		}
		if(currStep == TutorialSteps.STEP_2){
			if(Input.GetKeyDown(KeyCode.W)){
				
			}
		}
	}
	
	void SetTutorialStep(TutorialSteps step){
		currStep = step;
		switch(currStep){
		case TutorialSteps.STEP_1:
			AngelControl angel = player.GetComponent<AngelControl>();
			angel.enabled = false;
			break;
		case TutorialSteps.STEP_2:
			Destroy(title);
			angel = player.GetComponent<AngelControl>();			
			angel.enabled = true;
			angel.canMove = false;
			HelperController follower = escort.GetComponent<HelperController>();
			break;
		}
	}
	*/
}
