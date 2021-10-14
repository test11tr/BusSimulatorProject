using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManStateHandler : MonoBehaviour
{
    [SerializeField] public RCC_SceneManager sceneManager;
    public Animator anim;
    bool fd_isopen = false;
    bool rd_isopen = false;
    bool rl_isopen = false;
    bool ll_isopen = false;
    bool blinkerAtLeft = false;
    bool blinkerAtRight = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        sceneManager = FindObjectOfType<RCC_SceneManager>();
    }

    void Update()
    {
        //KapýKontrol & Motor Kontrol
        if (sceneManager.activePlayerVehicle.speed < 2)
        {
            //ON KAPI
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FrontDoorSwitch();
            }
            //ARKA KAPI
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RearDoorSwitch();
            }
            //SAG BAGAJLAR
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                RightLuggageSwitch();
            }
            //SOL BAGAJLAR
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                LeftLuggageSwitch();
            }
            
            //Hareket Kontrol
            CheckIfCanMove();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            BlinkerToLeft();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            BlinkerToRight();
        }
    }

    #region DOOR LUGGAGE BLINKER SWITCH METHODS
    public void FrontDoorSwitch()
    {
        if (fd_isopen)
        {
            fd_isopen = false;
            anim.SetBool("fd_open", false);
        }
        else
        {
            fd_isopen = true;
            anim.SetBool("fd_open", true);
        }
    }
    public void RearDoorSwitch()
    {
        if (rd_isopen)
        {
            rd_isopen = false;
            anim.SetBool("rd_open", false);
        }
        else
        {
            rd_isopen = true;
            anim.SetBool("rd_open", true);
        }
    }
    public void RightLuggageSwitch()
    {
        if (rl_isopen)
        {
            rl_isopen = false;
            anim.SetBool("rl1_open", false);
            anim.SetBool("rl2_open", false);
            //anim.SetBool("rl3_open", false);
        }
        else
        {
            rl_isopen = true;
            anim.SetBool("rl1_open", true);
            anim.SetBool("rl2_open", true);
            //anim.SetBool("rl3_open", true);
        }
    }
    public void LeftLuggageSwitch()
    {
        if (ll_isopen)
        {
            ll_isopen = false;
            anim.SetBool("ll1_open", false);
            anim.SetBool("ll2_open", false);
        }
        else
        {
            ll_isopen = true;
            anim.SetBool("ll1_open", true);
            anim.SetBool("ll2_open", true);
        }
    }
    public void BlinkerToLeft()
    {
        if (!blinkerAtLeft)
        {
            blinkerAtLeft = true;
            blinkerAtRight = false;
            anim.SetBool("bl_left", true);
            anim.SetBool("bl_right", false);
        }
        else
        {
            blinkerAtLeft = false;
            anim.SetBool("bl_left", false);
            anim.SetBool("bl_right", false);
        }
    }
    public void BlinkerToRight()
    {
        if (!blinkerAtRight)
        {
            blinkerAtRight = true;
            blinkerAtLeft = false;
            anim.SetBool("bl_right", true);
            anim.SetBool("bl_left", false);
        }
        else
        {
            blinkerAtRight = false;
            anim.SetBool("bl_right", false);
            anim.SetBool("bl_left", false);
        }
    }
    #endregion

    public void CheckIfCanMove()
    {
        if (fd_isopen || rd_isopen || rl_isopen || ll_isopen)
        {
            sceneManager.activePlayerVehicle.canControl = false;
            print("Hareket etmeden önce lütfen tüm kapýlarý kapayýnýz.");
        }
        else
        {
            sceneManager.activePlayerVehicle.canControl = true;
            //print("Þuan hareket edebilirsin.");
        }
    }
}
