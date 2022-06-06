//using Datos;
//using Entidades.EntityModels;
//using Entidades.ViewModels.Permisos;
//using Microsoft.Extensions.Caching.Memory;
//using System.Collections.Generic;
//using System.Linq;

//namespace Logica
//{
//    public class PermisosService : IPermisosCacheService
//    {
//        private readonly IMemoryCache _cache;
//        public PermisosService(IMemoryCache cache)
//        {
//            _cache = cache;
//        }


//        public UserPermissionsModel ObtenerPermisos(string userName)
//        {
//            UserPermissionsModel permiso = new UserPermissionsModel();
//            string keyCache = GetKeyByUserName(userName);

//            if (!_cache.TryGetValue(keyCache, out permiso))
//            {
//                permiso = GetUserPermissionFromDatabase(userName);
//                _cache.Set(keyCache, permiso);
//            }

//            return permiso;
//        }
//        public IEnumerable<PrmModulosEModel> ObtenerModulos(string userName)
//        {
//            var todosLosModulos = GetAllModules();
//            var modulosConPermisoIds = ObtenerPermisos(userName).permisosList.Select(permiso => permiso.IdModulo).Distinct();
//            var modulosConPermiso = todosLosModulos.Where(modulo => modulosConPermisoIds.Contains(modulo.Id));

//            return IncludeParensToModules(modulosConPermiso);
//        }
//        public void ActualizarCache(string userName)
//        {
//            RemoveCachePerms(userName);
//        }


//        private void RemoveCachePerms(string userName)
//        {
//            _cache.Remove(GetKeyByUserName(userName));
//        }
//        private IEnumerable<PrmModulosEModel> IncludeParensToModules(IEnumerable<PrmModulosEModel> modulosConPermiso)
//        {
//            return GetAllModules()
//                .Where(modulo => modulosConPermiso.Any(child => modulo.Id == child.Id || modulo.Id == child.ModuloPadreId));
//        }
//        private IEnumerable<PrmModulosEModel> GetAllModules()
//        {
//            List<PrmModulosEModel> _allModules = new List<PrmModulosEModel>();
//            if (!_cache.TryGetValue("modulos", out _allModules))
//            {
//                using (var context = new ApplicationDbContext())
//                    _allModules = new UnitOfWork(context).ModulosRepository
//                                            .Get(x => x.Activo && x.Version.Contains("Basic"))
//                                            .Select(x => {

//                                                // x.ModuloPadre = null;
//                                                x.ModulosHijos.Clear();

//                                                return x;
//                                            })
//                                            .ToList();


//                _cache.Set("modulos", _allModules);
//            }

//            return _allModules;
//        }
//        private UserPermissionsModel GetUserPermissionFromDatabase(string userName)
//        {

//            using (ApplicationDbContext dbContext = new ApplicationDbContext())
//            {
//                IUnitOfWork unitOfWork = new UnitOfWork(dbContext);

//                var user = userName == "superx" ?
//                      AccountService.GetSuperX(userName)
//                      : unitOfWork.UsuariosRepository.GetFirst(x => x.UserName == userName);

//                var permisosList = userName == "superx" ?
//                  unitOfWork.PermisosRepository.All().ToList()
//                  : unitOfWork.PermisosRepository.ByUser(user.Id).ToList();



//                return new UserPermissionsModel
//                {
//                    UserId = user.Id,
//                    UserName = user.UserName,
//                    Email = user.Email,
//                    CellPhone = user.CellPhone,
//                    LastName = user.LastName,
//                    permisosList = permisosList
//                };
//            }

//        }
//        private string GetKeyByUserName(string userName) => $"prm_{userName}";

//    }

//}
