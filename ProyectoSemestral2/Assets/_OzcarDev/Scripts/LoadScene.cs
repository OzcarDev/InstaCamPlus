using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
	public Animator anim;
	public static LoadScene Instance;
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{if (Instance == null)
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
	else
	{
		Destroy(gameObject);
	}
		
	}
	
    // Start is called before the first frame update
	public void LoadNextScene(string scene)
	{
		StartCoroutine(LoadingScene(scene));
		
	}
	
	public IEnumerator LoadingScene(string scene)
	{
		anim.Play("FadeIn");
		yield return new WaitForSeconds(1f);
		AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
		while(!operation.isDone){
			yield return null;
		}
		anim.Play("FadeOut");
	}
	
	public void Quit(){
		Application.Quit();
	}
}
