using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botellaprincipal : Singleton<botellaprincipal>
{

    int angulo_abajo = 90;
    int limite = 40;
    public GameObject fotoreceta;
    public GameObject agua;
    float tiempopasado = 0;
    bool unavez = true;
    bool acabada = false;


    void Update()
    {


        if (this.transform.eulerAngles.x < (angulo_abajo + limite) && this.transform.eulerAngles.x > (angulo_abajo - limite))
        {
            agua.gameObject.SetActive(true);
            AudioManager.instance.caerLiquidoDeBotella.Play();
            tiempopasado += Time.deltaTime;
            if (tiempopasado >= 3.0f)
            {                
                    fotoreceta.SetActive(true);
                agua.gameObject.SetActive(false);
                AudioManager.instance.caerLiquidoDeBotella.Stop();
                acabada = true;
                tiempopasado = 0;
            }

        }
        else
        {
            agua.gameObject.SetActive(false);
            AudioManager.instance.caerLiquidoDeBotella.Stop();

            tiempopasado = 0;
        }
    }

    }

