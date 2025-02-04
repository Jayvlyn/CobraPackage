using System;
using Cobra.DesignPattern;
using UnityEngine;
using UnityEngine.Assertions;

namespace Cobra.UnitTesting
{
    public class Test_EventBus : UnitTest
    {
        [Test]
        public void Adding()
        {
            //Assemble
            EventBus bus = new EventBus();
            
            //Act
            bus.AddListener(FakeMethod);
            
            //Assert
            Assert.AreEqual(1, bus.Count);
        }
        [Test]
        public void Removing()
        {
            //Assemble
            EventBus bus = new EventBus();
            
            //Act
            bus.AddListener(FakeMethod);
            bus.RemoveListener(FakeMethod);
            
            //Assert
            Assert.AreEqual(0, bus.Count);
        }
        [Test]
        public void Invocation()
        {
            //Assemble
            EventBus bus = new EventBus();
            
            //Act
            bus.AddListener(FakeMethod);
            bus.RemoveListener(FakeMethod);
            
            //Assert
            bus.Invoke();
        }
        [Test]
        public void Dictionary()
        {
            //Assemble
            EventBusDictionary bus = new EventBusDictionary();
            
            //Act
            bus.AddListener("Sec1",FakeMethod);
            bus.AddListener("Sec1",FakeMethod2);
            bus.AddListener("Sec2",FakeMethod2);
            
            //Assert
            Assert.AreEqual(2, bus.Entries);
        }

        public void FakeMethod(EventSubscriberArgs args)
        {
        }

        public void FakeMethod2(EventSubscriberArgs args)
        {
            
        }
    }
}