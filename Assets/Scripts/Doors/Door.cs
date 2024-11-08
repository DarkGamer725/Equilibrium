using UnityEngine;

public abstract class Door : MonoBehaviour
{
    protected Animator animator;
    protected bool isOpen;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        Open(isOpen);
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void Open(bool hasToOpen)
    {
        if (hasToOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    protected void Open()
    {
        animator.SetBool("Open", true);
        isOpen = true;
    }

    protected void Close()
    {
        animator.SetBool("Open", false);
        isOpen = false;
    }
}
