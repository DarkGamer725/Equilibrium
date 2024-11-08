using UnityEngine;

public class DoorTriggered : Door, IActivable
{
    [SerializeField] Switch trigger;


    protected override void Start()
    {
        base.Start();
        trigger.RegisterOnActivate(Trigger);
    }

    private void Trigger(bool activate)
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
        Open();
    }

    public void Deactivate()
    {
        Close();
    }
}
