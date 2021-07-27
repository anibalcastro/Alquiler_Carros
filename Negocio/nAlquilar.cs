using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;
using Objetos;
using Datos;

namespace Negocio
{
    public class nAlquilar
    {
        XmlDocument doc;
        string rutaXml;

        XmlDocument docCopia;
        string rutaXmlCopia;

        public DateTime fecha_Devolucion(DateTime fecha, int dias)
        {
            DateTime devolver = fecha.AddDays(dias);

            return devolver;
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

            new Datos.bdAlquiler().guardarDatosXML(doc, ruta);

        }

        public void LeerXML(string ruta)
        {
            rutaXml = ruta;
            doc = new XmlDocument();
            doc.Load(rutaXml);
        }

        public void RegistrarAlquiler(ObjAlquiler alquiler)
        {

            XmlNode Registro = this.Crear(alquiler);

            XmlNode nodo = doc.DocumentElement;

            nodo.InsertAfter(Registro, nodo.LastChild);

            new bdAlquiler().guardarDatosXML(doc, rutaXml);

        }

        public XmlNode Crear(ObjAlquiler alquiler)
        {
            //Info usuario
            XmlNode usuario = doc.CreateElement("Usuario");

            XmlElement xcedula = doc.CreateElement("cedula");
            xcedula.InnerText = alquiler.cedula.ToString();
            usuario.AppendChild(xcedula);

            XmlElement xnombre = doc.CreateElement("nombre");
            xnombre.InnerText = alquiler.nombre.ToString();
            usuario.AppendChild(xnombre);

            XmlElement xgenero = doc.CreateElement("genero");
            xgenero.InnerText = alquiler.genero.ToString();
            usuario.AppendChild(xgenero);

            XmlElement xcorreo = doc.CreateElement("correo_electronico");
            xcorreo.InnerText = alquiler.correo.ToString();
            usuario.AppendChild(xcorreo);


            //Info carro
            XmlNode alqui = doc.CreateElement("Alquiler");

            XmlElement xPlaca = doc.CreateElement("placa");
            xPlaca.InnerText = alquiler.placa.ToString();
            alqui.AppendChild(xPlaca);

            XmlElement xAnno = doc.CreateElement("año");
            xAnno.InnerText = alquiler.año.ToString();
            alqui.AppendChild(xAnno);

            XmlElement xmarca = doc.CreateElement("marca");
            xmarca.InnerText = alquiler.marca.ToString();
            alqui.AppendChild(xmarca);

            XmlElement xmodelo = doc.CreateElement("modelo");
            xmodelo.InnerText = alquiler.modelo.ToString();
            alqui.AppendChild(xmodelo);

            XmlElement xestilo = doc.CreateElement("estilo");
            xestilo.InnerText = alquiler.estilo.ToString();
            alqui.AppendChild(xestilo);

            XmlElement xcolor = doc.CreateElement("color");
            xcolor.InnerText = alquiler.color.ToString();
            alqui.AppendChild(xcolor);

            XmlElement xsilla = doc.CreateElement("silla_bebes");
            xsilla.InnerText = alquiler.silla.ToString();
            alqui.AppendChild(xsilla);

            XmlElement xgps = doc.CreateElement("gps");
            xgps.InnerText = alquiler.gps.ToString();
            alqui.AppendChild(xgps);

            XmlElement xdias = doc.CreateElement("dias");
            xdias.InnerText = alquiler.dias.ToString();
            alqui.AppendChild(xdias);

            XmlElement xmonto = doc.CreateElement("monto_total");
            xmonto.InnerText = alquiler.monto_pagar.ToString();
            alqui.AppendChild(xmonto);

            XmlElement xfecha_retiro = doc.CreateElement("fecha_retiro");
            xfecha_retiro.InnerText = alquiler.fecha_retiro.ToString();
            alqui.AppendChild(xfecha_retiro);

            XmlElement xfecha_devolucion = doc.CreateElement("fecha_devolucion");
            xfecha_devolucion.InnerText = alquiler.fecha_devolucion.ToString();
            alqui.AppendChild(xfecha_devolucion);


            usuario.AppendChild(alqui);

            return usuario;
        }

