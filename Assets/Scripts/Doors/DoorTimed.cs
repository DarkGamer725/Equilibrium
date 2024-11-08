using UnityEngine;

public class DoorTimed : Door
{

    [SerializeField] float openedTime;
    [SerializeField] float closedTime;
    [SerializeField] bool openAtStart;
    float timeCounter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        timeCounter = 0;
        isOpen = openAtStart;

        animator.SetBool("Open", openAtStart);
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if (isOpen && timeCounter > openedTime)
        {
            Close();
            timeCounter = 0;
        }

        if (!isOpen && timeCounter > closedTime)
        {
            Open();
            timeCounter = 0;
        }
    }
}
