using Logica.Favoritos;
using Logica.Favoritos.DTOs;
using Logica.Favoritos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    [Authorize]

    public class PlacesController : Controller
    {
        private readonly IFavoritosService _favoritosService;
        private readonly IFoursquarePlacesService _foursquarePlacesService;

        public PlacesController(IFoursquarePlacesService foursquarePlacesService, IFavoritosService favoritosService)
        {
            _favoritosService = favoritosService;
            _foursquarePlacesService = foursquarePlacesService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetPlaces([FromBody] FiltrosModel filtros)
        {
            var response = await _foursquarePlacesService.Buscar(filtros);

            return Ok(response);
        }
        public async Task<IActionResult> GetPlaceDetails(string placeId)
        {
            var response = await _foursquarePlacesService.GetDetails(placeId);

            return Ok(response);
        }

        public async Task<IActionResult> GetPlacePhoto(string placeId)
        {

            var response = await _foursquarePlacesService.GetPhotos(placeId);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateMarker(MarkersDTO marker)
        {
            try
            {
                var markerSaved = _favoritosService.Create(marker);

                return Json(markerSaved);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult GetMarkers()
        {

            var consulta = _favoritosService.Listar();

            return Json(consulta);
        }


        [HttpDelete]
        public ActionResult Delete(int markerId)
        {
            try
            {
                _favoritosService.Delete(markerId);
                return Ok("Se ha elimnado el marcador.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

}
