//   Assembly-CSharp
//   Copyright (C) 2020  Ye William
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
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
        Created = new GameObject {
            name = "FadeInBlur"
        }; //Create the GameObject
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
        StartCoroutine("StartFade");
    }

    // Update is called once per frame
    void Update() {

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
    IEnumerator StartFade() {
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
