using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class viewPoints : MonoBehaviour
{
    private ParticleSystem m_ParticleSystem;
    [DllImport("PCLProj")]
    public static extern int readPointCloudFile([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] voPoints);
    void Start()
    {
        float[] Points = new float[10000];
        int PointNumber = 0;
        PointNumber = readPointCloudFile(Points);
        Debug.Log("点云的数量是: " + PointNumber);

        m_ParticleSystem = GetComponent<ParticleSystem>();
        var main = m_ParticleSystem.main;
        main.startSpeed = 0.0f;
        main.startLifetime = 1000.0f;

        //var pointCount = drawList.Count;
        ParticleSystem.Particle[] allParticles;
        allParticles = new ParticleSystem.Particle[PointNumber];
        main.maxParticles = PointNumber;
        m_ParticleSystem.Emit(PointNumber);
        m_ParticleSystem.GetParticles(allParticles);
        for (int i = 0; i < PointNumber; i++)
        {
            allParticles[i].position = new Vector3(Points[3 * i], Points[3 * i + 1], Points[3 * i + 2]);    // 设置每个点的位置
            allParticles[i].startColor = Color.yellow;    // 设置每个点的rgb
            allParticles[i].startSize = 0.02f;
        }

        m_ParticleSystem.SetParticles(allParticles, PointNumber);      // 将点云载入粒子系统

    }
}
