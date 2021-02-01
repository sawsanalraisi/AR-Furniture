using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexModel : MonoBehaviour
{

    public int modelID;


    public void ModelIDFun()
    {

        ManagerScript.instance.IndexModel = modelID;
    }
  
}
