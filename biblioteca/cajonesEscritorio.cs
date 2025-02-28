using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajonesEscritorio : Singleton<cajonesEscritorio>
{
    public bool tocadas = false;
    public void lanzaranimcajon()
    {
        this.GetComponent<Animator>().SetTrigger("cajon");
    }


    public void fotoslondrestocadas()
    {
        tocadas = true;
    }
}
