using UnityEngine;
using System.Reflection;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

public class StaticInitializer : MonoBehaviour
{
    private void Start()
    {
        InitializeStaticClasses();
    }

    private void InitializeStaticClasses()
    {
        Type[] typeList = Assembly.GetExecutingAssembly().GetTypes().Where(type => string.Equals(type.Namespace, "MVS.Static", StringComparison.Ordinal) && Attribute.GetCustomAttribute(type, typeof(CompilerGeneratedAttribute)) == null).ToArray();
        foreach (Type type in typeList)
        {
            type.GetMethod("Initialize", BindingFlags.Static | BindingFlags.Public).Invoke(type, null);
        }
    }
}
