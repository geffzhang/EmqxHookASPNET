namespace EmqxHookASPNET.Model
{
    public class ClientAuthenticateRequest
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
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
