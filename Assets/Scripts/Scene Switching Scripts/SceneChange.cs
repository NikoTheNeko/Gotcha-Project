using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour{
    /**
        This function will basically swap scenes
        add the scene you want to change to in the parameter
    **/
    public void SceneChangeTo(string SceneToChangeTo){
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
    }

}
