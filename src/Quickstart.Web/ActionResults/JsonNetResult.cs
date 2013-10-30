using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Quickstart.Web.ActionResults
{
    public class JsonNetResult : ActionResult
    {
        private const string ContentType = "application/json";

        private readonly object data;
        private readonly Formatting formatting;
        private readonly JsonSerializerSettings serializerSettings;

        public JsonNetResult(object data)
        {
            this.data = data;
            formatting = Formatting.None;
            serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = ContentType;

            if (data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = formatting };
                JsonSerializer serializer = JsonSerializer.Create(serializerSettings);

                serializer.Serialize(writer, data);
                writer.Flush();
            }
        }

        public object Data
        {
            get { return data; }
        }
    }
}