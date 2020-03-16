using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonPlayerController : MonoBehaviour
{

    const float LEFTLIMIT = -827f, RIGHTLIMIT = 827f;
    float speed = 400f, barValue;
    float triggerSpeed = 1200f, triggerAngle;


    Vector3 deltaPos, mousePosition;
    public GameObject CanionBallPrefab;
    public GameObject ProgressBar;
    LineRenderer trajectory;
    const int trajectoryVertices = 20;

    private void Awake()
    {
        trajectory = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        deltaPos = new Vector3();
        trajectory.positionCount = trajectoryVertices;
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos.y = deltaPos.z = 0;
        deltaPos = new Vector3(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime;
        transform.Translate(deltaPos);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,
            LEFTLIMIT,
            RIGHTLIMIT), transform.position.y);

        mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        deltaPos = mousePosition - gameObject.transform.position;
        triggerAngle = Mathf.Atan(deltaPos.y / deltaPos.x);

        //triggerAngle = Vector3.Angle(transform.position, mousePosition);

        if (deltaPos.x < 0)
        {
            triggerAngle = 90;
        }
        else if (deltaPos.y < 0)
        {
            triggerAngle = 0;
        }


        if (Input.GetButton("Fire1"))
        {
            barValue = Mathf.PingPong(Time.time, 1) * 100f;
            ProgressBar.GetComponent<ProgressBar>().BarValue = barValue;

        }

        if (Input.GetButtonUp("Fire1"))
        {
            Instantiate(CanionBallPrefab, transform.position, Quaternion.identity)
                .GetComponent<cannonBallBehavior>()
                .Shoot(triggerSpeed * (barValue / 100), triggerAngle);
        }

        
        /* Liner*/ 

        /*
        for (int i = 0; i < trajectoryVertices; i++)
        {
            trajectory.SetPosition(i, GetPosition((float)i 
            / trajectoryVertices, Mathf.Pow(triggerSpeed, 2) * Mathf.Sin(triggerAngle * 2) 
            / (Physics.gravity.y)));
        }
       */



    }
    Vector3 GetPosition(float resolutionProportion, float xMax)
    {
        float xRelative = resolutionProportion * xMax;
        float yRelative = xRelative * Mathf.Tan(triggerAngle) - (Mathf.Abs(Physics.gravity.y) * Mathf.Pow(xRelative, 2))
        / (2 * (triggerSpeed * (barValue / 100))) * (triggerSpeed * (barValue / 100)) * Mathf.Cos(Mathf.Pow(triggerAngle, 2));

        return new Vector3(xRelative, yRelative);
    }

}
