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

        public static void InsertarActualizarProveedor(int codigoProveedor, string razonSocial, string provincia, string localidad, string direccion, string telefono, string mail, string cuil, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones)
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
                proveedor.PersonaContacto = personaContacto;
                proveedor.NumeroCuenta = numeroCuenta;
                proveedor.Banco = banco;
                proveedor.Cbu = cbu;
                proveedor.Observaciones = observaciones;
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
                tablaProveedores.Columns.Add("personaContacto");
                tablaProveedores.Columns.Add("numeroCuenta");
                tablaProveedores.Columns.Add("banco");
                tablaProveedores.Columns.Add("cbu");
                tablaProveedores.Columns.Add("observaciones");

                List<Proveedor> listaProveedores = CatalogoProveedor.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaProveedores.Aggregate(tablaProveedores, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.RazonSocial, r.Provincia, r.Localidad, r.Direccion, r.Telefono, r.Mail, r.Cuil,
                        r.PersonaContacto, r.NumeroCuenta, r.Banco, r.Cbu, r.Observaciones); return dt;
                });

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

        public static void InsertarActualizarCliente(int codigoUsuario, string razonSocial, string provincia, string localidad, string direccion, string telefono, string mail, string cuil, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones)
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
                cliente.PersonaContacto = personaContacto;
                cliente.NumeroCuenta = numeroCuenta;
                cliente.Banco = banco;
                cliente.Cbu = cbu;
                cliente.Observaciones = observaciones;
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
                tablaClientes.Columns.Add("personaContacto");
                tablaClientes.Columns.Add("numeroCuenta");
                tablaClientes.Columns.Add("banco");
                tablaClientes.Columns.Add("cbu");
                tablaClientes.Columns.Add("observaciones");

                List<Cliente> listaClientes = CatalogoCliente.RecuperarLista(x => x.IsInactivo == isInactivos, nhSesion);

                listaClientes.Aggregate(tablaClientes, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.RazonSocial, r.Provincia, r.Localidad, r.Direccion, r.Telefono, r.Mail, r.Cuil,
                        r.PersonaContacto, r.NumeroCuenta, r.Banco, r.Cbu, r.Observaciones); return dt;
                });

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

        public static void InsertarActualizarArticulo(int codigoArticulo, string descripcionCorta, string descripcionLarga, string marca, string nombreImagen, double precio, int codigoMoneda)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction transaccion = nhSesion.BeginTransaction();

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

                HistorialPrecio histPrecio = (from h in articulo.HistorialesPrecio where h.FechaHasta == null select h).SingleOrDefault();

                if (histPrecio == null)
                {
                    histPrecio = new HistorialPrecio();
                    histPrecio.FechaDesde = DateTime.Now;
                    histPrecio.FechaHasta = null;
                    histPrecio.Precio = precio;
                    histPrecio.CodigoMoneda = codigoMoneda;

                    articulo.HistorialesPrecio.Add(histPrecio);
                }
                else
                {
                    if (histPrecio.Precio != precio || histPrecio.CodigoMoneda != codigoMoneda)
                    {
                        histPrecio.FechaHasta = DateTime.Now.AddSeconds(-1);

                        HistorialPrecio histPrecioNuevo = new HistorialPrecio();
                        histPrecioNuevo.FechaDesde = DateTime.Now;
                        histPrecioNuevo.FechaHasta = null;
                        histPrecioNuevo.Precio = precio;
                        histPrecio.CodigoMoneda = codigoMoneda;

                        articulo.HistorialesPrecio.Add(histPrecioNuevo);
                    }
                }

                articulo.DescripcionCorta = descripcionCorta;
                articulo.DescripcionLarga = descripcionLarga;
                articulo.Marca = marca;
                articulo.NombreImagen = nombreImagen;

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
                tablaArticulos.Columns.Add("nombreImagen");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarTodos(nhSesion);

                listaArticulos.Aggregate(tablaArticulos, (dt, r) => { dt.Rows.Add(r.Codigo, r.DescripcionCorta, r.DescripcionLarga, r.Marca, r.NombreImagen); return dt; });

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

        public static DataTable RecuperarArticulosEnNotaDePedido(int codigoNotaDePedido)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulos = new DataTable();
                tablaArticulos.Columns.Add("codigoArticulo");
                tablaArticulos.Columns.Add("descripcionCorta");
                tablaArticulos.Columns.Add("descripcionLarga");
                tablaArticulos.Columns.Add("cantidad", typeof(int));
                tablaArticulos.Columns.Add("fechaEntrega", typeof(DateTime));

                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);

                notaDePedido.ItemsNotaDePedido.Aggregate(tablaArticulos, (dt, r) => { dt.Rows.Add(r.Codigo, r.Articulo.DescripcionCorta, r.Articulo.DescripcionLarga, r.Cantidad, r.FechaEntrega); return dt; });

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

        #endregion

        #region ArticuloProveedor

        public static DataTable RecuperarArticulosProveedoresPorArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulosProveedores = new DataTable();
                tablaArticulosProveedores.Columns.Add("codigoArticuloProveedor");
                tablaArticulosProveedores.Columns.Add("codigoProveedor");
                tablaArticulosProveedores.Columns.Add("razonSocialProveedor");
                tablaArticulosProveedores.Columns.Add("costoActual");

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.ArticulosProveedor.Aggregate(tablaArticulosProveedores, (dt, r) => { dt.Rows.Add(r.Codigo, r.Proveedor.Codigo, r.Proveedor.RazonSocial, r.HistorialesCosto.Where(x => x.FechaHasta == null).Select(x => x.Costo).SingleOrDefault()); return dt; });

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

        public static DataTable RecuperarHistorialCostosPorArticuloProveedor(int codigoArticuloProveedor)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaHistorialPrecio = new DataTable();
                tablaHistorialPrecio.Columns.Add("codigoHistorialCosto");
                tablaHistorialPrecio.Columns.Add("fechaDesde");
                tablaHistorialPrecio.Columns.Add("fechaHasta");
                tablaHistorialPrecio.Columns.Add("costo");

                ArticuloProveedor artProv = CatalogoArticuloProveedor.RecuperarPorCodigo(codigoArticuloProveedor, nhSesion);

                artProv.HistorialesCosto.Aggregate(tablaHistorialPrecio, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaDesde, r.FechaHasta, r.Costo); return dt; });

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

        public static void InsertarActualizarArticuloProveedor(int codigoArticuloProveedor, int codigoArticulo, int codigoProveedor, double costo, int codigoMoneda)
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

                articuloProveedor.Proveedor = CatalogoProveedor.RecuperarPorCodigo(codigoProveedor, nhSesion);

                HistorialCosto histPrecio = (from h in articuloProveedor.HistorialesCosto where h.FechaHasta == null select h).SingleOrDefault();

                if (histPrecio == null)
                {
                    histPrecio = new HistorialCosto();
                    histPrecio.FechaDesde = DateTime.Now;
                    histPrecio.FechaHasta = null;
                    histPrecio.Costo = costo;
                    histPrecio.CodigoMoneda = codigoMoneda;

                    articuloProveedor.HistorialesCosto.Add(histPrecio);
                }
                else
                {
                    if (histPrecio.Costo != costo || histPrecio.CodigoMoneda != codigoMoneda)
                    {
                        histPrecio.FechaHasta = DateTime.Now.AddSeconds(-1);

                        HistorialCosto histPrecioNuevo = new HistorialCosto();
                        histPrecioNuevo.FechaDesde = DateTime.Now;
                        histPrecioNuevo.FechaHasta = null;
                        histPrecioNuevo.Costo = costo;
                        histPrecio.CodigoMoneda = codigoMoneda;

                        articuloProveedor.HistorialesCosto.Add(histPrecioNuevo);
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

        #endregion

        #region ArticuloCliente

        public static DataTable RecuperarArticulosClientesPorArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulosClientes = new DataTable();
                tablaArticulosClientes.Columns.Add("codigoArticuloCliente");
                tablaArticulosClientes.Columns.Add("codigoInterno");
                tablaArticulosClientes.Columns.Add("codigoCliente");
                tablaArticulosClientes.Columns.Add("razonSocialCliente");
                tablaArticulosClientes.Columns.Add("precioActual");

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.ArticulosClientes.Aggregate(tablaArticulosClientes, (dt, r) => { dt.Rows.Add(r.Codigo, r.CodigoInterno, r.Cliente.Codigo, r.Cliente.RazonSocial, articulo.HistorialesPrecio.Where(x => x.FechaHasta == null).Select(x => x.Precio).SingleOrDefault()); return dt; });

                return tablaArticulosClientes;
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

        public static DataTable RecuperarHistorialPreciosPorArticulo(int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaHistorialPrecio = new DataTable();
                tablaHistorialPrecio.Columns.Add("codigoHistorialPrecio");
                tablaHistorialPrecio.Columns.Add("fechaDesde");
                tablaHistorialPrecio.Columns.Add("fechaHasta");
                tablaHistorialPrecio.Columns.Add("precio");

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.HistorialesPrecio.Aggregate(tablaHistorialPrecio, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaDesde, r.FechaHasta, r.Precio); return dt; });

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

        public static void InsertarActualizarArticuloCliente(int codigoArticuloCliente, int codigoArticulo, string codigoInterno, int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Articulo articulo;
                articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                ArticuloCliente articuloCliente;

                if (codigoArticuloCliente == 0)
                {
                    articuloCliente = new ArticuloCliente();
                    articulo.ArticulosClientes.Add(articuloCliente);
                }
                else
                {
                    articuloCliente = (from ap in articulo.ArticulosClientes where ap.Codigo == codigoArticuloCliente select ap).SingleOrDefault();
                }

                articuloCliente.Cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);
                articuloCliente.CodigoInterno = codigoInterno;

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

        #endregion

        #region NotaDePedido

        public static DataTable RecuperarTodasNotasDePedido()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaNotasDePedido = new DataTable();
                tablaNotasDePedido.Columns.Add("codigoNotaDePedido");
                tablaNotasDePedido.Columns.Add("numeroInternoCliente");
                tablaNotasDePedido.Columns.Add("fechaEmision");
                tablaNotasDePedido.Columns.Add("codigoEstado");
                tablaNotasDePedido.Columns.Add("codigoContratoMarco");
                tablaNotasDePedido.Columns.Add("descripcionContratoMarco");
                tablaNotasDePedido.Columns.Add("codigoCliente");
                tablaNotasDePedido.Columns.Add("razonSocialCliente");
                tablaNotasDePedido.Columns.Add("fechaHoraProximaEntrega");
                tablaNotasDePedido.Columns.Add("observaciones");

                List<NotaDePedido> listaNotasDePedido = CatalogoNotaDePedido.RecuperarTodos(nhSesion);

                foreach (NotaDePedido notaPedido in listaNotasDePedido)
                {
                    int codigoEstado = 0;
                    DateTime fechaHoraProximaEntrega = DateTime.MinValue;

                    if (notaPedido.ItemsNotaDePedido.Count > 0)
                    {
                        switch (notaPedido.CodigoEstado)
                        {
                            case Constantes.EstadosNotaDePedido.VIGENTE:
                                List<ItemNotaDePedido> listaItemsNotaDePedidoVencidos = (from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now select n).ToList();

                                if (listaItemsNotaDePedidoVencidos.Count > 0)
                                {
                                    codigoEstado = Constantes.EstadosNotaDePedido.VENCIDA;
                                    fechaHoraProximaEntrega = listaItemsNotaDePedidoVencidos.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                }
                                else
                                {
                                    List<ItemNotaDePedido> listaItemsNotaDePedidoProximosAVencer = (from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now.AddDays(5) select n).ToList();
                                    if (listaItemsNotaDePedidoProximosAVencer.Count > 0)
                                    {
                                        codigoEstado = Constantes.EstadosNotaDePedido.PROXIMA_VENCER;
                                        fechaHoraProximaEntrega = listaItemsNotaDePedidoProximosAVencer.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                    }
                                    else
                                    {
                                        codigoEstado = Constantes.EstadosNotaDePedido.VIGENTE;
                                        fechaHoraProximaEntrega = notaPedido.ItemsNotaDePedido.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                    }
                                }

                                break;
                            case Constantes.EstadosNotaDePedido.ANULADA:
                                codigoEstado = Constantes.EstadosNotaDePedido.ANULADA;
                                break;

                            case Constantes.EstadosNotaDePedido.ENTREGADA:
                                codigoEstado = Constantes.EstadosNotaDePedido.ENTREGADA;
                                break;
                        }
                    }

                    tablaNotasDePedido.Rows.Add(new object[] { notaPedido.Codigo, notaPedido.NumeroInternoCliente, notaPedido.FechaEmision, codigoEstado, notaPedido.ContratoMarco != null ? notaPedido.ContratoMarco.Codigo : 0, 
                        notaPedido.ContratoMarco != null ? notaPedido.ContratoMarco.Descripcion : "", notaPedido.Cliente.Codigo, notaPedido.Cliente.RazonSocial, fechaHoraProximaEntrega == DateTime.MinValue ? "" : fechaHoraProximaEntrega.ToString(), notaPedido.Observaciones});
                }

                return tablaNotasDePedido;
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

        /// <summary>
        /// Columnas del DataTabla tablaItemsNotaDePedido: codigoItemNotaDePedido, codigoArticulo, cantidad, fechaEntrega
        /// </summary>
        public static void InsertarActualizarNotaDePedido(int codigoNotaDePedido, string numeroInternoCliente, DateTime fechaEmision, string observaciones, int codigoContratoMarco, int codigoCliente, DataTable tablaItemsNotaDePedido)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction transaccion = nhSesion.BeginTransaction();

            try
            {
                NotaDePedido notaDePedido;

                if (codigoNotaDePedido == 0)
                {
                    notaDePedido = new NotaDePedido();
                    notaDePedido.CodigoEstado = Constantes.EstadosNotaDePedido.VIGENTE;
                }
                else
                {
                    notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);
                }

                notaDePedido.Cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);
                notaDePedido.ContratoMarco = codigoContratoMarco == 0 ? null : CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);
                notaDePedido.FechaEmision = fechaEmision;
                notaDePedido.NumeroInternoCliente = numeroInternoCliente;
                notaDePedido.Observaciones = observaciones;

                foreach (DataRow filaItemNotaDePedido in tablaItemsNotaDePedido.Rows)
                {
                    int codigoItemNotaDePedido = Convert.ToInt32(filaItemNotaDePedido["codigoItemNotaDePedido"]);
                    ItemNotaDePedido item = new ItemNotaDePedido();

                    if (codigoItemNotaDePedido == 0)
                    {
                        item = new ItemNotaDePedido();
                        notaDePedido.ItemsNotaDePedido.Add(item);
                    }

                    item.Articulo = CatalogoArticulo.RecuperarPorCodigo(Convert.ToInt32(filaItemNotaDePedido["codigoArticulo"]), nhSesion);
                    item.Cantidad = Convert.ToInt32(filaItemNotaDePedido["cantidad"]);
                    item.FechaEntrega = Convert.ToDateTime(filaItemNotaDePedido["fechaEntrega"]);
                }

                CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
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

        public static void ActivarAnularNotaDePedido(int codigoNotaDePedido, string observaciones)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);

                if (notaDePedido.CodigoEstado == Constantes.EstadosNotaDePedido.ANULADA)
                {
                    notaDePedido.CodigoEstado = Constantes.EstadosNotaDePedido.VIGENTE;
                }
                else
                {
                    notaDePedido.CodigoEstado = Constantes.EstadosNotaDePedido.ANULADA;
                }

                notaDePedido.Observaciones = observaciones;

                CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
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

        #region ContratoMarco

        public static DataTable RecuperarContratosMarcoVigentePorCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaContratosMarco = new DataTable();
                tablaContratosMarco.Columns.Add("codigoContratoMarco");
                tablaContratosMarco.Columns.Add("fechaInicio");
                tablaContratosMarco.Columns.Add("fechaFin");
                tablaContratosMarco.Columns.Add("descripcion");

                List<ContratoMarco> listaContratosMarco = CatalogoContratoMarco.RecuperarLista(x => x.FechaInicio < DateTime.Now && x.FechaFin > DateTime.Now && x.Cliente.Codigo == codigoCliente, nhSesion);

                listaContratosMarco.Aggregate(tablaContratosMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaInicio, r.FechaFin, r.Descripcion); return dt; });

                return tablaContratosMarco;
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

        public static DataTable RecuperarContratosMarcoVigentePorClienteYArticulo(int codigoCliente, int codigoArticulo)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaContratosMarco = new DataTable();
                tablaContratosMarco.Columns.Add("codigoContratoMarco");
                tablaContratosMarco.Columns.Add("fechaInicio");
                tablaContratosMarco.Columns.Add("fechaFin");
                tablaContratosMarco.Columns.Add("descripcion");

                List<ContratoMarco> listaContratosMarco = CatalogoContratoMarco.RecuperarVigentePorClienteYArticulo(codigoCliente, codigoArticulo, nhSesion);

                listaContratosMarco.Aggregate(tablaContratosMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaInicio, r.FechaFin, r.Descripcion); return dt; });

                return tablaContratosMarco;
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
