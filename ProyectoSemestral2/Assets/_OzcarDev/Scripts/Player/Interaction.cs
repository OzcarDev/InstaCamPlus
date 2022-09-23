using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace com.OzcarDev.WalkingSim
{
    public class Interaction : MonoBehaviour
{
        public LayerMask layerMask;
        GameManager gameManager;
       public TextMeshProUGUI objectText;
        // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
            
            CheckInteraction();
    }
       
    void CheckInteraction()
    {
       RaycastHit hit;
       var ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .4f));

       if (Physics.Raycast(ray, out hit, 5, layerMask))
       {
       	if(hit.transform.gameObject.tag== "Interaction"){

                gameManager.panelGamePlay.GetComponent<Animator>().Play("bigCursor");
                objectText.text = hit.transform.gameObject.name;
                Globals.currentObjective = hit.transform.gameObject.name;

           if (Input.GetButtonDown("Interaction") && !gameManager.readingMode&&!gameManager.photoMode)
           {
                    if(hit.transform.gameObject.GetComponent<PlayAnim>()!=null) hit.transform.gameObject.GetComponent<PlayAnim>().PlayAnimation();
                    if (hit.transform.gameObject.GetComponent<Letter>() != null)
                    {
                        Globals.currentContent = hit.transform.gameObject.GetComponent<Letter>().content;
                        Globals.currentObject = hit.transform.gameObject.GetComponent<Letter>().objectName;
                        gameManager.ReadingMode();
                    }
                    if (hit.transform.gameObject.GetComponent<Key>() != null)
                    {
                        Globals.playerKeys.Add(hit.transform.gameObject.GetComponent<Key>().keyID);
                        Destroy(hit.transform.gameObject);
                        
                    }
           }

            }
            else
            {
                gameManager.panelGamePlay.GetComponent<Animator>().Play("normalCursor");
                objectText.text = "";
                Globals.currentObjective = null;
            }
       
       }
            
    }

     
}
}
