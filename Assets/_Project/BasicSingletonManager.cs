using Cobra.DesignPattern;
using UnityEngine;

public class BasicSingletonManager : Singleton<BasicSingletonManager>
{
    [SerializeField] private float effe;
}
