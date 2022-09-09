namespace EmqxHookASPNET.Model
{
    /// <summary>
    /// 客户端授权请求
    /// </summary>
    public class ClientAuthorizeRequest
    {
        /// <summary>
        /// 链接客户端Id
        /// </summary>
        public string Clientid { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 授权的Topic
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 正在被授权的 Action
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 客户端使用的协议的名称，如MQTT、CoAP等
        /// </summary>
        public string Protoname { get; set; }
    }
}
