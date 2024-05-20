using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    private int _counter = 0;
    private bool _isCounting = false;

    private void Start()
    {
        UpdateCounterText();
    }

    private void OnMouseDown()
    {
        _isCounting = !_isCounting;

        if (_isCounting == true)
        {
            StartCoroutine(Count());
        }
    }

    private IEnumerator Count()
    {
        while (_isCounting == true)
        {
            yield return new WaitForSeconds(0.5f);
            _counter++;
            UpdateCounterText();
        }
    }

    private void UpdateCounterText()
    {
        _counterText.text = _counter.ToString();
    }
}