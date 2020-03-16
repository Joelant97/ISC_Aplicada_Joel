using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cannonBallBehavior : MonoBehaviour
{
    Vector3 currentSpeed = Vector3.zero;
    bool shooted = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!shooted)
            return;

        transform.Translate(
            currentSpeed * Time.deltaTime + Physics.gravity * Mathf.Pow(Time.deltaTime, 2) / 2);
        currentSpeed += Physics.gravity * Time.deltaTime;
    }

    public void Shoot(float triggerSpeed, float triggerAngle)
    {
        currentSpeed = new Vector3(
            triggerSpeed * Mathf.Cos(triggerAngle),
            triggerSpeed * Mathf.Sin(triggerAngle));
    }


}
