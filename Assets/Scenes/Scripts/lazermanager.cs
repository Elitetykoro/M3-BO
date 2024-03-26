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
    [SerializeField] private Transform ParticlePosTop;
    [SerializeField] private Transform ParticlePosBottom;
    [SerializeField] private ParticleSystem ParticleTop;
    [SerializeField] private ParticleSystem ParticleBottom;
    private float LazerSpawnTime = 5f;
    private bool active = true;
    public Animator animator;
    [SerializeField] private CinemachineVirtualCamera Vcam;
    [SerializeField] private CinemachineBasicMultiChannelPerlin noise;
    [SerializeField] private float AST;
    [SerializeField] private float INTS;
    [SerializeField] private LineRenderer LazerRenderer;
    private float TopPos;
    private float BottomPos;
    






    // Start is called before the first frame update
    void Start()
    {
        noise = Vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        LazerRenderer.positionCount = 2;
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
            TopPos = Random.Range(-49, 49);
            BottomPos = Random.Range(-49, 49);
            ParticlePosTop.position = new Vector3(TopPos, 0,30);
            ParticlePosBottom.position = new Vector3(BottomPos, 0, -30);
            SoundManager.Instance.PlaySound(LazerChargeSound);
            ParticleTop.Play();
            ParticleBottom.Play();
            yield return new WaitForSeconds(1.5f);
            LazerRenderer.SetPosition(0,ParticlePosTop.position);
            LazerRenderer.SetPosition(1, ParticlePosBottom.position);
            MakeLazerCollider();
            //Lazer.transform.position = new Vector3(TopPos,0,0);
            //Lazer.transform.rotation = Quaternion.Euler(0,Mathf.Atan2(TopPos, BottomPos) * -Mathf.Rad2Deg + 90, 0);
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
    private void MakeLazerCollider()
    {
       MeshCollider MSCOL = Lazer.GetComponent<MeshCollider>();
        if (MSCOL == null)
        {
            MSCOL = Lazer.GetComponent<MeshCollider>();
        }

        Mesh LazerMesh = new Mesh();
        LazerRenderer.BakeMesh(LazerMesh, true);
        MSCOL.sharedMesh = LazerMesh;
}

}