        //COPIA DEL USUARIO
        public void CrearXMLCopia(string ruta, string nodoRaiz)
        {
            rutaXmlCopia = ruta;
            docCopia = new XmlDocument();

            XmlDeclaration xmlDeclaration = docCopia.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlNode nodo = docCopia.DocumentElement;
            docCopia.InsertBefore(xmlDeclaration, nodo);

            XmlNode elemento = docCopia.CreateElement(nodoRaiz);
            docCopia.AppendChild(elemento);

            new Datos.bdAlquiler().guardarDatosXML(docCopia, ruta);

        }
        public void RegistrarAlquilerCopia(ObjAlquiler alquiler)
        {

            XmlNode Registro = this.CrearCopia(alquiler);

            XmlNode nodo = docCopia.DocumentElement;

            nodo.InsertAfter(Registro, nodo.LastChild);

            new bdAlquiler().guardarDatosXML(docCopia, rutaXmlCopia);

        }
        public XmlNode CrearCopia(ObjAlquiler alquiler)
        {
            //Info usuario
            XmlNode usuario = docCopia.CreateElement("Usuario");

            XmlElement xcedula = docCopia.CreateElement("cedula");
            xcedula.InnerText = alquiler.cedula.ToString();
            usuario.AppendChild(xcedula);

            XmlElement xnombre = docCopia.CreateElement("nombre");
            xnombre.InnerText = alquiler.nombre.ToString();
            usuario.AppendChild(xnombre);

            XmlElement xgenero = docCopia.CreateElement("genero");
            xgenero.InnerText = alquiler.genero.ToString();
            usuario.AppendChild(xgenero);

            XmlElement xcorreo = docCopia.CreateElement("correo_electronico");
            xcorreo.InnerText = alquiler.correo.ToString();
            usuario.AppendChild(xcorreo);


            //Info carro
            XmlNode alqui = docCopia.CreateElement("Alquiler");

            XmlElement xPlaca = docCopia.CreateElement("placa");
            xPlaca.InnerText = alquiler.placa.ToString();
            alqui.AppendChild(xPlaca);

            XmlElement xAnno = docCopia.CreateElement("año");
            xAnno.InnerText = alquiler.año.ToString();
            alqui.AppendChild(xAnno);

            XmlElement xmarca = docCopia.CreateElement("marca");
            xmarca.InnerText = alquiler.marca.ToString();
            alqui.AppendChild(xmarca);

            XmlElement xmodelo = docCopia.CreateElement("modelo");
            xmodelo.InnerText = alquiler.modelo.ToString();
            alqui.AppendChild(xmodelo);

            XmlElement xestilo = docCopia.CreateElement("estilo");
            xestilo.InnerText = alquiler.estilo.ToString();
            alqui.AppendChild(xestilo);

            XmlElement xcolor = docCopia.CreateElement("color");
            xcolor.InnerText = alquiler.color.ToString();
            alqui.AppendChild(xcolor);

            XmlElement xsilla = docCopia.CreateElement("silla_bebes");
            xsilla.InnerText = alquiler.silla.ToString();
            alqui.AppendChild(xsilla);

            XmlElement xgps = docCopia.CreateElement("gps");
            xgps.InnerText = alquiler.gps.ToString();
            alqui.AppendChild(xgps);

            XmlElement xdias = docCopia.CreateElement("dias");
            xdias.InnerText = alquiler.dias.ToString();
            alqui.AppendChild(xdias);

            XmlElement xmonto = docCopia.CreateElement("monto_total");
            xmonto.InnerText = alquiler.monto_pagar.ToString();
            alqui.AppendChild(xmonto);

            XmlElement xfecha_retiro = docCopia.CreateElement("fecha_retiro");
            xfecha_retiro.InnerText = alquiler.fecha_retiro.ToString();
            alqui.AppendChild(xfecha_retiro);

            XmlElement xfecha_devolucion = docCopia.CreateElement("fecha_devolucion");
            xfecha_devolucion.InnerText = alquiler.fecha_devolucion.ToString();
            alqui.AppendChild(xfecha_devolucion);


            usuario.AppendChild(alqui);

            return usuario;
        }

        // MAIL
        public bool enviarEmail(string destino, string archivo)
        {
            bool valido = false;

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add(destino);
            mmsg.Subject = "Confirmación de alquiler de vehiculo";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Bcc.Add("adobe.rentacar12@gmail.com"); //ENVIAR COPIA

            mmsg.Body = "CONFIRMACIÓN DE ALQUILER";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false;

            if (System.IO.File.Exists(@archivo))
            {
                mmsg.Attachments.Add(new Attachment(@archivo));
            }

            mmsg.From = new System.Net.Mail.MailAddress("adobe.rentacar12@gmail.com");
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("adobe.rentacar12@gmail.com", "CodigoC#");
            
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(mmsg);
                valido = true;

            }
            catch (Exception e)
            {
                valido = false;
            }


