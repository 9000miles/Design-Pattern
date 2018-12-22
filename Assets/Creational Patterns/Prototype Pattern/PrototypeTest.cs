using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeTest : MonoBehaviour, ICloneable
{
    public int age;
    public string nameNon;
    public Vector3 vec;
    public float[] nums;

    [ContextMenu("Copy")]
    public object Clone()
    {
        PrototypeTest prototype = (PrototypeTest)this.MemberwiseClone();
        PrototypeFactory<PrototypeTest>.prototype = prototype;
        return prototype;
    }

    [ContextMenu("Past")]//用反射获取属性值，再赋值
    public void Past()
    {
        this.age = PrototypeFactory<PrototypeTest>.prototype.age;
        this.nameNon = PrototypeFactory<PrototypeTest>.prototype.nameNon;
        this.vec = PrototypeFactory<PrototypeTest>.prototype.vec;
        this.nums = PrototypeFactory<PrototypeTest>.prototype.nums;
    }
}

public static class PrototypeFactory<T>
{
    public static T prototype;
}