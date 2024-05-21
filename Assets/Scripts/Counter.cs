using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    private int _counter = 0;
    private bool _isCounting = false;
    private WaitForSeconds _waitForHalfSecond = new WaitForSeconds(0.5f);

    private void Start()
    {
        UpdateCounterText();
    }

    private void OnMouseDown()
    {
        _isCounting = !_isCounting;

        if (_isCounting == true)
        {
            StartCoroutine(IncreaseCount());
        }
        else
        {
            StopCoroutine(IncreaseCount());
        }
    }

    private IEnumerator IncreaseCount()
    {
        while (_isCounting == true)
        {
            yield return _waitForHalfSecond;
            _counter++;
            UpdateCounterText();
        }
    }

    private void UpdateCounterText()
    {
        _counterText.text = _counter.ToString();
    }
}