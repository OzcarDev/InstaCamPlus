using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public string StateA;
    public string StateB;
    GameManager gameManager;
    public string idle;
    public enum AnimState
    {
        On,
        Off
    }

    public AnimState _AnimState;
    string keyRequirement = "";

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    public void PlayAnimation()
    {
        if(GetComponent<Door>() != null)
        {
            keyRequirement = GetComponent<Door>().MyKeyID;
        }

        if (StateA != "" && StateB != "")
        {
	        if (Globals.Instance.playerKeys.Contains(keyRequirement))
            {
                if (_AnimState == AnimState.On)
                {
                    GetComponent<Animator>().CrossFade(StateB, .25f);
	                _AnimState = AnimState.Off;
	                AudioManager.Instance.PlaySFX(StateB);
                }
                else
                {
                    GetComponent<Animator>().CrossFade(StateA, .25f);
	                _AnimState = AnimState.On;
	                AudioManager.Instance.PlaySFX(StateA);
                }
            }
            else
            {
	            Globals.Instance.currentContent = GetComponent<Door>().closeMessage;
	            Globals.Instance.currentObject = "...";
                gameManager.ReadingMode();
                
            }
        }
        else
        {
          
                GetComponent<Animator>().Play(idle);
          
        }
    }
}
