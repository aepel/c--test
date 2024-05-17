using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace Qualyt.Domain.Models.Mails
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        //public string Nombre { get; set; }

        [Display(Name = "Asunto")]
        public string Subject { get; set; }

        [Display(Name = "Cuerpo")]
        public string Body { get; set; }

        //public string Descripcion { get; set; }

        public TipoEmailTemplate TipoEmailTemplate { get; set; }


        [NotMapped]
        public string Descripcion
        {
            get
            {
                string descripcion = "";
                /*
                switch (TipoEmailTemplate)
                {
                    case TipoEmailTemplate.EmpresaPendienteHabilitacion:
                        descripcion = EmailTemplateLocalization.descripcion_empresa_pendiente_habilitacion;
                        break;
                    case TipoEmailTemplate.ConfirmacionDeUsuarioYDatosAccesoUsuario:
                        descripcion = EmailTemplateLocalization.descripcion_confirmacion_de_usuario_y_datos_acceso_usuario;
                        break;
                    case TipoEmailTemplate.ConfirmacionDeUsuario:
                        descripcion = EmailTemplateLocalization.descripcion_confirmacion_de_usuario;
                        break;
                    case TipoEmailTemplate.DatosAccesoUsuario:
                        descripcion = EmailTemplateLocalization.descripcion_datos_acceso_usuario;
                        break;
                    case TipoEmailTemplate.ReinicioDeContrasena:
                        descripcion = EmailTemplateLocalization.descripcion_reinicio_de_contrasena;
                        break;
                    case TipoEmailTemplate.DenunciaCreadaDenunciante:
                        descripcion = EmailTemplateLocalization.descripcion_denuncia_creada_denunciante;
                        break;
                    case TipoEmailTemplate.DenunciaCreadaAdministradores:
                        descripcion = EmailTemplateLocalization.descripcion_denuncia_creada_administradores;
                        break;
                    case TipoEmailTemplate.NuevaRespuestaDelDenunciante:
                        descripcion = EmailTemplateLocalization.descripcion_nueva_respuesta_del_denunciante;
                        break;
                    case TipoEmailTemplate.DenunciaActualizada:
                        descripcion = EmailTemplateLocalization.descripcion_denuncia_actualizada;
                        break;
                    case TipoEmailTemplate.AccesoDenunciante:
                        descripcion = EmailTemplateLocalization.descripcion_acceso_denunciante;
                        break;
                }
                */
                return descripcion;
            }
        }

        public EmailTemplate()
        {

        }

        public EmailTemplate(string subject, string body, TipoEmailTemplate tipoEmailTemplate)
        {
            //this.Nombre = nombre;
            this.Subject = subject;
            this.Body = body;
            this.TipoEmailTemplate = tipoEmailTemplate;
        }

        public List<Tag> getTagsFromSubject()
        {
            List<Tag> tags = new List<Tag>();
            foreach (Match m in Utilidades.findAllTagOccurences(Subject))
                tags.Add(new Tag(m.Value, null));

            return tags;
        }

        public List<Tag> getTagsFromBody()
        {
            List<Tag> tags = new List<Tag>();
            foreach (Match m in Utilidades.findAllTagOccurences(Body))
                tags.Add(new Tag(m.Value, null));

            return tags;
        }
    }
    public enum TipoEmailTemplate
    {
        TermsAndConditionsAcceptance=1,
        TomorrowControls=2,
        PasswordRecovery=3
    }
}
