using Newtonsoft.Json;
using System;

namespace SecretSantaTest.Shared
{
    public class FriendPresent
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secretFriend")]
        public string SecretFriend { get; set; }

        [JsonProperty("pin")]
        public string PIN { get; set; }
    }
}
