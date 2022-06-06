using Datos;
using Entidades.EntityModels;
using Entidades.ViewModels;
using Logica.Favoritos.DTOs;
using Logica.Services;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Favoritos
{
    public class FavoritosService : IFavoritosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserLoggedService _userLoggedService;

        public FavoritosService(IUnitOfWork unitOfWork, IUserLoggedService userService)
        {
            _unitOfWork = unitOfWork;
            _userLoggedService = userService;
        }
        public MarkersDTO Create(MarkersDTO model)
        {

            var favoritoEntity = _unitOfWork.FavoritosRepository.GetFirst(x => x.Fsq_id == model.Fsq_id && x.Usuario == _userLoggedService.GetUserName());

            if (favoritoEntity != null)
                return GetById(favoritoEntity.Id);

            favoritoEntity = DtoToEmodel(model);

            _unitOfWork.FavoritosRepository.Add(favoritoEntity);
            _unitOfWork.SaveChanges();

            return GetById(favoritoEntity.Id);
        }

        public void Delete(int id)
        {
            var favoritoEntity = _unitOfWork.FavoritosRepository.GetById(id);

            if (favoritoEntity != null)
                _unitOfWork.FavoritosRepository.Remove(favoritoEntity);

            _unitOfWork.SaveChanges();

        }


        public IEnumerable<MarkersDTO> Listar()
        {
            var query = _unitOfWork.FavoritosRepository.Get(x => x.Usuario == _userLoggedService.GetUserName());


            return query.Select(x => EModelToDto(x)).OrderByDescending(x => x.FechaCreacion);
        }


        public MarkersDTO GetById(int id)
        {
            var first = _unitOfWork.FavoritosRepository.Get(x => x.Id == id)
                           .Select(x => EModelToDto(x))
                           .FirstOrDefault();

            return first;
        }


        FavoritosEModel DtoToEmodel(MarkersDTO model)
        {
            var ranking = _unitOfWork.FavoritosRepository.Get(x => x.Fsq_id == model.Fsq_id).Count();


            return new FavoritosEModel
            {
                Fsq_id = model.Fsq_id,
                Nombre = model.Nombre,
                Direccion = model.Direccion,
                Ranking = ranking + 1,
                Imagen = model.Imagen,
                Usuario = _userLoggedService.GetUserName(),
                Categoria = model.Categoria,
                FechaCreacion = System.DateTime.Now,
            };
        }
        public MarkersDTO EModelToDto(FavoritosEModel entity)
        {

            return new MarkersDTO
            {
                Id = entity.Id,
                Fsq_id = entity.Fsq_id,
                Nombre = entity.Nombre,
                Direccion = entity.Direccion,
                Ranking = entity.Ranking,
                Imagen = entity.Imagen,
                Usuario = entity.Usuario,
                Categoria = entity.Categoria,
                FechaCreacion = entity.FechaCreacion,
            };


        }

    }

}
