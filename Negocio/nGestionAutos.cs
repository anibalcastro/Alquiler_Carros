using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;
using Datos;
using System.Xml;

namespace Negocio
{
    public class nGestionAutos
    {
        List<string> modelo_Hyundai = new List<string> { "Elantra", "Tucson", "Accent" };
        List<string> modelo_Toyota = new List<string> { "Rav4", "Corolla", "Yaris" };
        List<string> modelo_Nissan = new List<string> { "Sentra", "Pathfinder", "Qashqai" };

        List<string> Estilo_Sedan = new List<string> { "Elantra", "Accent", "Corolla", "Yaris", "Sentra" };
        List<string> Estilo_4X4 = new List<string> { "Tucson", "Rav4", "Pathfinder", "Qashqai" };


        XmlDocument doc;
        string rutaXml;

        public List<string> modelos(string marca)
        {
            if (marca == "Nissan")
            {
                return modelo_Nissan;

            }
            else if (marca == "Toyota")
            {
                return modelo_Toyota;
            }
            else
            {
                return modelo_Hyundai;
            }
        }

        public string validarEstilo(string modelo)
        {
            string estilo = "";

            if (Estilo_Sedan.Contains(modelo))
            {
                estilo = "Sedan";
            }
            else if (Estilo_4X4.Contains(modelo))
            {
                estilo = "4X4";
            }

            return estilo;
        }

        public void CrearXML(string ruta, string nodoRaiz)
        {
            rutaXml = ruta;
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlNode nodo = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, nodo);

            XmlNode elemento = doc.CreateElement(nodoRaiz);
            doc.AppendChild(elemento);

            new Datos.bdGestionAutos().guardarDatosXML(doc, ruta);

        }

        public void LeerXML(string ruta)
        {
            rutaXml = ruta;
            doc = new XmlDocument();
            doc.Load(rutaXml);
        }

        public void RegistrarCarros(ObjCarros carros)
        {

            XmlNode Registro = this.Crear(carros);

            XmlNode nodo = doc.DocumentElement;

            nodo.InsertAfter(Registro, nodo.LastChild);

            new bdLogin().guardarDatosXML(doc, rutaXml);

        }


        public XmlNode Crear(ObjCarros carros)
        {
            XmlNode Registro = doc.CreateElement("Carros");

            XmlElement xPlaca = doc.CreateElement("placa");
            xPlaca.InnerText = carros.placa.ToString();
            Registro.AppendChild(xPlaca);

            XmlElement xAnno = doc.CreateElement("año");
            xAnno.InnerText = carros.año.ToString();
            Registro.AppendChild(xAnno);

            XmlElement xprecio = doc.CreateElement("precio");
            xprecio.InnerText = carros.precio.ToString();
            Registro.AppendChild(xprecio);

            XmlElement xmarca = doc.CreateElement("marca");
            xmarca.InnerText = carros.marca.ToString();
            Registro.AppendChild(xmarca);

            XmlElement xmodelo = doc.CreateElement("modelo");
            xmodelo.InnerText = carros.modelo.ToString();
            Registro.AppendChild(xmodelo);

            XmlElement xestilo = doc.CreateElement("estilo");
            xestilo.InnerText = carros.estilo.ToString();
            Registro.AppendChild(xestilo);

            XmlElement xcolor = doc.CreateElement("color");
            xcolor.InnerText = carros.color.ToString();
            Registro.AppendChild(xcolor);

            XmlElement xestado = doc.CreateElement("estado");
            xestado.InnerText = carros.estado.ToString();
            Registro.AppendChild(xestado);

            return Registro;
        }


        public List<ObjCarros> llenarLista()
        {
            List<ObjCarros> Lista = new List<ObjCarros>();
            XmlNodeList listaUsuarios = doc.SelectNodes("Adobe/Carros");

            XmlNode unUsuario;

            for (int x = 0; x < listaUsuarios.Count; x++)
            {
                unUsuario = listaUsuarios.Item(x);
                ObjCarros objetos = new ObjCarros
                {
                    placa = unUsuario.SelectSingleNode("placa").InnerText,
                    año = Convert.ToInt32(unUsuario.SelectSingleNode("año").InnerText),
                    precio = Convert.ToInt32(unUsuario.SelectSingleNode("precio").InnerText),
                    marca = unUsuario.SelectSingleNode("marca").InnerText,
                    modelo = unUsuario.SelectSingleNode("modelo").InnerText,
                    estilo = unUsuario.SelectSingleNode("estilo").InnerText,
                    color = unUsuario.SelectSingleNode("color").InnerText,
                    estado = unUsuario.SelectSingleNode("estado").InnerText,
                };

                Lista.Add(objetos);
            }
            return Lista;
        }

        public void Modificar(ObjCarros carros)
        {
            XmlNodeList listaProducto = doc.SelectNodes("Adobe/Carros");

            foreach (XmlNode item in listaProducto)
            {
                if (item.SelectSingleNode("placa").InnerText == carros.placa)
                {
                    
                    item.SelectSingleNode("año").InnerText = Convert.ToString(carros.año);
                    item.SelectSingleNode("precio").InnerText = Convert.ToString(carros.precio);
                    item.SelectSingleNode("marca").InnerText = Convert.ToString(carros.marca);
                    item.SelectSingleNode("modelo").InnerText = carros.modelo;
                    item.SelectSingleNode("estilo").InnerText = carros.estilo;
                    item.SelectSingleNode("color").InnerText = carros.color;
                    item.SelectSingleNode("estado").InnerText = carros.estado;

                }
            }

            new bdGestionAutos().guardarDatosXML(doc, rutaXml);
        }

