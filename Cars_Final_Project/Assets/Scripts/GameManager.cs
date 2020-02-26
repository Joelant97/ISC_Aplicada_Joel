using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Wheel wheel;
    public Bin bin;
    public DeadZone deadZone;

    public static Vector2 topRight;
    public static Vector2 bottomLeft;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        Bin bin1 = Instantiate(bin) as Bin;
        bin1.Init(false);

        Instantiate(deadZone);
       

        float randomSecnd = Random.Range(4, 6);


        //2th. Parameter is time when start the first time y the 3th. the betwen any update.  
        InvokeRepeating("inst", 2f, randomSecnd); //Call the inst function in several times.


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void inst()
    {
        float randomSecnd2 = Random.Range(-10, 10);
        Instantiate(wheel, new Vector3(randomSecnd2, 4f, -0.084f), transform.rotation);
        
    }


}
