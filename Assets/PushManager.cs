using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PushManager : MonoBehaviour
{
    public DrinkManager drinkManager;
    [SerializeField] private bool notificationFlag = true;

    private void Start()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    private void Update()
    {
        int minute = System.DateTime.Now.Minute;
        int second = System.DateTime.Now.Second;
        if ((minute == 59 && second == 15) && notificationFlag)
        {
            notificationFlag = false;
            LocalPushNotification.AllClear();
            int mnw=drinkManager.getMaxNeedyWater();
            LocalPushNotification.AddSchedule("水分補給の時間です！", "水分を"+(mnw/16).ToString()+"mlを目安に補給して下さい。", 1, 45,"0");
        }
        else
        {
            notificationFlag = true;
        }
    }

    public void fouceNotification()
    {
        
    }
}
