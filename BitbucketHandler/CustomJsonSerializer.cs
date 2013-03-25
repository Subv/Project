using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Serializers;
using RestSharp;

namespace BitbucketHandler
{
    class CustomJsonSerializer : ISerializer
    {
        public CustomJsonSerializer()
        {
            ContentType = "application/json.";
            Namespace = "";
            RootElement = null;
            DateFormat = "";
        }

        public string Serialize(object obj)
        {
            return SimpleJson.SerializeObject(obj);
        }

        /// <summary>
        /// Name of the root element to use when serializing
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// XML namespace to use when serializing
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Format string to use when serializing dates
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }
    }
}
