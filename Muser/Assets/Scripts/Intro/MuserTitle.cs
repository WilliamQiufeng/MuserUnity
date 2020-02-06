using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuserTitle : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    void OnAnimationEnd() {
        Debug.Log("OnAnimationEnd");
        SceneManager.LoadScene("SelectionScene");
    }
}
