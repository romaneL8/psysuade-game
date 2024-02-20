using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolDown : MonoBehaviour
{
    public Image dashCoolDown;
    public float coolDownTimer = 5f;
    public bool coolingDown;
    private float time;

    private Coroutine reset;

    // Start is called before the first frame update
    void Start()
    {
        coolingDown = false;
        dashCoolDown = GetComponent<Image>();
        time = coolDownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            CoolDown();
            //Invoke("ResetTimer", 5f);
            reset = StartCoroutine(ResetCoolDown());
        }
        else
        {
            coolingDown = false;
            time = coolDownTimer;
        }
    }

    void CoolDown()
    {
        time -= Time.deltaTime;
        dashCoolDown.fillAmount = time / coolDownTimer;
    }

    //void ResetTimer()
    //{
    //    if (time <= 0)
    //    {
    //        coolingDown = false;
    //        time = coolDownTimer;
    //        dashCoolDown.fillAmount = coolDownTimer;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    private IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(2);

        while (time <= 0)
        {
            coolingDown = false;
            time = coolDownTimer;
            dashCoolDown.fillAmount = coolDownTimer;

            yield return new WaitForSeconds(0.1f);
        }

        reset = null;
    }
}
