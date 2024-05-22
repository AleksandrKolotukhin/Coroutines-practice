using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;
    private bool _isCounting = false;
    private WaitForSeconds _waitingTime = new WaitForSeconds(0.5f);
    private Coroutine _increaseScoreCoroutine;

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnMouseDown()
    {
        _isCounting = !_isCounting;

        if (_isCounting == true)
        {
            _increaseScoreCoroutine = StartCoroutine(IncreaseScore());
        }
        else
        {
            if (_increaseScoreCoroutine != null)
            {
                StopCoroutine(IncreaseScore());
                _increaseScoreCoroutine = null;
            }
        }
    }

    private IEnumerator IncreaseScore()
    {
        while (_isCounting == true)
        {
            yield return _waitingTime;
            _score++;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }
}