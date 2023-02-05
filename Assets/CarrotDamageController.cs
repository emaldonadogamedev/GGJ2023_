using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotDamageController : MonoBehaviour
{
    [SerializeField]
    private List<Rigidbody> m_leafRigidBodies = new List<Rigidbody>();

    [SerializeField]
    [Range(1f, 100f)]
    private float m_forceIntensity = 30f;

    private void OnCollisionEnter(Collision collision)
    {
        if(m_leafRigidBodies.Count > 0 &&
            collision.gameObject.CompareTag("Beetle Enemy"))
        {
            int randomIndex = Random.Range(0, m_leafRigidBodies.Count - 1);
            var rb = m_leafRigidBodies[randomIndex];
            m_leafRigidBodies.RemoveAt(randomIndex);

            rb.useGravity = true;
            rb.AddForce(GetRandomForceVector(m_forceIntensity));
        }
    }

    private Vector3 GetRandomForceVector(float intensity)
    {
        var forceVector = new Vector3(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));

        forceVector.Normalize();

        return forceVector * intensity;
    }
}