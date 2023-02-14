using System;
using System.Collections.Generic;

namespace Ejercicio_ColegioABC.Models;

public partial class Materia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Curso> Idcursos { get; } = new List<Curso>();

    public virtual ICollection<Estudiante> Idestudiantes { get; } = new List<Estudiante>();
}
