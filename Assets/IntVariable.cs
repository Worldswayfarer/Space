using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    [NonSerialized]
    public int RuntimeValue;
    public int InitialValue;

    public void OnBeforeSerialize()
    {
            
    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }
}

