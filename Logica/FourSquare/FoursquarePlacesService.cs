using Entidades.ViewModels;
using Logica.Favoritos.Models;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Threading.Tasks;

namespace Logica.Favoritos
{
    public class FoursquarePlacesService : IFoursquarePlacesService
    {
        private readonly FoursquareModel _optionsFoursquare;
        public FoursquarePlacesService(IOptions<FoursquareModel> optionsFoursquare)
        {
            _optionsFoursquare = optionsFoursquare.Value;

        }
        public async Task<string> Buscar(FiltrosModel filtros)
        {

            var client = new RestClient($"{_optionsFoursquare.Endpoint}/search");
            var request = BuildRequiest();

            request.AddParameter("query", filtros.Buscar);
            request.AddParameter("ll", $"{filtros.Ubicacion.Latitud},{filtros.Ubicacion.Longitud}");
            request.AddParameter("radius", filtros.Radio);

            var response = await client.ExecuteGetAsync(request);

            return response.Content;
        }

        public async Task<string> GetDetails(string placeId)
        {
            var client = new RestClient($"{_optionsFoursquare.Endpoint}/{placeId}");
            var request = BuildRequiest();
            var response = await client.ExecuteGetAsync(request);

            return response.Content;
        }

        public async Task<string> GetPhotos(string placeId)
        {
            var client = new RestClient($"{_optionsFoursquare.Endpoint}/{placeId}/photos");
            var request = BuildRequiest();
            var response = await client.ExecuteGetAsync(request);

            return response.Content;
        }

        RestRequest BuildRequiest()
        {
            var request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", _optionsFoursquare.Key);

            return request;
        }
    }
}
