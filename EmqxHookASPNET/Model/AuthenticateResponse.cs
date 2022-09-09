using System.Text.Json.Serialization;

namespace EmqxHookASPNET.Model
{
    /// <summary>
    /// HTTP 身份验证器响应
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// "allow" | "deny" | "ignore", // Default `"ignore"`
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; } = "ingore";

        [JsonPropertyName("is_superuser")]
        public bool IsSuperuser { get; set; } = false;
    }
}
