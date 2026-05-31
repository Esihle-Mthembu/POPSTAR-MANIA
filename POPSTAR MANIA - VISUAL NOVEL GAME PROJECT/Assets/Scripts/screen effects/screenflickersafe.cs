//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class ScreenFlicker : MonoBehaviour
//{
//    public static ScreenFlicker Instance;

//    [Header("Overlay Image")]
//    public Image flickerImage;

//    private Coroutine flickerCoroutine;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    public void StartFlicker(float duration)
//    {
//        if (flickerImage == null)
//        {
//            Debug.LogWarning("ScreenFlicker: flickerImage is NULL (not assigned or scene changed)");
//            return;
//        }

//        if (flickerCoroutine != null)
//        {
//            StopCoroutine(flickerCoroutine);
//            flickerCoroutine = null;
//        }

//        flickerCoroutine = StartCoroutine(FlickerEffect(duration));
//    }

//    public void StopFlicker()
//    {
//        if (flickerCoroutine != null)
//        {
//            StopCoroutine(flickerCoroutine);
//            flickerCoroutine = null;
//        }

//        if (flickerImage == null) return;

//        Color reset = flickerImage.color;
//        reset.a = 0f;
//        flickerImage.color = reset;

//        flickerImage.rectTransform.anchoredPosition = Vector2.zero;
//    }

//    IEnumerator FlickerEffect(float duration)
//    {
//        if (flickerImage == null)
//        {
//            Debug.LogWarning("ScreenFlicker: flickerImage missing during effect");
//            yield break;
//        }

//        float timer = 0f;

//        while (timer < duration)
//        {
//            if (flickerImage == null)
//                yield break;

//            Color color = flickerImage.color;
//            color.a = Random.Range(0f, 0.6f);
//            flickerImage.color = color;

//            flickerImage.rectTransform.anchoredPosition =
//                new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));

//            yield return new WaitForSeconds(0.02f);
//            timer += Time.deltaTime;
//        }

//        flickerImage.rectTransform.anchoredPosition = Vector2.zero;

//        Color reset = flickerImage.color;
//        reset.a = 0f;
//        flickerImage.color = reset;

//        flickerCoroutine = null;
//    }
//}