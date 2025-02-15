using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public List<Mole> moles = new();
    public int activeMoles = 0;

    private void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }
        else
        {
            Destroy(gameObject);

            Debug.LogWarning("Había otro objeto \"GameController\" en la escena.");
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnMolesInSequence());
    }

    public void MoleFinished()
    {
        activeMoles--;
    }

    private Mole GetNextHiddenMole()
    {
        foreach (Mole mole in moles)
        {
            if (mole.IsHidden())
            {
                return mole;
            }
        }

        return null;
    }

    private IEnumerator SpawnMolesInSequence()
    {
        while (true)
        {
            if (activeMoles < 3)
            {
                Mole nextMole = GetNextHiddenMole();

                if (nextMole != null)
                {
                    activeMoles++;

                    StartCoroutine(nextMole.AppearAndDisappear());
                }
            }

            yield return new WaitForSeconds(0.25f); // Pequeña espera antes de revisar de nuevo
        }
    }
}