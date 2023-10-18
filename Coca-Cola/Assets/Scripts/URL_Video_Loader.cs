using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class URL_Video_Loader : MonoBehaviour
{   
    [Header("Main Components")]
    public VideoPlayer videoPlayer;
    public RawImage rawImage;

    [Header("URL")]
    public string video_URL;

    private void Get_BaseComponents()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        rawImage = GetComponent<RawImage>();
    }

    IEnumerator Start()
    {
        Get_BaseComponents();
        UnityWebRequest www = UnityWebRequest.Get(video_URL);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(" CANNOT GET URL " + www.error);
        }
        else
        {
            string _tempVideo = Application.persistentDataPath + "/tempVideo.mp4";
            System.IO.File.WriteAllBytes(_tempVideo, www.downloadHandler.data);
            videoPlayer.url = _tempVideo;

            videoPlayer.Prepare();
            videoPlayer.loopPointReached += VideoPlayerLoop;

            while(!videoPlayer.isPrepared)
            {
                yield return null;
            }
            videoPlayer.Play();
        }
        
    }

    private void VideoPlayerLoop(VideoPlayer source)
    {

    }
}
