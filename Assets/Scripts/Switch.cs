using System.Collections;
using UnityEngine;

public class Switch  : MonoBehaviour
{
    //[SerializeField] MonoBehaviour activableObject;
    [SerializeField] Color activeColor;
    [SerializeField] Color deactiveColor;
    [SerializeField] Color errorColor;

    [SerializeField] float errorDelay;

    MeshRenderer rend;

    int state; //  0 desactivado, 1 activado, -1 error

    public delegate void TriggerDelegate(bool b);
    event TriggerDelegate OnChangeState;

    //private IActivable activable;

    private void Start()
    {
        state = 0;
        rend = GetComponent<MeshRenderer>();

        /*activable = activableObject as IActivable;

        if (activable == null)
        {
            Debug.LogError("Asigned component doesn't implement IActivable");
        }*/
    }

    public void RegisterOnActivate(TriggerDelegate f)
    {
        OnChangeState += f;
    }

    public void RegisterOnDeactivate(TriggerDelegate f)
    {
        OnChangeState += f;
    }

    public void Activate(bool activate)
    {
        if (activate)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        state = 1 ;
        rend.materials[1].color = activeColor;
    }

    public void Deactivate()
    {
        state = 0 ;
        rend.materials[1].color = deactiveColor;
    }

    public void Error()
    {
        state = -1;
        rend.materials[1].color = errorColor;
        StartCoroutine(DeactivateDelay());
    }

    IEnumerator DeactivateDelay()
    {
        yield return new WaitForSeconds(errorDelay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (state == 1)
            {
                //activable.Deactivate();
                if (OnChangeState != null)
                {
                    OnChangeState(false);
                }
                Deactivate();
            }
            else
            {
                //activable.Activate();
                if (OnChangeState != null)
                {
                    OnChangeState(true);
                }
                Activate();
            }

            
        }
    }
}
