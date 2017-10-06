using Newtonsoft.Json;
using System;

namespace InstagramWrapper.DataModel
{
    [JsonObject("relationship")]
    public class Relationship
    {
        [JsonProperty("outgoing_status")]
        public string OutgoingStatus { get; set; }
        [JsonProperty("incoming_status")]
        public string IncomingStatus { get; set; }

        public RelationshipOutgoingStatus? RelationshipOutgoingStatus
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(OutgoingStatus))
                    return (RelationshipOutgoingStatus)Enum.Parse(typeof(RelationshipOutgoingStatus), this.OutgoingStatus, true);
                else
                    return null;
            }
        }
        public RelationshipIncomingStatus? RelationshipIncomingStatus
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(IncomingStatus))
                    return (RelationshipIncomingStatus)Enum.Parse(typeof(RelationshipIncomingStatus), this.IncomingStatus, true);
                else
                    return null;
            }
        }
    }
}
