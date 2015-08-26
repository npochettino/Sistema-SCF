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

        public static void InsertarActualizarProveedor(int codigoProveedor, string razonSocial, string provincia, string localidad, string direccion, string telefono, string fax, string mail, string cuil, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones, int numeroInterno)
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
                proveedor.Fax = fax;
                proveedor.Cbu = cbu;
                proveedor.Observaciones = observaciones;
                proveedor.IsInactivo = false;
                proveedor.NumeroInterno = numeroInterno;

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

        public static void InsertarActualizarCliente(int codigoUsuario, string razonSocial, string provincia, string localidad, string direccion, string telefono, string fax, string mail, string cuil, string personaContacto, string numeroCuenta, string banco, string cbu, string observaciones, int numeroInterno)
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
                cliente.Fax = fax;
                cliente.Mail = mail;
                cliente.Cuil = cuil;
                cliente.PersonaContacto = personaContacto;
                cliente.NumeroCuenta = numeroCuenta;
                cliente.Banco = banco;
                cliente.Cbu = cbu;
                cliente.Observaciones = observaciones;
                cliente.IsInactivo = false;
                cliente.NumeroInterno = numeroInterno;

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

        public static DataTable RecuperarClientePorContratoMarco(int codigoContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            try
            {
                DataTable tablaCliente = new DataTable();
                tablaCliente.Columns.Add("codigoCliente");
                tablaCliente.Columns.Add("razonSocial");
                tablaCliente.Columns.Add("provincia");
                tablaCliente.Columns.Add("localidad");
                tablaCliente.Columns.Add("direccion");
                tablaCliente.Columns.Add("telefono");
                tablaCliente.Columns.Add("mail");
                tablaCliente.Columns.Add("cuil");
                tablaCliente.Columns.Add("personaContacto");
                tablaCliente.Columns.Add("numeroCuenta");
                tablaCliente.Columns.Add("banco");
                tablaCliente.Columns.Add("cbu");
                tablaCliente.Columns.Add("observaciones");

                ContratoMarco contratoMarco = CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);

                tablaCliente.Rows.Add(new object[] { contratoMarco.Cliente.Codigo, contratoMarco.Cliente.RazonSocial, contratoMarco.Cliente.Provincia, contratoMarco.Cliente.Localidad,
                contratoMarco.Cliente.Direccion, contratoMarco.Cliente.Telefono, contratoMarco.Cliente.Mail, contratoMarco.Cliente.Cuil, contratoMarco.Cliente.PersonaContacto,
                contratoMarco.Cliente.NumeroCuenta, contratoMarco.Cliente.Banco, contratoMarco.Cliente.Cbu, contratoMarco.Cliente.Observaciones});

                return tablaCliente;
            }
            catch (Exception ex)
            {
                throw ex;
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
                tablaArticulos.Columns.Add("precio");
                tablaArticulos.Columns.Add("nombreImagen");
                tablaArticulos.Columns.Add("codigoArticuloCliente");
                tablaArticulos.Columns.Add("codigoCliente");
                tablaArticulos.Columns.Add("razonSocialCliente");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarTodos(nhSesion);

                listaArticulos.Aggregate(tablaArticulos, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.DescripcionCorta, r.DescripcionLarga, r.Marca,

                        r.RecuperarPrecioActual(), r.NombreImagen, string.Empty, string.Empty, string.Empty); return dt;

                });

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

        public static DataTable RecuperarArticuloPorCodigoInternoCliente(string codigoInternoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulo = new DataTable();
                tablaArticulo.Columns.Add("codigoArticulo");
                tablaArticulo.Columns.Add("descripcionCorta");
                tablaArticulo.Columns.Add("descripcionLarga");
                tablaArticulo.Columns.Add("marca");
                tablaArticulo.Columns.Add("precio");
                tablaArticulo.Columns.Add("nombreImagen");
                tablaArticulo.Columns.Add("codigoArticuloCliente");
                tablaArticulo.Columns.Add("codigoCliente");
                tablaArticulo.Columns.Add("razonSocialCliente");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarPorCodigoInternoCliente(codigoInternoCliente, nhSesion);

                listaArticulos.Aggregate(tablaArticulo, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.DescripcionCorta, r.DescripcionLarga, r.Marca,
                        r.RecuperarPrecioActual(), r.NombreImagen,
                        (from ac in r.ArticulosClientes where ac.CodigoInterno == codigoInternoCliente select ac).SingleOrDefault().CodigoInterno,
                        (from ac in r.ArticulosClientes where ac.CodigoInterno == codigoInternoCliente select ac.Cliente).SingleOrDefault().Codigo,
                        (from ac in r.ArticulosClientes where ac.CodigoInterno == codigoInternoCliente select ac.Cliente).SingleOrDefault().RazonSocial); return dt;
                });

                return tablaArticulo;
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

        public static DataTable RecuperarArticulosPorCodigoCliente(int codigoCliente)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaArticulo = new DataTable();
                tablaArticulo.Columns.Add("codigoArticulo");
                tablaArticulo.Columns.Add("descripcionCorta");
                tablaArticulo.Columns.Add("descripcionLarga");
                tablaArticulo.Columns.Add("marca");
                tablaArticulo.Columns.Add("precio");
                tablaArticulo.Columns.Add("nombreImagen");
                tablaArticulo.Columns.Add("codigoArticuloCliente");
                tablaArticulo.Columns.Add("codigoCliente");
                tablaArticulo.Columns.Add("razonSocialCliente");

                List<Articulo> listaArticulos = CatalogoArticulo.RecuperarPorCodigoCliente(codigoCliente, nhSesion);
                Cliente cliente = CatalogoCliente.RecuperarPorCodigo(codigoCliente, nhSesion);

                List<Articulo> a = (from b in listaArticulos where b.ArticulosClientes.Count > 1 select b).ToList();

                listaArticulos.Aggregate(tablaArticulo, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.DescripcionCorta, r.DescripcionLarga, r.Marca,
                        r.RecuperarPrecioActual(), r.NombreImagen,
                        (from ac in r.ArticulosClientes where ac.Cliente.Codigo == codigoCliente select ac).SingleOrDefault().CodigoInterno,
                        cliente.Codigo, cliente.RazonSocial); return dt;
                });

                return tablaArticulo;
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

                Articulo articulo = CatalogoArticulo.RecuperarPorCodigo(codigoArticulo, nhSesion);

                articulo.ArticulosClientes.Aggregate(tablaArticulosClientes, (dt, r) => { dt.Rows.Add(r.Codigo, r.CodigoInterno, r.Cliente.Codigo, r.Cliente.RazonSocial); return dt; });

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

        public static DataTable RecuperarTodasNotasDePedido(bool soloVigentes)
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

                List<NotaDePedido> listaNotasDePedido;
                if (soloVigentes)
                {
                    listaNotasDePedido = CatalogoNotaDePedido.RecuperarLista(x => x.CodigoEstado == Constantes.Estados.VIGENTE, nhSesion);
                }
                else
                {
                    listaNotasDePedido = CatalogoNotaDePedido.RecuperarTodos(nhSesion);
                }

                foreach (NotaDePedido notaPedido in listaNotasDePedido)
                {
                    int codigoEstado = 0;
                    DateTime fechaHoraProximaEntrega = DateTime.MinValue;

                    if (notaPedido.ItemsNotaDePedido.Count > 0)
                    {
                        List<Entrega> listaEntregas = CatalogoEntrega.RecuperarLista(x => x.NotaDePedido.Codigo == notaPedido.Codigo, nhSesion);

                        switch (notaPedido.CodigoEstado)
                        {
                            case Constantes.Estados.VIGENTE:
                                List<ItemNotaDePedido> listaItemsNotaDePedidoVencidos = (from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now select n).ToList();

                                if (listaEntregas.Count > 0) //valido que no haya alguna entrega que cumpla el item nota de pedido
                                {
                                    List<ItemNotaDePedido> listaBorrar = new List<ItemNotaDePedido>();

                                    foreach (ItemNotaDePedido itemNP in listaItemsNotaDePedidoVencidos)
                                    {
                                        List<ItemEntrega> listaItemsEntrega = (from e in listaEntregas where (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault() != null select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault()).ToList();
                                        int cantidadAEntregarTotal = (from e in listaItemsEntrega select e.CantidadAEntregar).Sum();

                                        if (cantidadAEntregarTotal >= itemNP.CantidadPedida)
                                        {
                                            listaBorrar.Add(itemNP);
                                        }
                                    }

                                    foreach (ItemNotaDePedido itemBorrar in listaBorrar)
                                    {
                                        listaItemsNotaDePedidoVencidos.Remove(itemBorrar);
                                    }
                                }

                                if (listaItemsNotaDePedidoVencidos.Count > 0)
                                {
                                    codigoEstado = Constantes.Estados.VENCIDA;
                                    fechaHoraProximaEntrega = listaItemsNotaDePedidoVencidos.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                }
                                else
                                {
                                    List<ItemNotaDePedido> listaItemsNotaDePedidoProximosAVencer = (from n in notaPedido.ItemsNotaDePedido where n.FechaEntrega < DateTime.Now.AddDays(5) select n).ToList();

                                    if (listaEntregas.Count > 0) //valido que no haya alguna entrega que cumpla el item nota de pedido
                                    {
                                        List<ItemNotaDePedido> listaBorrar = new List<ItemNotaDePedido>();

                                        foreach (ItemNotaDePedido itemNP in listaItemsNotaDePedidoProximosAVencer)
                                        {
                                            List<ItemEntrega> listaItemsEntrega = (from e in listaEntregas where (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault() != null select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault()).ToList();
                                            int cantidadAEntregarTotal = (from e in listaItemsEntrega select e.CantidadAEntregar).Sum();

                                            if (cantidadAEntregarTotal >= itemNP.CantidadPedida)
                                            {
                                                listaBorrar.Add(itemNP);
                                            }
                                        }

                                        foreach (ItemNotaDePedido itemBorrar in listaBorrar)
                                        {
                                            listaItemsNotaDePedidoProximosAVencer.Remove(itemBorrar);
                                        }
                                    }

                                    if (listaItemsNotaDePedidoProximosAVencer.Count > 0)
                                    {
                                        codigoEstado = Constantes.Estados.PROXIMA_VENCER;
                                        fechaHoraProximaEntrega = listaItemsNotaDePedidoProximosAVencer.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                    }
                                    else
                                    {
                                        codigoEstado = Constantes.Estados.VIGENTE;
                                        fechaHoraProximaEntrega = notaPedido.ItemsNotaDePedido.OrderBy(x => x.FechaEntrega).ToList()[0].FechaEntrega;
                                    }
                                }

                                break;
                            case Constantes.Estados.ANULADA:
                                codigoEstado = Constantes.Estados.ANULADA;
                                break;

                            case Constantes.Estados.ENTREGADA:
                                codigoEstado = Constantes.Estados.ENTREGADA;
                                break;
                        }
                    }

                    tablaNotasDePedido.Rows.Add(new object[] { notaPedido.Codigo, notaPedido.NumeroInternoCliente, notaPedido.FechaEmision, codigoEstado, notaPedido.ContratoMarco != null ? notaPedido.ContratoMarco.Codigo : 0, 
                        notaPedido.ContratoMarco != null ? notaPedido.ContratoMarco.Descripcion : "", notaPedido.Cliente.Codigo, notaPedido.Cliente.RazonSocial, fechaHoraProximaEntrega == DateTime.MinValue ? "" : fechaHoraProximaEntrega.ToString(), notaPedido.Observaciones});
                }

                DataView dv = tablaNotasDePedido.DefaultView;
                dv.Sort = "codigoEstado desc";

                return dv.ToTable();
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
                    notaDePedido.CodigoEstado = Constantes.Estados.VIGENTE;
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
                    item.CantidadPedida = Convert.ToInt32(filaItemNotaDePedido["cantidad"]);
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

                if (notaDePedido.CodigoEstado == Constantes.Estados.ANULADA)
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.VIGENTE;
                }
                else
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.ANULADA;
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

        #region ItemNotaDePedido

        public static DataTable RecuperarItemsNotaDePedido(int codigoNotaDePedido)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsNotaDePedido = new DataTable();
                tablaItemsNotaDePedido.Columns.Add("codigoItemNotaDePedido");
                tablaItemsNotaDePedido.Columns.Add("codigoArticulo");
                tablaItemsNotaDePedido.Columns.Add("descripcionCorta");
                tablaItemsNotaDePedido.Columns.Add("descripcionLarga");
                tablaItemsNotaDePedido.Columns.Add("marca");
                tablaItemsNotaDePedido.Columns.Add("precio");
                tablaItemsNotaDePedido.Columns.Add("cantidad");
                tablaItemsNotaDePedido.Columns.Add("fechaEntrega");
                tablaItemsNotaDePedido.Columns.Add("cantidadEntregada");

                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaDePedido, nhSesion);

                List<Entrega> listaEntregas = CatalogoEntrega.RecuperarLista(x => x.NotaDePedido.Codigo == codigoNotaDePedido, nhSesion);

                foreach (ItemNotaDePedido item in notaDePedido.ItemsNotaDePedido)
                {

                    int cantidadEntregada = (from e in listaEntregas select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == item.Codigo select i.CantidadAEntregar).SingleOrDefault()).Sum();

                    tablaItemsNotaDePedido.Rows.Add(item.Codigo, item.Articulo.Codigo, item.Articulo.DescripcionCorta, item.Articulo.DescripcionLarga, item.Articulo.Marca,
                    item.Articulo.RecuperarPrecioActual(), item.CantidadPedida, item.FechaEntrega, cantidadEntregada);
                }


                return tablaItemsNotaDePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ContratoMarco

        public static string InsertarContratosMarcosPorTabla(DataTable tablaItemsContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction trans = nhSesion.BeginTransaction();

            try
            {
                List<ContratoMarco> listaContratosMarco = new List<ContratoMarco>();

                foreach (DataRow fila in tablaItemsContratoMarco.Rows)
                {
                    string descripcionCM = fila["CM"].ToString();

                    ContratoMarco cm = (from c in listaContratosMarco where c.Descripcion == descripcionCM select c).SingleOrDefault();

                    if (cm == null)
                    {
                        cm = new ContratoMarco();
                        cm.Descripcion = descripcionCM;
                        cm.FechaInicio = Convert.ToDateTime(fila["INICIO"]);
                        cm.FechaFin = Convert.ToDateTime(fila["FIN"]);
                        cm.Comprador = fila["COMPRADOR"].ToString();

                        Cliente cliente = CatalogoCliente.RecuperarPorRazonSocial(fila["Cliente"].ToString(), nhSesion);

                        if (cliente == null)
                        {
                            return "Cliente inexistente: " + fila["Cliente"].ToString();
                        }

                        cm.Cliente = cliente;

                        listaContratosMarco.Add(cm);
                    }

                    string descripcionCorta = fila["texto breve"].ToString();

                    Articulo articulo = CatalogoArticulo.RecuperarPor(x => x.DescripcionCorta == descripcionCorta, nhSesion);

                    if (articulo == null)
                    {
                        articulo = new Articulo();
                        articulo.DescripcionCorta = descripcionCorta;
                        articulo.DescripcionLarga = string.Empty;
                        articulo.Marca = string.Empty;
                        articulo.NombreImagen = string.Empty;
                        articulo.UnidadMedida = fila["unidad de medida"].ToString();
                    }

                    ArticuloCliente artCl = (from a in articulo.ArticulosClientes where a.CodigoInterno == fila["cod planta"].ToString() && a.Cliente.Codigo == cm.Cliente.Codigo select a).SingleOrDefault();

                    if (artCl == null)
                    {
                        artCl = new ArticuloCliente();
                        artCl.CodigoInterno = fila["cod planta"].ToString();
                        artCl.Cliente = cm.Cliente;
                        articulo.ArticulosClientes.Add(artCl);
                    }

                    //HistorialPrecio histPrecio = (from h in articulo.HistorialesPrecio where h.FechaHasta == null select h).SingleOrDefault();
                    //if (histPrecio == null)
                    //{
                    //    histPrecio = new HistorialPrecio();
                    //    histPrecio.CodigoMoneda = RecuperarCodigoMoneda(fila["moneda"].ToString());
                    //    histPrecio.FechaDesde = fechaHoraDesde;
                    //    histPrecio.FechaHasta = null;
                    //    histPrecio.Precio = Convert.ToDouble(fila["precio base"]);
                    //}
                    //else
                    //{
                    //    if (histPrecio.Precio != Convert.ToDouble(fila["precio base"]) || histPrecio.CodigoMoneda != RecuperarCodigoMoneda(fila["moneda"].ToString()))
                    //    {
                    //        histPrecio.FechaHasta = fechaHoraDesde.AddSeconds(-1);
                    //        HistorialPrecio histPrecioNuevo = new HistorialPrecio();
                    //        histPrecio.CodigoMoneda = RecuperarCodigoMoneda(fila["moneda"].ToString());
                    //        histPrecio.FechaDesde = fechaHoraDesde;
                    //        histPrecio.FechaHasta = null;
                    //        histPrecio.Precio = Convert.ToDouble(fila["precio base"]);
                    //    }
                    //}

                    ItemContratoMarco itemCM = new ItemContratoMarco();
                    itemCM.Articulo = articulo;
                    itemCM.Precio = Convert.ToDouble(fila["precio base"]);
                    itemCM.Posicion = Convert.ToInt32(fila["pos"]);

                    cm.ItemsContratoMarco.Add(itemCM);
                }

                foreach (ContratoMarco cm in listaContratosMarco)
                {
                    CatalogoContratoMarco.InsertarActualizar(cm, nhSesion);
                }

                trans.Commit();
                return "ok";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        private static int RecuperarCodigoMoneda(string moneda)
        {
            switch (moneda)
            {
                case "USD":
                    return Constantes.Moneda.DOLAR;
                case "ARS":
                    return Constantes.Moneda.PESO;
                case "EUR":
                    return Constantes.Moneda.EURO;
                default:
                    return 1;
                    break;
            }
        }

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

        public static DataTable RecuperarTodosContratosMarcos(bool vigentes)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaContratosMarco = new DataTable();
                tablaContratosMarco.Columns.Add("codigoContratoMarco");
                tablaContratosMarco.Columns.Add("descripcion");
                tablaContratosMarco.Columns.Add("fechaInicio");
                tablaContratosMarco.Columns.Add("fechaFin");
                tablaContratosMarco.Columns.Add("codigoCliente");
                tablaContratosMarco.Columns.Add("cuilCliente");
                tablaContratosMarco.Columns.Add("razonSocialCliente");

                List<ContratoMarco> listaContratosMarco = new List<ContratoMarco>();

                if (vigentes)
                {
                    listaContratosMarco = CatalogoContratoMarco.RecuperarLista(x => x.FechaFin >= DateTime.Now, nhSesion);
                }
                else
                {
                    listaContratosMarco = CatalogoContratoMarco.RecuperarLista(x => x.FechaFin <= DateTime.Now, nhSesion);
                }

                listaContratosMarco.Aggregate(tablaContratosMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion, r.FechaInicio, r.FechaFin, r.Cliente.Codigo, r.Cliente.Cuil, r.Cliente.RazonSocial); return dt; });

                return tablaContratosMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarTodosItemsContratoMarco(int codigoContratoMarco)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsContratoMarco = new DataTable();
                tablaItemsContratoMarco.Columns.Add("codigoItemContratoMarco");
                tablaItemsContratoMarco.Columns.Add("codigoArticulo");
                tablaItemsContratoMarco.Columns.Add("descripcioncorta");
                tablaItemsContratoMarco.Columns.Add("precio");

                ContratoMarco contratoMarco = CatalogoContratoMarco.RecuperarPorCodigo(codigoContratoMarco, nhSesion);

                contratoMarco.ItemsContratoMarco.Aggregate(tablaItemsContratoMarco, (dt, r) => { dt.Rows.Add(r.Codigo, r.Articulo.Codigo, r.Articulo.DescripcionCorta, r.Precio); return dt; });

                return tablaItemsContratoMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Entregas

        public static DataTable RecuperarTodasEntregas()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaEntrega = new DataTable();
                tablaEntrega.Columns.Add("codigoEntrega");
                tablaEntrega.Columns.Add("codigoNotaDePedido");
                tablaEntrega.Columns.Add("codigoCliente");
                tablaEntrega.Columns.Add("razonSocialCliente");
                tablaEntrega.Columns.Add("fechaEmision");
                tablaEntrega.Columns.Add("numeroNotaDePedido");
                tablaEntrega.Columns.Add("numeroRemito");
                tablaEntrega.Columns.Add("codigoEstado");
                tablaEntrega.Columns.Add("observaciones");

                List<Entrega> listaEntregas = CatalogoEntrega.RecuperarTodos(nhSesion);

                listaEntregas.Aggregate(tablaEntrega, (dt, r) => { dt.Rows.Add(r.Codigo, r.NotaDePedido.Codigo, r.NotaDePedido.Cliente.Codigo, r.NotaDePedido.Cliente.RazonSocial, r.FechaEmision, r.NotaDePedido.NumeroInternoCliente, r.NumeroRemito, r.CodigoEstado, r.Observaciones); return dt; });

                return tablaEntrega;
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

        public static DataTable RecuperarUltimaEntrega()
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaEntrega = new DataTable();
                tablaEntrega.Columns.Add("codigoEntrega");
                tablaEntrega.Columns.Add("fechaEmision");
                tablaEntrega.Columns.Add("numeroRemito");
                tablaEntrega.Columns.Add("codigoEstado");
                tablaEntrega.Columns.Add("observaciones");

                Entrega entrega = CatalogoEntrega.RecuperarUltima(nhSesion);

                if (entrega != null)
                {
                    tablaEntrega.Rows.Add(new object[] { entrega.Codigo, entrega.FechaEmision, entrega.NumeroRemito, entrega.CodigoEstado, entrega.Observaciones });
                }

                return tablaEntrega;
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

        public static void InsertarActualizarEntrega(int codigoEntrega, DateTime fechaEmision, int codigoNotaPedido, int numeroRemito, string observaciones, DataTable tablaItemsEntrega)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction tran = nhSesion.BeginTransaction();

            try
            {
                Entrega entrega;
                if (codigoEntrega == 0)
                {
                    entrega = new Entrega();
                }
                else
                {
                    entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);
                }

                NotaDePedido notaDePedido = CatalogoNotaDePedido.RecuperarPorCodigo(codigoNotaPedido, nhSesion);

                entrega.CodigoEstado = Constantes.Estados.VIGENTE;
                entrega.FechaEmision = fechaEmision;
                entrega.NotaDePedido = notaDePedido;
                entrega.NumeroRemito = numeroRemito;
                entrega.Observaciones = observaciones;

                foreach (DataRow filaItem in tablaItemsEntrega.Rows)
                {
                    int codigoItemEntrega = Convert.ToInt32(filaItem["codigoItemEntrega"]);
                    ItemEntrega item;

                    if (codigoItemEntrega < 1)
                    {
                        item = new ItemEntrega();
                        entrega.ItemsEntrega.Add(item);
                    }
                    else
                    {
                        item = (from i in entrega.ItemsEntrega where i.Codigo == codigoItemEntrega select i).SingleOrDefault();
                        if (!Convert.IsDBNull(filaItem["isEliminada"]) && Convert.ToBoolean(filaItem["isEliminada"]))
                        {
                            entrega.ItemsEntrega.Remove(item);
                        }
                    }

                    item.CantidadAEntregar = Convert.ToInt32(filaItem["cantidad"]);
                    item.ArticuloProveedor = null;
                    item.ItemNotaDePedido = (from i in notaDePedido.ItemsNotaDePedido where i.Codigo == Convert.ToInt32(filaItem["codigoItemNotaDePedido"]) select i).SingleOrDefault();
                }

                CatalogoEntrega.InsertarActualizar(entrega, nhSesion);
                ValidarNotaDePedido(notaDePedido, nhSesion);

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        private static void ValidarNotaDePedido(NotaDePedido notaDePedido, ISession nhSesion)
        {
            try
            {
                int cantidadCumplidas = 0;
                List<Entrega> listaEntregas = CatalogoEntrega.RecuperarLista(x => x.NotaDePedido.Codigo == notaDePedido.Codigo && x.CodigoEstado != Constantes.Estados.ANULADA, nhSesion);
                if (listaEntregas.Count > 0) //calido que no haya alguna entrega que cumpla el item nota de pedido
                {
                    List<ItemNotaDePedido> listaBorrar = new List<ItemNotaDePedido>();

                    foreach (ItemNotaDePedido itemNP in notaDePedido.ItemsNotaDePedido)
                    {
                        List<ItemEntrega> listaItemsEntrega = (from e in listaEntregas where (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault() != null select (from i in e.ItemsEntrega where i.ItemNotaDePedido.Codigo == itemNP.Codigo && i != null select i).SingleOrDefault()).ToList();
                        int cantidadAEntregarTotal = (from e in listaItemsEntrega select e.CantidadAEntregar).Sum();

                        if (cantidadAEntregarTotal >= itemNP.CantidadPedida)
                        {
                            cantidadCumplidas++;
                        }
                    }
                }

                if (cantidadCumplidas == notaDePedido.ItemsNotaDePedido.Count)
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.ENTREGADA;
                    CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
                }
                else if (notaDePedido.CodigoEstado == Constantes.Estados.ENTREGADA)
                {
                    notaDePedido.CodigoEstado = Constantes.Estados.VIGENTE;
                    CatalogoNotaDePedido.InsertarActualizar(notaDePedido, nhSesion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActivarAnularEntrega(int codigoEntrega, string observaciones)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();
            ITransaction tran = nhSesion.BeginTransaction();

            try
            {
                Entrega entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);

                if (entrega.CodigoEstado == Constantes.Estados.ANULADA)
                {
                    entrega.CodigoEstado = Constantes.Estados.VIGENTE;
                }
                else
                {
                    entrega.CodigoEstado = Constantes.Estados.ANULADA;
                }

                entrega.Observaciones = observaciones;

                CatalogoEntrega.InsertarActualizar(entrega, nhSesion);
                ValidarNotaDePedido(entrega.NotaDePedido, nhSesion);

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EntregadaPendienteEntrega(int codigoEntrega, string observaciones)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                Entrega entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);

                if (entrega.CodigoEstado == Constantes.Estados.ENTREGADA)
                {
                    entrega.CodigoEstado = Constantes.Estados.VIGENTE;
                }
                else
                {
                    entrega.CodigoEstado = Constantes.Estados.ENTREGADA;
                }

                entrega.Observaciones = observaciones;

                CatalogoEntrega.InsertarActualizar(entrega, nhSesion);
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

        #region ItemEntrega

        public static DataTable RecuperarItemsEntrega(int codigoEntrega)
        {
            ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            try
            {
                DataTable tablaItemsEntrega = new DataTable();
                tablaItemsEntrega.Columns.Add("codigoItemEntrega");
                tablaItemsEntrega.Columns.Add("codigoArticulo");
                tablaItemsEntrega.Columns.Add("descripcionCorta");
                tablaItemsEntrega.Columns.Add("cantidad");
                tablaItemsEntrega.Columns.Add("codigoProveedor");
                tablaItemsEntrega.Columns.Add("razonSocialProveedor");
                tablaItemsEntrega.Columns.Add("codigoItemNotaDePedido");

                Entrega entrega = CatalogoEntrega.RecuperarPorCodigo(codigoEntrega, nhSesion);

                if (entrega != null)
                {
                    entrega.ItemsEntrega.Aggregate(tablaItemsEntrega, (dt, r) =>
                    {
                        dt.Rows.Add(r.Codigo, r.ItemNotaDePedido.Articulo.Codigo, r.ItemNotaDePedido.Articulo.DescripcionCorta, r.CantidadAEntregar, r.ArticuloProveedor != null ? r.ArticuloProveedor.Proveedor.Codigo : 0, r.ArticuloProveedor != null ? r.ArticuloProveedor.Proveedor.RazonSocial : "", r.ItemNotaDePedido.Codigo); return dt;
                    });
                }

                return tablaItemsEntrega;
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
