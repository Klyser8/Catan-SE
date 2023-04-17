using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManagerScript : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(PrepareVideo());
    }

    private System.Collections.IEnumerator PrepareVideo()
    {
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(1);
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
