using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using Michsky;
using Michsky.MUIP;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class DrinkManager : MonoBehaviour
{
    public TextMeshProUGUI needyWaterText;
    [SerializeField] private int needyWater = 100;
    public int maxNeedyWater = 100;
    public Slider waterSlider;
    public TextMeshProUGUI needyWaterSliderText;
    public Transform waterTfm;
    private float waterScaleY;
    public TMP_InputField drinkWaterIn;
    public float WaterScaleY
    {
        get
        {
            return waterScaleY;
        }
        set
        {
            waterScaleY = Mathf.Clamp(value, 0.01f, 1.3f);
        }
    }

    public void setMaxNeedyWater(int value)
    {
        maxNeedyWater = value;
    }
    
    public int getMaxNeedyWater()
    {
        return maxNeedyWater;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitWaterInfo();
    }

    // Update is called once per frame
    void Update()
    {
        // WaterInfoUpdate();
    }

    public void InitWaterInfo()
    {
        needyWater = maxNeedyWater;
        needyWaterText.text = maxNeedyWater.ToString() + "ml";
        waterSlider.value = ((int)((float)(needyWater) / (float)(maxNeedyWater) * 100));
        needyWaterSliderText.text = maxNeedyWater.ToString() + "ml";
        waterTfm.DOScaleY(1.3f, 0.5f);
    }

    public void WaterInfoUpdate()
    {
        waterSlider.value = ((int)((float)(needyWater) / (float)(maxNeedyWater) * 100));
        needyWaterSliderText.text = maxNeedyWater.ToString() + "ml";
        needyWaterText.text = needyWater.ToString() + "ml";
        WaterScaleY = (1.3f) * (float)(needyWater) / (float)(maxNeedyWater);
        Vector3 waterScale = waterTfm.localScale;
        // waterScale.y = WaterScaleY;
        // waterTfm.localScale = waterScale;
        waterTfm.DOScaleY(waterScaleY, 1f);
    }

    public void drinkWater()
    {
        if(drinkWaterIn.text==null) return;
        int drinkedWater =  int.Parse(drinkWaterIn.text);
        drinkWaterIn.text = "";
        needyWater -= drinkedWater;
        WaterInfoUpdate();
    }
}
