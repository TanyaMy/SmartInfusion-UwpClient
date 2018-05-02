using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using SmartInfusion_UwpClient.Business.Services;

namespace SmartInfusion_UwpClient.Data.Api.Rest
{
    public class PostFormUrlEncodedRequestBuilder
    {
        private readonly UrlRequestBuilder _requestBuilder;
        private readonly IList<KeyValuePair<string, string>> _params;
        private readonly IPreferencesService _preferencesService;

        public PostFormUrlEncodedRequestBuilder(UrlRequestBuilder requestBuilder)
        {
            _requestBuilder = requestBuilder;
            _params = new List<KeyValuePair<string, string>>();
            _preferencesService = App.Container.Resolve<IPreferencesService>();
        }

        public PostFormUrlEncodedRequestBuilder Param(string key, string value)
        {
            _params.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public Task<TResult> PostAsync<TResult>()
        {
            Request request = _requestBuilder.CreateRequest();
            return request.PostFormUrlEncoded<TResult>(_params);
        }
    }
}
