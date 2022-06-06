using Base_Comun;
using Entidades.EntityModels;
using FAB_Datos.Entidades;
using FAB_Datos.ViewModels.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAB_Datos
{
    public class LogLogica
    {
        private readonly UsuariosEModel _userLogued;
        private LogEModel Logg { get; set; }
        public LogLogica(UsuariosEModel userLogued)
        {
            _userLogued = userLogued;
            Logg = new LogEModel();
        }

        public LogEModel SetOldRegister<T>(T entityOld)
        {
            var entityCreated = MetodosExtension.JsonSerialize(entityOld);
            this.Logg.FilaOriginal = entityCreated;
            return this.Logg;
        }
        public void LogCreacion<T>(T entityNew, int idRow)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var TableName = dbContext.Model.GetEntityTypes().First(t => t.ClrType == typeof(T)).GetAnnotation("Relational:TableName").Value.ToString();
                    var CreatedJson = MetodosExtension.JsonSerialize(entityNew);

                    this.Logg.Tabla = TableName;
                    this.Logg.IdTabla = idRow;
                    this.Logg.FilaOriginal = null;
                    this.Logg.FilaActualizada = CreatedJson;
                    this.Logg.Fecha = DateTime.Now;
                    this.Logg.IdUsuario = _userLogued.Id;
                    this.Logg.Tipo = "Creacion";

                    dbContext.Log.Add(this.Logg);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
            }
        }
        public void LogAtualizacion<T>(T entityUpdate, int idRow)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var TableName = dbContext.Model.GetEntityTypes().First(t => t.ClrType == typeof(T)).GetAnnotation("Relational:TableName").Value.ToString();
                    var UpdateJson = MetodosExtension.JsonSerialize(entityUpdate);

                    this.Logg.Tabla = TableName;
                    this.Logg.IdTabla = idRow;
                    this.Logg.FilaActualizada = UpdateJson;
                    this.Logg.Fecha = DateTime.Now;
                    this.Logg.IdUsuario = _userLogued.Id;
                    this.Logg.Tipo = "Actualizacion";

                    dbContext.Log.Add(this.Logg);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
            }
        }

        public void LogEliminacion<T>(T entityDelete, int idRow)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var TableName = dbContext.Model.GetEntityTypes().First(t => t.ClrType == typeof(T)).GetAnnotation("Relational:TableName").Value.ToString();
                    var deleteJson = MetodosExtension.JsonSerialize(entityDelete);

                    this.Logg.Tabla = TableName;
                    this.Logg.IdTabla = idRow;
                    this.Logg.FilaOriginal = deleteJson;
                    this.Logg.FilaActualizada = null;
                    this.Logg.Fecha = DateTime.Now;
                    this.Logg.IdUsuario = _userLogued.Id;
                    this.Logg.Tipo = "Eliminacion";

                    dbContext.Log.Add(this.Logg);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
            }
        }
        public List<LogViewModel> TraerRegistros(String tabla)
        {
            List<LogViewModel> list = new List<LogViewModel>();

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {

                var query = from log in dbContext.Log.Include("UsuarioEModel")
                            //join pl in dbContext.EPlaneacion on log.IdTabla equals pl.Id
                            where log.Tabla == tabla
                            select new { log }; // ,pl.Lote


                foreach (var x in query)
                {
                    list.Add(new LogViewModel
                    {
                        Id = x.log.Id,
                        IdUsuario = x.log.IdUsuario,
                        Usuario = String.Format("{0}", x.log.EUsuarios.Nombre),
                        Tabla = tableName(x.log.Tabla),
                        Fecha = x.log.Fecha,
                        IdTabla = x.log.IdTabla,
                        Tipo = x.log.Tipo,
                        //Lote = x.Lote,
                    });

                }

            }
            return list;
        }
        String tableName(String name)
        {
            switch (name)
            {
                case "pl_Planeacion":
                    name = "Planeación";
                    break;
                case "pl_Almacen":
                    name = "Almacen";
                    break;
                case "pl_Produccion":
                    name = "Producción";
                    break;
                case "pl_CCalidad":
                    name = "Control Calidad";
                    break;
                case "pl_QA":
                    name = "Aseguramiento Calidad";
                    break;
            }
            return name;
        }

        public LogViewModel LogById(int id)
        {
            LogViewModel model = null;

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var x = dbContext.Log.Include("UsuarioEModel").FirstOrDefault(xx => xx.Id == id);

                if (x != null)
                {
                    model = new LogViewModel();
                    model.Id = x.Id;
                    model.IdUsuario = x.IdUsuario;
                    model.Usuario = String.Format("{0}", x.EUsuarios.Nombre);
                    model.Fecha = x.Fecha;
                    model.Tabla = x.Tabla;
                    model.IdTabla = x.IdTabla;
                    model.FilaOriginal = x.FilaOriginal;
                    model.FilaActualizada = x.FilaActualizada;
                    model.Tipo = x.Tipo;
                }


            }
            return model;
        }

        //public void LogCreacion<T>(T entity, int idTabla)
        //{
        //    try
        //    {
        //        using (ApplicationDbContext dbContext = new ApplicationDbContext())
        //        {

        //            var TableName = dbContext.Model.GetEntityTypes().First(t => t.ClrType == typeof(T)).GetAnnotation("Relational:TableName").Value.ToString();
        //            var entityCreated = MetodosExtension.JsonSerialize(entity);

        //            LogEModel entityLog = new LogEModel();
        //            entityLog.Tabla = TableName;
        //            entityLog.IdTabla = idTabla;
        //            entityLog.FilaActualizada = entityCreated;
        //            entityLog.Fecha = DateTime.Now;
        //            entityLog.IdUsuario = _userLogued.Id;
        //            entityLog.Tipo = "Creacion";

        //            dbContext.LogEModel.Add(entityLog);
        //            dbContext.SaveChanges();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //    }
        //}
        //public void LogCreacion<T>(T entityOld, T entity, int idTabla)
        //{
        //    try
        //    {
        //        using (ApplicationDbContext dbContext = new ApplicationDbContext())
        //        {

        //            var TableName = dbContext.Model.GetEntityTypes().First(t => t.ClrType == typeof(T)).GetAnnotation("Relational:TableName").Value.ToString();
        //            var original = MetodosExtension.JsonSerialize(entityOld);
        //            var editado = MetodosExtension.JsonSerialize(entity);

        //            LogEModel entityLog = new LogEModel();
        //            entityLog.Tabla = TableName;
        //            entityLog.IdTabla = idTabla;
        //            entityLog.FilaOriginal = original;
        //            entityLog.FilaActualizada = editado;
        //            entityLog.Fecha = DateTime.Now;
        //            entityLog.IdUsuario = _userLogued.Id;
        //            entityLog.Tipo = "Modificacion";

        //            dbContext.LogEModel.Add(entityLog);
        //            dbContext.SaveChanges();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //    }
        //}

        //public void RegistrarLog(String tabla, int idTabla, String old, String update)
        //{
        //    try
        //    {
        //        using (ApplicationDbContext dbContext = new ApplicationDbContext())
        //        {
        //            LogEModel entity = new LogEModel();

        //            entity.Tabla = tabla;
        //            entity.IdTabla = idTabla;
        //            entity.FilaOriginal = old;
        //            entity.FilaActualizada = update;
        //            entity.Fecha = DateTime.Now;
        //            entity.IdUsuario = _userLogued.Id;
        //            entity.Tipo = "Modificacion";
        //            dbContext.LogEModel.Add(entity);

        //            dbContext.SaveChanges();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //    }
        //}


        ///////////////////*////////////


    }

}
