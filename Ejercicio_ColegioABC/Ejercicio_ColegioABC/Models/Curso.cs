using System;
using System.Collections.Generic;

namespace Ejercicio_ColegioABC.Models;

public partial class Curso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Idestudiante { get; set; }

    public virtual Estudiante? IdestudianteNavigation { get; set; }

    public virtual ICollection<Materia> Idmateria { get; } = new List<Materia>();
}
