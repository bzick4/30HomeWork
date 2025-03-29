using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update


   public AudioSource audioSource; // Аудиоисточник
    private string audioUrl = " https://drive.google.com/uc?export=download&id=1g3KBj4jWVEbr6TGMHGIY16ZkZP1T9tSr"; // Сюда вставь ссылку на аудиофайл

    void Start()
    {
        StartCoroutine(DownloadAudio(audioUrl));
    }

    IEnumerator DownloadAudio(string url)
    {
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Ошибка загрузки аудиофайла: " + request.error);
        }
    }
}
