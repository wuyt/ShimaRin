using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ShimaRin
{
    public class WebVideosLoading : MonoBehaviour
    {
        /// <summary>
        /// 视频播放组件
        /// </summary>
        public VideoPlayer videoPlayer;
        /// <summary>
        /// 视频地址输入框
        /// </summary>
        public InputField inputField;

        /// <summary>
        /// 加载视频
        /// </summary>
        public void LoadVideo()
        {
            videoPlayer.url = inputField.text;
            videoPlayer.Play();
        }
    }
}