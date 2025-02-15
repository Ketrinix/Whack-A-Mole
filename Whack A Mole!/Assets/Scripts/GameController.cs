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
        // Obtener todos los topos ocultos en una lista
        List<Mole> hiddenMoles = new();

        foreach (Mole mole in moles)
        {
            if (mole.IsHidden())
            {
                hiddenMoles.Add(mole);
            }
        }

        // Si hay topos ocultos, elegir uno al azar
        if (hiddenMoles.Count > 0)
        {
            return hiddenMoles[Random.Range(0, hiddenMoles.Count)];
        }

        return null; // No hay topos disponibles
    }

    private IEnumerator SpawnMolesInSequence()
    {
        while (true)
        {
            if (activeMoles < 5)
            {
                Mole nextMole = GetNextHiddenMole();

                if (nextMole != null)
                {
                    activeMoles++;

                    nextMole.StartMoleSpawnerCorutine();
                }
            }

            yield return new WaitForSeconds(1f); // Pequeña espera antes de revisar de nuevo
        }
    }
}