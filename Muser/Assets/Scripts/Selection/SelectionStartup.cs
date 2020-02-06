using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionStartup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Current Directory: {System.IO.Directory.GetCurrentDirectory()}");
        Muser.Runtime.Consts.sheetGroups = System.IO.Directory.GetDirectories($"Assets{Muser.Runtime.Consts.separator}DefaultSheets");
        foreach (string path in Muser.Runtime.Consts.sheetGroups) {
            Debug.Log($"Sheet Group Entry: {path}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
