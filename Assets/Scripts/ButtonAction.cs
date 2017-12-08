using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Made by Jimmy Chao (Lazer)
/// 012677182
/// CECS 451
/// </summary>
public class ButtonAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