            return valido;
        }

        //LlenarListaVehiculosAlquilados
        public List<ObjAlquiler> llenarListaAlquilados()
        {
            List<ObjAlquiler> Lista = new List<ObjAlquiler>();
            XmlNodeList listaUsuarios = doc.SelectNodes("Alquilados/Usuario");
            XmlNodeList listaAlquiler = doc.SelectNodes("Alquilados/Usuario/Alquiler");

            XmlNode unUsuario;
            XmlNode unAlquiler;


            
                for (int x = 0; x < listaUsuarios.Count; x++)
                {
                    unUsuario = listaUsuarios.Item(x);
                    unAlquiler = listaAlquiler.Item(x);

                        ObjAlquiler objetos = new ObjAlquiler
                        {

                            cedula = Convert.ToInt32(unUsuario.SelectSingleNode("cedula").InnerText),
                            nombre = unUsuario.SelectSingleNode("nombre").InnerText,
                            genero = unUsuario.SelectSingleNode("genero").InnerText,
                            correo = unUsuario.SelectSingleNode("correo_electronico").InnerText,

                            placa = unAlquiler.SelectSingleNode("placa").InnerText,
                            año = Convert.ToInt32(unAlquiler.SelectSingleNode("año").InnerText),
                            marca = unAlquiler.SelectSingleNode("marca").InnerText,
                            modelo = unAlquiler.SelectSingleNode("modelo").InnerText,
                            estilo = unAlquiler.SelectSingleNode("estilo").InnerText,
                            color = unAlquiler.SelectSingleNode("color").InnerText,
                            silla = unAlquiler.SelectSingleNode("silla_bebes").InnerText,
                            gps = unAlquiler.SelectSingleNode("gps").InnerText,
                            dias = Convert.ToInt32(unAlquiler.SelectSingleNode("dias").InnerText),
                            monto_pagar = Convert.ToInt32(unAlquiler.SelectSingleNode("monto_total").InnerText),
                            fecha_retiro = Convert.ToDateTime(unAlquiler.SelectSingleNode("fecha_retiro").InnerText),
                            fecha_devolucion = Convert.ToDateTime(unAlquiler.SelectSingleNode("fecha_devolucion").InnerText),

                        };

                        Lista.Add(objetos);
                        

                    

                
                }


            
            return Lista;
        }

        public List<ObjAlquiler> reporteFechas(DateTime desde, DateTime hasta)
        {
            List<ObjAlquiler> reporte = new List<ObjAlquiler>();
            List<ObjAlquiler> alquilados = this.llenarListaAlquilados();

            for (int x = 0; x < alquilados.Count; x++)
            {
                if (desde <= alquilados[x].fecha_retiro && hasta >= alquilados[x].fecha_retiro)
                {
                    ObjAlquiler objetos = new ObjAlquiler
                    {
                        cedula = alquilados[x].cedula,
                        nombre = alquilados[x].nombre,
                        genero = alquilados[x].genero,
                        correo = alquilados[x].correo,
                        placa =  alquilados[x].placa,
                        año =    alquilados[x].año,
                        marca =  alquilados[x].marca,
                        modelo = alquilados[x].modelo,
                        estilo = alquilados[x].estilo,
                        color =  alquilados[x].color,
                        silla =  alquilados[x].silla,
                        gps =    alquilados[x].gps,
                        dias = alquilados[x].dias,
                        monto_pagar = alquilados[x].monto_pagar,
                        fecha_retiro = alquilados[x].fecha_retiro,
                        fecha_devolucion = alquilados[x].fecha_devolucion,
                    };

                    reporte.Add(objetos);
                }
            }
            return reporte;
        }

        public List<int> marcasUtilizadas()
        {
            List<string> marcas = new List<string>() { "Toyota", "Hyundai", "Nissan" };
            List<ObjAlquiler> alquiler = this.llenarListaAlquilados();

            List<int> lista = new List<int>();

            
            for (int x = 0; x < marcas.Count; x++)
            {
                int contador = 0;
                
                for (int y = 0; y < alquiler.Count; y++)
                {
                    if (alquiler[y].marca.Equals(marcas[x]))
                    {
                        contador = contador + 1;
                    }
                }

                lista.Add(contador);
       
            }
            return lista;
        }
       

    }
}
