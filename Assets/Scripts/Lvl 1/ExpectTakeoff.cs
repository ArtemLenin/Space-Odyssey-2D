using UnityEngine;

public class ExpectTakeoff : MonoBehaviour
{
    private bool _signal = false;

    public bool Signal { get => _signal; private set => _signal = value; }

    private void Update()
    {
        CheckInput();
        if (_signal)
        {
            // start animation
            // 
            GameManager.Instance.CheckCompletion();
        }
    }

    private void CheckInput()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Signal = true;
        }
#endif
    }
}