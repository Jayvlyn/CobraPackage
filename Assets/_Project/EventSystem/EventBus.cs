// using System;
// using System.Collections.Generic;
// using System.Reflection;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.Events;



using System;
using System.Reflection;
using UnityEngine.Events;
using UnityEngine;

public class MethodTesting : MonoBehaviour
{
    public void Test()
    {
        StartCoroutine();
    }

    public void M1()
    {
        
    }
}



public class Example
{
    // Method that takes int and string as parameters
    private void WhatWeWant(int t, string ets)
    {
        // Example method logic
    }

    private void WhatWeWant(string t, int ets)
    {
        
    }

    // Method that processes another method and gets the parameter types
    private void ProcessMethod(Delegate method)
    {
        // Get the MethodInfo object of the passed method
        MethodInfo methodInfo = method.Method;

        // Get the parameters of the method
        ParameterInfo[] parameters = methodInfo.GetParameters();

        // Create a list of parameter types
        foreach (var parameter in parameters)
        {
            Console.WriteLine($"Parameter: {parameter.Name}, Type: {parameter.ParameterType}");
        }
    }

    private void AddListener(Delegate method)
    {
        
    }

    public void Test()
    {
        // Create a delegate pointing to the 'WhatWeWant' method
        UnityAction<int, string> methodDelegate = WhatWeWant; ;
        ProcessMethod(WhatWeWant);

        // Pass the delegate to ProcessMethod
        ProcessMethod(methodDelegate);
    }

    public static void Main()
    {
        Example example = new Example();
        example.Test();
    }
}








//
// public class EventBuss
// {
//     private List<Type> parameters = new();
//     
//     //public void AddListener
//
//
//     public void Invoke(List<Type> parameters)
//     {
//         
//     }
//
//     public void AddListener(UnityAction ua)
//     {
//         
//     }
// }
//
// public class EventBusDic<T>
// {
//     private Dictionary<int, EventBuss<T>> bob = new ();
// }
// public class EventBuss<T>
// {
//     public void AddListener(UnityAction<T> ua)
//     {
//         
//     }
// }
//
// public class EventData<T>
// {
//     public Type GetType()
//     {
//         return typeof(T);
//     }
//
//     public T data;
//
// }
//
//
// public static class EventHolderForSpecificProject
// {
//     public static EventBuss playerNoParamsEventBus = new EventBuss();
//     public static EventBuss<int> bus2 = new EventBuss<int>();
//     public static EventBuss<TestClassA> bus3 = new EventBuss<TestClassA>();
//     public static EventBuss<Multi> bus4 = new EventBuss<Multi>();
//
//     public static EventBuss<List<Type>> typeList = new();
//     public static EventBuss<object[]> testGuy = new();
// }
//
// public class TestClassA
// {
//
//     public EventBusDic<int> intPlayerDic = new();
//
//     private void Converter(UnityAction<int, string> action)
//     {
//         Type firstParam = action.GetMethodInfo().MemberTypes[0];
//         EventHolderForSpecificProject.testGuy.AddListener(() => action(action.Method.));
//     }
//
//     private void Method1()
//     {
//         EventHolderForSpecificProject.playerNoParamsEventBus.AddListener(TestMethod1);
//         EventHolderForSpecificProject.bus2.AddListener(TestMethod2);
//         EventHolderForSpecificProject.playerNoParamsEventBus.Invoke(new List<Type>());
//         
//         EventHolderForSpecificProject.typeList.AddListener(TestMethod0);
//         EventHolderForSpecificProject.testGuy.AddListener(WhatWeWant);
//         
//         Converter(WhatWeWant);
//     }
//
//     private void WhatWeWant(int t, string ets)
//     {
//         
//     }
//     private void TestMethod0(List<Type> types)
//     {
//         
//     }
//
//     private void TestMethod1()
//     {
//         
//     }
//
//     private void TestMethod2(int a)
//     {
//         ParamGuy("a", "b", "c", 6, 'e');
//         Action<object[]> a1 = ParamGuy;
//     }
//
//     private void ParamGuy(params object[] parameters)
//     {
//         foreach (var p in parameters)
//         {
//             if (p is int)
//             {
//                 Debug.Log(p);
//             }
//         }
//     }
//     
// }
//
// public class Multi
// {
//     public int alldata;
//     public string allDataIneed;
// }