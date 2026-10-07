using UnityEngine;

public class CharSelectemanager : MonoBehaviour
{
    [SerializeField] GameObject ScoreCanvas;
    [SerializeField] GameObject dinosprite;
    [SerializeField] GameObject frogsprite;
        void Start()
    {
        Time.timeScale=0;

        
    }

    void BeginGame()
    {
        Time.timeScale=1f;
        ScoreCanvas.SetActive(true);
        gameObject.SetActive(false);

    }
  public void choosedino()
  {
    dinosprite.SetActive(true);
   
    
     BeginGame();
    

  }
  public void choosefrog()
    {
        frogsprite.SetActive(true);
        BeginGame();
    }


}
