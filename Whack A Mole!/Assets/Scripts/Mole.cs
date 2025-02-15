using System.Collections;
using TMPro;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public TextMeshProUGUI thoughtCloudText;
    public float appearDuration;
    public float disappearDuration;
    public float minDisappearTime;
    public float maxDisappearTime;

    private SpriteRenderer sR = null;
    private Coroutine moleSpawnerCoroutine = null;
    private Vector2 hiddenScale = new(0f, 0f);
    private Vector2 visibleScale = new(1f, 1f);
    private readonly char[] vowels = { 'A', 'E', 'I', 'O', 'U' };

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sR.color = Color.yellow;
        transform.localScale = hiddenScale;
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");

        StartCoroutine(HitMole());
    }

    public void StartMoleSpawnerCorutine()
    {
        moleSpawnerCoroutine = StartCoroutine(MoleSpawner());
    }

    public bool IsHidden()
    {
        return (Vector2)transform.localScale == hiddenScale;
    }

    public IEnumerator MoleSpawner()
    {
        yield return StartCoroutine(Appear());

        float disappearTime = Random.Range(minDisappearTime, maxDisappearTime);

        yield return new WaitForSeconds(disappearTime);
        yield return StartCoroutine(Disappear());
    }

    private void AssignRandomVowel()
    {
        if (thoughtCloudText != null)
        {
            char randomVowel = vowels[Random.Range(0, vowels.Length)];

            thoughtCloudText.text = randomVowel.ToString();
        }
    }

    private IEnumerator Appear()
    {
        AssignRandomVowel();

        yield return StartCoroutine(ScaleMole(hiddenScale, visibleScale, appearDuration));
    }

    private IEnumerator Disappear()
    {
        GameController.gameController.MoleFinished();

        yield return StartCoroutine(ScaleMole(visibleScale, hiddenScale, disappearDuration));

        sR.color = Color.yellow;
    }

    private IEnumerator ScaleMole(Vector2 startScale, Vector2 endScale, float duration)
    {
        float time = 0f;

        while (time < duration)
        {
            transform.localScale = Vector2.Lerp(startScale, endScale, time / duration);

            time += Time.deltaTime;

            yield return null;
        }

        transform.localScale = endScale;
    }

    private IEnumerator HitMole()
    {
        if (moleSpawnerCoroutine != null)
        {
            StopCoroutine(moleSpawnerCoroutine);
        }

        sR.color = Color.red;

        yield return new WaitForSeconds(2f);

        StartCoroutine(Disappear());
    }
}