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
using Muser.Runtime;

public class LRSelection : MonoBehaviour {
    public Animator Animator;
    public Image Icon;
    public Text Name, SheetAuthor, MusicAuthor;
    private int selection = 0;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnClick(bool left) {
        Debug.Log($"Clicked: left: {left}");
        selection += (left ? -1 : 1);
        if (selection >= Consts.sheetGroups.Length || selection < 0) {
            selection = left ? Consts.sheetGroups.Length - 1 : 0;
        }
        if(Consts.sheetGroups.Length > 1)
            OnStartSelection();
    }
    public void OnStartSelection() {
        if (Animator.GetBool("CanAnimate")) {
            Animator.SetTrigger("OnSelectChange");
            Animator.SetBool("CanAnimate", false);
        }
    }

    public void OnUpdateMetaInfo() {
        Name.text = $"{System.IO.Path.GetFileName(Consts.sheetGroups[selection])}";
    }

    public void OnStopSelection() {
        Animator.SetTrigger("OnSelectFinished");
        OnUpdateMetaInfo();
        Animator.SetBool("CanAnimate", true);
    }
}
