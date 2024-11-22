using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTutorial : MonoBehaviour
{
    //public static <class_name> instance;
    public static SingletonTutorial instance;
    private void Awake() {
        instance = this;
    }
}
