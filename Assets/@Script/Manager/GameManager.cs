using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GameManager
{
    public Action<float> moneyAction;
    public Action<float, float> weightAction;
    public Action<float, float> breathAction;
    private float _money;
    public float Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            moneyAction?.Invoke(value);
        }
    }

    public int BagCount { get; set; } = 4;
    public float MaxWeight { get; set; }
    private float _weight;
    public float Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            _weight = value;
            weightAction?.Invoke(value, MaxWeight);
        }
    }

    public float MaxBreath { get; set; }
    private float _breath; 
    public float Breath
    {
        get
        {
            return _breath;
        }
        set
        {
            _breath = value;
            breathAction?.Invoke(value, MaxBreath);
        }
    }

    
}
