//using UnityEngine;
//using System.Collections;

//public class ScreenShake : MonoBehaviour
//{
//    public static ScreenShake Instance;

//    private Vector3 originalPosition;

//    private void Awake()
//    {
//        // Singleton
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

//    private void Start()
//    {
//        originalPosition = transform.localPosition;
//    }

//    public void StartShake(float duration, float strength)
//    {
//        StartCoroutine(Shake(duration, strength));
//    }

//    IEnumerator Shake(float duration, float strength)
//    {
//        float timer = 0f;

//        while (timer < duration)
//        {
//            float x = Random.Range(-strength, strength);
//            float y = Random.Range(-strength, strength);

//            transform.localPosition = originalPosition + new Vector3(x, y, 0);

//            timer += Time.deltaTime;

//            yield return null;
//        }

//        transform.localPosition = originalPosition;
//    }
//}