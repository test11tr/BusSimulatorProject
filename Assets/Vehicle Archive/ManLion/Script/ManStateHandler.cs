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
    bool hazardLightOn = false;
    bool seatbeltOn = false;
    bool vehicleStopping = false;
    bool wipersOn = false;
    int lightMode = 0;
    bool engineFailed = false;
    bool engineChecksStarted = false;

    [SerializeField] private AudioClip brakeNdoorAudio;
    [SerializeField] private AudioClip seatbeltOnAudio;
    [SerializeField] private AudioClip seatbeltOffAudio;
    [SerializeField] private AudioClip stickAudio;
    [SerializeField] private AudioClip engineOffSound;
    [SerializeField] private AudioClip wiperSlowAudio;
    [SerializeField] private AudioClip wiperFastAudio;
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
    [SerializeField] private GameObject farlar;
    [SerializeField] private GameObject farlar2;
    [SerializeField] private GameObject farlar3;

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
    private Material farlar_mat;
    private Material farlar2_mat;
    private Material farlar3_mat;



    private float randomMalfunctionNumber = 22.5f;

    #region Vehicle - Tire Health
    public float totalDamage { get; private set; }
    public float tireMaxHealth = 100;
    public float tireHealth = 100;
    public float tireWearRate = 0.001f;
    #endregion
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
        farlar_mat = farlar.GetComponent<Renderer>().material;
        farlar2_mat = farlar2.GetComponent<Renderer>().material;
        farlar3_mat = farlar3.GetComponent<Renderer>().material;
        //
        int_emniyet_mat.EnableKeyword("_EMISSION");
        totalDamage = PlayerPrefs.GetFloat("TotalDamage");
        tireHealth = PlayerPrefs.GetFloat("tireHealth");
        
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
    IEnumerator HazardLightBlink()
    {
        yield return new WaitForSeconds(0.2f);
        while (hazardLightOn)
        {
            int_dortluler_em_mat.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
            int_dortluler_em_mat.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator vehicleStoppingCouritine()
    {
        yield return new WaitForSeconds(5f);
        vehicleStopping = false;
    }
    IEnumerator wiperSoundCouritine()
    {
        yield return new WaitForSeconds(0.1f);
        while (wipersOn)
        {
            if (anim.GetInteger("wiperMode") == 1)
            {
                AudioSource.PlayClipAtPoint(wiperSlowAudio, transform.position, 0.75f);
                yield return new WaitForSeconds(3f);
            }
            else if (anim.GetInteger("wiperMode") == 2)
            {
                AudioSource.PlayClipAtPoint(wiperFastAudio, transform.position, 0.75f);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }

    IEnumerator EngineMalfunction()
    {
        yield return new WaitForSeconds(2f);
        while (engineChecksStarted)
        {
            randomMalfunctionNumber = totalDamage / 25;
            float temp = Random.Range(0, randomMalfunctionNumber);
            //print(randomMalfunctionNumber);
            print("Temp:" + temp);
            if (temp > 19)
            {
                print("ARIZA");
                if (!engineFailed)
                {
                    engineFailed = true;
                    ShutDownEverything();
                }
            }
            else
            {
                print("MOTOR TESTİ GEÇTİ");
            }
            yield return new WaitForSeconds(2f);
            //StartCoroutine(EngineMalfunction());
        }
    }

    void Update()
    {
        //Debug.Log(sceneManager.activePlayerVehicle.speed);
        //KapýKontrol & Motor Kontrol
        if (sceneManager.activePlayerVehicle.engineRunning)
        {
            //Lastik Aşınması
            if (sceneManager.activePlayerVehicle.speed > 5)
            {
                TireWear();
            }

            //MotorHasarı
            if (totalDamage > 25)
            {
                //EngineCheck
                if (!engineChecksStarted)
                {
                    engineChecksStarted = true;
                    StartCoroutine(EngineMalfunction());
                }
                int_motorarizasi_mat.EnableKeyword("_EMISSION");
            }else if (totalDamage <25)
            {
                if(engineChecksStarted)
                {
                    engineChecksStarted = false;
                }
                int_motorarizasi_mat.DisableKeyword("_EMISSION");
            }
            
            //TISS Sesi
            if (sceneManager.activePlayerVehicle.brakeInput == 1 && sceneManager.activePlayerVehicle.speed < 1 && !vehicleStopping)
            {
                vehicleStopping = true; // Sesin ayný anda 100 kere oynamasý için.
                AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 1.5f);
                StartCoroutine(vehicleStoppingCouritine());
            }

            //BenzinAlarmı
            if (sceneManager.activePlayerVehicle.fuelTank < 25)
                int_benzinalarm_mat.EnableKeyword("_EMISSION");
            else if (sceneManager.activePlayerVehicle.fuelTank > 25)
                int_benzinalarm_mat.DisableKeyword("_EMISSION");
            
            //FAR Emissionları
            if (sceneManager.activePlayerVehicle.lowBeamHeadLightsOn)
            {
                farlar_mat.EnableKeyword("_EMISSION");
                farlar2_mat.EnableKeyword("_EMISSION");
                farlar3_mat.EnableKeyword("_EMISSION");
            }
            else if (!sceneManager.activePlayerVehicle.lowBeamHeadLightsOn)
            {
                farlar_mat.DisableKeyword("_EMISSION");
                farlar2_mat.DisableKeyword("_EMISSION");
                farlar3_mat.DisableKeyword("_EMISSION");
            }

            //El Freni Alarm Iþýðý
            if (sceneManager.activePlayerVehicle.handbrakeInput == 1)
                int_elfreni_mat.EnableKeyword("_EMISSION");
            else if (sceneManager.activePlayerVehicle.handbrakeInput == 0)
                int_elfreni_mat.DisableKeyword("_EMISSION");

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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                HazardLightOn();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                LightSwitch();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                WiperSwitch();
            }
            //Motor Kapama Sesi
            if (Input.GetKeyDown(KeyCode.I))
            {
                AudioSource.PlayClipAtPoint(engineOffSound, transform.position, 1);
            }
            //Uzun Far Stick Sesi
            if (Input.GetKeyDown(KeyCode.K) && sceneManager.activePlayerVehicle.lowBeamHeadLightsOn)
            {
                AudioSource.PlayClipAtPoint(stickAudio, transform.position, 0.75f);
            }
            //Uzun Far Göstergesi
            if (sceneManager.activePlayerVehicle.highBeamHeadLightsOn)
            {
                int_uzakfar_mat.EnableKeyword("_EMISSION");
            }
            else if (!sceneManager.activePlayerVehicle.highBeamHeadLightsOn)
            {
                int_uzakfar_mat.DisableKeyword("_EMISSION");
            }
        }else if(!sceneManager.activePlayerVehicle.engineRunning && engineFailed)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                engineFailed = false;
                sceneManager.activePlayerVehicle.handbrakeInput = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SeatbeltSwitch();
        }
    }

    #region SWITCH METHODS & FUNCTIONS
    public void FrontDoorSwitch()
    {
        if (fd_isopen)
        {
            fd_isopen = false;
            anim.SetBool("fd_open", false);
            int_onkapi_mat.DisableKeyword("_EMISSION");
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 1);
        }
        else
        {
            fd_isopen = true;
            anim.SetBool("fd_open", true);
            int_onkapi_mat.EnableKeyword("_EMISSION");
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 1);
        }
    }
    public void RearDoorSwitch()
    {
        if (rd_isopen)
        {
            rd_isopen = false;
            anim.SetBool("rd_open", false);
            int_arkakapi_mat.DisableKeyword("_EMISSION");
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 1);
        }
        else
        {
            rd_isopen = true;
            anim.SetBool("rd_open", true);
            int_arkakapi_mat.EnableKeyword("_EMISSION");
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 1);
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
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
        }
        else
        {
            rl_isopen = true;
            anim.SetBool("rl1_open", true);
            anim.SetBool("rl2_open", true);
            //anim.SetBool("rl3_open", true);
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
        }
    }
    public void LeftLuggageSwitch()
    {
        if (ll_isopen)
        {
            ll_isopen = false;
            anim.SetBool("ll1_open", false);
            anim.SetBool("ll2_open", false);
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
        }
        else
        {
            ll_isopen = true;
            anim.SetBool("ll1_open", true);
            anim.SetBool("ll2_open", true);
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
            AudioSource.PlayClipAtPoint(brakeNdoorAudio, transform.position, 0.5f);
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
    public void HazardLightOn()
    {
        if (!hazardLightOn)
        {
            hazardLightOn = true;
            int_dortlulerbut_mat.EnableKeyword("_EMISSION");
            StartCoroutine(HazardLightBlink());
        }
        else
        {
            hazardLightOn = false;
            int_dortlulerbut_mat.DisableKeyword("_EMISSION");
        }
    }
    public void SeatbeltSwitch()
    {
        if (!seatbeltOn)
        {
            seatbeltOn = true;
            int_emniyet_mat.DisableKeyword("_EMISSION");
            AudioSource.PlayClipAtPoint(seatbeltOnAudio, transform.position, 1);
        }
        else
        {
            seatbeltOn = false;
            int_emniyet_mat.EnableKeyword("_EMISSION");
            AudioSource.PlayClipAtPoint(seatbeltOffAudio, transform.position, 1);
        }
    }

    public void LightSwitch()
    {
        if ( lightMode== 0)
        {
            AudioSource.PlayClipAtPoint(stickAudio, transform.position, 0.75f);
            dashboardP1Mat.EnableKeyword("_EMISSION");
            dashboardP2Mat.EnableKeyword("_EMISSION");
            dashboardP3Mat.EnableKeyword("_EMISSION");
            dashboardP4Mat.EnableKeyword("_EMISSION");
            lightMode = 1;
        }
        else if (lightMode == 1)
        {
            AudioSource.PlayClipAtPoint(stickAudio, transform.position, 0.75f);
            dashboardP1Mat.EnableKeyword("_EMISSION");
            dashboardP2Mat.EnableKeyword("_EMISSION");
            dashboardP3Mat.EnableKeyword("_EMISSION");
            dashboardP4Mat.EnableKeyword("_EMISSION");
            int_yakinfar_mat.EnableKeyword("_EMISSION");
            lightMode = 2;
        }
        else if (lightMode == 2)
        {
            AudioSource.PlayClipAtPoint(stickAudio, transform.position, 0.75f);
            dashboardP1Mat.DisableKeyword("_EMISSION");
            dashboardP2Mat.DisableKeyword("_EMISSION");
            dashboardP3Mat.DisableKeyword("_EMISSION");
            dashboardP4Mat.DisableKeyword("_EMISSION");
            int_yakinfar_mat.DisableKeyword("_EMISSION");
            lightMode = 0;
        }
    }

    public void WiperSwitch()
    {
        if (anim.GetInteger("wiperMode") == 0)
        {
            wipersOn = true;
            AudioSource.PlayClipAtPoint(stickAudio, transform.position, 0.75f);
            anim.SetInteger("wiperMode", 1);
            StartCoroutine(wiperSoundCouritine());
        }
        else if (anim.GetInteger("wiperMode") == 1)
        {
            wipersOn = true;
            AudioSource.PlayClipAtPoint(stickAudio, transform.position, 0.75f);
            anim.SetInteger("wiperMode", 2);
        }
        else if (anim.GetInteger("wiperMode") == 2)
        {
            wipersOn = false;
            AudioSource.PlayClipAtPoint(stickAudio, transform.position, 0.75f);
            StopCoroutine(wiperSoundCouritine());
            anim.SetInteger("wiperMode", 0);
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

    private void TireWear()
    {
        tireHealth -= ((sceneManager.activePlayerVehicle.engineRPM / 10000f) * tireWearRate) * Time.fixedDeltaTime;
        tireHealth = Mathf.Clamp(tireHealth, 0f, tireMaxHealth);
        PlayerPrefs.SetFloat("tireHealth", tireHealth);

        sceneManager.activePlayerVehicle.tireWearSteer = tireHealth / 4;

    }

    private void ShutDownEverything()
    {
        //OffEngine
        AudioSource.PlayClipAtPoint(engineOffSound, transform.position, 1);
        RCC.SetEngine(sceneManager.activePlayerVehicle, false);
        sceneManager.activePlayerVehicle.handbrakeInput = 1;
        //OffEverything
        dashboardP1Mat.DisableKeyword("_EMISSION");
        dashboardP2Mat.DisableKeyword("_EMISSION");
        dashboardP3Mat.DisableKeyword("_EMISSION");
        dashboardP4Mat.DisableKeyword("_EMISSION");
        int_yakinfar_mat.DisableKeyword("_EMISSION");
        int_uzakfar_mat.DisableKeyword("_EMISSION");
        lightMode = 0;
        wipersOn = false;
        anim.SetInteger("wiperMode", 0); //Silecekleri Kapama Çalışmıyor
        hazardLightOn = false;
        int_dortlulerbut_mat.DisableKeyword("_EMISSION");
        anim.SetBool("bl_left", false);
        anim.SetBool("bl_right", false);
        blinkerAtLeft = false;
        blinkerAtRight = false;
        int_benzinalarm_mat.DisableKeyword("_EMISSION");
        sceneManager.activePlayerVehicle.lowBeamHeadLightsOn = false;
        sceneManager.activePlayerVehicle.highBeamHeadLightsOn = false;
        sceneManager.activePlayerVehicle.indicatorsOn = RCC_CarControllerV3.IndicatorsOn.Off;
        engineChecksStarted = false;
        StopCoroutine(wiperSoundCouritine());
    }
}
