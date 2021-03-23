using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    static int health=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            health -= 1;
            string myString = health.ToString();
        }
    }
    string myString = health.ToString();
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 50, 20), myString);
    }
}
