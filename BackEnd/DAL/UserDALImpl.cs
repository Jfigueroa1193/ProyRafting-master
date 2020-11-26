using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Entities;

namespace BackEnd.DAL
{
  public class UserDALImpl : IUserDAL
    {
        private BDContext context;

        public bool eliminar(string Rol_ID, int Usuario_ID)
        {
            throw new NotImplementedException();
        }

        public string[] gerRolesForUser(string NombreUsuario)
        {
            string[] resultado;
            using (context = new BDContext())
            {
                resultado = context.sp_getRolesForUser(NombreUsuario).ToArray();
            }
            return resultado;
        }

        public Usuarios get(int Usuario_ID)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> getAll()
        {
            throw new NotImplementedException();
        }

        public Usuarios getUser(string NombreUsuario)
        {
            try
            {
                Usuarios resultado;
                using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
                {
                    Expression<Func<Usuarios, bool>> consulta = (u => u.NombreUsuario.Equals(NombreUsuario));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuarios getUser(string NombreUsuario, string Clave)
        {
            try
            {
                Usuarios resultado;
                using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
                {
                    Expression<Func<Usuarios, bool>> consulta = (u => u.NombreUsuario.Equals(NombreUsuario) && u.Clave.Equals(Clave));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuarios getUser(int Colaborador_ID)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> getUsuariosRole(string NombreRol)
        {
            List<Usuarios> result = new List<Usuarios>();
            List<string> lista;
            using (context = new BDContext())
            {
                lista = context.sp_getUsuariosRole(NombreRol).ToList();
                Usuarios user;
                foreach (var item in lista)
                {
                    user = this.getUser(item);
                    result.Add(user);
                }

            }
            return result;
        }

        public bool insertar(int Rol_ID, string login)
        {
            throw new NotImplementedException();
        }

        public bool insertar(string NombreRol, string login)
        {
            throw new NotImplementedException();
        }

        public bool isUserInRole(string NombreUsuario, string NombreRol)
        {
            bool result = false;
            using (context = new BDContext())
            {
                result = (bool)context.sp_isUserInRole(NombreUsuario, NombreRol).First();
            }

            return result;
        }

        public List<Roles> listarRoles()
        {
            throw new NotImplementedException();
        }

        public Usuarios ObtenerPorID(int Usuario_ID)
        {
            throw new NotImplementedException();
        }
    }
}
