using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessagesManager : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI titleText;
    GameManager gameManager;
    public float textSpeed = 0.1f;

    int index;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (gameManager.readingMode)
        {
            if (Input.GetButtonDown("Interaction"))
            {
                if (dialogueText.text == Globals.currentContent[index])
                {
                    NextLine();
                }
                else if(dialogueText.text.Length>1)
                {
	                StopAllCoroutines();
	                 dialogueText.text = Globals.currentContent[index];
                }
            }
        }
        
    }

    public void StartDialogue()
    {
        titleText.text = Globals.currentObject;
        dialogueText.text = string.Empty;
        index = 0;
        StartCoroutine(WriteLine());

    }

    IEnumerator WriteLine()
	{
		
        foreach(char letter in Globals.currentContent[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        
    }

    public void NextLine()
    {
        if (index < Globals.currentContent.Count -1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
	        gameManager.panelGamePlay.SetActive(true);
            gameManager.panelText.SetActive(false);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        gameManager.readingMode = false;
    }

}
