// using System;
// using System.Collections.Generic;
// using System.Reflection;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.Events;



using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Events;

public class EventBus
{
    private List<EventListener> listeners = new();
    public void AddListener(Delegate d)
    {
        List<Type> typeParams = new List<Type>();
        MethodInfo methodInfo = d.Method;
        ParameterInfo[] parameters = methodInfo.GetParameters();
        foreach (var parameter in parameters)
        {
            typeParams.Add(parameter.GetType());
        }
        listeners.Add(new EventListener() { d = d, typeParams = typeParams });
    }

    public void Invoke(params object[] parameters)
    {
        List<Type> typeParams = new List<Type>();
        foreach (var parameter in parameters)
        {
            typeParams.Add(parameter.GetType());
        }
        
        foreach (var listener in listeners)
        {
            if (Matches(typeParams, listener.typeParams))
            {
                listener.d?.DynamicInvoke(parameters);
            }
        }
    }

    private bool Matches(List<Type> option1, List<Type> option2)
    {
        if (option1.Count != option2.Count) return false;
        for (int i = 0; i < option1.Count; i++)
        {
            if (option1[i].GetType() != option2[i].GetType()) return false;
        }
        return true;
    }
}

public class EventListener
{
    public Delegate d;
    public List<Type> typeParams = new List<Type>();
}
