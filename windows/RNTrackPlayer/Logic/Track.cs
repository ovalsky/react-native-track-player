using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackPlayer.Logic
{
    public class Track
    {
        public string Id { get; set; }
        public Uri Url { get; set; }
        public string Type { get; set; }
        public double Duration { get; set; }

        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public Uri Artwork { get; set; }

        public Track(JObject data)
        {
            Id = (string)data.GetValue("id");
            Url = Utils.GetUri(data, "url", null);
            Type = Utils.GetValue<string>(data, "type", TrackType.Default);
            Duration = Utils.GetValue<double>(data, "duration", 0);

            Title = Utils.GetValue<string>(data, "title", null);
            Artist = Utils.GetValue<string>(data, "artist", null);
            Album = Utils.GetValue<string>(data, "album", null);
            Artwork = Utils.GetUri(data, "artwork", null);
        }

        public JObject ToObject()
        {
            return JObject.FromObject(this);
        }
    }

    public static class TrackType
    {
        public const string Default = "default";
        public const string Dash = "dash";
        public const string Hls = "hls";
        public const string SmoothStreaming = "smoothstreaming";
    }
}
