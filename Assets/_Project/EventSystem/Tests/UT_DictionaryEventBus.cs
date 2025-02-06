using System;
using Cobra.DesignPattern.Observer;
using Cobra.UnitTesting;
using UnityEngine;
using UnityEngine.Assertions;

public class UT_DictionaryEventBus : UnitTest
{
    private void FakeMethod()
    {
        
    }
    private void FakeMethod(int data)
    {
        
    }
    private void FakeMethod(string data)
    {
        
    }



    [Test]
    private void BusCountCorrect()
    {
        //Assemble
        EventBusWeakDictionary looselyTypedEventBus = new();
        //Act
        //Assert
        Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
    }
    
    [Test]
    private void AddingListenerThroughMethod()
    {
        //Assemble
        EventBusWeakDictionary looselyTypedEventBus = new();
        //Act
        looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
        //Assert
        Assert.AreEqual(1, looselyTypedEventBus.Count("key1"));
    }
    
    [Test]
    private void AddingListenerMultiple()
    {
        //Assemble
        EventBusWeakDictionary looselyTypedEventBus = new();
        //Act
        looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
        looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
        //Assert
        Assert.AreEqual(2, looselyTypedEventBus.Count("key1"));
    }
    [Test]
    private void AddingListenerMultipleUnique()
    {
        //Assemble
        EventBusWeakDictionary looselyTypedEventBus = new();
        //Act
        looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
        looselyTypedEventBus.AddListener("key2", (Action)FakeMethod);
        //Assert
        Assert.AreEqual(1, looselyTypedEventBus.Count("key1"));
    }
    
    [Test]
    private void RemovingListenerThroughMethod()
    {
        //Assemble
        EventBusWeakDictionary looselyTypedEventBus = new();
        //Act
        looselyTypedEventBus.RemoveListener("bus0", (Action)FakeMethod);
        //Assert
        Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
    }
    
    
    [Test]
    private void BlankInvocation()
    {
        //Assemble
        EventBusWeakDictionary looselyTypedEventBus = new();
        //Act
        looselyTypedEventBus.Invoke("key1");
        //Assert
        Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
    }
    
    [Test]
    private void ParameterizedInvocation()
    {
        //Assemble
        EventBusWeakDictionary looselyTypedEventBus = new();
        //Act
        looselyTypedEventBus.Invoke("key1", 7, "string");
        //Assert
        Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
    }

}
