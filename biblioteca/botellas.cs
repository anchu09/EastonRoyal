using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botellas : Singleton<botellas>
{


    int angulo_abajo = 90;
    int limite = 40;

    public GameObject agua;
    float tiempopasado = 0;
    bool unavez = true;

    bool dentrocuadrado = false;

    void Update()
    {
    

        if (this.transform.eulerAngles.x < (angulo_abajo + limite) && this.transform.eulerAngles.x > (angulo_abajo - limite))
        {
            agua.gameObject.SetActive(true);
            AudioManager.instance.caerLiquidoDeBotella.Play();

            tiempopasado += Time.deltaTime;
            if (tiempopasado >= 2.0f)
            {

                if (unavez) {

                    if (
                        dentrocuadrado == true
                        ) {
                        tablonBebidas.instance.pintar_Ultimo_cuadrado();
                        unavez = false;
                        dentrocuadrado = false;

                    }
               }

            }
            if (tiempopasado >= 3.0f)
            {
                agua.gameObject.SetActive(false);
                AudioManager.instance.caerLiquidoDeBotella.Stop();

                tiempopasado = 0;

            }

        }
        else
        {
            agua.gameObject.SetActive(false);
            AudioManager.instance.caerLiquidoDeBotella.Stop();
            unavez = true;
            tiempopasado = 0;
        }
    }
    public void setDentroCuadrado(bool value)
    {
        dentrocuadrado = value;
    }

}
