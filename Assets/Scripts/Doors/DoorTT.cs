using UnityEngine;

public class DoorTT : Door, IActivable
{
    float timer;
    [SerializeField] float openedTime;
    [SerializeField] Switch trigger;

    protected override void Start()
    {
        base.Start();
        trigger.RegisterOnActivate(Trigger);
    }

    private void Trigger(bool activate)
    {
        if (!isOpen)
        {
            Open();
            timer = 0;
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            timer += Time.deltaTime;
            if (timer > openedTime)
            {
                Close();
                trigger.Activate(false);
            }
        }
    }

    public void Activate()
    {
        Open();
    }

    public void Deactivate()
    {
        Close();
    }
}
