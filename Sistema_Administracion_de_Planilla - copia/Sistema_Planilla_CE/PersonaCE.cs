﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class PersonaCE
    {
        public int Id_Persona { get; set; }
        public string Nombre_Persona { get; set; }
        public string Apellido1_Persona { get; set; }
        public string Apellido2_Persona { get; set; }
        public DateTime FechaNacimiento_Persona { get; set; }
        public int Id_Direccion { get; set; }
        public string Detalle_Direccion { get; set; }
        public int Id_Provincia { get; set; }
        public string Nombre_Provincia { get; set; }
        public int Id_Canton { get; set; }
        public string Nombre_Canton { get; set; }
        public int Id_Distrito { get; set; }
        public string Nombre_Distrito { get; set; }
        public int Id_Email { get; set; }
        public string Correo_Email { get; set; }
        public int FKId_Direccion_Persona { get; set; }
        public int FKId_Email_Persona { get; set; }
        public string NumeroIdentidad_Persona { get; set; }
        public string NombreCompleto_Persona { get { return $"{Apellido1_Persona}{" "}{Apellido2_Persona}{", "}{Nombre_Persona}"; }}
        public string DetalleCompleto_Direccion { get { return $"{Detalle_Direccion}{", "}{Nombre_Provincia}{" - "}{Nombre_Canton}{" - "}{Nombre_Distrito}"; } }
    }
}
