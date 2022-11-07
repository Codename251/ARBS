using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractions : MonoBehaviour
{

	public GameObject defaultMenu;
	public GameObject levels;

	

	public void startPlayerVSIA()
	{
		defaultMenu.SetActive(false);
		levels.SetActive(true);
	}
	
	public void startPvP()
	{
		SceneManager.LoadScene("");
	}
	
	public void quitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}

	public void level1()
	{
		Debug.Log("level1");
		PlayerPrefs.SetInt("Selected_Level", 1);
		SceneManager.LoadScene("GameSetUp");


	}
	public void level2()
	{
		Debug.Log("level2");
		PlayerPrefs.SetInt("Selected_Level", 2);
		SceneManager.LoadScene("GameSetUp");


	}
	public void level3()
	{
		Debug.Log("level3");
		PlayerPrefs.SetInt("Selected_Level", 3);
		SceneManager.LoadScene("GameSetUp");


	}


}
