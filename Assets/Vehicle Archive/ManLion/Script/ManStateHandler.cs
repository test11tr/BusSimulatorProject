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
    int lightMode = 0;

    [SerializeField] private GameObject leftBlinkerLight;
    [SerializeField] private GameObject rightBlinkerLight;
    [SerializeField] private GameObject dashboardP1;
    [SerializeField] private GameObject dashboardP2;
    [SerializeField] private GameObject dashboardP3;
    [SerializeField] private GameObject dashboardP4;
    [SerializeField] private GameObject int_arkakapi;
    [SerializeField] private GameObject int_onkapi;
    [SerializeField] private GameObject int_yakinfar;
    [SerializeField] private GameObject int_uzakfar;
    [SerializeField] private GameObject int_emniyet;
    [SerializeField] private GameObject int_elfreni;
    [SerializeField] private GameObject int_dortlulerbut;
    [SerializeField] private GameObject int_dortluler_em;
    [SerializeField] private GameObject int_benzinalarm;
    [SerializeField] private GameObject int_motorarizasi;


    private Material leftBlinkMat;
    private Material rightBlinkMat;
    private Material dashboardP1Mat;
    private Material dashboardP2Mat;
    private Material dashboardP3Mat;
    private Material dashboardP4Mat;
    private Material int_arkakapi_mat;
    private Material int_onkapi_mat;
    private Material int_yakinfar_mat;
    private Material int_uzakfar_mat;
    private Material int_emniyet_mat;
    private Material int_elfreni_mat;
    private Material int_dortlulerbut_mat;
    private Material int_dortluler_em_mat;
    private Material int_benzinalarm_mat;
    private Material int_motorarizasi_mat;

    void Start()
    {
        anim = GetComponent<Animator>();
        sceneManager = FindObjectOfType<RCC_SceneManager>();
        leftBlinkMat = leftBlinkerLight.GetComponent<Renderer>().material;
        rightBlinkMat = rightBlinkerLight.GetComponent<Renderer>().material;
        dashboardP1Mat = dashboardP1.GetComponent<Renderer>().material;
        dashboardP2Mat = dashboardP2.GetComponent<Renderer>().material;
        dashboardP3Mat = dashboardP3.GetComponent<Renderer>().material;
        dashboardP4Mat = dashboardP4.GetComponent<Renderer>().material;
        int_arkakapi_mat = int_arkakapi.GetComponent<Renderer>().material;
        int_onkapi_mat = int_onkapi.GetComponent<Renderer>().material;
        int_yakinfar_mat = int_yakinfar.GetComponent<Renderer>().material;
        int_uzakfar_mat = int_uzakfar.GetComponent<Renderer>().material;
        int_emniyet_mat = int_emniyet.GetComponent<Renderer>().material;
        int_elfreni_mat = int_elfreni.GetComponent<Renderer>().material;
        int_dortlulerbut_mat = int_dortlulerbut.GetComponent<Renderer>().material;
        int_dortluler_em_mat = int_dortluler_em.GetComponent<Renderer>().material;
        int_benzinalarm_mat = int_benzinalarm.GetComponent<Renderer>().material;
        int_motorarizasi_mat = int_motorarizasi.GetComponent<Renderer>().material;
    }

    IEnumerator LeftBlinkLight()
    {
        yield return new WaitForSeconds(0.2f);
        while (blinkerAtLeft)
        {
            leftBlinkMat.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
            leftBlinkMat.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator RightBlinkLight()
    {
        yield return new WaitForSeconds(0.2f);
        while (blinkerAtRight)
        {
            rightBlinkMat.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
            rightBlinkMat.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void DisableLight()
    {

    }
    void Update()
    {
 //       Debug.Log(sceneManager.activePlayerVehicle.speed);
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


        if (Input.GetKeyDown(KeyCode.Q))
        {
            BlinkerToLeft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            BlinkerToRight();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LightSwitch();
        }
        if (sceneManager.activePlayerVehicle.highBeamHeadLightsOn)
        {
            int_uzakfar_mat.EnableKeyword("_EMISSION");
        }
        else if(!sceneManager.activePlayerVehicle.highBeamHeadLightsOn)
        {
            int_uzakfar_mat.DisableKeyword("_EMISSION");
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
            StartCoroutine(LeftBlinkLight());
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
            StartCoroutine(RightBlinkLight());
        }
        else
        {
            blinkerAtRight = false;
            anim.SetBool("bl_right", false);
            anim.SetBool("bl_left", false);
        }
    }

    public void LightSwitch()
    {
        if (lightMode == 0)
        {
            dashboardP1Mat.EnableKeyword("_EMISSION");
            dashboardP2Mat.EnableKeyword("_EMISSION");
            dashboardP3Mat.EnableKeyword("_EMISSION");
            dashboardP4Mat.EnableKeyword("_EMISSION");
            lightMode = 1;
        }
        else if (lightMode == 1)
        {
            dashboardP1Mat.EnableKeyword("_EMISSION");
            dashboardP2Mat.EnableKeyword("_EMISSION");
            dashboardP3Mat.EnableKeyword("_EMISSION");
            dashboardP4Mat.EnableKeyword("_EMISSION");
            int_yakinfar_mat.EnableKeyword("_EMISSION");
            lightMode = 2;
        }
        else if (lightMode == 2)
        {
            dashboardP1Mat.DisableKeyword("_EMISSION");
            dashboardP2Mat.DisableKeyword("_EMISSION");
            dashboardP3Mat.DisableKeyword("_EMISSION");
            dashboardP4Mat.DisableKeyword("_EMISSION");
            int_yakinfar_mat.DisableKeyword("_EMISSION");
            lightMode = 0;
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
