using BibliotecaSCF.Catalogos;
using BibliotecaSCF.Clases;
using BibliotecaSCF.ClasesComplementarias;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Controladores
{
    public class ControladorGeneral
    {
        #region Proveedores

        public static void InsertarActualizarProveedor(int codigoProveedor, string razonSocial, string provincia, string localidad, string direccion, string telefono, string mail, string cuil)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Proveedor proveedor;

                if (codigoProveedor == 0)
                {
                    proveedor = new Proveedor();
                }
                else
                {
                    proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);
                }

                proveedor.RazonSocial = razonSocial;
                proveedor.Provincia = provincia;
                proveedor.Localidad = localidad;
                proveedor.Direccion = direccion;
                proveedor.Telefono = telefono;
                proveedor.Mail = mail;
                proveedor.Cuil = cuil;
                proveedor.IsInactivo = false;

                CatalogoProveedor.InsertarActualizar(proveedor, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosProveedores(bool isInactivos)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaProveedores = new DataTable();
                tablaProveedores.Columns.Add("codigoProveedor");
                tablaProveedores.Columns.Add("razonSocial");
                tablaProveedores.Columns.Add("provincia");
                tablaProveedores.Columns.Add("localidad");
                tablaProveedores.Columns.Add("direccion");
                tablaProveedores.Columns.Add("telefono");
                tablaProveedores.Columns.Add("mail");
                tablaProveedores.Columns.Add("cuil");

                List<Proveedor> listaProveedores = CatalogoProveedor.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaProveedores.Aggregate(tablaProveedores, (dt, r) => { dt.Rows.Add(r.Codigo, r.RazonSocial, r.Provincia, r.Localidad, r.Direccion, r.Telefono, r.Mail, r.Cuil); return dt; });

                return tablaProveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void ActivarInactivarProveedor(int codigoProveedor)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Proveedor proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);

                if (proveedor.IsInactivo)
                {
                    proveedor.IsInactivo = false;
                }
                else
                {
                    proveedor.IsInactivo = true;
                }

                CatalogoProveedor.InsertarActualizar(proveedor, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarProveedor(int codigoProveedor)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Proveedor proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);

                CatalogoProveedor.Eliminar(proveedor, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Usuarios

        public static void InsertarActualizarUsuario(int codigoUsuario, string nombreUsuario, string contraseña)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Usuario usuario;

                if (codigoUsuario == 0)
                {
                    usuario = new Usuario();
                }
                else
                {
                    usuario = CatalogoUsuario.RecuperarPorCodigo(codigoUsuario, nhSesion);
                }

                usuario.NombreUsuario = nombreUsuario;
                usuario.Contraseña = contraseña;

                CatalogoUsuario.InsertarActualizar(usuario, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarLogueoUsuario(string nombreUsuario, string contraseña)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario");
                tablaUsuario.Columns.Add("nombreUsuario");
                tablaUsuario.Columns.Add("contraseña");

                Usuario usuarioActual = CatalogoUsuario.RecuperarPorUsuarioYContraseña(nombreUsuario, contraseña, nhSesion);

                if (usuarioActual == null)
                {
                    tablaUsuario = null;
                }
                else
                {
                    tablaUsuario.Rows.Add(new object[] { usuarioActual.Codigo, usuarioActual.NombreUsuario, usuarioActual.Contraseña });
                }

                return tablaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosUsuarios()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuarios = new DataTable();
                tablaUsuarios.Columns.Add("codigoUsuario");
                tablaUsuarios.Columns.Add("nombreUsuario");
                tablaUsuarios.Columns.Add("contraseña");

                List<Usuario> listaUsuarios = CatalogoUsuario.RecuperarTodos(nhSesion);

                listaUsuarios.Aggregate(tablaUsuarios, (dt, r) => { dt.Rows.Add(r.Codigo, r.NombreUsuario, r.Contraseña); return dt; });

                return tablaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Cliente

        public static void InsertarActualizarCliente(int codigoUsuario, string razonSocial, string provincia, string localidad, string direccion, string telefono, string mail, string cuil)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cliente;

                if (codigoUsuario == 0)
                {
                    cliente = new Cliente();
                }
                else
                {
                    cliente = CatalogoCliente.RecuperarPorCodigo(codigoUsuario, nhSesion);
                }

                cliente.RazonSocial = razonSocial;
                cliente.Provincia = provincia;
                cliente.Localidad = localidad;
                cliente.Direccion = direccion;
                cliente.Telefono = telefono;
                cliente.Mail = mail;
                cliente.Cuil = cuil;
                cliente.IsInactivo = false;

                CatalogoCliente.InsertarActualizar(cliente, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodosClientes(bool isInactivos)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaClientes = new DataTable();
                tablaClientes.Columns.Add("codigoCliente");
                tablaClientes.Columns.Add("razonSocial");
                tablaClientes.Columns.Add("provincia");
                tablaClientes.Columns.Add("localidad");
                tablaClientes.Columns.Add("direccion");
                tablaClientes.Columns.Add("telefono");
                tablaClientes.Columns.Add("mail");
                tablaClientes.Columns.Add("cuil");

                List<Cliente> listaClientes = CatalogoCliente.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaClientes.Aggregate(tablaClientes, (dt, r) => { dt.Rows.Add(r.Codigo, r.RazonSocial, r.Provincia, r.Localidad, r.Direccion, r.Telefono, r.Mail, r.Cuil); return dt; });

                return tablaClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void ActivarInactivarCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                if (cliente.IsInactivo)
                {
                    cliente.IsInactivo = false;
                }
                else
                {
                    cliente.IsInactivo = true;
                }

                CatalogoCliente.InsertarActualizar(cliente, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Cliente cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                CatalogoCliente.Eliminar(cliente, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Articulo

        public static DataTable RecuperarTodosArticulos()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulos = new DataTable();
                tablaArticulos.Columns.Add("codigoArticulo");
                tablaArticulos.Columns.Add("descripcionCorta");
                tablaArticulos.Columns.Add("descripcionLarga");
                tablaArticulos.Columns.Add("marca");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarTodos(nhSesion);

                listaArticulos.Aggregate(tablaArticulos, (dt, r) => { dt.Rows.Add(r.Codigo, r.DescripcionCorta, r.DescripcionLarga, r.Marca); return dt; });

                return tablaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarArticulosProveedoresPorArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulosProveedores = new DataTable();
                tablaArticulosProveedores.Columns.Add("codigoArticuloProveedor");
                tablaArticulosProveedores.Columns.Add("codigoProveedor");
                tablaArticulosProveedores.Columns.Add("razonSocialProveedor");
                tablaArticulosProveedores.Columns.Add("codigoInterno");
                tablaArticulosProveedores.Columns.Add("precioActual");

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.ArticulosProveedor.Aggregate(tablaArticulosProveedores, (dt, r) => { dt.Rows.Add(r.Codigo, r.Proveedor.Codigo, r.Proveedor.RazonSocial, r.CodigoInterno, r.HistorialPrecio.Where(x => x.FechaHasta == null).Select(x => x.Precio).SingleOrDefault()); return dt; });

                return tablaArticulosProveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarHistorialPreciosPorArticuloProveedor(int codigoArticuloProveedor)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaHistorialPrecio = new DataTable();
                tablaHistorialPrecio.Columns.Add("codigoHistorialPrecio");
                tablaHistorialPrecio.Columns.Add("fechaDesde");
                tablaHistorialPrecio.Columns.Add("fechaHasta");
                tablaHistorialPrecio.Columns.Add("precio");

                ArticuloProveedor artProv = CatalogoArticuloProveedor.RecuperarPorCodigo(codigoArticuloProveedor, nhSesion);

                artProv.HistorialPrecio.Aggregate(tablaHistorialPrecio, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaDesde, r.FechaHasta, r.Precio); return dt; });

                return tablaHistorialPrecio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void InsertarActualizarArticulo(int codigoArticulo, string descripcionCorta, string descripcionLarga, string marca)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Articulo articulo;

                if (codigoArticulo == 0)
                {
                    articulo = new Articulo();
                }
                else
                {
                    articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);
                }

                articulo.DescripcionCorta = descripcionCorta;
                articulo.DescripcionLarga = descripcionLarga;
                articulo.Marca = marca;

                CatalogoArticulo.InsertarActualizar(articulo, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void InsertarActualizarArticuloProveedor(int codigoArticuloProveedor, int codigoArticulo, int codigoInterno, int codigoProveedor, double precio, bool isDolar)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction transaccion = nhSesion.BeginTransaction();

            try
            {
                Articulo articulo;
                articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                ArticuloProveedor articuloProveedor;

                if (codigoArticuloProveedor == 0)
                {
                    articuloProveedor = new ArticuloProveedor();
                    articulo.ArticulosProveedor.Add(articuloProveedor);
                }
                else
                {
                    articuloProveedor = (from ap in articulo.ArticulosProveedor where ap.Codigo == codigoArticuloProveedor select ap).SingleOrDefault();
                }

                articuloProveedor.CodigoInterno = codigoInterno;
                articuloProveedor.Proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);

                HistorialPrecio histPrecio = (from h in articuloProveedor.HistorialPrecio where h.FechaHasta == null select h).SingleOrDefault();

                if (histPrecio == null)
                {
                    histPrecio = new HistorialPrecio();
                    histPrecio.FechaDesde = DateTime.Now;
                    histPrecio.FechaHasta = null;
                    histPrecio.Precio = precio;
                    histPrecio.IsDolar = isDolar;

                    articuloProveedor.HistorialPrecio.Add(histPrecio);
                }
                else
                {
                    if (histPrecio.Precio != precio || histPrecio.IsDolar != isDolar)
                    {
                        histPrecio.FechaHasta = DateTime.Now.AddSeconds(-1);

                        HistorialPrecio histPrecioNuevo = new HistorialPrecio();
                        histPrecioNuevo.FechaDesde = DateTime.Now;
                        histPrecioNuevo.FechaHasta = null;
                        histPrecioNuevo.Precio = precio;
                        histPrecio.IsDolar = isDolar;

                        articuloProveedor.HistorialPrecio.Add(histPrecioNuevo);
                    }
                }

                CatalogoArticulo.InsertarActualizar(articulo, nhSesion);
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                CatalogoArticulo.Eliminar(articulo, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion
    }
}
