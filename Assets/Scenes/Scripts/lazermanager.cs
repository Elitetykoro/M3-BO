using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class lazermanager : MonoBehaviour
{
    [SerializeField] private GameObject LazerWarning;
    [SerializeField] private GameObject Lazer;
    [SerializeField] private Transform Player;
    [SerializeField] private AudioClip ShootSound;
    [SerializeField] private AudioClip LazerChargeSound;
    private float LazerSpawnTime = 5f;
    private bool active = true;
    public Animator animator;
    [SerializeField] private CinemachineVirtualCamera Vcam;
    [SerializeField] private CinemachineBasicMultiChannelPerlin noise;
    [SerializeField] private float AST;
    [SerializeField] private float INTS;






    // Start is called before the first frame update
    void Start()
    {
        noise = Vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine("LazerSpawn");
        //CamShakeOff();


    }

    // Update is called once per frame
    void Update()
    {

    }




    private IEnumerator LazerSpawn()
    {
        while (active)
        {
            yield return new WaitForSeconds(LazerSpawnTime);
            SoundManager.Instance.PlaySound(LazerChargeSound);
            LazerWarning.transform.position = Player.position;
            LazerWarning.transform.rotation = Quaternion.Euler(0, Random.Range(20, 160), 0);
            LazerWarning.SetActive(true);
            animator.SetBool("isActive", true);
            yield return new WaitForSeconds(1.5f);
            animator.SetBool("isActive", false);
            LazerWarning.SetActive(false);
            Lazer.transform.position = LazerWarning.transform.position;
            Lazer.transform.rotation = LazerWarning.transform.rotation;
            Lazer.SetActive(true);
            SoundManager.Instance.PlaySound(ShootSound);
            CamShake(INTS, AST);
            yield return new WaitForSeconds(0.5f);

            Lazer.SetActive(false);
            if (LazerSpawnTime > 2)
            {
                LazerSpawnTime = LazerSpawnTime - 0.1f;
            }
        }
    }
    private void CamShake(float Intensity, float ShakeTime)
    {
        noise.m_AmplitudeGain = Intensity;
        StartCoroutine(ShakeTimeManager(ShakeTime));
    }

    IEnumerator ShakeTimeManager(float ShakeTime)
    {
        yield return new WaitForSeconds(ShakeTime);
        CamShakeOff();
    }
    private void CamShakeOff()
    {
        noise.m_AmplitudeGain = 0;
    }

}