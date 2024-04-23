using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : SingletonMonoBehaviour<PlayerStats>
{
    [SerializeField] private int maxSanity;
    [SerializeField] private int currentSanity;
    [SerializeField] private int clarityLevel;

    [SerializeField] private List<Renderer> randomObjects;

    [SerializeField] private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;

        UIManager.Instance.UpdateClarity(clarityLevel);
        UIManager.Instance.UpdateSanity(currentSanity);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSanity <= 0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Restart the run");
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene(1);

        }
    }

    public void DecreaseSanity()
    {
        if (currentSanity > 10) // Ensure there's enough sanity to use focus
        {
            currentSanity -= 10; // Cost of using focus
            UIManager.Instance.UpdateSanity(currentSanity);
            IncreaseClarity();

            var chosenObj = randomObjects[Random.Range(0, randomObjects.Count)];

            mat = chosenObj.materials[1];

            mat.SetFloat("_Noise_Scale", mat.GetFloat("_Noise_Scale") + 50);
        }
    }

    public void IncreaseClarity()
    {
        clarityLevel++;
        UIManager.Instance.UpdateClarity(clarityLevel);
    }

    public void IncreaseSanity()
    {
        // Clarity provides a reduction in sanity loss rate or restores sanity
        currentSanity += 10; // Example: restore sanity based on clarity level
        if (currentSanity > maxSanity)
            currentSanity = maxSanity;

        UIManager.Instance.UpdateSanity(currentSanity);
    }

    // GETTER

    public int GetCurrentSanity()
    {
        return currentSanity;
    }

    public int GetCurrentClarity()
    {
        return clarityLevel;
    }
}
