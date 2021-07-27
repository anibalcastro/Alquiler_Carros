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
    public class nInicio
    {
        string nombre;
        string genero;
        string correo;
        int cedula;
        int rol;

        XmlDocument doc;
        string rutaXml;

        public void CrearXML(string ruta, string nodoRaiz)
        {
            rutaXml = ruta;
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlNode nodo = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, nodo);

            XmlNode elemento = doc.CreateElement(nodoRaiz);
            doc.AppendChild(elemento);

            new Datos.bdLogin().guardarDatosXML(doc, ruta);

        }

        public void LeerXML(string ruta)
        {
            rutaXml = ruta;
            doc = new XmlDocument();
            doc.Load(rutaXml);
        }

        public void RegistrarUsuario(Objetos.ObjUsuarios usu)
        {

            XmlNode Registro = this.CrearUsuario(usu);

            XmlNode nodo = doc.DocumentElement;

            nodo.InsertAfter(Registro, nodo.LastChild);

            new bdLogin().guardarDatosXML(doc, rutaXml);

        }

        public XmlNode CrearUsuario(ObjUsuarios usu)
        {
            XmlNode Registro = doc.CreateElement("usuario");

            XmlElement xcedula = doc.CreateElement("cedula");
            xcedula.InnerText = usu.cedula.ToString();
            Registro.AppendChild(xcedula);


            XmlElement xnombre = doc.CreateElement("nombre");
            xnombre.InnerText = usu.nombre.ToString();
            Registro.AppendChild(xnombre);

            XmlElement xgenero = doc.CreateElement("genero");
            xgenero.InnerText = usu.genero.ToString();
            Registro.AppendChild(xgenero);

            XmlElement xcorreo = doc.CreateElement("correo_electronico");
            xcorreo.InnerText = usu.correo.ToString();
            Registro.AppendChild(xcorreo);

            XmlElement xcontrasena = doc.CreateElement("contrasenna");
            xcontrasena.InnerText = usu.contrasenna.ToString();
            Registro.AppendChild(xcontrasena);

            XmlElement xrol = doc.CreateElement("rol");
            xrol.InnerText = usu.rol.ToString();
            Registro.AppendChild(xrol);


            return Registro;
        }

        public List<ObjUsuarios> llenarLista()
        {
            List<ObjUsuarios> Lista = new List<ObjUsuarios>();
            XmlNodeList listaUsuarios = doc.SelectNodes("Login/usuario");

            XmlNode unUsuario;

            for (int x = 0; x < listaUsuarios.Count; x++)
            {
                unUsuario = listaUsuarios.Item(x);
                ObjUsuarios objetos = new ObjUsuarios
                {
                    cedula = Convert.ToInt32(unUsuario.SelectSingleNode("cedula").InnerText),
                    nombre = unUsuario.SelectSingleNode("nombre").InnerText,
                    genero = unUsuario.SelectSingleNode("genero").InnerText,
                    correo = unUsuario.SelectSingleNode("correo_electronico").InnerText,
                    contrasenna = unUsuario.SelectSingleNode("contrasenna").InnerText,
                    rol = Convert.ToInt32(unUsuario.SelectSingleNode("rol").InnerText)
                };

                Lista.Add(objetos);
            }
            return Lista;
        }

        public bool validarUsuario(int user, string password)
        {

            List<ObjUsuarios> lista = this.llenarLista();

            bool validar = false;

            for (int x = 0; x < lista.Count; x++)
            {
                if (lista[x].cedula.Equals(user) && password.Equals(lista[x].contrasenna))
                {
                    validar = true;
                    nombre = lista[x].nombre;
                    cedula = lista[x].cedula;
                    genero = lista[x].genero;
                    correo = lista[x].correo;
                    rol = lista[x].rol;
                    break;
                }
            }

            return validar;
        }

        public int retornarRol()
        {

            return rol;
        }

        public ObjUsuarios retornarInfo()
        {
            ObjUsuarios usuario = new ObjUsuarios
            {
                cedula = cedula,
                nombre = nombre,
                genero = genero,
                correo = correo
                
            };
            return usuario;
        }

    }
}
