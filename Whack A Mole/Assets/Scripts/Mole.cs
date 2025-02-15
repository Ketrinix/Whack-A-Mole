using System.Collections;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float appearDuration;
    public float minDisappearTime;
    public float maxDisappearTime;

    private Vector2 hiddenScale = new(0f, 0f);
    private Vector2 visibleScale = new(1f, 1f);

    public IEnumerator AppearAndDisappear()
    {
        yield return StartCoroutine(ScaleMole(hiddenScale, visibleScale, appearDuration));

        float disappearTime = Random.Range(minDisappearTime, maxDisappearTime);

        yield return new WaitForSeconds(disappearTime);

        GameController.gameController.MoleFinished();

        yield return StartCoroutine(ScaleMole(visibleScale, hiddenScale, appearDuration));
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

    public bool IsHidden()
    {
        return (Vector2)transform.localScale == hiddenScale;
    }
}