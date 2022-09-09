using System.Text.Json.Serialization;

namespace EmqxHookASPNET.Model
{
    public class AuthorizeResponse
    {
        /// <summary>
        /// "allow" | "deny" | "ignore", // Default `"ignore"`
        /// allow: Allow Publish or Subscribe.
        /// deny: Deny Publish or Subscribe.
        /// ignore: Ignore this request, it will be handed over to the next authorizer.
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; } = "ingore";
    }
}
