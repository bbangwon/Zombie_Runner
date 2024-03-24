using StarterAssets;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;

        FindObjectOfType<WeaponSwitcher>().enabled = false;
        var starterAssetsInput = GetComponent<StarterAssetsInputs>();

        starterAssetsInput.cursorLocked = false;
        starterAssetsInput.cursorInputForLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
