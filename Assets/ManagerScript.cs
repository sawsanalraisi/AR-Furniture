using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{


    public static ManagerScript instance { get; private set; }
    private void Awake() { if (instance == null) { instance = this; } }



    public int IndexModel;

}
