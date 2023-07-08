using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Stat
{
    //[SerializableField]
    public int baseValue;

    public int GetValue()
    {
        return baseValue;
    }

}
