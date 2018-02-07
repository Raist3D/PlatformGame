using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScaleEasing : MonoBehaviour
{
    public Vector3 iniValue;
    public Vector3 finalValue;
    public float currentTime;
    public float timeDuration;

    private Vector3 deltaValue;


    // Use this for initialization
    private void Start()
    {
        deltaValue = finalValue - iniValue;
    }

    // Update is called once per frame
    private void Update()
    {
        //EASING
        if(currentTime <= timeDuration)
        {
            //DO EASING EJE X
            //Vector3 easingValue = iniValue;
            //easingValue.x = Easing.BounceEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration);

            Vector3 easingValue = new Vector3(easingValue.x = Easing.BounceEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                               easingValue.y = Easing.BounceEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                               easingValue.z = Easing.BounceEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));

            transform.localScale = easingValue;

            currentTime += Time.deltaTime;

           /* if(currentTime >= timeDuration)
            {
                Debug.Log("Easing a terminado justo ahora!");
                transform.localScale = finalValue;

                currentTime = 0;
                Vector3 ini = iniValue;
                iniValue = finalValue;
                finalValue = ini;
                deltaValue = finalValue - iniValue;

            }*/
        }
        else
        {
            Debug.Log("Easing finished!");
        }
    }
}
