using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{
    private string App_ID = "ca-app-pub-1858206893495181~6017773586";


    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(App_ID);
    }

}
