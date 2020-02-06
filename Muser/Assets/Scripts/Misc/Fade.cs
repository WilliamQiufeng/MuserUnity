using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
    public Sprite sprite;
    public GameObject parent;
    public float initial, step, final, interval;
    private Image img;
    private GameObject Created;
    // Start is called before the first frame update
    void Start() {
        // Modified from https://gamedev.stackexchange.com/a/102432
        Created = new GameObject(); //Create the GameObject
        Created.name = "FadeInBlur";
        img = Created.AddComponent<Image>(); //Add the Image Component script
        img.sprite = sprite; //Set the Sprite of the Image Component on the new GameObject
        img.raycastTarget = false;
        var transform = Created.GetComponent<RectTransform>();
        transform.anchoredPosition = new Vector2(0, 0);
        transform.anchorMin = new Vector2(0, 0);
        transform.anchorMax = new Vector2(1, 1);
        transform.offsetMin = new Vector2(0, 0);
        Debug.Log(Screen.currentResolution);
        transform.offsetMax = new Vector2(Screen.width - 1, Screen.height - 1);
        transform.SetParent(parent.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
        Created.SetActive(true); //Activate the GameObject
        StartCoroutine("fade");
    }

    // Update is called once per frame
    void Update() {

    }
    IEnumerator fade() {
        bool increase = final > initial;
        for (float i = initial; increase ? i < final : i > final; i += step) {
            img.color = new Color(1, 1, 1, i);
            // Debug.Log($"Alpha: {i}");
            yield return new WaitForSeconds(interval);
        }
        img.color = new Color(1, 1, 1, final);
        Destroy(Created);
        yield return null;
    }
}
