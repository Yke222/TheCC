using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

      public void PlayGame()
      {
          Debug.Log("Opening game");
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
    
      public void QuitGame()
      {
          Debug.Log("Quiting game");
          Application.Quit();
      }
      
      
      public void SetLava()
      {
          ArenaPicker.ArenaNumber = 1;
      }

      public void SetSea()
      {
          ArenaPicker.ArenaNumber = 2;
      }

      public void SetIce()
      {
          ArenaPicker.ArenaNumber = 3;
      }
}
