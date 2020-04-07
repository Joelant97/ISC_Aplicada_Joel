using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasFlyScript : MonoBehaviour
{
    public static int vidaValue = 6;
    Text vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Text>();//
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "Vidas: " + vidaValue;
    }
}
