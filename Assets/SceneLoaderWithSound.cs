using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderWithSound : MonoBehaviour
{
    public string sceneName;
    public AudioClip sceneMusic;

    private AudioSource audioSource;

    void Start()
    {
        // Tạo AudioSource nếu chưa có
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sceneMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnDestroy()
    {
        // Dừng phát âm thanh khi đối tượng bị hủy
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
