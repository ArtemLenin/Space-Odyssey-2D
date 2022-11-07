using UnityEngine;

public class ExpectTakeoff : MonoBehaviour
{
    private bool _signal = false;

    public bool Signal { get => _signal; private set => _signal = value; }

    private void Update()
    {
        CheckInput();
        if (Signal)
        {
            Launch();
        }
    }

    private void Launch()
    {
        //
        // start animation
        // 
        GameManager.Instance.CheckCompletion();
    }

    private void CheckInput()
    {
        Signal = GameManager.Bridge.Signal;
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Signal = true;
        }
#endif
    }
}