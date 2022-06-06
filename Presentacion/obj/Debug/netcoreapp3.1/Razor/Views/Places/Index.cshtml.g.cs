#pragma checksum "D:\Github\Pruebas\FoursquarePlaces\Presentacion\Presentacion\Views\Places\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8385737bad99cdb927225660b1e0df7e2294a3a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Places_Index), @"mvc.1.0.view", @"/Views/Places/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Github\Pruebas\FoursquarePlaces\Presentacion\Presentacion\Views\_ViewImports.cshtml"
using Presentacion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github\Pruebas\FoursquarePlaces\Presentacion\Presentacion\Views\_ViewImports.cshtml"
using Presentacion.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8385737bad99cdb927225660b1e0df7e2294a3a0", @"/Views/Places/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccf57c469e1b8e05140e56e7f20f29b558100cc2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Places_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frm-buscar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Github\Pruebas\FoursquarePlaces\Presentacion\Presentacion\Views\Places\Index.cshtml"
  
    ViewData["Title"] = "Places";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <!-- Sidebar  -->\r\n\r\n    <div class=\"col-3 bg-light     \" id=\"barralateral\">\r\n        <h3>Buscar lugares</h3>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8385737bad99cdb927225660b1e0df7e2294a3a04011", async() => {
                WriteLiteral(@"
            <div class=""input-group mb-3"">
                <input id=""inp-buscar"" type=""text"" class=""form-control"" placeholder=""Buscar..."" aria-describedby=""btn-buscar"">
                <button id=""btn-buscar"" class=""btn btn-outline-secondary"" type=""submit"">Buscar</button>
            </div>

        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

        <div class=""card mt-4"">
            <div class=""card-body"" id=""div-detalleMarker"">  </div>
        </div>

    </div>

    <div class=""col-9"">

        <h1>Mi Mapa</h1>
        <div class=""d-flex  justify-content-end"">
            <button type=""submit"" id=""btn-buscar"" class=""btn btn-secondary btn-sm"" onclick=""verFavoritos()"">Favoritos</button>
            <button type=""submit"" id=""btn-buscar"" class=""btn btn-secondary btn-sm ml-2"" onclick=""centerMap()"">Mi ubicación</button>
        </div>


        <section id=""map"" class=""mt-1""></section>


        <div style=""display:none"" id=""imagesContainer"" class=""alert alert-light alert-dismissible p-1 pt-2"">
            <button type=""button"" class=""btn-close"" onclick=""$('#imagesContainer').hide()""></button>
            <h4>Imagenes</h4>


            <div id=""demo"" class=""carousel slide mt-3"" data-bs-ride=""carousel"">

                <div id=""carrucel"" class=""carousel-inner""></div>

                <!-- Left and right controls/icon");
            WriteLiteral(@"s -->
                <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#demo"" data-bs-slide=""prev"">
                    <span class=""carousel-control-prev-icon""></span>
                </button>
                <button class=""carousel-control-next"" type=""button"" data-bs-target=""#demo"" data-bs-slide=""next"">
                    <span class=""carousel-control-next-icon""></span>
                </button>
            </div>
        </div>



    </div>



</div>

");
#nullable restore
#line 65 "D:\Github\Pruebas\FoursquarePlaces\Presentacion\Presentacion\Views\Places\Index.cshtml"
  
    Html.RenderPartial("_Markers");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script>
        var map;
        const infoWindow = new google.maps.InfoWindow();
        var markersArray = [];
        var currentLocations = [];


        $(document ).ready(function() {

                initialize()
                centerMap();


                   $(""#frm-buscar"").submit( function (e) {
                       e.preventDefault();

                       let buscar= $(""#inp-buscar"").val();

                       if (buscar){
                           removeMarkers();
                           currentLocations=[];
                           searchPlaces(buscar);
                       }


                   });

    });

     function  searchPlaces(buscar){
         
         let htmlResult=  `<h5 class=""card-title"">Resultados de busqueda</h5>`;
         $(""#btn-buscar"").html('<span class=""spinner-border spinner-border-sm mr-2"" role=""status"" aria-hidden=""true""></span>').prop('disabled', true);  

        getLocations(buscar)
        .then((location");
            WriteLiteral(@"s) => {


            if(locations.length == 0 )
                throw 'No se encontraron sugerencias.'    

            for(item of locations){

                let location = {
                    lat: item.geocodes.main.latitude,
                    lng: item.geocodes.main.longitude,
                }
                addMarker(item.fsq_id,location,item.name)
            }
            currentLocations=locations;
            htmlResult   +=`<label> Se ha encontrado ${locations.length} ${locations.length == 1 ? 'sugerencia' : 'sugerencias'}.  </label>`;

        }).catch((err) => {
            console.error(err);
            htmlResult   +=`<label> ${err} </label>`;
        }).finally(() => {
            $(""#div-detalleMarker"").html(htmlResult);
            $(""#btn-buscar"").html('Buscar').prop('disabled', false);
        });

    }

    function buidlCarrucelItems(images){

        let html =""""
        let imageCards=[]
        let buildCard = (item) => ` <div class=""col-md-4""> ");
            WriteLiteral(@" <div class=""card mb-2"">  <img class=""card-img-top markerImage"" src=""${item.prefix}original${item.suffix}"" alt=""Card image cap"" height=""170px"">  </div>  </div>`

       for (var i = 0; i < images.length; i++) {

            html +=
                    `<div class=""carousel-item ${i== 0 ? 'active' : '' }"">
                                    <div class=""row"">
                                       ${buildCard(images[i])}
                                       ${i+1<images.length? buildCard(images[i+1]) : ''}
                                       ${i+2<images.length? buildCard(images[i+2]) : ''}
                                        </div>
                                    </div>
                                </div>`;

                                i++; i++;
        }

        return html;
    }


    function centerMap(){

         navigator.geolocation.getCurrentPosition((data)=>{

             let currentPosition = {
                               lat: data.coords.latitude,");
            WriteLiteral(@"
                               lng: data.coords.longitude
                           }

                           map.setZoom(14);
                           infoWindow.setPosition(currentPosition);
                           infoWindow.setContent(""Te encuentraas aquí."");
                           infoWindow.open(map);
                           map.setCenter(currentPosition);
         })

    }

     function moveToLocation(location){
         var center = new google.maps.LatLng(location.lat, location.lng);

         map.panTo(center);

      }

      function addMarker(id,location, info) {
        let marker =  new google.maps.Marker({
                    position: location,
                    map,
                    title:info,
                  });

       marker.addListener(""click"", () => {
          infoWindow.close();
          infoWindow.setContent(marker.getTitle());
          infoWindow.open(marker.getMap(), marker);
          seleccionarMarker(id)
        });

            WriteLiteral(@"
      markersArray.push(marker)

    }

      function initialize() {
          const mapOptions = {
            center: new google.maps.LatLng(0, 0),
            zoom: 2,
            mapTypeId: google.maps.MapTypeId.ROADMAP
          };

      map = new google.maps.Map(document.getElementById(""map""), mapOptions);
    }

    function removeMarkers() {

        for (i in markersArray) {
          markersArray[i].setMap(null);
        }

        markersArray= [];

    }


      function seleccionarMarker(placeId){

          console.log(placeId)

          mostrarDetalle(placeId);
          mostrarFotos(placeId);

      }

      function mostrarFotos(placeId){

            $(""#imagesContainer"").show();
            $(""#carrucel"").html('Buscando fotos...');

            getLocationPhotos(placeId)
            .then((fotos) => {

                if(fotos.length == 0)
                    throw 'Sin resultados'

                let carrucel=  buidlCarrucelItems(fotos);
 ");
            WriteLiteral(@"               $(""#carrucel"").html(carrucel);

            }).catch((err) => {
                console.log(err)
                $(""#carrucel"").html('Sin resultados de fotos...');
            })

      }

      function mostrarDetalle(placeId){

            $(""#div-detalleMarker"").html('Buscando detalle...');

            let currLocation=currentLocations.find(x => x.fsq_id == placeId)
            console.log('currr',currLocation)
            getLocationDetails(placeId)
            .then((detalle) => {
                    console.log(detalle)

                if(detalle.length == 0)
                    throw 'Sin resultados'


                let htmlDetalle=  `<h4 class=""card-title"">${currLocation.name}</h4>
                <label> <strong> Disatancia:</strong> ${currLocation.distance} metros</label><br />
                <label> <strong> Zona horaria:</strong>  ${detalle.timezone} </label><br />
                <label> <strong>  Dirección:</strong> ${currLocation.location.formatted_");
            WriteLiteral(@"address}, ${currLocation.location.country} </label>
               <div id=""div-saveMarker""><a href=""#"" class=""link-secondary float-end"" onclick=""saveFavorito_click('${currLocation.fsq_id}')"">  Guardar en favoritos</a></div>`;
               
                $(""#div-detalleMarker"").html(htmlDetalle);

            }).catch((err) => {
                console.log(err)
                $(""#div-detalleMarker"").html('Sin resultados de ésta ubicación...');
            })

      }

</script>


<script>
          var getLocations = (busqueda)=> new Promise(function (resolve, reject) {
          let centerMap= map.getCenter().toJSON();
              var filtros = {
                    ""buscar"":busqueda,
                    ""radio"":3000,
                    ""ubicacion"":{
                        ""Latitud"":centerMap.lat+'',
                        ""Longitud"":centerMap.lng+''
                        }
                };


            fetch('/Places/GetPlaces', {
              method: 'POST',
  ");
            WriteLiteral(@"            body: JSON.stringify(filtros),
              headers:{
                'Content-Type': 'application/json'
              }
            }).then(res => res.json())
            .catch(error => reject(error))
            .then(response => resolve(response.results));

      });

      function getLocationDetails  (placeId){

            return new Promise((resolve, reject) => {

                   $.ajax({
                        url:'/Places/GetPlaceDetails',
                        type: ""GET"",
                        data: {placeId},
                        success: function (data) {
                           try {     
                               resolve(JSON.parse(data)); 
                           }
                           catch (err) {
                               console.log(err); 
                               reject('Ocurrio un error al obtener el detalle');
                           } 
                        },
                        error: function (e");
            WriteLiteral(@"rr) {
                            reject(err);
                        }
                    });
              });
      }
      const getLocationPhotos = (placeId)=> new Promise(function (resolve, reject) {

           $.ajax({
                url:'/Places/GetPlacePhoto',
                type: ""GET"",
                data: {placeId},
                success: function (data) {
                    try {              
                        resolve(JSON.parse(data));               
                    }
                    catch (err) {
                        console.log(err); 
                        reject('Ocurrio un error al obtener las imagenes');
                    }               
                }
            }).fail(function (err) {
                console.log(err)
                reject('Ocurrio un error al obtener las imagenes');
            });

      });

</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591