using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float killForce = 5f;
    [SerializeField] private bool kill;
    [SerializeField] private bool revive;

    [SerializeField] private Rigidbody[] RbS;
    [SerializeField] private Collider[] colls;
    [SerializeField] private Animator anim;
   // Start is called before the first frame update
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        RbS = GetComponentsInChildren<Rigidbody>();
        colls = GetComponentsInChildren<Collider>();
        Revive();
    }

    private void Kill()
    {
        kill = false;
        SetRagdoll(true);
        SetMain(false);
    }
    private void Revive()
    {
        revive = false;
        SetRagdoll(false);
        SetMain(true);
    }

    void SetRagdoll(bool active)
    {
        for (int i = 0; i < RbS.Length; i++)
        {
            RbS[i].isKinematic = !active;
        }
        for (int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = active;
        }
    }
    void SetMain(bool active)
    {
        anim.enabled=active;
        RbS[0].isKinematic = !active;
        colls[0].enabled = active;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Kill();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Revive();
        }
    }
}
