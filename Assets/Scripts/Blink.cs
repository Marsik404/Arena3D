using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private Image _blinkImage;

    private float _speedBlink = 5f;
    public Color TargetColor = Color.red;
    private float _returnDelay = 0.1f;

    private bool _isBlinking = false;
    private float _startAlpha;

    private void Start()
    {
        _blinkImage = GetComponent<Image>();
        _blinkImage.color = Color.clear;
        _startAlpha = _blinkImage.color.a;
    }

    private void Update()
    {
        if (_isBlinking)
        {
            float newAlpha = Mathf.MoveTowards(_blinkImage.color.a, TargetColor.a, _speedBlink * Time.deltaTime);
            _blinkImage.color = new Color(TargetColor.r, TargetColor.g, TargetColor.b, newAlpha);

            if (newAlpha == TargetColor.a)
            {
                _isBlinking = false;
                StartCoroutine(ReturnToNormal());
            }
        }
    }

    public void ActivateBlink()
    {
        _isBlinking = true;
    }

    private IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(_returnDelay);

        float currentAlpha = _blinkImage.color.a;
        while (currentAlpha > _startAlpha)
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, _startAlpha, _speedBlink * Time.deltaTime);
            _blinkImage.color = new Color(TargetColor.r, TargetColor.g, TargetColor.b, currentAlpha);
            yield return null;
        }
    }
}
