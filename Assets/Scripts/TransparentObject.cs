using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{

    [Range(0,1)]
    [SerializeField] private float _transparencyValue = 0.7f;
    [SerializeField] private float _transparencyFadeTime = .4f;  
    private SpriteRenderer _spriteRender;
    // Start is called before the first frame update
    void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PLayer_Controller >())
        {
            StartCoroutine(FadeTree(_spriteRender, _transparencyFadeTime, _spriteRender.color.a, _transparencyValue));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PLayer_Controller >())
        {
            StartCoroutine(FadeTree(_spriteRender, _transparencyFadeTime, _spriteRender.color.a, 1f));
        }    
    }

    private IEnumerator FadeTree(SpriteRenderer _spriteTransparency, float _fadeTime, float _startValue, float _targetTransparency)
    {
        float _timeElapsed = 0;
        while (_timeElapsed < _fadeTime)
        {
            _timeElapsed += Time.deltaTime;
            float _newAlpha = Mathf.Lerp(_startValue, _targetTransparency, _timeElapsed / _fadeTime);
            _spriteTransparency.color = new Color(_spriteTransparency.color.r, _spriteTransparency.color.g, _spriteTransparency.color.b, _newAlpha);
            yield return null;

        }
    }
}
