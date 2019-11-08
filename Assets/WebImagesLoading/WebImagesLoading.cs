using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace ShimaRin
{
    /// <summary>
    /// 从网络加载图片并显示
    /// </summary>
    public class WebImagesLoading : MonoBehaviour
    {
        /// <summary>
        /// 3D平面
        /// </summary>
        public GameObject plane;
        /// <summary>
        /// UI图片
        /// </summary>
        public Image image;
        /// <summary>
        /// 输入框
        /// </summary>
        public InputField inputField;

        /// <summary>
        /// 显示图片
        /// </summary>
        public void DisplayImage()
        {
            StartCoroutine(LoadImage());
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadImage()
        {
            using (UnityWebRequest webRequest = new UnityWebRequest())
            {
                //设置URL
                webRequest.url = inputField.text;
                //设置访问方式
                webRequest.method = UnityWebRequest.kHttpVerbGET;
                //设置下载类型
                webRequest.downloadHandler = new DownloadHandlerTexture();

                //协程等待
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError || webRequest.isHttpError)
                {
                    Debug.Log(webRequest.error);
                }
                else
                {
                    //将图片加载到3D平面
                    plane.GetComponent<Renderer>().material.mainTexture = DownloadHandlerTexture.GetContent(webRequest);
                    //将图片加载到UI图片
                    Texture2D texture2D = DownloadHandlerTexture.GetContent(webRequest);
                    image.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                }
            }
        }
    }
}