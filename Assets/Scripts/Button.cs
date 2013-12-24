using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }
}
