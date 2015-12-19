using UnityEngine;
using System.Collections;

public class CreateProtectMask : MonoBehaviour
{
    private ForceCode m_ForceCode;

    private bool isChangeScale;

    private float m_ScaleChangeSpeed = 0.02f;

    private float m_ChangeTime = 3f;

    private Vector3 m_PreLocalScale = new Vector3(1f, 1f, 1f);
    private float m_PreRadius = 1f;

    public void Click()
    {
        isChangeScale = true;
    }

    private void Start()
    {
        m_ForceCode = gameObject.GetComponent<ForceCode>();
        isChangeScale = false;
        transform.localScale = m_PreLocalScale;
    }

    private void Update()
    {
        if (isChangeScale)
        {
            m_ChangeTime = m_ChangeTime - Time.deltaTime;
            if (m_ChangeTime > 0)
            {
                transform.localScale += new Vector3(m_ScaleChangeSpeed, m_ScaleChangeSpeed, 0f);
                m_ForceCode.m_Radius += m_ScaleChangeSpeed;
            }
            else
            {
                transform.localScale = m_PreLocalScale;
                m_ForceCode.m_Radius = m_PreRadius;
                m_ChangeTime = 1f;
                isChangeScale = false;
            }
        }
    }
}