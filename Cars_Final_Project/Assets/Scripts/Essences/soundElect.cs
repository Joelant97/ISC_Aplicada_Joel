using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundElect : MonoBehaviour
{
    public AudioSource tickSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.gameObject.name);

        //Play Sound
        tickSource.Play();
        

    }
}