        public void Eliminar(ObjCarros carros)
        {
            XmlNodeList listaProducto = doc.SelectNodes("Adobe/Carros");
            XmlNode estudiante = doc.DocumentElement;

            foreach (XmlNode item in listaProducto)
            {
                if (item.SelectSingleNode("placa").InnerText == carros.placa)
                {
                    XmlNode borrarNodo = item;
                    estudiante.RemoveChild(borrarNodo);
                }
            }

            new bdGestionAutos().guardarDatosXML(doc, rutaXml);
        }


        ////////////////////////////////////////////////////////////////////////
        ///
        ///////////////////////////////////////////////////////////////////////
        public List<ObjCarros> llenarListaDisponibles()
        {
            List<ObjCarros> Lista = new List<ObjCarros>();
            XmlNodeList listaUsuarios = doc.SelectNodes("Adobe/Carros");

            XmlNode unUsuario;

            for (int x = 0; x < listaUsuarios.Count; x++)
            {
                unUsuario = listaUsuarios.Item(x);

                if (unUsuario.SelectSingleNode("estado").InnerText == "Disponible")
                {

                    ObjCarros objetos = new ObjCarros
                    {
                        placa = unUsuario.SelectSingleNode("placa").InnerText,
                        año = Convert.ToInt32(unUsuario.SelectSingleNode("año").InnerText),
                        precio = Convert.ToInt32(unUsuario.SelectSingleNode("precio").InnerText),
                        marca = unUsuario.SelectSingleNode("marca").InnerText,
                        modelo = unUsuario.SelectSingleNode("modelo").InnerText,
                        estilo = unUsuario.SelectSingleNode("estilo").InnerText,
                        color = unUsuario.SelectSingleNode("color").InnerText,
                        estado = unUsuario.SelectSingleNode("estado").InnerText,
                    };
                    Lista.Add(objetos);

                }


            }
            return Lista;
        }

        public bool validarExistencia(string placa)
        {
            bool valido = false;

            XmlNodeList listaProducto = doc.SelectNodes("Adobe/Carros");

            foreach (XmlNode item in listaProducto)
            {
                if (item.SelectSingleNode("placa").InnerText == placa)
                {
                    valido = true;
                }
            }

            return valido;
        }

        public List<ObjCarros> llenarListaDisponiblesFiltrados(ObjFiltro filtro)
        {
            List<ObjCarros> Lista = new List<ObjCarros>();
            XmlNodeList listaUsuarios = doc.SelectNodes("Adobe/Carros");

            XmlNode unUsuario;

            for (int x = 0; x < listaUsuarios.Count; x++)
            {
                unUsuario = listaUsuarios.Item(x);

                if (
                    unUsuario.SelectSingleNode("estado").InnerText == "Disponible" &&
                    unUsuario.SelectSingleNode("marca").InnerText == filtro.marca &&
                    unUsuario.SelectSingleNode("modelo").InnerText == filtro.modelo &&
                    unUsuario.SelectSingleNode("estilo").InnerText == filtro.estilo &&
                    unUsuario.SelectSingleNode("color").InnerText == filtro.color &&
                    Convert.ToInt32(unUsuario.SelectSingleNode("año").InnerText) == filtro.año
                    )
                {

                    ObjCarros objetos = new ObjCarros
                    {
                        placa = unUsuario.SelectSingleNode("placa").InnerText,
                        año = Convert.ToInt32(unUsuario.SelectSingleNode("año").InnerText),
                        precio = Convert.ToInt32(unUsuario.SelectSingleNode("precio").InnerText),
                        marca = unUsuario.SelectSingleNode("marca").InnerText,
                        modelo = unUsuario.SelectSingleNode("modelo").InnerText,
                        estilo = unUsuario.SelectSingleNode("estilo").InnerText,
                        color = unUsuario.SelectSingleNode("color").InnerText,
                        estado = unUsuario.SelectSingleNode("estado").InnerText,
                    };
                    Lista.Add(objetos);

                }


            }
            return Lista;
        }

        public int validarPrecio(string placa)
        {
            int precio = 0;

            XmlNodeList listaProducto = doc.SelectNodes("Adobe/Carros");

            foreach (XmlNode item in listaProducto)
            {
                if (item.SelectSingleNode("placa").InnerText == placa)
                {
                    precio = Convert.ToInt32(item.SelectSingleNode("precio").InnerText);
                }
            }

            return precio;
        }

        public void modificarDisponibilidad(string placa)
        {
            XmlNodeList listaProducto = doc.SelectNodes("Adobe/Carros");

            foreach (XmlNode item in listaProducto)
            {
                if (item.SelectSingleNode("placa").InnerText == placa)
                {
                    item.SelectSingleNode("estado").InnerText = "Alquilado";
                }
            }
            new bdGestionAutos().guardarDatosXML(doc, rutaXml);
        }



    }
}
