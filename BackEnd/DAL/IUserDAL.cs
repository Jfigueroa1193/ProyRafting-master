using System;
using BackEnd.Entities;
using System.Collections.Generic;


namespace BackEnd.DAL
{
    interface IUserDAL
    {
        bool insertar(int Rol_ID, string login);
        bool insertar(string NombreRol, string login);
        Usuarios getUser(string NombreUsuario);
        Usuarios getUser(string NombreUsuario, string Clave);
        Usuarios getUser(int Colaborador_ID);
        Usuarios get(int Usuario_ID);
        List<Usuarios> getAll();
        bool isUserInRole(string NombreUsuario, string NombreRol);
        string[] gerRolesForUser(string NombreUsuario);
        List<Usuarios> getUsuariosRole(string NombreRol);
        List<Roles> listarRoles();
        bool eliminar(string Rol_ID, int Usuario_ID);
        Usuarios ObtenerPorID(int Usuario_ID);
    }
}
