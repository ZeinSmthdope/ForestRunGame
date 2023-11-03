using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHome : MonoBehaviour {

    public void HomeMenu() {
        SceneManager.LoadScene("GameMenuScene");
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
}
