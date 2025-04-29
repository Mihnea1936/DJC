using UnityEngine;
using TMPro; // ← adaugă asta!
using System.Collections;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public int enemiesKilled = 0;
    public int enemiesToKill = 50;

    public TextMeshProUGUI missionText;  // ← modifică tipul aici
    public TextMeshProUGUI victoryText;  // ← și aici

    void Start()
    {
        victoryText.gameObject.SetActive(false);
        missionText.text = "Kill " + enemiesToKill + " enemies to capture the island!";


        // Ascunde MissionText după 4 secunde
    StartCoroutine(HideMissionTextAfterDelay());
    }
    IEnumerator HideMissionTextAfterDelay()
{
    yield return new WaitForSeconds(4f);  // poți schimba timpul după preferință
    missionText.gameObject.SetActive(false);
}

    public void EnemyKilled()
    {
        enemiesKilled++;

        if(enemiesKilled >= enemiesToKill)
        {
            GameWon();
        }
    }

    void GameWon()
    {
        Debug.Log("Ai castigat!");
        victoryText.gameObject.SetActive(true);
        victoryText.text = "Congratulations! You captured the island. Good luck with the next one!";

        
        Time.timeScale = 0f;
        StartCoroutine(ReturnToMenuAfterDelay());
    }
    IEnumerator ReturnToMenuAfterDelay()
{
    // Folosește "WaitForSecondsRealtime" pentru că Time.timeScale = 0
    yield return new WaitForSecondsRealtime(4f);

    // (Repornește timpul jocului)
    Time.timeScale = 1f;

    // Încarcă scena de meniu (înlocuiește "TitleMenu" cu numele scenei tale de meniu dacă e diferit)
    SceneManager.LoadScene("TitleMenu");
}
}
