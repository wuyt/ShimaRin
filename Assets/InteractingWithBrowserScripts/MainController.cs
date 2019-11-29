using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

namespace ShimaRin.InteractingWithBrowserScripts
{
    public class MainController : MonoBehaviour
    {
        /// <summary>
        /// 输入文本框
        /// </summary>
        public InputField inputField;
        /// <summary>
        /// 显示文本
        /// </summary>
        public Text text;

        /// <summary>
        /// 引入外部方法
        /// </summary>
        /// <param name="info">字符串参数</param>
        [DllImport("__Internal")]
        private static extern void GetFromUnity(string info);

        void Awake()
        {
            WebGLInput.captureAllKeyboardInput = false;
        }
        /// <summary>
        /// 发送信息到Html
        /// </summary>
        public void SendToHtml()
        {
            Debug.Log(inputField.text);
            GetFromUnity(inputField.text);
        }
        /// <summary>
        /// 从Html获取信息
        /// </summary>
        /// <param name="info">字符串参数</param>
        public void GetFromHtml(string info)
        {
            Debug.Log(info);
            text.text = info;
        }
        /// <summary>
        /// 当文本框被选中
        /// </summary>
        public void OnSelect()
        {
            WebGLInput.captureAllKeyboardInput = true;
        }
        /// <summary>
        /// 当文本框取消选中
        /// </summary>
        public void OnDeselect()
        {
            WebGLInput.captureAllKeyboardInput = false;
        }
    }
}

